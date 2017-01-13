using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.Win32;
using SqlRunner.Core;

namespace SqlRunner.WPF.MainWindow
{
    public class ViewModel : SqlRunner.Core.ViewModel
    {
        public ViewModel()
        {
            this.OpenFilesCommand = CreateAsyncCommand(OpenFilesAsync);
            this.StartCommand = CreateAsyncCommand(StartAsync);
            this.StartCommand.CanExecute = false;
        }

        private async Task StartAsync()
        {

            using (TransactionScope transaction = new TransactionScope( TransactionScopeOption.Required, TimeSpan.MaxValue))
            {
                bool hasErrors = false;


                string server = "appdvsqlli1", database = "onet_v21_1";

                var builder = new System.Data.SqlClient.SqlConnectionStringBuilder
                {
                    InitialCatalog = database,
                    DataSource = server,
                    IntegratedSecurity = true
                };

                double statementPercentage;

                using (var connection = new System.Data.SqlClient.SqlConnection(builder.ConnectionString))
                {
                    await connection.OpenAsync();
                    foreach (var file in OpenedFiles)
                    {
                        var statements = Regex.Split(
                                System.IO.File.ReadAllText(file.Path),
                                @"^\s*GO\s*\d*\s*($|\-\-.*$)",
                                RegexOptions.Multiline |
                                RegexOptions.IgnorePatternWhitespace |
                                RegexOptions.IgnoreCase)
                                .Where(x => !string.IsNullOrWhiteSpace(x))
                                .Select(x => x.Trim(' ', '\r', '\n')).ToList();

                        file.IsExecuting = true;
                        file.CompletionPercent = 0;

                        statementPercentage = 1 / (double)statements.Count;

                        try
                        {
                            foreach (var statement in statements)
                            {
                                using (var command = connection.CreateCommand())
                                {
                                    command.CommandText = statement;
                                    command.CommandTimeout = 600;
                                    await command.ExecuteNonQueryAsync();
                                    file.CompletionPercent += statementPercentage;
                                }
                            }

                            file.IsCompleted = true;
                        }
                        catch (Exception ex)
                        {
                            file.IsError = true;
                            file.ExceptionMessage = ex.Message;
                            hasErrors = true;
                        }
                        finally
                        {
                            file.IsExecuting = false;
                            
                        }
                    }
                }

                if (hasErrors || true)
                {
                    if (System.Windows.MessageBox.Show("Commit transaction?", "", System.Windows.MessageBoxButton.YesNo) == System.Windows.MessageBoxResult.Yes)
                    {
                        transaction.Complete();
                    }
                }

                
            }
        }

        private Task OpenFilesAsync()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Multiselect = true,
                Title = "Select Files to Open",
                CheckFileExists = true,
                Filter = "SQL Files|*.sql",
            };

            if (ofd.ShowDialog() ?? false)
            {
                foreach (var file in ofd.FileNames)
                {
                    this.OpenedFiles.Add(new WPF.MainWindow.ViewModel.OpenedFileViewModel
                    {
                        Filename = System.IO.Path.GetFileName(file),
                        Path = file,
                        IsError = false,
                        IsExecuting = false
                    });

                    StartCommand.CanExecute = true;
                }
            }

            return Task.FromResult<object>(null);
        }

        private OpenedFileViewModel _selectedFile;

        public ObservableCollection<OpenedFileViewModel> OpenedFiles { get; } = new ObservableCollection<OpenedFileViewModel>();
        public DelegateCommand OpenFilesCommand { get; }

        public OpenedFileViewModel SelectedFile
        {
            get
            {
                return _selectedFile;
            }

            set
            {
                _selectedFile = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand StartCommand { get; private set; }

        public class OpenedFileViewModel : SqlRunner.Core.ViewModel
        {
            private string _filename, _path, _exceptionMessage;
            private bool _isExecuting, _isError;
            private double _completionPercent = 0d;
            private bool _isCompleted;

            public string ExceptionMessage
            {
                get
                {
                    return _exceptionMessage;
                }
                set
                {
                    _exceptionMessage = value;
                    OnPropertyChanged();
                }
            }



            public string Filename
            {
                get
                {
                    return _filename;
                }

                set
                {
                    _filename = value;
                    OnPropertyChanged();
                }
            }

            public bool IsError
            {
                get
                {
                    return _isError;
                }

                set
                {
                    _isError = value;
                    OnPropertyChanged();
                }
            }

            public bool IsCompleted
            {
                get { return _isCompleted; }
                set { _isCompleted = value;
                    OnPropertyChanged();
                }
            }

            public bool IsExecuting
            {
                get
                {
                    return _isExecuting;
                }

                set
                {
                    _isExecuting = value;
                    OnPropertyChanged();
                }
            }

            public string Path
            {
                get
                {
                    return _path;
                }

                set
                {
                    _path = value;
                    OnPropertyChanged();
                }
            }

            public double CompletionPercent
            {
                get
                {
                    return _completionPercent;
                }

                set
                {
                    _completionPercent = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}

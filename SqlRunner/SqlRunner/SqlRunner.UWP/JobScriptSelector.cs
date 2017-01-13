using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlRunner.Core;

namespace SqlRunner.UWP
{
    public class JobScriptSelector : SqlRunner.IJobScriptSelector
    {
        public async Task<IEnumerable<IJobScript>> GetScriptsAsync()
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker
            {
                ViewMode = Windows.Storage.Pickers.PickerViewMode.List,
                CommitButtonText = "Open",
            };
            picker.FileTypeFilter.Add(".sql");


            var selectedFiles = await picker.PickMultipleFilesAsync();

            if (selectedFiles == null)
                return Enumerable.Empty<IJobScript>();

            return selectedFiles.Select(file => new JobScript(file.Path)).AsEnumerable<IJobScript>();
        }
    }
}

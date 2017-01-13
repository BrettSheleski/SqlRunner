﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Services
{
    public enum ServiceRequestStatus
    {
        Found,
        NotFound,
        Unauthorized,
        InvalidRequest
    }
}

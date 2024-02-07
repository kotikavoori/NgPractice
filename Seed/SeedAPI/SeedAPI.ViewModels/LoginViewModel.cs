﻿using SeedAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeedAPI.ViewModels
{
    public class LoginViewModel : IBaseViewModel
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
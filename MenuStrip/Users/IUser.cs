﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuStrip.Users
{
    public interface IUser
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public IDictionary<string, int> Configs { get; set; }
    }
}

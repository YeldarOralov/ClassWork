﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem2
{
    public interface IReporter
    {
        void SendMessage(string message);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Interface
{
    public interface IPriorityService
    {
        void SendMessage(string message, int priority);
    }
}

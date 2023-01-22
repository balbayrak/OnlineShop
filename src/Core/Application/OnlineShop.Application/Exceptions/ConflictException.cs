﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Exceptions
{
    public abstract class ConflictException : BaseException
    {
        protected ConflictException(string message) : base(message)
        {
        }
    }
}

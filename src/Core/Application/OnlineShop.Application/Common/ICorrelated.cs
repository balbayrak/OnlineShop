﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Common
{
    public interface ICorrelated
    {
        public Guid CorrelationId { get; set; }
    }
}

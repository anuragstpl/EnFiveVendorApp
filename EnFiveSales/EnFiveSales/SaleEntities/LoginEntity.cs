﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnFiveSales.SaleEntities
{
    public class LoginEntity : BaseEntity
    {
        public string UserNameOREmail { get; set; }
        public string PasswordHash { get; set; }
    }
}
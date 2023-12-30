﻿using Microsoft.EntityFrameworkCore;

namespace PulseActiveShop.Dal.Sql.Contexts
{
    public abstract class BaseContext : DbContext
    {
        private string _connectionString;
        
        public BaseContext(string connectionString)
        {
            this._connectionString = connectionString;
        }
    }
}

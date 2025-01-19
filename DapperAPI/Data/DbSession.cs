﻿using System.Data;
using System.Data.SqlClient;

namespace DapperAPI.Data
{
    public class DbSession : IDisposable
    {
        public IDbConnection Connection { get; }

        public IDbTransaction Transaction { get; set; }

        public DbSession(IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            Connection.Open();
        }

        public void Dispose()
        {
            Connection?.Dispose();
        }
    }
}

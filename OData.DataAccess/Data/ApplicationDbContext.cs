using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OData.DataAccess.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace OData.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ConnectionStringSettings _connectionStringSettings;

        public ApplicationDbContext(IOptions<ConnectionStringSettings> options)
        {
            _connectionStringSettings = options.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionStringSettings.LocalDB);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }

    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiiCore.Models
{
    public class MyProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source= miraii.space; Database= miraii_space; User ID=miraii_space; Password=Hostmiraii007;");
           
        }
        public DbSet<ContentDataModel> ContentData { get; set; }
    }
}

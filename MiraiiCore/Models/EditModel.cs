using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiiCore.Models
{
    public class EditModel:DbContext
    {
        public EditModel(DbContextOptions<EditModel> options):base(options)
        {

        }

        public DbSet<ContentDataViewModel> ContentData { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiiCore.Models
{
    public class ContentDataModel
    {
        [Key]
        public int ContentID { get; set; }
        public String ContentLocation { get; set; }
        public String ContentName { get; set; }
        public String ContentCategory { get; set; }
        public String FileType { get; set; }
        public String ContentDescription { get; set; }
        public String ContentDate { get; set; }
        public String ContentWriter { get; set; }
        public String Controller { get; set; }
        public String Action { get; set; }
        public String Editor { get; set; }
        public String Release { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiiCore.Models
{
    public class StoryViewModel
    {
        [Key]
        public int StoryID { get; set; }
        public string StoryImage { get; set; }
        public string StoryFileType { get; set; }
        public string StoryName { get; set; }
        public string StoryCategory { get; set; }
        public string StoryDescription { get; set; }
        public string StoryWriter { get; set; }
        public string StoryEditor { get; set; }
        public string StoryDate { get; set; }
        public string StoryController { get; set; }
        public string StoryAction { get; set; }
        public string StoryRelease { get; set; }
        public List<StoryViewModel> StoryInfo { get; set; }
    }
}

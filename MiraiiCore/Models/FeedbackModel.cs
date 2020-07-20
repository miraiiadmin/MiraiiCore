using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiiCore.Models
{
    public class FeedbackModel
    {
        [Key]
        public int FeedbackID { get; set; }
        public string Feedback { get; set; }
        public DateTime Date { get; set; }

        public List<FeedbackModel> FeedbackList { get; set; }

        
    }
}

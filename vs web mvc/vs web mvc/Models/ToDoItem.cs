using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace vs_web_mvc.Models
{
    public class ToDoItem
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [Display(Name = "Modified On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ModifiedOn { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal EstimatedHour { get; set; }

    }
}

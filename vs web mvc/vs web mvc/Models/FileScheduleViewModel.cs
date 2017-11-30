using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vs_web_mvc.Models
{
    public class FileScheduleViewModel
    {
        [BindProperty]
        public FileUpload FileUpload { get; set; }
        public IList<Schedule> Schedule { get; set; }
    }
}

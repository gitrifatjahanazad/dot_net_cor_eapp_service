using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vs_web_mvc.Models;
using Microsoft.EntityFrameworkCore;
using vs_web_mvc.Utilities;

namespace vs_web_mvc.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ToDoContext _context;
        public FileUpload FileUpload { get; set; }

        public IList<Schedule> Schedule { get; set; }
        public ScheduleController(ToDoContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var Schedule = await _context.Schedule.AsNoTracking().ToListAsync();

            var fileScheduleViewModel = new FileScheduleViewModel();
            fileScheduleViewModel.Schedule = Schedule;
            return View(fileScheduleViewModel);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Perform an initial check to catch FileUpload class
            // attribute violations.
            
            if (!ModelState.IsValid)
            {
                var Schedule = await _context.Schedule.AsNoTracking().ToListAsync();
                return View();
            }

            var publicScheduleData =
                await FileHelpers.ProcessFormFile(FileUpload.UploadPublicSchedule, ModelState);

            var privateScheduleData =
                await FileHelpers.ProcessFormFile(FileUpload.UploadPrivateSchedule, ModelState);

            // Perform a second check to catch ProcessFormFile method
            // violations.
            if (!ModelState.IsValid)
            {
                Schedule = await _context.Schedule.AsNoTracking().ToListAsync();
                return View();
            }

            var schedule = new Schedule()
            {
                PublicSchedule = publicScheduleData,
                PublicScheduleSize = FileUpload.UploadPublicSchedule.Length,
                PrivateSchedule = privateScheduleData,
                PrivateScheduleSize = FileUpload.UploadPrivateSchedule.Length,
                Title = FileUpload.Title,
                UploadDT = DateTime.UtcNow
            };

            _context.Schedule.Add(schedule);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
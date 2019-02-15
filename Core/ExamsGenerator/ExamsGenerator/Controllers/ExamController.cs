using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamsGenerator.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ExamsGenerator.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class ExamController : Controller
    {
        private readonly ExamsContext _context;
        
        public ExamController(ExamsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Get create question page
        public IActionResult Create()
        {
            ViewData["DegreeOfDifficultyId"] = new SelectList(_context.DegreeOfDifficulty, "DegreeOfDifficultyId", "DegreeOfDifficultyId");
            ViewData["LanguageId"] = new SelectList(_context.Language, "LanguageId", "Language1");
            ViewData["Class"] = new SelectList(_context.Class, "ClassId", "ClassId");
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "Name");
            ViewData["Title"] = new SelectList(_context.Subject, "SubjectId", "Name");

            return View();
        }

        // POST: Question/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,SubTitle,SubjectId,DegreeOfDifficultyId," +
            "Disclaimer,ClassId,Instruction, DurationInMinutes")] ExamOrder examOrder)
        {
            examOrder.CreateDate = DateTime.UtcNow;
            if (ModelState.IsValid)
            {
                _context.Add(examOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(examOrder);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamsGenerator.Models;
using Microsoft.AspNetCore.Authorization;

namespace ExamsGenerator.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class QuestionController : Controller
    {
        private readonly ExamsContext _context;

        public QuestionController(ExamsContext context)
        {
            _context = context;
        }

        // Get questions
        public async Task<IActionResult> Index()
        {
            var questions = _context.Question
                .Include(q => q.DegreeOfDifficulty)
                .Include(q => q.Language)
                .Include(q => q.LevelOfEducationInternational)
                .Include(q => q.QuestionType)
                .Include(q => q.Subject);

            return View(await questions.ToListAsync());
        }

        // Get question details
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .Include(q => q.DegreeOfDifficulty)
                .Include(q => q.Language)
                .Include(q => q.LevelOfEducationInternational)
                .Include(q => q.QuestionType)
                .Include(q => q.Subject)
                .SingleOrDefaultAsync(m => m.QuestionId == id);

            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // Get create question page
        public IActionResult Create()
        {
            ViewData["DegreeOfDifficultyId"] = new SelectList(_context.DegreeOfDifficulty, "DegreeOfDifficultyId", "DegreeOfDifficultyId");
            ViewData["LanguageId"] = new SelectList(_context.Language, "LanguageId", "Language1");
            ViewData["LevelOfEducationInternationalId"] = new SelectList(_context.LevelOfEducationInternational,
                "LevelOfEducationInternationalId", "Iscedcode");
            ViewData["QuestionTypeId"] = new SelectList(_context.QuestionType, "QuestionTypeId", "Name");
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "Name");
            return View();
        }

        // POST: Question/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuestionId,CreateDate,UserId,LanguageId,Text,SubjectId,DegreeOfDifficultyId," +
            "QuestionTypeId,LevelOfEducationInternationalId")] Question question)
        {
            if (ModelState.IsValid)
            {
                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["DegreeOfDifficultyId"] = new SelectList(_context.DegreeOfDifficulty, "DegreeOfDifficultyId", 
                "DegreeOfDifficultyId", question.DegreeOfDifficultyId);
            ViewData["LanguageId"] = new SelectList(_context.Language, "LanguageId", "LanguageId", question.LanguageId);
            ViewData["LevelOfEducationInternationalId"] = new SelectList(_context.LevelOfEducationInternational, 
                "LevelOfEducationInternationalId", "LevelOfEducationInternationalId", question.LevelOfEducationInternationalId);
            ViewData["QuestionTypeId"] = new SelectList(_context.QuestionType, "QuestionTypeId", "QuestionTypeId", question.QuestionTypeId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SubjectId", question.SubjectId);
            return View(question);
        }

        // GET: Question/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question.SingleOrDefaultAsync(m => m.QuestionId == id);
            if (question == null)
            {
                return NotFound();
            }
            ViewData["DegreeOfDifficultyId"] = new SelectList(_context.DegreeOfDifficulty, "DegreeOfDifficultyId", 
                "DegreeOfDifficultyId", question.DegreeOfDifficultyId);
            ViewData["LanguageId"] = new SelectList(_context.Language, "LanguageId", "LanguageId", question.LanguageId);
            ViewData["LevelOfEducationInternationalId"] = new SelectList(_context.LevelOfEducationInternational,
                "LevelOfEducationInternationalId", "LevelOfEducationInternationalId", question.LevelOfEducationInternationalId);
            ViewData["QuestionTypeId"] = new SelectList(_context.QuestionType, "QuestionTypeId", "QuestionTypeId", question.QuestionTypeId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SubjectId", question.SubjectId);
            return View(question);
        }

        // POST: Question/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("QuestionId,CreateDate,UserId,LanguageId,Text,SubjectId," +
            "DegreeOfDifficultyId,QuestionTypeId,LevelOfEducationInternationalId")] Question question)
        {
            if (id != question.QuestionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.QuestionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DegreeOfDifficultyId"] = new SelectList(_context.DegreeOfDifficulty, "DegreeOfDifficultyId", 
                "DegreeOfDifficultyId", question.DegreeOfDifficultyId);
            ViewData["LanguageId"] = new SelectList(_context.Language, "LanguageId", "LanguageId", question.LanguageId);
            ViewData["LevelOfEducationInternationalId"] = new SelectList(_context.LevelOfEducationInternational, 
                "LevelOfEducationInternationalId", "LevelOfEducationInternationalId", question.LevelOfEducationInternationalId);
            ViewData["QuestionTypeId"] = new SelectList(_context.QuestionType, "QuestionTypeId", "QuestionTypeId", question.QuestionTypeId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SubjectId", question.SubjectId);
            return View(question);
        }

        // GET: Question/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .Include(q => q.DegreeOfDifficulty)
                .Include(q => q.Language)
                .Include(q => q.LevelOfEducationInternational)
                .Include(q => q.QuestionType)
                .Include(q => q.Subject)
                .SingleOrDefaultAsync(m => m.QuestionId == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var question = await _context.Question.SingleOrDefaultAsync(m => m.QuestionId == id);
            _context.Question.Remove(question);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(long id)
        {
            return _context.Question.Any(e => e.QuestionId == id);
        }
    }
}

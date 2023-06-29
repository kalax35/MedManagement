using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedManagement.Data;

namespace MedManagement.Controllers
{
    public class TermsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TermsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Terms
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Terms.Include(t => t.Doctor).Include(t => t.MedicalFacility);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Terms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Terms == null)
            {
                return NotFound();
            }

            var terms = await _context.Terms
                .Include(t => t.Doctor)
                .Include(t => t.MedicalFacility)
                .FirstOrDefaultAsync(m => m.TermsID == id);
            if (terms == null)
            {
                return NotFound();
            }

            return View(terms);
        }

        // GET: Terms/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorID", "DoctorName");
            ViewData["MedicalFacilityId"] = new SelectList(_context.MedicalFacility, "Id", "City");
            return View();
        }

        // POST: Terms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TermsID,CreatedDate,LastUpdatedOn,IsBusy,MedicalFacilityId,DoctorId")] Terms terms)
        {
            //if (ModelState.IsValid)
            {
                _context.Add(terms);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorID", "DoctorName", terms.DoctorId);
            ViewData["MedicalFacilityId"] = new SelectList(_context.MedicalFacility, "Id", "City", terms.MedicalFacilityId);
            return View(terms);
        }

        // GET: Terms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Terms == null)
            {
                return NotFound();
            }

            var terms = await _context.Terms.FindAsync(id);
            if (terms == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorID", "DoctorName", terms.DoctorId);
            ViewData["MedicalFacilityId"] = new SelectList(_context.MedicalFacility, "Id", "City", terms.MedicalFacilityId);
            return View(terms);
        }

        // POST: Terms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TermsID,CreatedDate,LastUpdatedOn,IsBusy,MedicalFacilityId,DoctorId")] Terms terms)
        {
            if (id != terms.TermsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(terms);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TermsExists(terms.TermsID))
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
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorID", "DoctorName", terms.DoctorId);
            ViewData["MedicalFacilityId"] = new SelectList(_context.MedicalFacility, "Id", "City", terms.MedicalFacilityId);
            return View(terms);
        }

        // GET: Terms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Terms == null)
            {
                return NotFound();
            }

            var terms = await _context.Terms
                .Include(t => t.Doctor)
                .Include(t => t.MedicalFacility)
                .FirstOrDefaultAsync(m => m.TermsID == id);
            if (terms == null)
            {
                return NotFound();
            }

            return View(terms);
        }

        // POST: Terms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Terms == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Terms'  is null.");
            }
            var terms = await _context.Terms.FindAsync(id);
            if (terms != null)
            {
                _context.Terms.Remove(terms);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TermsExists(int id)
        {
          return (_context.Terms?.Any(e => e.TermsID == id)).GetValueOrDefault();
        }
    }
}

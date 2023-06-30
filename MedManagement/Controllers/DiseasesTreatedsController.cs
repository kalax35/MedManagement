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
    public class DiseasesTreatedsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiseasesTreatedsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DiseasesTreateds
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DiseasesTreated.Include(d => d.Doctor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DiseasesTreateds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DiseasesTreated == null)
            {
                return NotFound();
            }

            var diseasesTreated = await _context.DiseasesTreated
                .Include(d => d.Doctor)
                .FirstOrDefaultAsync(m => m.DiseasesTreatedID == id);
            if (diseasesTreated == null)
            {
                return NotFound();
            }

            return View(diseasesTreated);
        }

        // GET: DiseasesTreateds/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorID", "DoctorName");
            return View();
        }

        // POST: DiseasesTreateds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiseasesTreatedID,Name,DoctorId")] DiseasesTreated diseasesTreated)
        {

                _context.Add(diseasesTreated);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorID", "DoctorName", diseasesTreated.DoctorId);
            return View(diseasesTreated);
        }

        // GET: DiseasesTreateds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DiseasesTreated == null)
            {
                return NotFound();
            }

            var diseasesTreated = await _context.DiseasesTreated.FindAsync(id);
            if (diseasesTreated == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorID", "DoctorName", diseasesTreated.DoctorId);
            return View(diseasesTreated);
        }

        // POST: DiseasesTreateds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DiseasesTreatedID,Name,DoctorId")] DiseasesTreated diseasesTreated)
        {
            if (id != diseasesTreated.DiseasesTreatedID)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            {
                var tdtDb = await _context.DiseasesTreated.FindAsync(id);
                try
                {
                    tdtDb.Name = diseasesTreated.Name;
                    tdtDb.DoctorId = diseasesTreated.DoctorId;


                    _context.Update(tdtDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiseasesTreatedExists(diseasesTreated.DiseasesTreatedID))
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
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorID", "DoctorName", diseasesTreated.DoctorId);
            return View(diseasesTreated);
        }

        // GET: DiseasesTreateds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DiseasesTreated == null)
            {
                return NotFound();
            }

            var diseasesTreated = await _context.DiseasesTreated
                .Include(d => d.Doctor)
                .FirstOrDefaultAsync(m => m.DiseasesTreatedID == id);
            if (diseasesTreated == null)
            {
                return NotFound();
            }

            return View(diseasesTreated);
        }

        // POST: DiseasesTreateds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DiseasesTreated == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DiseasesTreated'  is null.");
            }
            var diseasesTreated = await _context.DiseasesTreated.FindAsync(id);
            if (diseasesTreated != null)
            {
                _context.DiseasesTreated.Remove(diseasesTreated);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiseasesTreatedExists(int id)
        {
          return (_context.DiseasesTreated?.Any(e => e.DiseasesTreatedID == id)).GetValueOrDefault();
        }
    }
}

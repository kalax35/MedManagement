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
    public class MedicalFacilitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicalFacilitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MedicalFacilities
        public async Task<IActionResult> Index()
        {
              return _context.MedicalFacility != null ? 
                          View(await _context.MedicalFacility.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.MedicalFacility'  is null.");
        }

        // GET: MedicalFacilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MedicalFacility == null)
            {
                return NotFound();
            }

            var medicalFacility = await _context.MedicalFacility
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicalFacility == null)
            {
                return NotFound();
            }

            return View(medicalFacility);
        }

        // GET: MedicalFacilities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicalFacilities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Street,City,Phone,PostalCode")] MedicalFacility medicalFacility)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicalFacility);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicalFacility);
        }

        // GET: MedicalFacilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MedicalFacility == null)
            {
                return NotFound();
            }

            var medicalFacility = await _context.MedicalFacility.FindAsync(id);
            if (medicalFacility == null)
            {
                return NotFound();
            }
            return View(medicalFacility);
        }

        // POST: MedicalFacilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Street,City,Phone,PostalCode")] MedicalFacility medicalFacility)
        {
            if (id != medicalFacility.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalFacility);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalFacilityExists(medicalFacility.Id))
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
            return View(medicalFacility);
        }

        // GET: MedicalFacilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MedicalFacility == null)
            {
                return NotFound();
            }

            var medicalFacility = await _context.MedicalFacility
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicalFacility == null)
            {
                return NotFound();
            }

            return View(medicalFacility);
        }

        // POST: MedicalFacilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MedicalFacility == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MedicalFacility'  is null.");
            }
            var medicalFacility = await _context.MedicalFacility.FindAsync(id);
            if (medicalFacility != null)
            {
                _context.MedicalFacility.Remove(medicalFacility);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalFacilityExists(int id)
        {
          return (_context.MedicalFacility?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

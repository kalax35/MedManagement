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
    public class DoctorMedicalFacilitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorMedicalFacilitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DoctorMedicalFacilities
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DoctorMedicalFacility.Include(d => d.Doctor).Include(d => d.MedicalFacility);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DoctorMedicalFacilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DoctorMedicalFacility == null)
            {
                return NotFound();
            }

            var doctorMedicalFacility = await _context.DoctorMedicalFacility
                .Include(d => d.Doctor)
                .Include(d => d.MedicalFacility)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (doctorMedicalFacility == null)
            {
                return NotFound();
            }

            return View(doctorMedicalFacility);
        }

        // GET: DoctorMedicalFacilities/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorID", "DoctorName");
            ViewData["MedicalFacilityId"] = new SelectList(_context.MedicalFacility, "Id", "City");
            return View();
        }

        // POST: DoctorMedicalFacilities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DoctorId,MedicalFacilityId")] DoctorMedicalFacility doctorMedicalFacility)
        {
            //if (ModelState.IsValid)
            {
                _context.Add(doctorMedicalFacility);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorID", "DoctorName", doctorMedicalFacility.DoctorId);
            ViewData["MedicalFacilityId"] = new SelectList(_context.MedicalFacility, "Id", "City", doctorMedicalFacility.MedicalFacilityId);
            return View(doctorMedicalFacility);
        }

        // GET: DoctorMedicalFacilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DoctorMedicalFacility == null)
            {
                return NotFound();
            }

            var doctorMedicalFacility = await _context.DoctorMedicalFacility.FindAsync(id);
            if (doctorMedicalFacility == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorID", "DoctorName", doctorMedicalFacility.DoctorId);
            ViewData["MedicalFacilityId"] = new SelectList(_context.MedicalFacility, "Id", "City", doctorMedicalFacility.MedicalFacilityId);
            return View(doctorMedicalFacility);
        }

        // POST: DoctorMedicalFacilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DoctorId,MedicalFacilityId")] DoctorMedicalFacility doctorMedicalFacility)
        {
            if (id != doctorMedicalFacility.ID)
            {
                return NotFound();
            }

           // if (ModelState.IsValid)
            {
                var dmftDb = await _context.DoctorMedicalFacility.FindAsync(id);
                try
                {
                    dmftDb.DoctorId = doctorMedicalFacility.DoctorId;
                    dmftDb.MedicalFacilityId = doctorMedicalFacility.MedicalFacilityId;

                    _context.Update(dmftDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorMedicalFacilityExists(doctorMedicalFacility.ID))
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
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorID", "DoctorName", doctorMedicalFacility.DoctorId);
            ViewData["MedicalFacilityId"] = new SelectList(_context.MedicalFacility, "Id", "City", doctorMedicalFacility.MedicalFacilityId);
            return View(doctorMedicalFacility);
        }

        // GET: DoctorMedicalFacilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DoctorMedicalFacility == null)
            {
                return NotFound();
            }

            var doctorMedicalFacility = await _context.DoctorMedicalFacility
                .Include(d => d.Doctor)
                .Include(d => d.MedicalFacility)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (doctorMedicalFacility == null)
            {
                return NotFound();
            }

            return View(doctorMedicalFacility);
        }

        // POST: DoctorMedicalFacilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DoctorMedicalFacility == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DoctorMedicalFacility'  is null.");
            }
            var doctorMedicalFacility = await _context.DoctorMedicalFacility.FindAsync(id);
            if (doctorMedicalFacility != null)
            {
                _context.DoctorMedicalFacility.Remove(doctorMedicalFacility);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorMedicalFacilityExists(int id)
        {
          return (_context.DoctorMedicalFacility?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}

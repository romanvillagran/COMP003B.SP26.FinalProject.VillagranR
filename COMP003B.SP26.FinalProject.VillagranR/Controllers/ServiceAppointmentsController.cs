using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP003B.SP26.FinalProject.VillagranR.Data;
using COMP003B.SP26.FinalProject.VillagranR.Models;

namespace COMP003B.SP26.FinalProject.VillagranR.Controllers
{
    public class ServiceAppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceAppointmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServiceAppointments
        public async Task<IActionResult> Index()
        {
            return View(await _context.serviceAppointment.ToListAsync());
        }

        // GET: ServiceAppointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceAppointment = await _context.serviceAppointment
                .FirstOrDefaultAsync(m => m.ServiceAppointmentId == id);
            if (serviceAppointment == null)
            {
                return NotFound();
            }

            return View(serviceAppointment);
        }

        // GET: ServiceAppointments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceAppointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceAppointmentId")] ServiceAppointment serviceAppointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceAppointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceAppointment);
        }

        // GET: ServiceAppointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceAppointment = await _context.serviceAppointment.FindAsync(id);
            if (serviceAppointment == null)
            {
                return NotFound();
            }
            return View(serviceAppointment);
        }

        // POST: ServiceAppointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceAppointmentId")] ServiceAppointment serviceAppointment)
        {
            if (id != serviceAppointment.ServiceAppointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceAppointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceAppointmentExists(serviceAppointment.ServiceAppointmentId))
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
            return View(serviceAppointment);
        }

        // GET: ServiceAppointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceAppointment = await _context.serviceAppointment
                .FirstOrDefaultAsync(m => m.ServiceAppointmentId == id);
            if (serviceAppointment == null)
            {
                return NotFound();
            }

            return View(serviceAppointment);
        }

        // POST: ServiceAppointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceAppointment = await _context.serviceAppointment.FindAsync(id);
            if (serviceAppointment != null)
            {
                _context.serviceAppointment.Remove(serviceAppointment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceAppointmentExists(int id)
        {
            return _context.serviceAppointment.Any(e => e.ServiceAppointmentId == id);
        }
    }
}

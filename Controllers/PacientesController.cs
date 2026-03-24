using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConnectaMVC.Data;
using ConnectaMVC.Models;

namespace ConnectaMVC.Controllers
{
    public class PacientesController : Controller
    {
        private readonly AppDbContext _context;

        public PacientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Pacientes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PacienteModel.Include(p => p.Usuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Pacientes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacienteModel = await _context.PacienteModel
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (pacienteModel == null)
            {
                return NotFound();
            }

            return View(pacienteModel);
        }

        // GET: Pacientes/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.UsuarioModel, "Id", "Id");
            return View();
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,ContatoEmergencia,HistoricoPaciente")] PacienteModel pacienteModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacienteModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.UsuarioModel, "Id", "Id", pacienteModel.UsuarioId);
            return View(pacienteModel);
        }

        // GET: Pacientes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacienteModel = await _context.PacienteModel.FindAsync(id);
            if (pacienteModel == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.UsuarioModel, "Id", "Id", pacienteModel.UsuarioId);
            return View(pacienteModel);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UsuarioId,ContatoEmergencia,HistoricoPaciente")] PacienteModel pacienteModel)
        {
            if (id != pacienteModel.UsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacienteModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteModelExists(pacienteModel.UsuarioId))
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
            ViewData["UsuarioId"] = new SelectList(_context.UsuarioModel, "Id", "Id", pacienteModel.UsuarioId);
            return View(pacienteModel);
        }

        // GET: Pacientes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacienteModel = await _context.PacienteModel
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (pacienteModel == null)
            {
                return NotFound();
            }

            return View(pacienteModel);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var pacienteModel = await _context.PacienteModel.FindAsync(id);
            if (pacienteModel != null)
            {
                _context.PacienteModel.Remove(pacienteModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteModelExists(string id)
        {
            return _context.PacienteModel.Any(e => e.UsuarioId == id);
        }
    }
}

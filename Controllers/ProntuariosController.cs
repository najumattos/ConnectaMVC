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
    public class ProntuariosController : Controller
    {
        private readonly AppDbContext _context;

        public ProntuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Prontuario
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ProntuarioModel.Include(p => p.Paciente).Include(p => p.PsicologoResponsavel);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Prontuario/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prontuarioModel = await _context.ProntuarioModel
                .Include(p => p.Paciente)
                .Include(p => p.PsicologoResponsavel)
                .FirstOrDefaultAsync(m => m.ProntuarioId == id);
            if (prontuarioModel == null)
            {
                return NotFound();
            }

            return View(prontuarioModel);
        }

        // GET: Prontuario/Create
        public IActionResult Create()
        {
            ViewData["PacienteId"] = new SelectList(_context.PacienteModel, "PacienteId", "PacienteId");
            ViewData["PsicologoResponsavelId"] = new SelectList(_context.PsicologoModel, "PsicologoId", "PsicologoId");
            return View();
        }

        // POST: Prontuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProntuarioId,PsicologoResponsavelId,PacienteId,DataCriacao,DataUltimaAtualizacao,Queixas,TipoProntuario")] ProntuarioModel prontuarioModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prontuarioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PacienteId"] = new SelectList(_context.PacienteModel, "PacienteId", "PacienteId", prontuarioModel.PacienteId);
            ViewData["PsicologoResponsavelId"] = new SelectList(_context.PsicologoModel, "PsicologoId", "PsicologoId", prontuarioModel.PsicologoResponsavelId);
            return View(prontuarioModel);
        }

        // GET: Prontuario/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prontuarioModel = await _context.ProntuarioModel.FindAsync(id);
            if (prontuarioModel == null)
            {
                return NotFound();
            }
            ViewData["PacienteId"] = new SelectList(_context.PacienteModel, "PacienteId", "PacienteId", prontuarioModel.PacienteId);
            ViewData["PsicologoResponsavelId"] = new SelectList(_context.PsicologoModel, "PsicologoId", "PsicologoId", prontuarioModel.PsicologoResponsavelId);
            return View(prontuarioModel);
        }

        // POST: Prontuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ProntuarioId,PsicologoResponsavelId,PacienteId,DataCriacao,DataUltimaAtualizacao,Queixas,TipoProntuario")] ProntuarioModel prontuarioModel)
        {
            if (id != prontuarioModel.ProntuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prontuarioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProntuarioModelExists(prontuarioModel.ProntuarioId))
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
            ViewData["PacienteId"] = new SelectList(_context.PacienteModel, "PacienteId", "PacienteId", prontuarioModel.PacienteId);
            ViewData["PsicologoResponsavelId"] = new SelectList(_context.PsicologoModel, "PsicologoId", "PsicologoId", prontuarioModel.PsicologoResponsavelId);
            return View(prontuarioModel);
        }

        // GET: Prontuario/Desativar/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prontuarioModel = await _context.ProntuarioModel
                .Include(p => p.Paciente)
                .Include(p => p.PsicologoResponsavel)
                .FirstOrDefaultAsync(m => m.ProntuarioId == id);
            if (prontuarioModel == null)
            {
                return NotFound();
            }

            return View(prontuarioModel);
        }

        // POST: Prontuario/Desativar/5
        [HttpPost, ActionName("Desativar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var prontuarioModel = await _context.ProntuarioModel.FindAsync(id);
            if (prontuarioModel != null)
            {
                _context.ProntuarioModel.Remove(prontuarioModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProntuarioModelExists(string id)
        {
            return _context.ProntuarioModel.Any(e => e.ProntuarioId == id);
        }
    }
}

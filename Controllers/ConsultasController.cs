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
    public class ConsultasController : Controller
    {
        private readonly AppDbContext _context;

        public ConsultasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Consultas
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ConsultaModel.Include(c => c.Prontuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Consultas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaModel = await _context.ConsultaModel
                .Include(c => c.Prontuario)
                .FirstOrDefaultAsync(m => m.ConsultaId == id);
            if (consultaModel == null)
            {
                return NotFound();
            }

            return View(consultaModel);
        }

        // GET: Consultas/Create
        public IActionResult Create()
        {
            ViewData["ProntuarioId"] = new SelectList(_context.ProntuarioModel, "ProntuarioId", "ProntuarioId");
            return View();
        }

        // POST: Consultas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConsultaId,DataHoraConsulta,DuracaoConsulta,AnotacoesConsulta,ProntuarioId")] ConsultaModel consultaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProntuarioId"] = new SelectList(_context.ProntuarioModel, "ProntuarioId", "ProntuarioId", consultaModel.ProntuarioId);
            return View(consultaModel);
        }

        // GET: Consultas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaModel = await _context.ConsultaModel.FindAsync(id);
            if (consultaModel == null)
            {
                return NotFound();
            }
            ViewData["ProntuarioId"] = new SelectList(_context.ProntuarioModel, "ProntuarioId", "ProntuarioId", consultaModel.ProntuarioId);
            return View(consultaModel);
        }

        // POST: Consultas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ConsultaId,DataHoraConsulta,DuracaoConsulta,AnotacoesConsulta,ProntuarioId")] ConsultaModel consultaModel)
        {
            if (id != consultaModel.ConsultaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaModelExists(consultaModel.ConsultaId))
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
            ViewData["ProntuarioId"] = new SelectList(_context.ProntuarioModel, "ProntuarioId", "ProntuarioId", consultaModel.ProntuarioId);
            return View(consultaModel);
        }

        // GET: Consultas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaModel = await _context.ConsultaModel
                .Include(c => c.Prontuario)
                .FirstOrDefaultAsync(m => m.ConsultaId == id);
            if (consultaModel == null)
            {
                return NotFound();
            }

            return View(consultaModel);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var consultaModel = await _context.ConsultaModel.FindAsync(id);
            if (consultaModel != null)
            {
                _context.ConsultaModel.Remove(consultaModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaModelExists(string id)
        {
            return _context.ConsultaModel.Any(e => e.ConsultaId == id);
        }
    }
}

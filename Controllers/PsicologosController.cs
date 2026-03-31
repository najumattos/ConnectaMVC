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
    public class PsicologosController : Controller
    {
        private readonly AppDbContext _context;

        public PsicologosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Psicologo
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PsicologoModel.Include(p => p.Usuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Psicologo/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var psicologoModel = await _context.PsicologoModel
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.PsicologoId == id);
            if (psicologoModel == null)
            {
                return NotFound();
            }

            return View(psicologoModel);
        }

        // GET: Psicologo/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.UsuarioModel, "Id", "Id");
            return View();
        }

        // POST: Psicologo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PsicologoId,UsuarioId,RegistroAcademico,Descricao,TipoPerfil")] PsicologoModel psicologoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(psicologoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.UsuarioModel, "Id", "Id", psicologoModel.UsuarioId);
            return View(psicologoModel);
        }

        // GET: Psicologo/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var psicologoModel = await _context.PsicologoModel.FindAsync(id);
            if (psicologoModel == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.UsuarioModel, "Id", "Id", psicologoModel.UsuarioId);
            return View(psicologoModel);
        }

        // POST: Psicologo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PsicologoId,UsuarioId,RegistroAcademico,Descricao,TipoPerfil")] PsicologoModel psicologoModel)
        {
            if (id != psicologoModel.PsicologoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(psicologoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PsicologoModelExists(psicologoModel.PsicologoId))
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
            ViewData["UsuarioId"] = new SelectList(_context.UsuarioModel, "Id", "Id", psicologoModel.UsuarioId);
            return View(psicologoModel);
        }

        // GET: Psicologo/Desativar/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var psicologoModel = await _context.PsicologoModel
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.PsicologoId == id);
            if (psicologoModel == null)
            {
                return NotFound();
            }

            return View(psicologoModel);
        }

        // POST: Psicologo/Desativar/5
        [HttpPost, ActionName("Desativar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var psicologoModel = await _context.PsicologoModel.FindAsync(id);
            if (psicologoModel != null)
            {
                _context.PsicologoModel.Remove(psicologoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PsicologoModelExists(string id)
        {
            return _context.PsicologoModel.Any(e => e.PsicologoId == id);
        }
    }
}

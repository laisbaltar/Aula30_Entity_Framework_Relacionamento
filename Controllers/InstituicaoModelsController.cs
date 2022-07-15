using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aula30.Models;

namespace Aula30.Controllers
{
    public class InstituicaoModelsController : Controller
    {
        private readonly EscolaContext _context;

        public InstituicaoModelsController(EscolaContext context)
        {
            _context = context;
        }

        // GET: InstituicaoModels
        public async Task<IActionResult> Index()
        {
              return _context.Instituicoes != null ? 
                          View(await _context.Instituicoes.ToListAsync()) :
                          Problem("Entity set 'EscolaContext.Instituicoes'  is null.");
        }

        // GET: InstituicaoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Instituicoes == null)
            {
                return NotFound();
            }

            var instituicaoModel = await _context.Instituicoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instituicaoModel == null)
            {
                return NotFound();
            }

            return View(instituicaoModel);
        }

        // GET: InstituicaoModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InstituicaoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Endereco,Cnpj")] InstituicaoModel instituicaoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instituicaoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instituicaoModel);
        }

        // GET: InstituicaoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Instituicoes == null)
            {
                return NotFound();
            }

            var instituicaoModel = await _context.Instituicoes.FindAsync(id);
            if (instituicaoModel == null)
            {
                return NotFound();
            }
            return View(instituicaoModel);
        }

        // POST: InstituicaoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Endereco,Cnpj")] InstituicaoModel instituicaoModel)
        {
            if (id != instituicaoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instituicaoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstituicaoModelExists(instituicaoModel.Id))
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
            return View(instituicaoModel);
        }

        // GET: InstituicaoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Instituicoes == null)
            {
                return NotFound();
            }

            var instituicaoModel = await _context.Instituicoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instituicaoModel == null)
            {
                return NotFound();
            }

            return View(instituicaoModel);
        }

        // POST: InstituicaoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Instituicoes == null)
            {
                return Problem("Entity set 'EscolaContext.Instituicoes'  is null.");
            }
            var instituicaoModel = await _context.Instituicoes.FindAsync(id);
            if (instituicaoModel != null)
            {
                _context.Instituicoes.Remove(instituicaoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstituicaoModelExists(int id)
        {
          return (_context.Instituicoes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

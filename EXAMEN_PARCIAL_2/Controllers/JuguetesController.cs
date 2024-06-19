using EXAMEN_PARCIAL_2.Entities;
using EXAMEN_PARCIAL_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EXAMEN_PARCIAL_2.Controllers
{
    public class JuguetesController : Controller
    {
        private readonly AplicationDbContext _context;

        public JuguetesController(AplicationDbContext context)
        {
            _context = context;
        }
    
         public async Task<IActionResult> JugueteList()
        {
            var juguetes = await _context.juguetes
                .Select(j => new JuguetesModel()
                {
                    Id = j.Id,
                    Codigo = j.Codigo,
                    Nombre = j.Nombre,
                    Precio = j.Precio,
                    Vigencia = j.Vigencia,
                    Activo = j.Activo
                })
                .ToListAsync();

            return View(juguetes);
        }
 [HttpGet]
        public IActionResult JugueteAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> JugueteAdd(JuguetesModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var juguete = new Juguete()
            {
                Id = Guid.NewGuid(),
                Codigo = model.Codigo,
                Nombre = model.Nombre,
                Precio = model.Precio,
                Vigencia = model.Vigencia,
                Activo = model.Activo
            };

            _context.juguetes.Add(juguete);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(JugueteList));
        }

        
        [HttpGet]
        public async Task<IActionResult> JugueteEdit(Guid id)
        {
            var jugueteEdit = await _context.juguetes
                .Where(j => j.Id == id)
                .FirstOrDefaultAsync();

            if (jugueteEdit == null)
            {
                return RedirectToAction(nameof(JugueteList));
            }

            var model = new JuguetesModel()
            {
                Id = jugueteEdit.Id,
                Codigo = jugueteEdit.Codigo,
                Nombre = jugueteEdit.Nombre,
                Precio = jugueteEdit.Precio,
                Vigencia = jugueteEdit.Vigencia,
                Activo = jugueteEdit.Activo
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> JugueteEdit(JuguetesModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var jugueteEdit = await _context.juguetes
                .Where(j => j.Id == model.Id)
                .FirstOrDefaultAsync();

            if (jugueteEdit == null)
            {
                return RedirectToAction(nameof(JugueteList));
            }

            jugueteEdit.Codigo = model.Codigo;
            jugueteEdit.Nombre = model.Nombre;
            jugueteEdit.Precio = model.Precio;
            jugueteEdit.Vigencia = model.Vigencia;
            jugueteEdit.Activo = model.Activo;

            _context.juguetes.Update(jugueteEdit);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(JugueteList));
        }

        
        [HttpGet]
        public async Task<IActionResult> JugueteDelete(Guid id)
        {
            var jugueteDelet = await _context.juguetes
                .Where(j => j.Id == id)
                .FirstOrDefaultAsync();

            if (jugueteDelet == null)
            {
                return RedirectToAction(nameof(JugueteList));
            }

            var model = new JuguetesModel()
            {
                Id = jugueteDelet.Id,
                Codigo = jugueteDelet.Codigo,
                Nombre = jugueteDelet.Nombre,
                Precio = jugueteDelet.Precio,
                Vigencia = jugueteDelet.Vigencia,
                Activo = jugueteDelet.Activo
            };

            return View(model);
        }
        //Aqui me da error en Juguete delete y no se por que 
        public async Task<IActionResult> JugueteDelete(Guid id)
        {
            var jugueteD = await _context.juguetes
                .Where(j => j.Id == id)
                .FirstOrDefaultAsync();

            if (jugueteD == null)
            {
                return RedirectToAction(nameof(JugueteList));
            }

            _context.juguetes.Remove(jugueteD);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(JugueteList));
        }
    }


    }

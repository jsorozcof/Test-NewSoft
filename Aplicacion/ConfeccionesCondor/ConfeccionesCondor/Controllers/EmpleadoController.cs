using ConfeccionesCondor.Core_StoredProcs;
using ConfeccionesCondor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfeccionesCondor.Controllers
{


    public class EmpleadoController : Controller
    {
        private readonly TransactionDbContext _context;
        private readonly EmpleadoRepository _repository;

        public EmpleadoController(TransactionDbContext context, EmpleadoRepository repository)
        {
            _context = context;
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository)); // Inyecto el repositorio de procedimientos almacenados
        }


        [HttpGet]

        //Opcion 2 para hacer get
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleadoModel>>> Get()
        {
            return await _repository.GetAll();
        }


        //Opcion 1 para hacer get
        // GET: Empleado
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empleado.Include(a => a.Area).ToListAsync());
        }

        // GET: Empleado/AddOrEdit(Insert)
        // GET: Empleado/AddOrEdit/5(Update)
        //[NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {

            List<SelectListItem> lstDoc= new List<SelectListItem>();
            lstDoc.Add(new SelectListItem() { Text = "CEDULA DE CUIDADANIA", Value = "1" });
            lstDoc.Add(new SelectListItem() { Text = "CEDULA DE EXTRANJERIA", Value = "2" });
            lstDoc.Add(new SelectListItem() { Text = "NUMERO DE IDENTIFICACION PERSONAL", Value = "3" });
            lstDoc.Add(new SelectListItem() { Text = "NUMERO DE IDENTIFICACION TRIBUTARIA", Value = "4" });

            List<AreaModel> lst = null;
            lst = (
                from d in _context.Area
                select new AreaModel
                {
                    AreaId = d.AreaId,
                    Nombre = d.Nombre
                }
                 ).ToList();

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString(),
                    Value = d.AreaId.ToString(),
                    Selected = false

                };
            });

            ViewBag.AreaItems = items;
            ViewBag.TipoDocItems = lstDoc;

            if (id == 0)
                return View(new EmpleadoModel());
            else
            {
                var empleadoModel = await _context.Empleado.FindAsync(id);
                if (empleadoModel == null)
                {
                    return NotFound();
                }
                return View(empleadoModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("EmpleadoId,TipoDocumentoId,NumeroDocumento,Nombres,Apellidos,AreaId,FechaNacimiento")] EmpleadoModel empleadoModel)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    empleadoModel.FechaCreacion = DateTime.Now;
                    _context.Add(empleadoModel);
                    await _context.SaveChangesAsync();

                }
                //Update
                else
                {
                    try
                    {

                        //empleadoModel.FechaNacimiento = Convert.ToDate(empleadoModel.FechaNacimiento.ToString("dd/MM/yyyy"));
                        empleadoModel.FechaCreacion = DateTime.Now;
                        _context.Update(empleadoModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TransactionModelExists(empleadoModel.EmpleadoId))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Empleado.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", empleadoModel) });
        }

        // GET: Empleado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionModel = await _context.Empleado
                .FirstOrDefaultAsync(m => m.EmpleadoId == id);
            if (transactionModel == null)
            {
                return NotFound();
            }

            return View(transactionModel);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transactionModel = await _context.Empleado.FindAsync(id);
            _context.Empleado.Remove(transactionModel);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Empleado.ToList()) });
        }

        private bool TransactionModelExists(int id)
        {
            return _context.Empleado.Any(e => e.EmpleadoId == id);
        }

        private static void GetList()
        { 
        
        }
    }
}

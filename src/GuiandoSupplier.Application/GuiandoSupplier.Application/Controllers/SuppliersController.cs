using AutoMapper;
using GuiandoSupplier.Domain.Entities;
using GuiandoSupplier.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GuiandoSupplier.Application.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SuppliersController(ISupplierService supplierService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _supplierService = supplierService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Suppliers
        public async Task<IActionResult> Index()
        {
            try
            {
                List<SupplierDTO> supplierDTOs = await _supplierService.Get();
                return View(supplierDTOs);
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"{ex}, Ops! algo deu errado.");
            }

        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupplierDTQ supplier)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SupplierDTO supplierDTO = _mapper.Map<SupplierDTO>(supplier);

                    if (supplier.FileLogo.Length > 0)
                    {
                        string folder = "uploads/logo/";
                        supplierDTO.LogoUrl = await Upload(folder, supplier.FileLogo);
                    }

                    await _supplierService.Add(supplierDTO);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    throw new ArgumentException($"{ex}, Ops! algo deu errado.");
                }

            }
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = _mapper.Map<SupplierDTQ>(await _supplierService.Get(id.Value));
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, SupplierDTQ supplier)
        {
            if (id != supplier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    SupplierDTO supplierDTO = _mapper.Map<SupplierDTO>(supplier);

                    if (supplier.FileLogo != null && supplier.FileLogo.Length > 0)
                    {
                        string folder = "uploads/logo/";
                        supplierDTO.LogoUrl = await Upload(folder, supplier.FileLogo);
                    }
                    await _supplierService.Update(supplierDTO);
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw new ArgumentException($"{ex}, Ops! algo deu errado.");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SupplierDTO supplier = await _supplierService.Get(id.Value);

            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            try
            {
                await _supplierService.Delete(id);
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"{ex}, Ops! algo deu errado.");
            }


            return RedirectToAction(nameof(Index));
        }

        private async Task<string> Upload(string folderPath, IFormFile file)
        {
            folderPath += file.FileName;
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return $"/" + folderPath;
        }

    }
}

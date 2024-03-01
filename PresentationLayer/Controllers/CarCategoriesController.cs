using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bussines_Layer.Models;
using DataLayer.Common;
using ServiceLayer;

namespace PresentationLayer.Controllers
{
    public class CarCategoriesController : Controller
    {
        private readonly CarCategoryManager carCategoryManager;

        public CarCategoriesController(CarCategoryManager carCategoryManager)
        {
            this.carCategoryManager = carCategoryManager;
        }

        // GET: CarCategories
        public async Task<IActionResult> Index()
        {
            return View(await carCategoryManager.ReadAllAsync());
        }

        // GET: CarCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carCategory = await carCategoryManager.ReadAsync((int)id);
            if (carCategory == null)
            {
                return NotFound();
            }

            return View(carCategory);
        }

        // GET: CarCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] CarCategory carCategory)
        {
            if (ModelState.IsValid)
            {
                await carCategoryManager.CreateAsync(carCategory);
                return RedirectToAction(nameof(Index));
            }
            return View(carCategory);
        }

        // GET: CarCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carCategory = await carCategoryManager.ReadAsync((int)(id));
            if (carCategory == null)
            {
                return NotFound();
            }
            return View(carCategory);
        }

        // POST: CarCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] CarCategory carCategory)
        {
            if (id != carCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await carCategoryManager.UpdateAsync(carCategory);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CarCategoryExists(carCategory.Id))
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
            return View(carCategory);
        }

        // GET: CarCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carCategory = await carCategoryManager.ReadAsync((int)id);
            if (carCategory == null)
            {
                return NotFound();
            }

            return View(carCategory);
        }

        // POST: CarCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await carCategoryManager.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CarCategoryExists(int id)
        {
          return await carCategoryManager.ReadAsync(id) is not null;
        }
    }
}

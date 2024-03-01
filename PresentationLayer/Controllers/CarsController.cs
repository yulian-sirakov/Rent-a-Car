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
    public class CarsController : Controller
    {
        private readonly CarManager carManager;
        private readonly CarCategoryManager carCategoryManager;

        public CarsController(CarManager _carManager, CarCategoryManager _carCategoryManager)
        {
            carManager = _carManager;
            carCategoryManager = _carCategoryManager;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            await LoadCarCategoriesAsync(true);
            return View(await carManager.ReadAllAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await LoadCarCategoriesAsync(true);
            var car = await carManager.ReadAsync((int)id, true, true);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public async Task<IActionResult> Create()
        {
            await LoadCarCategoriesAsync(true);
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,Model,Year,DailyRent,Description,IsReserved,CarCategoryId")] Car car)
        {
            if (ModelState.IsValid)
            {
                await carManager.CreateAsync(car);
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await LoadCarCategoriesAsync(false);
            var car = await carManager.ReadAsync((int)id, true, false);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Model,Year,DailyRent,Description,IsReserved,CarCategoryId")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await carManager.UpdateAsync(car);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CarExists(car.Id))
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
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await carManager.ReadAsync((int)id,false,false);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await carManager.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CarExists(int id)
        {
          return await carManager.ReadAsync((int)id,false,true) is not null;
        }

        private async Task LoadCarCategoriesAsync(bool readOnly)
        {
            ViewBag.CarCategories = new SelectList(await carCategoryManager.ReadAllAsync(false, readOnly), "Id", "Name");
        }
    }
}

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
    public class ReviewsController : Controller
    {
        private readonly ReviewManager reviewManager;
        private readonly CustomerManager customerManager;
        private readonly CarManager carManager;

        public ReviewsController(ReviewManager _reviewManager,
            CustomerManager _customerManager,
            CarManager _carManager)
        {
            reviewManager = _reviewManager;
            customerManager = _customerManager;
            carManager = _carManager;
        }

        // GET: Reviews
        public async Task<IActionResult> Index()
        {
            return View(await reviewManager.ReadAllAsync(true,true));
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await reviewManager.ReadAsync((int)id, true, false);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: Reviews/Create
        public async Task<IActionResult> Create()
        {
            await LoadNavigationalProperties();
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,ReviewText,Rating,CarId")] Review review)
        {
            if (ModelState.IsValid)
            {
               await reviewManager.CreateAsync(review);
                return RedirectToAction(nameof(Index));
            }
            return View(review);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await LoadNavigationalProperties();
            var review = await reviewManager.ReadAsync((int)id,true, false);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,ReviewText,Rating,CarId")] Review review)
        {
            if (id != review.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await reviewManager.UpdateAsync(review, true);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ReviewExists(review.Id))
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
            return View(review);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await reviewManager.ReadAsync((int)id, true, false);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           await reviewManager.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ReviewExists(int id)
        {
            return await  reviewManager.ReadAsync(id, false, true) is not null;
        }

        private async Task LoadNavigationalProperties()
        {
            ViewBag.Customers = new SelectList(await customerManager.ReadAllAsync(), "Id", "Name");
            ViewBag.Cars = new SelectList(await carManager.ReadAllAsync(), "Id", "Model");
        }
    }
}

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
using Bussines_Layer.Enums;

namespace PresentationLayer.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly ReservationManager reservationManager;
        private readonly CustomerManager customerManager;
        private readonly CarManager carManager;
        private readonly LocationManager locationManager;
        

        public ReservationsController(ReservationManager _reservationManager,
            CustomerManager _customerManager,
            CarManager _carManager,
            LocationManager _locationManager)
        {
            reservationManager = _reservationManager;
            customerManager = _customerManager;
            carManager = _carManager;
            locationManager = _locationManager;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            await LoadNavigationalProperties();
            return View(await reservationManager.ReadAllAsync(true,true));
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await LoadNavigationalProperties();
            var reservation = await reservationManager.ReadAsync((int)id, true, true);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public async Task<IActionResult> Create()
        {
            await LoadNavigationalProperties();
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,CarId,StartDate,EndDate,TotalPrice,Status,LocationId")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                await reservationManager.CreateAsync(reservation);
                return RedirectToAction(nameof(Index));
            }
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await LoadNavigationalProperties();
            var reservation = await reservationManager.ReadAsync((int)id, true,false);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,CarId,StartDate,EndDate,TotalPrice,Status,LocationId")] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await reservationManager.UpdateAsync(reservation,true);    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await ReservationExists(reservation.Id))
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
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await reservationManager.ReadAsync(((int)id), true, false);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await reservationManager.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ReservationExists(int id)
        {
          return await reservationManager.ReadAsync(id) is not null;
        }

        private async Task LoadNavigationalProperties()
        {
            var listEnum = new List<ReservationStatus>((ReservationStatus[])Enum.GetValues(typeof(ReservationStatus)))
                .Select(r => new {
                    Name = r.ToString(),
                    Id = Convert.ToInt32(r)
                });

            ViewBag.Enums = new SelectList(listEnum, "Id", "Name");
            ViewBag.Locations = new SelectList(await locationManager.ReadAllAsync(), "Id", "Adress");
            ViewBag.Customers = new SelectList(await customerManager.ReadAllAsync(), "Id", "Name");
            ViewBag.Cars = new SelectList(await carManager.ReadAllAsync(), "Id", "Model");
        }
    }
}

﻿using BlazorApplication.Components;
using Bussines_Layer.Models;
using DataLayer.Common;
using DataLayer.ModelsContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServiceLayer;

namespace BlazorApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddQuickGridEntityFrameworkAdapter();

            builder.Services.AddDbContext<RentACarDbContext>(options =>
            {
                options.UseSqlServer("Server=DESKTOP-SQ0CA1F\\SQLEXPRESS;Database=RentACar;Trusted_Connection=True;TrustServerCertificate=True;");
            });

            builder.Services.AddScoped<CarCategoryManager, CarCategoryManager>();
            builder.Services.AddScoped<IDb<CarCategory, int>, CarCategoryContext>();
            builder.Services.AddScoped<CarCategoryContext, CarCategoryContext>();

            builder.Services.AddScoped<CarManager, CarManager>();
            builder.Services.AddScoped<IDb<Car, int>, CarContext>();
            builder.Services.AddScoped<CarContext, CarContext>();

            builder.Services.AddScoped<ReviewManager, ReviewManager>();
            builder.Services.AddScoped<IDb<Review, int>, ReviewContext>();
            builder.Services.AddScoped<ReviewContext, ReviewContext>();

            builder.Services.AddScoped<ReservationManager, ReservationManager>();
            builder.Services.AddScoped<IDb<Reservation, int>, ReservationContext>();
            builder.Services.AddScoped<ReservationContext, ReservationContext>();

            builder.Services.AddScoped<CustomerManager, CustomerManager>();
            builder.Services.AddScoped<IDb<Customer, int>, CustomerContext>();
            builder.Services.AddScoped<CustomerContext, CustomerContext>();

            builder.Services.AddScoped<LocationManager, LocationManager>();
            builder.Services.AddScoped<IDb<Location, int>, LocationContext>();
            builder.Services.AddScoped<LocationContext, LocationContext>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}

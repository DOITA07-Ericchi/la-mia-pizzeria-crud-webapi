using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using La_Mia_Pizzeria_1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace La_Mia_Pizzeria_1.Database {
	public class PizzaContext : IdentityDbContext {
		public DbSet<Pizza> pizzas { get; set; }
		public DbSet<Variant> variants {get; set; }

		protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.UseSqlServer ("Data Source=ericchi.moe;Database=Pizzabase;User Id=SA;Password=DatabaseCaconeDegenerato;TrustServerCertificate=True");
		}
	}
}

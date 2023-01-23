using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using La_Mia_Pizzeria_1.Database;
using La_Mia_Pizzeria_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace La_Mia_Pizzeria_1.Controllers.Api {
	[Route ("api/[controller]")]
	[ApiController]
	public class PizzasController : Controller {
		// GET: api/values
		[HttpGet]
		public IActionResult Get () {
			using (PizzaContext db = new PizzaContext()) {
				List<Pizza> pizze = db.pizzas
					// .Include(pizzona => pizzona.Tags) // Non ho fatto i tag...
					.ToList<Pizza>();
				return Ok(pizze);
			}
		}
	}
}


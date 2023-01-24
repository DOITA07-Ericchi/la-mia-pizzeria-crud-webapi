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
		public IActionResult Get (string? search) {

			using (PizzaContext db = new PizzaContext ()) {
				List<Pizza> pizze = new List<Pizza> ();

				if (search is null || search == "") {
					pizze = db.pizzas
						// .Include (pzz => pzz.Tags) // Niente tags
						.ToList<Pizza> ();
				} else {
					// converto tutto in stringa minuscola, non mi interessano le lettere maiuscole
					search = search.ToLower ();

					pizze = db.pizzas.Where (pzz => pzz.Title.ToLower ().Contains (search))
									   // .Include (articolo => articolo.Tags) // No tags.
									   .ToList<Pizza> ();
				}

				return Ok (pizze);
			}
		}
		[HttpGet ("{id}")]
		public IActionResult Get (int id) {

			using (PizzaContext db = new PizzaContext ()) {
				Pizza pizza = db.pizzas.Where (pzz => pzz.Id == id).FirstOrDefault ();

				if (pizza is null) {
					return NotFound ("La pizza con questo id non è stato trovato!");
				}

				return Ok (pizza);
			}
		}
	}
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using La_Mia_Pizzeria_1.Database;
using La_Mia_Pizzeria_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace La_Mia_Pizzeria_1 {
	public class PizzaController : Controller {
		// GET: /<controller>/
		public IActionResult Index () {
			using (PizzaContext db = new PizzaContext ()) {
				List<Pizza> listaPizze = db.pizzas.ToList<Pizza> ();
				return View ("Index", listaPizze);
			}
		}

		public IActionResult Details (int id) {
			using (PizzaContext db = new PizzaContext ()) {
				// LINQ: syntax methods
				Pizza pizzaTrovata = db.pizzas
					.Where (SingolaPizza => SingolaPizza.Id == id)
					.Include(pizza=>pizza.Variant)
					.FirstOrDefault ();

				if (pizzaTrovata != null) {
					return View (pizzaTrovata);
				}

				return NotFound ("La pizza con l'id cercato non esiste!");
			}
		}

		public IActionResult Esempio (string nome, string cognome, int eta) {
			return Ok ("Hai inserito il parametro nome: " + nome + ", il parametro cognome: " + cognome + ", il parametro eta: " + eta);
		}

		[HttpGet]
		public IActionResult Create () {
			using (PizzaContext db = new PizzaContext ()) {
				List<Variant> variantsFromDb = db.variants.ToList<Variant> ();

				PizzaVariantView modelForView = new PizzaVariantView ();
				modelForView.Pizza = new Pizza ();

				modelForView.Variant = variantsFromDb;
				return View ("Create", modelForView);
			}
			
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create (PizzaVariantView formData) {
			if (!ModelState.IsValid) {
				return View ("Create", formData);
			}

			using (PizzaContext db = new PizzaContext ()) {
				db.pizzas.Add (formData.Pizza);
				db.SaveChanges ();
			}

			return RedirectToAction ("Index");
		}

		[HttpGet]
		public IActionResult Update (int id) {
			using (PizzaContext db = new PizzaContext ()) {
				Pizza pizzaDaCambiare = db.pizzas.Where (pizzona => pizzona.Id == id).FirstOrDefault ();

				if (pizzaDaCambiare == null) {
					return NotFound ("La pizza non è stata trovato");
				}

				return View ("Update", pizzaDaCambiare);
			}

		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Update (Pizza formData) {
			if (!ModelState.IsValid) {
				return View ("Update", formData);
			}

			using (PizzaContext db = new PizzaContext ()) {
				Pizza pizzaDaCambiare = db.pizzas.Where (pizzona => pizzona.Id == formData.Id).FirstOrDefault ();

				if (pizzaDaCambiare != null) {
					pizzaDaCambiare.Title = formData.Title;
					pizzaDaCambiare.Description = formData.Description;
					pizzaDaCambiare.Price = formData.Price;
					pizzaDaCambiare.Image = formData.Image;

					db.SaveChanges ();

					return RedirectToAction ("Index");
				} else {
					return NotFound ("La pizza che volevi modificare non è stata trovata!");
				}
			}

		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete (int id) {
			using (PizzaContext db = new PizzaContext ()) {
				Pizza pizzaDaDeletare = db.pizzas.Where (pizzona => pizzona.Id == id).FirstOrDefault ();

				if (pizzaDaDeletare != null) {
					db.pizzas.Remove (pizzaDaDeletare);
					db.SaveChanges ();

					return RedirectToAction ("Index");
				} else {
					return NotFound ("La pizza da eliminare non è stata trovata!");
				}
			}
		}
	}
}


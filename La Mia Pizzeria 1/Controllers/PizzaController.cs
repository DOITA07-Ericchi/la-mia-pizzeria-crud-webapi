using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using La_Mia_Pizzeria_1.Models;
using La_Mia_Pizzeria_1.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace La_Mia_Pizzeria_1 {
	public class PizzaController : Controller {
		// GET: /<controller>/
		public IActionResult Index () {
			List<Pizza> listaDellePizze = PizzaData.GetPizza ();

			return View ("Index", listaDellePizze);
		}

		public IActionResult Details (int id) {
			List<Pizza> listaDellePizze = PizzaData.GetPizza ();

			foreach (Pizza pizza in listaDellePizze) {
				if (pizza.Id == id) {
					return View (pizza);
				}
			}

			return NotFound ("La pizza con l'id cercato non esiste!");
		}

		public IActionResult Esempio (string nome, string cognome, int eta) {
			return Ok ("Hai inserito il parametro nome: " + nome + ", il parametro cognome: " + cognome + ", il parametro eta: " + eta);
		}
	}
}


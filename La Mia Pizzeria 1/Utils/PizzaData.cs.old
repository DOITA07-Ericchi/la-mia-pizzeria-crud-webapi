using System;
using La_Mia_Pizzeria_1.Models;
using Microsoft.Extensions.Hosting;

namespace La_Mia_Pizzeria_1.Utils {
	public static class PizzaData {
		private static List<Pizza> pizze;

		public static List<Pizza> GetPizza() {

			if (pizze != null) {
				return pizze;
			}

			pizze = new List<Pizza>(){
				new Pizza(0,"Margherita","La classica. Pomodoro e mozzarella in un tripudio di sapore.",5.50,"margherita.webp"),
				new Pizza(1,"Marinara","Olio, aglio e origano. Niente di più genuino e mediterraneo.",6.00,"marinara.webp"),
				new Pizza(2,"Quattro Stagioni","Quattro come gli elementi della terra. Una pizza che rappresenta l'essenza stessa dell'esistenza.",7.50,"quattrostagioni.webp")
		};
			return pizze;
		}
	}
}


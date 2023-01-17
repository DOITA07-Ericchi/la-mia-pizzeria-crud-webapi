using System;
namespace La_Mia_Pizzeria_1.Models
{
	public class Variant
	{
		public int Id { get; set; }
		public string Name {get; set; }
		public List<Pizza> Pizzas { get; set; }

		public Variant()
		{
		}
	}
}


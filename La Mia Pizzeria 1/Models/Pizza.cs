using System;
namespace La_Mia_Pizzeria_1.Models {
	public class Pizza {
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
		public string Image { get; set; }

		public Pizza (int id, string title, string description, double price, string image) {
			Id = id;
			Title = title;
			Description = description;
			Price = price;
			Image = image;
		}
	}
}


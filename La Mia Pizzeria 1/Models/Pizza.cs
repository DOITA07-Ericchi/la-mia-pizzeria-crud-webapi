using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace La_Mia_Pizzeria_1.Models {
	public class Pizza {
		public int Id { get; set; }
		[Column (TypeName = "varchar(128)")]
		[StringLength(128, ErrorMessage="Il campo titolo non può contenere più di 128 caratteri")]
		public string Title { get; set; }
		[Column (TypeName = "text")]
		public string Description { get; set; }
		[Column (TypeName = "decimal(5,2)")]
		public double Price { get; set; }
		[StringLength(512, ErrorMessage="Il campo immagine non può contenere più di 512 caratteri")]
		[Column (TypeName = "varchar(512)")]
		public string Image { get; set; }

		public Pizza () {

		}

		public Pizza (int id, string title, string description, double price, string image) {
			Id = id;
			Title = title;
			Description = description;
			Price = price;
			Image = image;
		}
	}
}

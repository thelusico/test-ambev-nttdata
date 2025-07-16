using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Product
    {        
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public ProductCategory Category { get; set; }
        public string Image { get; set; }
        public Rating Rating { get; set; }

        public Product() { }

        public Product(string title, decimal price, string description,
                      ProductCategory category, string image, Rating rating)
        {
            Id = Guid.NewGuid();
            Title = title;
            Price = price;
            Description = description;
            Category = category;
            Image = image;
            Rating = rating;
        }

        // Construtor para reconstrução (usado pelo MongoDB)
        public Product(Guid id, string title, decimal price, string description,
                      ProductCategory category, string image, Rating rating)
        {
            Id = id;
            Title = title;
            Price = price;
            Description = description;
            Category = category;
            Image = image;
            Rating = rating;
        }

    }
}

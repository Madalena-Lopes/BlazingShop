using System.ComponentModel.DataAnnotations;

namespace BlazingShop.Models
{
    public class Product
    {
        public Product()
        {
            
        }

        public Product(int id, string title, decimal price, int categoryId)
        {
            Id = id;
            Title = title;
            Price = price;
            CategoryId = categoryId;
        }

        [Key]
        [Required(ErrorMessage = "Id é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Título é obrigatório")]
        [MaxLength(150, ErrorMessage = "Título deve ter no máximo 150 caracteres")]
        [MinLength(5, ErrorMessage = "Título deve ter no mínimo 5 caracteres")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Preço é obrigatório")]
        [DataType(DataType.Currency)]
        [Range(1, 9999, ErrorMessage = "Preço deve estar entre 1 e 9999")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Categoria é obrigatória")]
        [Range(1, 9999, ErrorMessage = "Categoria deve estar entre 1 e 9999")]
        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

    }
}

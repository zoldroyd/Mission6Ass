using System.ComponentModel.DataAnnotations;

namespace Mission6Ass.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
}
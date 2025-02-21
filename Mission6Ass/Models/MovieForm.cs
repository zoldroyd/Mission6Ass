using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6Ass.Models;

public class MovieForm
{
    [Key] // make it a required input like the next 5
    public int MovieId { get; set; }
    
    [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    [Required]
    [Range(1888, 9999, ErrorMessage = "Year must be 1888 or later.")]
    public int Year { get; set; }
    
    public string? Director { get; set; }
    
    public string? Rating { get; set; }

    [Required]
    public bool Edited { get; set; }
    public string? LentTo { get; set; } // ? to make it nullable
    
    [Required]
    public bool CopiedToPlex { get; set; }
    
    [StringLength(25)] // not let it exceed 25 characters
    public string? Notes { get; set; } // ? to make it nullable
    
}
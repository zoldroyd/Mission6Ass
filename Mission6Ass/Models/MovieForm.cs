using System.ComponentModel.DataAnnotations;

namespace Mission6Ass.Models;

public class MovieForm
{
    [Key]
    [Required] // make it a required input like the next 5
    public int Id { get; set; }
    
    [Required]
    public string Category { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    [Required]
    public int Year { get; set; }
    
    [Required]
    public string Director { get; set; }
    
    [Required]
    public string Rating { get; set; }

    public bool Edited { get; set; }
    public string? LentTo { get; set; } // ? to make it nullable
    
    [StringLength(25)] // not let it exceed 25 characters
    public string? Notes { get; set; } // ? to make it nullable
    
}
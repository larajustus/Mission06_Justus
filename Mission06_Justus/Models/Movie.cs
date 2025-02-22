using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Justus.Models;

public class Movie
{
    [Key]
    [Required]
    public int MovieId { get; set; }
    [Required]
    public string Title { get; set; }
    [ForeignKey("CategoryId")]
    public int? CategoryId{ get; set; }
    public Category? Category { get; set; }
    [Required]
    [Range(1888, 9999, ErrorMessage = "Year must be 1888 or later")]
    public int Year { get; set; }
    public string? Director { get; set; }
    public string? Rating { get; set; }
    [Required]
    public bool Edited { get; set; }
    public string? LentTo { get; set; }
    [Required]
    public bool CopiedToPlex { get; set; }
    [MaxLength(25)]
    public string? Notes { get; set; }
}
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TestTaskSolution.Models;

[Index(nameof(FileName))]
public class Value
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string FileName { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public ulong Time { get; set; }
    [Required]
    public double Index { get; set; }
}
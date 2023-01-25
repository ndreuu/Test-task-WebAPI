using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TestTaskSolution.Models;

[Index(nameof(FileName))]
[Index(nameof(DateFirstOperation))]
[Index(nameof(AvarageIndex))]
[Index(nameof(AvarageTime))]
public class Result
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string FileName { get; set; }
    [Required]
    public ulong DeltaTime { get; set; }
    [DataType(DataType.Date)]
    [Required]
    public DateTime DateFirstOperation { get; set; }
    [Required]  
    public double AvarageTime { get; set; }
    [Required]
    public double AvarageIndex { get; set; }
    [Required]
    public double MedianIndex { get; set; }
    [Required]
    public double MaxIndex { get; set; }
    [Required]
    public double MinIndex { get; set; }
    [Required]
    public int CountOfRecords { get; set; }
}
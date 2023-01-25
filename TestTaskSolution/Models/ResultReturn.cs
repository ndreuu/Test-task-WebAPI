using System.ComponentModel.DataAnnotations;

namespace TestTaskSolution.Models;

public class ResultReturn
{
    public string FileName { get; set; }
    public ulong DeltaTime { get; set; }
    [DataType(DataType.Date)]
    public DateTime DateFirstOperation { get; set; }
    public double AvarageTime { get; set; }
    public double AvarageIndex { get; set; }
    public double MedianIndex { get; set; }
    public double MaxIndex { get; set; }
    public double MinIndex { get; set; }
    public int CountOfRecords { get; set; }
}
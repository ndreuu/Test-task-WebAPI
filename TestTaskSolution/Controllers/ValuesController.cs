using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTaskSolution.Data;
using TestTaskSolution.Models;
using TestTaskSolution.UnitTests;

namespace TestTaskSolution.Controllers;



[ApiController]
[Route("api/[controller]")]
public class ValuesController : Controller
{
    private readonly APIDbContext dbContext;
    
    public ValuesController(APIDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    [HttpGet("GetResultByFileName")]
    public async Task<IActionResult> GetResultByFileName(string fileName)
    {
        var results = await dbContext.Results.Where(v => v.FileName == fileName).ToArrayAsync();

        if (results.Length > 0)
        {
            var resultsReturn = new ResultReturn 
            {
                FileName = results[0].FileName,
                DeltaTime = results[0].DeltaTime,
                DateFirstOperation = results[0].DateFirstOperation,
                AvarageTime = results[0].AvarageTime,
                AvarageIndex = results[0].AvarageIndex,
                MedianIndex = results[0].MedianIndex,
                MaxIndex = results[0].MaxIndex,
                MinIndex = results[0].MinIndex,
                CountOfRecords = results[0].CountOfRecords
            };
            return Json(resultsReturn);
        }

        return NotFound();
    }
    
    [HttpGet("GetResultsByDateFirstOperation")]
    public async Task<IActionResult> GetResultsByDateFirstOperation(DateTime from, DateTime to)
    {
        var results = await dbContext.Results.Where(v => 
            v.DateFirstOperation.CompareTo(to) <= 0 && 
            v.DateFirstOperation.CompareTo(from) >= 0).ToArrayAsync();
    
        if (results.Length > 0)
        {
            var resultsReturn = results.ToList().ConvertAll<ResultReturn>(r => 
                new ResultReturn 
                {
                    FileName = r.FileName,
                    DeltaTime = r.DeltaTime,
                    DateFirstOperation = r.DateFirstOperation,
                    AvarageTime = r.AvarageTime,
                    AvarageIndex = r.AvarageIndex,
                    MedianIndex = r.MedianIndex,
                    MaxIndex = r.MaxIndex,
                    MinIndex = r.MinIndex,
                    CountOfRecords = r.CountOfRecords
                }).ToArray();
                
            return Json(resultsReturn);
        }
    
        return NotFound();
    }
    
    [HttpGet("GetResultsByAvarageIndex")]
    public async Task<IActionResult> GetResultsByAvarageIndex(double from, double to)
    {
        var results = await dbContext.Results.Where(v => 
            v.AvarageIndex.CompareTo(to) <= 0 && 
            v.AvarageIndex.CompareTo(from) >= 0).ToArrayAsync();
    
        if (results.Length > 0)
        {
            var resultsReturn = results.ToList().ConvertAll<ResultReturn>(r => 
                new ResultReturn 
                {
                    FileName = r.FileName,
                    DeltaTime = r.DeltaTime,
                    DateFirstOperation = r.DateFirstOperation,
                    AvarageTime = r.AvarageTime,
                    AvarageIndex = r.AvarageIndex,
                    MedianIndex = r.MedianIndex,
                    MaxIndex = r.MaxIndex,
                    MinIndex = r.MinIndex,
                    CountOfRecords = r.CountOfRecords
                }).ToArray();
                
            return Json(resultsReturn);
        }
    
        return NotFound();
    }

    [HttpGet("GetResultsByAvarageTime")]
    public async Task<IActionResult> GetResultsByAvarageTime(double from, double to)
    {
        var results = await dbContext.Results.Where(v => 
            v.AvarageTime <= to && 
            v.AvarageTime >= from).ToArrayAsync();
    
        if (results.Length > 0)
        {
            var resultsReturn = results.ToList().ConvertAll<ResultReturn>(r => 
                new ResultReturn 
                {
                    FileName = r.FileName,
                    DeltaTime = r.DeltaTime,
                    DateFirstOperation = r.DateFirstOperation,
                    AvarageTime = r.AvarageTime,
                    AvarageIndex = r.AvarageIndex,
                    MedianIndex = r.MedianIndex,
                    MaxIndex = r.MaxIndex,
                    MinIndex = r.MinIndex,
                    CountOfRecords = r.CountOfRecords
                }).ToArray();
                
            return Json(resultsReturn);
        }
    
        return NotFound();
    }
    
    [HttpGet("GetValuesByFileName")]
    public async Task<IActionResult> GetValuesByFileName(string fileName)
    {
        var values = await dbContext.Values.Where(v => v.FileName == fileName).ToArrayAsync();

        if (values.Length > 0)
        {
            var valuesReturn = values.ToList().ConvertAll<ValueReturn>(v => 
                new ValueReturn 
                {
                    FileName = v.FileName,
                    Date = v.Date,
                    Time = v.Time,
                    Index = v.Index
                }).ToArray();
            
            return Json(valuesReturn);
        }

        return NotFound();
    }

    [HttpPost("Upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (Path.GetExtension(file.FileName) != Constants.DOT_CSV)
        {
            throw new Exception("Expected *.csv file");
        }
        
        var existingValues = dbContext.Values.Where(v => v.FileName == file.FileName).ToArray();
        
        if (existingValues.Length > 0)
        {
            var existingValue = existingValues[0];
            var existingResult = dbContext.Results.Where(r => r.FileName == existingValues[0].FileName).ToArray()[0];
            
            dbContext.Remove(existingValue);    
            dbContext.Remove(existingResult);
            
            await dbContext.SaveChangesAsync();
        }

        try
        {
            var strings = Utils.parse(file.OpenReadStream());

            var values = strings.ConvertAll<Value>(s =>
                new Value
                {
                    Id = Guid.NewGuid(),
                    FileName = file.FileName,
                    Date = s.Date,
                    Index = s.Index,
                    Time = s.Time
                });

            if (values.Count > 0)
            {
                var result = new Result
                {
                    Id = Guid.NewGuid(),
                    FileName = file.FileName,
                    AvarageIndex = strings.ConvertAll(s => s.Index).Average(),
                    AvarageTime = strings.ConvertAll(s => (double)s.Time).Average(),
                    DeltaTime = strings.ConvertAll(s => s.Time).Max() - strings.ConvertAll(s => s.Time).Min(),
                    MaxIndex = strings.ConvertAll(s => s.Index).Max(),
                    MedianIndex = Utils.GetMedian(strings.ConvertAll(s => s.Index).ToArray()),
                    MinIndex = strings.ConvertAll(s => s.Index).Min(),
                    CountOfRecords = strings.Count,
                    DateFirstOperation = strings.ConvertAll(s => s.Date).Min()
                };

                await dbContext.Results.AddAsync(result);
                await dbContext.Values.AddRangeAsync(values);
                await dbContext.SaveChangesAsync();

                return Ok(values);
            }
        }
        catch (Exception e)
        {
            throw new HttpRequestException(e.Message); 
        }

        throw new HttpRequestException();
    }
}
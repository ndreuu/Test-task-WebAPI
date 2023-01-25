using System.Text;
using TestTaskSolution.Models;

namespace TestTaskSolution.UnitTests;

public class TestUtils
{
    
    public static IFormFile GetFileMock(string filename, string content)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(content);

        var file = new FormFile(
            baseStream: new MemoryStream(bytes),
            baseStreamOffset: 0,
            length: bytes.Length,
            name: "Data",
            fileName: filename
        )
        {
            Headers = new HeaderDictionary(),
            ContentType = "csv"
        };

        return file;
    }
    
    public static bool EqValue(Value value1, Value value2)
    {
        return value1.FileName == value2.FileName &&
               value1.Date == value2.Date &&
               value1.Time == value2.Time &&
               value1.Index.Equals(value2.Index);
    }
    
    public static bool EqValueReturn(ValueReturn value1, ValueReturn value2)
    {
        return value1.FileName == value2.FileName &&
               value1.Date == value2.Date &&
               value1.Time == value2.Time &&
               value1.Index.Equals(value2.Index);
    }
    
    public static bool EqResult(Result result1, Result result2)
    {
        return result1.FileName == result2.FileName &&
               result1.DeltaTime == result2.DeltaTime &&
               result1.DateFirstOperation == result2.DateFirstOperation &&
               result1.AvarageTime == result2.AvarageTime &&
               result1.AvarageIndex == result2.AvarageIndex &&
               result1.MedianIndex == result2.MedianIndex &&
               result1.MaxIndex == result2.MaxIndex &&
               result1.MinIndex == result2.MinIndex &&
               result1.CountOfRecords == result2.CountOfRecords ;
    }

    public static bool EqResultReturn(ResultReturn result1, ResultReturn result2)
    {
        return result1.FileName == result2.FileName &&
               result1.DeltaTime == result2.DeltaTime &&
               result1.DateFirstOperation == result2.DateFirstOperation &&
               result1.AvarageTime == result2.AvarageTime &&
               result1.AvarageIndex == result2.AvarageIndex &&
               result1.MedianIndex == result2.MedianIndex &&
               result1.MaxIndex == result2.MaxIndex &&
               result1.MinIndex == result2.MinIndex &&
               result1.CountOfRecords == result2.CountOfRecords ;
    }

    
    public static bool EqValues(Value[] values1, Value[] values2)
    {
        return values1
            .Zip(values2, (v1, v2) => (v1, v2))
            .ToArray()
            .Aggregate(true, (acc, vs) => acc && EqValue(vs.v1, vs.v2));
    }
    
    public static bool EqValueReturns(ValueReturn[] values1, ValueReturn[] values2)
    {
        return values1
            .Zip(values2, (v1, v2) => (v1, v2))
            .ToArray()
            .Aggregate(true, (acc, vs) => acc && EqValueReturn(vs.v1, vs.v2));
    }
    
    public static bool EqResultReturns(ResultReturn[] values1, ResultReturn[] values2)
    {
        return values1
            .Zip(values2, (v1, v2) => (v1, v2))
            .ToArray()
            .Aggregate(true, (acc, vs) => acc && EqResultReturn(vs.v1, vs.v2));
    }
    
    public static bool EqResults(Result[] results1, Result[] results2)
    {
        return results1
            .Zip(results2, (r1, r2) => (r1, r2))
            .ToArray()
            .Aggregate(true, (acc, vs) => acc && EqResult(vs.r1, vs.r2));
    }
}
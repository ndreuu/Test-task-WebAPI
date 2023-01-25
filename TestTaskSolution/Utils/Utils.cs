using System.Globalization;
using Microsoft.VisualBasic.FileIO;

namespace TestTaskSolution.UnitTests;

public record InputString
{
    public DateTime Date { get; init; }
    public ulong Time { get; init; }
    public double Index { get; init; }
}

public class Utils
{
    public static double GetMedian(double[] sourceNumbers) {
        if (sourceNumbers == null || sourceNumbers.Length == 0)
            throw new Exception("Median of empty array not defined.");

        double[] sortedPNumbers = (double[])sourceNumbers.Clone();
        Array.Sort(sortedPNumbers);

        var size = sortedPNumbers.Length;
        var mid = size / 2;
        var median = size % 2 != 0 ? sortedPNumbers[mid] : (sortedPNumbers[mid] + sortedPNumbers[mid - 1]) / 2;
        
        return median;
    }

    private static void addValidString(InputString inputString, List<InputString> acc)
    {
        if (inputString.Date.CompareTo(DateTime.Now) <= 0 &&
            inputString.Date.CompareTo(new DateTime(2000, 01, 01)) >= 0 &&
            inputString.Time >= 0 &&
            inputString.Index >= 0)
        {
            acc.Add(inputString);
        }
    }

    public static List<InputString> parse(Stream stream)
    {
        List<InputString> inputFields = new List<InputString>();
        using (TextFieldParser tfp = new TextFieldParser(stream))
        {
            tfp.TextFieldType = FieldType.Delimited;
            tfp.SetDelimiters(";");

            while (!tfp.EndOfData)
            {
                string[]? fields = tfp.ReadFields();
                
                if (tfp.LineNumber > 1000)
                {
                    throw new Exception("The number of rows must be less than 10k");
                }
                
                if (fields != null && fields.Length == Constants.FIELD_NUM)
                {
                    var inputString =  new InputString
                    {
                        Date = DateTime.ParseExact(fields[0], Constants.CSV_DATE_INPUT_FRMT, CultureInfo.InvariantCulture), 
                        Time = Convert.ToUInt64(fields[1]), 
                        Index = Convert.ToDouble(fields[2].Replace(',', '.'))
                    };

                    addValidString(inputString, inputFields);
                }
            }
            
            if (tfp.EndOfData && inputFields.Count == 0)
            {
                throw new Exception("Input file haven't valid strings");
            }
        }

        return inputFields;
    }
    
}
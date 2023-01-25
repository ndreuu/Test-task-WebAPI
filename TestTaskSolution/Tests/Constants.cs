using TestTaskSolution.Models;

namespace TestTaskSolution.UnitTests;

public class TestConstants
{
    public static string s2022_03_18__09_18_17s1744s1632s0 =  @"2022-03-18_09-18-17;1744;1632,0";
    public static string s2022_03_18__09_18_17s1744s1632c472 = @"2022-03-18_09-18-17;1744;1632,472";

    
    public static string EMPTY = @"";
    public static string THREE_EQ = 
        @$"{s2022_03_18__09_18_17s1744s1632c472}
          {s2022_03_18__09_18_17s1744s1632c472}
          {s2022_03_18__09_18_17s1744s1632c472}";
    public static string INVALID_THREE_SEMICOIN = @";s;s";
    public static string INVALID_EXTRA_FIELD = @$"{s2022_03_18__09_18_17s1744s1632c472};extra";
    public static string INVALID_DATE_LATE = @"3023-03-18_09-18-17;1744;1632,472";
    public static string INVALID_DATE_EARLY = @"1999-03-18_09-18-17;1744;1632,472";
    public static string TWO = 
        @$"{s2022_03_18__09_18_17s1744s1632c472}
          {s2022_03_18__09_18_17s1744s1632s0}";
    public static string THREE_ONE_VALID = 
        @$"{INVALID_DATE_LATE}
          {INVALID_DATE_LATE}
          {s2022_03_18__09_18_17s1744s1632s0}";
    
    public static Dictionary<string, Value> Instances = new Dictionary<string, Value>()
    {
        [s2022_03_18__09_18_17s1744s1632s0] = 
            new Value() 
            { 
                FileName = "test.csv", 
                Time = 1744, 
                Date = new DateTime(2022, 3, 18, 9, 18, 17), 
                Index = 1632 
            },
        [s2022_03_18__09_18_17s1744s1632c472] =
            new Value() 
            { 
                FileName = "test.csv", 
                Time = 1744, 
                Date = new DateTime(2022, 3, 18, 9, 18, 17), 
                Index = 1632.472 
            }
    };
    
    
}
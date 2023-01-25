using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTaskSolution.Controllers;
using TestTaskSolution.Data;
using TestTaskSolution.Models;
using Xunit;
using Xunit.Abstractions;

namespace TestTaskSolution.UnitTests
{
    public class UploadTest
    {
        private readonly ITestOutputHelper output;

        public UploadTest(ITestOutputHelper output)
        {
            this.output = output;
        }
        
        [Fact]
        public async Task THREE_ONE_VALID()
        {
            var option = new DbContextOptionsBuilder<APIDbContext>()
                .UseInMemoryDatabase(databaseName: "APIDb")
                .Options;
            var dbContex = new APIDbContext(option);
            var controller = new ValuesController(dbContex);
            
            var file = TestUtils.GetFileMock("test.csv", TestConstants.THREE_ONE_VALID);

            await controller.Upload(file);
            
            Value[] expectedValues = { 
                TestConstants.Instances[TestConstants.s2022_03_18__09_18_17s1744s1632s0]
            };

            Result[] expectedResults =
            {
                new Result()
                {
                    FileName = "test.csv",
                    DeltaTime = 0,
                    DateFirstOperation = new DateTime(2022, 3, 18, 9, 18, 17),
                    AvarageTime = 1744,
                    AvarageIndex = 1632,
                    MedianIndex = 1632,
                    MaxIndex = 1632,
                    MinIndex = 1632,
                    CountOfRecords = 1
                }
            };
            
            var actualValues = dbContex.Values.ToArray();
            var actualResults = dbContex.Results.ToArray();
            
            Assert.True(TestUtils.EqValues(expectedValues, actualValues) && TestUtils.EqResults(expectedResults, actualResults));   
        }
        
        [Fact]
        public async Task TWO()
        {
            var option = new DbContextOptionsBuilder<APIDbContext>()
                .UseInMemoryDatabase(databaseName: "APIDb")
                .Options;
            var dbContex = new APIDbContext(option);
            var controller = new ValuesController(dbContex);
            
            var file = TestUtils.GetFileMock("test.csv", TestConstants.TWO);

            await controller.Upload(file);
            
            Value[] expectedValues = { 
                TestConstants.Instances[TestConstants.s2022_03_18__09_18_17s1744s1632c472],
                TestConstants.Instances[TestConstants.s2022_03_18__09_18_17s1744s1632s0],
            };

            Result[] expectedResults =
            {
                new Result()
                {
                    FileName = "test.csv",
                    DeltaTime = 0,
                    DateFirstOperation = new DateTime(2022, 3, 18, 9, 18, 17),
                    AvarageTime = 1744,
                    AvarageIndex = 1632.2359999999999,
                    MedianIndex = 1632.2359999999999,
                    MaxIndex = 1632.472,
                    MinIndex = 1632,
                    CountOfRecords = 2
                }
            };
            
            var actualValues = dbContex.Values.ToArray();
            var actualResults = dbContex.Results.ToArray();
            
            Assert.True(TestUtils.EqValues(expectedValues, actualValues) && TestUtils.EqResults(expectedResults, actualResults));   
        }
        
        [Fact]
        public async Task EMPTY()
        {
            var option = new DbContextOptionsBuilder<APIDbContext>()
                .UseInMemoryDatabase(databaseName: "APIDb")
                .Options;
            var dbContex = new APIDbContext(option);
            var controller = new ValuesController(dbContex);
            
            var file = TestUtils.GetFileMock("test.csv", TestConstants.EMPTY);

            var act = async () => await controller.Upload(file);
            
            var exception = Assert.ThrowsAsync<HttpRequestException>(act);
            
            Assert.Equal("Input file haven't valid strings", exception.Result.Message);   
        }
        
        [Fact]
        public async Task THREE_EQ()
        {
            var option = new DbContextOptionsBuilder<APIDbContext>()
                .UseInMemoryDatabase(databaseName: "APIDb")
                .Options;
            var dbContex = new APIDbContext(option);
            var controller = new ValuesController(dbContex);
            
            var file = TestUtils.GetFileMock("test.csv", TestConstants.THREE_EQ);

            await controller.Upload(file);
            
            Value[] expectedValues = { 
                TestConstants.Instances[TestConstants.s2022_03_18__09_18_17s1744s1632c472],
                TestConstants.Instances[TestConstants.s2022_03_18__09_18_17s1744s1632c472],
                TestConstants.Instances[TestConstants.s2022_03_18__09_18_17s1744s1632c472]
            };
            
            var actualValues = dbContex.Values.ToArray();
            
            Assert.True(TestUtils.EqValues(expectedValues, actualValues));   
        }
        
        [Fact]
        public async Task INVALID_THREE_SEMICOIN()
        {
            var option = new DbContextOptionsBuilder<APIDbContext>()
                .UseInMemoryDatabase(databaseName: "APIDb")
                .Options;
            var dbContex = new APIDbContext(option);
            var controller = new ValuesController(dbContex);
            
            var file = TestUtils.GetFileMock("test.csv", TestConstants.INVALID_THREE_SEMICOIN);

            var act = async () => await controller.Upload(file);
            
            var exception = Assert.ThrowsAsync<HttpRequestException>(act);
            
            Assert.Equal("Wrong string format", exception.Result.Message);   
        }
        
        [Fact]
        public async Task INVALID_EXTRA_FIELD()
        {
            var option = new DbContextOptionsBuilder<APIDbContext>()
                .UseInMemoryDatabase(databaseName: "APIDb")
                .Options;
            var dbContex = new APIDbContext(option);
            var controller = new ValuesController(dbContex);
            
            var file = TestUtils.GetFileMock("test.csv", TestConstants.INVALID_EXTRA_FIELD);

            var act = async () => await controller.Upload(file);
            
            var exception = Assert.ThrowsAsync<HttpRequestException>(act);
            
            Assert.Equal("Input file haven't valid strings", exception.Result.Message);   
        }
        
        [Fact]
        public async Task INVALID_DATE_LATE()
        {
            var option = new DbContextOptionsBuilder<APIDbContext>()
                .UseInMemoryDatabase(databaseName: "APIDb")
                .Options;
            var dbContex = new APIDbContext(option);
            var controller = new ValuesController(dbContex);
            
            var file = TestUtils.GetFileMock("test.csv", TestConstants.INVALID_DATE_LATE);

            var act = async () => await controller.Upload(file);
            
            var exception = Assert.ThrowsAsync<HttpRequestException>(act);
            
            Assert.Equal("Input file haven't valid strings", exception.Result.Message);   
        }
        
        [Fact]
        public async Task INVALID_DATE_EARLY()
        {
            var option = new DbContextOptionsBuilder<APIDbContext>()
                .UseInMemoryDatabase(databaseName: "APIDb")
                .Options;
            var dbContex = new APIDbContext(option);
            var controller = new ValuesController(dbContex);
            
            var file = TestUtils.GetFileMock("test.csv", TestConstants.INVALID_DATE_EARLY);

            var act = async () => await controller.Upload(file);
            
            var exception = Assert.ThrowsAsync<HttpRequestException>(act);
            
            Assert.Equal("Input file haven't valid strings", exception.Result.Message);   
        }
    }
}
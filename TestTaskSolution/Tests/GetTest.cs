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
    public class GetTest
    {
        private readonly ITestOutputHelper output;

        public GetTest(ITestOutputHelper output)
        {
            this.output = output;
        }
        
        [Fact]
        public async Task GetResultByFileName()
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

            var jsonResult = await controller.GetValuesByFileName("test.csv") as JsonResult;


            ValueReturn[] expectedValueReturns =
            {
                new ValueReturn()
                {
                    FileName = "test.csv",
                    Time = 1744,
                    Date = new DateTime(2022, 3, 18, 9, 18, 17),
                    Index = 1632
                }
            };
            
            Assert.True(TestUtils.EqValueReturns(jsonResult.Value as ValueReturn[], expectedValueReturns));
        }
        
        [Fact]
        public async Task GetResultByFileNameException()
        {
            var option = new DbContextOptionsBuilder<APIDbContext>()
                .UseInMemoryDatabase(databaseName: "APIDb")
                .Options;
            var dbContex = new APIDbContext(option);
            var controller = new ValuesController(dbContex);
            
            var file = TestUtils.GetFileMock("test.csv", TestConstants.THREE_ONE_VALID);

            await controller.Upload(file);
            
            var jsonResult = await controller.GetValuesByFileName("err.csv") as NotFoundResult;
            
            Assert.True(jsonResult.StatusCode == 404);
        }
        
        [Fact]
        public async Task GetResultsByDateFirstOperation()
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

            var jsonResult = await controller.GetResultsByDateFirstOperation(
                new DateTime(2022, 3, 18, 9, 18, 17), 
                new DateTime(2022, 3, 18, 9, 18, 17)) as JsonResult;


            ResultReturn[] expectedResultReturns =
            {
                new ResultReturn()
                {
                    FileName = "test.csv",
                    DeltaTime = 0,
                    DateFirstOperation = new DateTime(2022, 3, 18, 9, 18, 17),
                    AvarageTime = 1744,
                    AvarageIndex = 1632,
                    MedianIndex = 1632,
                    MaxIndex = 1632,
                    MinIndex = 1632,
                    CountOfRecords = 1,
                }
            };
            
            Assert.True(TestUtils.EqResultReturns(jsonResult.Value as ResultReturn[], expectedResultReturns));
        }
        
        [Fact]
        public async Task GetResultsByDateFirstOperationExtension()
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

            var jsonResult = await controller.GetResultsByDateFirstOperation(
                new DateTime(2020, 3, 18, 9, 18, 17), 
                new DateTime(2020, 3, 18, 9, 18, 17)) as NotFoundResult;


            Assert.True(jsonResult.StatusCode == 404);
        }
        
        [Fact]
        public async Task GetResultsByAvarageTime()
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

            var jsonResult = await controller.GetResultsByAvarageTime(1744, 1744) as JsonResult;


            ResultReturn[] expectedResultReturns =
            {
                new ResultReturn()
                {
                    FileName = "test.csv",
                    DeltaTime = 0,
                    DateFirstOperation = new DateTime(2022, 3, 18, 9, 18, 17),
                    AvarageTime = 1744,
                    AvarageIndex = 1632,
                    MedianIndex = 1632,
                    MaxIndex = 1632,
                    MinIndex = 1632,
                    CountOfRecords = 1,
                }
            };
            
            Assert.True(TestUtils.EqResultReturns(jsonResult.Value as ResultReturn[], expectedResultReturns));
        }
        
        [Fact]
        public async Task GetResultsByAvarageTimeException()
        {
            var option = new DbContextOptionsBuilder<APIDbContext>()
                .UseInMemoryDatabase(databaseName: "APIDb")
                .Options;
            var dbContex = new APIDbContext(option);
            var controller = new ValuesController(dbContex);
            
            var file = TestUtils.GetFileMock("test.csv", TestConstants.THREE_ONE_VALID);

            await controller.Upload(file);
            
            var jsonResult = await controller.GetResultsByAvarageTime(17, 17) as NotFoundResult;

            Assert.True(jsonResult.StatusCode == 404);
        }
        
        [Fact]
        public async Task GetValuesByFileName()
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

            var jsonResult = await controller.GetValuesByFileName("test.csv") as JsonResult;


            ValueReturn[] expectedValueReturns =
            {
                new ValueReturn()
                {
                    FileName = "test.csv",
                    Time = 1744,
                    Date = new DateTime(2022, 3, 18, 9, 18, 17),
                    Index = 1632
                }
            };
            
            Assert.True(TestUtils.EqValueReturns(jsonResult.Value as ValueReturn[], expectedValueReturns));
        }
        
        [Fact]
        public async Task GetValuesByFileNameException()
        {
            var option = new DbContextOptionsBuilder<APIDbContext>()
                .UseInMemoryDatabase(databaseName: "APIDb")
                .Options;
            var dbContex = new APIDbContext(option);
            var controller = new ValuesController(dbContex);
            
            var file = TestUtils.GetFileMock("test.csv", TestConstants.THREE_ONE_VALID);

            await controller.Upload(file);
            
            var jsonResult = await controller.GetValuesByFileName("err.csv") as NotFoundResult;

            Assert.True(jsonResult.StatusCode == 404);
        }
        
    }
}
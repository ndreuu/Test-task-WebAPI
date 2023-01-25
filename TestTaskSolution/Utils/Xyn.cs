using System.Globalization;
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
    public class PlayGround
    {
        private readonly ITestOutputHelper output;

        public PlayGround(ITestOutputHelper output)
        {
            this.output = output;
        }

        private IFormFile GetFileMock(string filename, string content)
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
        
        [Fact]
        public async Task GetAuthorByIdAsync_Success_Test()
        {
            var option = new DbContextOptionsBuilder<APIDbContext>()
                .UseInMemoryDatabase(databaseName: "APIDb")
                .Options;
            var dbContex = new APIDbContext(option);
            var controller = new ValuesController(dbContex);


            var file = GetFileMock("dummy.csv", 
                @"2022-03-18_09-18-17;1744;1632,472
                        2022-03-18_09-18-17;1744;1632,472
                        2022-03-18_09-18-17;1744;1632,472
                        2022-03-18_09-18-17;1744;1632,472
                        2022-03-18_09-18-17;1744;1632,472
                        2022-03-18_09-18-17;1744;1632,472
                        2022-03-18_09-18-17;1744;1632,472");

            //Act
            var result = await controller.Upload(file);
            
            foreach (var value in dbContex.Values.ToArray())
            {
                output.WriteLine(value.FileName);
                
            }
            
            //Assert
            Assert.Equal(1 , 1);
            
            
            // controller.Upload(new FormFile("fsd"));


            // var option = new DbContextOptionsBuilder<APIDbContext>()
            //     .UseInMemoryDatabase(databaseName: "APIDb")
            //     .Options;
            // var dbContex = new APIDbContext(option);
            // var controller = new ValuesController(dbContex);
            //
            // var stream = new MemoryStream();
            // var fileName = "SolutionTestTask/TestTaskSolution/Utils/tst.csv";
            // var file = new FormFile(stream, 0, stream.Length, "", fileName);
            //
            //
            //
            // var values = controller.Upload(file);
            //
            // // values.Result.ToString();
            // Assert.Equal(file.Name, "sd");
            // var aaa = dbContex.Result.ToArray();

            // Assert.Equal(aaa.Length, 123);

            // Assert.True(Enumerable.SequenceEqual(new Result[] {new Result{Id = Guid.Empty}}, dbContex.Result.ToArray()));
        }
        
        


        
        [Fact]
        public void playGround()
        {
            var dateTime = DateTime.ParseExact("2022-03-18_09-18-17","yyyy-MM-dd_hh-mm-ss",
                CultureInfo.InvariantCulture);
            Assert.Equal(1, 1);
        }
        
        [Fact]
        public void playGroundsdf()
        {
            var dateTime = DateTime.ParseExact("2022-03-18_09-18-17","yyyy-MM-dd_hh-mm-ss",
                CultureInfo.InvariantCulture);
            double[] aa = {1.1,1.1,2.2,4.5}; 
            var a = Utils.GetMedian(aa);
            Console.WriteLine("a");
            Console.WriteLine(a.ToString());
            Assert.Equal(1, 1);
        }

        [Fact]
        public void playGroundsdfs()
        {
            // Upload()            
            Assert.Equal(1, 1);
        }

    }
}
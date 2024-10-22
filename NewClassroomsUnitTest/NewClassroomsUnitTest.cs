using NewClassroomsTrial.Dtos;
using NewClassroomsTrial.Controllers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace NewClassroomsUnitTest
{
    [TestClass]
    public class NewClassroomsUnitTest
    {
        private UserController _userController;

        [TestInitialize]
        public void Setup()
        {
            _userController = new UserController();
        }

        [TestMethod]
        public void TestTxtFormat()
        {
            string filePath = "TestDataTxt.json";
            using(StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                UserStatisticsDto userStatistics = JsonConvert.DeserializeObject<UserStatisticsDto>(json);
                var result = _userController.GenerateStatistics(userStatistics);

                Assert.IsNotNull(result);
                var fileResult = result as FileResult;
                Assert.IsNotNull(fileResult);
                Assert.AreEqual("statistics.txt", fileResult.FileDownloadName);
            }
            
        }

        [TestMethod]
        public void TestJsonFormat()
        {
            string filePath = "TestDataJson.json";
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                UserStatisticsDto userStatistics = JsonConvert.DeserializeObject<UserStatisticsDto>(json);
                var result = _userController.GenerateStatistics(userStatistics);

                Assert.IsNotNull(result);
                var fileResult = result as FileResult;
                Assert.IsNotNull(fileResult);
                Assert.AreEqual("statistics.json", fileResult.FileDownloadName);
            }

        }

        [TestMethod]
        public void TestXmlFormat()
        {
            string filePath = "TestDataXml.json";
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                UserStatisticsDto userStatistics = JsonConvert.DeserializeObject<UserStatisticsDto>(json);
                var result = _userController.GenerateStatistics(userStatistics);

                Assert.IsNotNull(result);
                var fileResult = result as FileResult;
                Assert.IsNotNull(fileResult);
                Assert.AreEqual("statistics.xml", fileResult.FileDownloadName);
            }

        }
    }
}
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySingingBird.Core.Map;

namespace MySingingBird.Tests
{
    [TestClass]
    public class MapUserTest
    {
        private string twitterUserJson;
        private MapUser _target;
        [TestInitialize]
        public void Setup()
        {
            string path = @"C:\Users\stevenmo\Documents\Visual Studio 2010\Projects\MySingingBird\MySingingBird.Tests\twitterUser.txt";
            twitterUserJson = File.ReadAllText(path);
            _target = new MapUser();
        }

        [TestMethod]
        public void ShouldBeAbleToParseJson()
        {
            var result = _target.MapProfileInfo(twitterUserJson);

            Assert.IsNotNull(result);
        }

        
    }
}

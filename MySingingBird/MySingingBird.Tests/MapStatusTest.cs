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
    public class MapStatusTest
    {
        public MapStatus _target;

        [TestInitialize]
        public void Setup()
        {
            _target = new MapStatus();
        }

        [TestMethod]
        public void Should_be_able_to_map_status_json_to_status_entitiy()
        {
            string path = @"C:\Users\stevenmo\Documents\Visual Studio 2010\Projects\MySingingBird\MySingingBird.Tests\user_timeline.txt";
            string jsonResponse = File.ReadAllText(path);
            var result = _target.Map(jsonResponse);
            Assert.IsNotNull(result);
        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySingingBird.Core.Services;

namespace MySingingBird.Tests
{
    [TestClass]
    public class OauthCreationTest
    {
        private OAuthCreationService _target;
 
        [TestInitialize]
        public void Setup()
        {
            _target = new OAuthCreationService();
        }
        [TestMethod]
        public void should_be_able_to_create_signature()
        {
            string expected = "fxZo3Gai+F3g6hMF0U3132MG4HI=";

            string url = "https://api.twitter.com/1/users/lookup.json";
            string result = _target.CreateSignature(url);

            Assert.AreEqual(expected,result);
        }
    }
}

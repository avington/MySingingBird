using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySingingBird.Core.Entities;
using MySingingBird.Core.Services;
using Rhino.Mocks;

namespace MySingingBird.Tests
{
    [TestClass]
    public class AnalyzeStatusesServiceTest
    {
        private AnalyzeStatusesService _target;
        private IMathService _analysis;

        [TestInitialize]
        public void Setup()
        {
            _analysis = MockRepository.GenerateMock<IMathService>();
            _target = new AnalyzeStatusesService(_analysis);
        }
        
        [TestMethod]
        public void When_a_list_of_twitter_status_provided_should_be_able_anylize_response()
        {
            IList<TwitterStatusItem> response = BuildValidResponse();
            _analysis.Expect(x => x.CalculatePercent(4, 7)).Return(.50m);
            var result = _target.Anylize(response);
            Assert.IsNotNull(result);
            Assert.AreEqual(.50m,result.PercentReplies);
            Assert.AreEqual("50.0 %",result.PercentRepliesFormatted);
        }


        private IList<TwitterStatusItem> BuildValidResponse()
        {
            return new List<TwitterStatusItem>
                       {
                           new TwitterStatusItem
                               {
                                   InReplyToName = "rawlesmarie",
                                   Retweeted = false,
                                   Text = "@rawlesmarie lol I'm very easy to beat, I suck at that game! Only good at putting playlists together apparently :P"
                               },
                               new TwitterStatusItem
                               {
       
                                   Retweeted = false,
                                   Text = "lol I'm very easy to beat, I suck at that game! Only good at putting playlists together apparently :P"
                               },
                               new TwitterStatusItem
                               {
                                   InReplyToName = "rawlesmarie",
                                   Retweeted = false,
                                   Text = "@rawlesmarie lol I'm very easy to beat, I suck at that game! Only good at putting playlists together apparently :P"
                               },
                               new TwitterStatusItem
                               {

                                   Retweeted = false,
                                   Text = "lol I'm very easy to beat, I suck at that game! Only good at putting playlists together apparently :P"
                               },
                               new TwitterStatusItem
                               {
                                   InReplyToName = "rawlesmarie",
                                   Retweeted = false,
                                   Text = "@rawlesmarie lol I'm very easy to beat, I suck at that game! Only good at putting playlists together apparently :P"
                               },
                               new TwitterStatusItem
                               {

                                   Retweeted = true,
                                   Text = "@rawlesmarie lol I'm very easy to beat, I suck at that game! Only good at putting playlists together apparently :P"
                               },
                               new TwitterStatusItem
                               {
                                   InReplyToName = "rawlesmarie",
                                   Retweeted = false,
                                   Text = "@rawlesmarie lol I'm very easy to beat, I suck at that game! Only good at putting playlists together apparently :P"
                               },
                       };
        }
    }
}

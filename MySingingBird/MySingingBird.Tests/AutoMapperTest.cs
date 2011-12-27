using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySingingBird.Core.Entities;
using MySingingBird.Core.Map;
using MySingingBird.Core.ViewModel;

namespace MySingingBird.Tests
{
    [TestClass]
    public class AutoMapperTest
    {
        [TestMethod]
        public void Should_be_able_to_map_search_request_object_to_view_data()
        {
            var task = new AutoMapperTask();
            task.Execute();

            var src = new SearchRequest
                                    {
                                        GeoInfoCode =
                                            new GeoInfo {Latitude = "100", Longitude = "100", RadiusMiles = 10},
                                        Q = "#usguys",
                                        ShowUser = true,
                                        ResultType = "json",
                                        Until = new DateTime(2000, 1, 1)
                                    };
            var item = Mapper.Map<SearchRequest, TwitterSearchViewModel>(src);
            Assert.IsNotNull(item);
            Assert.AreEqual("#usguys",item.Q);
            Assert.AreEqual("100",item.Latitude);
        }

        [TestMethod]
        public void Should_be_able_to_map_view_model_to_request()
        {
            var task = new AutoMapperTask();
            task.Execute();

            var src = new TwitterSearchViewModel
                          {
                              Latitude = "90",
                              Longitude = "80",
                              Q = "#usguys",
                              Until = new DateTime(2000, 2, 2),
                              ResultType = "json",
                              RadiusMiles = 99,
                              ShowUser = true,
                          };

            var item = Mapper.Map<TwitterSearchViewModel, SearchRequest>(src);
            item.GeoInfoCode = new GeoInfo();
            item.GeoInfoCode = Mapper.Map<TwitterSearchViewModel, GeoInfo>(src);
            Assert.IsNotNull(item);
            Assert.AreEqual("90",item.GeoInfoCode.Latitude);
        }
    }
}

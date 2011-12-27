using AutoMapper;
using MySingingBird.Core.Entities;
using MySingingBird.Core.ViewModel;

namespace MySingingBird.Core.Map
{
    public class SearchResponseProfile : Profile
    {
        public override string ProfileName
        {
            get { return "SearchResponseProfile"; }
        }
        protected override void Configure()
        {
            CreateMap<TwitterSearchViewModel, SearchRequest>();
            CreateMap<TwitterSearchViewModel, GeoInfo>();
            
        }

        private IMappingExpression<TwitterSearchViewModel, GeoInfo> MapGeoCode(TwitterSearchViewModel src)
        {
            return CreateMap<TwitterSearchViewModel, GeoInfo>();
        }
    }
}
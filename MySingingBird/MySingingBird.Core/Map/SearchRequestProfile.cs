using AutoMapper;
using MySingingBird.Core.Entities;
using MySingingBird.Core.Helpers;
using MySingingBird.Core.ViewModel;

namespace MySingingBird.Core.Map
{
    public class SearchRequestProfile : Profile
    {
        public override string ProfileName
        {
            get { return "SearchRequestProfile"; }
        }
        protected override void Configure()
        {
            CreateMap<SearchRequest, TwitterSearchViewModel>()
                .ForMember(dest => dest.Latitude, option => option.MapFrom(src => src.GeoInfoCode.With(x => x.Latitude)))
                .ForMember(dest => dest.Longitude,option => option.MapFrom(src => src.GeoInfoCode.With(x => x.Longitude)))
                .ForMember(dest => dest.RadiusMiles, option => option.MapFrom(src => src.GeoInfoCode ==null ? 0 : src.GeoInfoCode.RadiusMiles));

        }
    }
}
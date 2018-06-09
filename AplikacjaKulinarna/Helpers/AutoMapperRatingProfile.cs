using AplikacjaKulinarna.Data.DbModels;
using AplikacjaKulinarna.Data.ModelsDto.Rating;
using AutoMapper;

namespace AplikacjaKulinarna.API.Helpers
{
    public class AutoMapperRatingProfile : Profile
    {
        public AutoMapperRatingProfile()
        {
            CreateMap<SaveRatingDto, Rating>();
            CreateMap<Rating, RatingDto>();
        }
    }
}
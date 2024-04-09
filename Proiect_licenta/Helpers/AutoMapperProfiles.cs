using AutoMapper;
using Disertatie_backend.DTO;
using Disertatie_backend.DTO.Anime;
using Disertatie_backend.DTO.Movies;
using Disertatie_backend.Entities;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Entities.Movies;
using Disertatie_backend.Extensions;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Disertatie_backend.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src =>
                    src.ProfilePicture.Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src =>
                    src.DateOfBirth.CalculateAge()));

            CreateMap<IFindFluent<AppUser, AppUser>, List<MemberDto>>().ReverseMap();
            CreateMap<MemberDto, MemberDto>().ReverseMap();

            CreateMap<Photo, PhotoDto>().ReverseMap();

            CreateMap<MemberUpdateDto, AppUser>().ReverseMap();

            CreateMap<RegisterDto, AppUser>().ReverseMap();

            CreateMap<Message, MessageDto>()
                .ForMember(dest => dest.SenderPhotoUrl, opt => opt.MapFrom(src =>
                    src.Sender.ProfilePicture.Url))
                .ForMember(dest => dest.RecipientPhotoUrl, opt => opt.MapFrom(src =>
                    src.Recipient.ProfilePicture.Url)).ReverseMap();

            CreateMap<MovieItem, Movie>().ReverseMap();

            CreateMap<Movie, MovieItem>().ReverseMap();

            CreateMap<Movie, MovieCard>().ReverseMap();

            CreateMap<Datum, AnimeCard>().ReverseMap();
        }
    }
}

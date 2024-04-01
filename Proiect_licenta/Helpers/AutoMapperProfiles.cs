using AutoMapper;
using Disertatie_backend.DTO;
using Disertatie_backend.DTO.Movies;
using Disertatie_backend.Entities;
using Disertatie_backend.Entities.Movies;
using Disertatie_backend.Extensions;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

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

            CreateMap<IFindFluent<AppUser, IQueryable>, List<MemberDto>>().ReverseMap();
            CreateMap<MemberDto, MemberDto>().ReverseMap();

            CreateMap<Photo, PhotoDto>();

            CreateMap<MemberUpdateDto, AppUser>();

            CreateMap<RegisterDto, AppUser>();

            CreateMap<Message, MessageDto>()
                .ForMember(dest => dest.SenderPhotoUrl, opt => opt.MapFrom(src =>
                    src.Sender.ProfilePicture.Url))
                .ForMember(dest => dest.RecipientPhotoUrl, opt => opt.MapFrom(src =>
                    src.Recipient.ProfilePicture.Url));

            CreateMap<MovieItem, MovieItem>();
            CreateMap<Movie, Movie>();

            CreateMap<Movie, MovieItem>();
            CreateMap<MovieItem, Movie>();

            CreateMap<Movie, MovieCard>();
            CreateMap<MovieCard, Movie>();
        }
    }
}

using AutoMapper;
using Proiect_licenta.DTO;
using Proiect_licenta.DTO.Movies;
using Proiect_licenta.Entities;
using Proiect_licenta.Entities.Movies;
using Proiect_licenta.Extensions;

namespace Proiect_licenta.Helpers
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
            CreateMap<Photo, PhotoDto>();

            CreateMap<MemberUpdateDto, AppUser>();

            CreateMap<RegisterDto, AppUser>();

            CreateMap<Message, MessageDto>()
                .ForMember(dest => dest.SenderPhotoUrl, opt => opt.MapFrom(src =>
                    src.Sender.ProfilePicture.Url))
                .ForMember(dest => dest.RecipientPhotoUrl, opt => opt.MapFrom(src =>
                    src.Recipient.ProfilePicture.Url));

            //CreateMap<DateTime, DateTime>().ConvertUsing(d => DateTime.SpecifyKind(d, DateTimeKind.Utc));

            CreateMap<MovieItem, MovieItem>();
            CreateMap<Movie, Movie>();

            CreateMap<Movie, MovieItem>();
            CreateMap<MovieItem, Movie>();

            CreateMap<Movie, MovieCard>();
            CreateMap<MovieCard, Movie>();
        }
    }
}

namespace GuessTheNumber.Core.MappingProfiles
{
    using AutoMapper;
    using GuessTheNumber.Core.DTO;
    using GuessTheNumber.DAL.Entities;
    using Microsoft.AspNetCore.Identity;

    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameModel>()
                .ForMember(dest => dest.GameId, opt => opt.MapFrom(src => src.GameId))
                .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.GameDate))
                .ForMember(dest => dest.GameWinnerId, opt => opt.MapFrom(src => src.GameWinnerId));

            CreateMap<IdentityUser, GameModel>()
                .ForMember(dest => dest.PlayerId, opt => opt.MapFrom(src => src.Id));

            CreateMap<Game, HistoryModel>()
                .ForMember(dest => dest.ListOfAttempts, opt => opt.MapFrom(src => src.Attempts));

            CreateMap<Attempt, ListOfAttempt>()
                .ForMember(dest => dest.GameId, opt => opt.MapFrom(src => src.GameId))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time));
            CreateMap<IdentityUser, ListOfAttempt>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));

            CreateMap<Game, AllGamesHistoryModel>()
                .ForMember(dest => dest.ListOfAttempts, opt => opt.MapFrom(src => src.Attempts));
        }
    }
}
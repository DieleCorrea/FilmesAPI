using ApiFilme.Data.Dtos;
using ApiFilme.Models;
using AutoMapper;

namespace ApiFilme.Profiles
{
    public class CinemaProfile: Profile
    {
        public CinemaProfile()
        {
                CreateMap<CreateCinemaDto, Cinema>();
                CreateMap<Cinema, ReadCinemaDto>();
                CreateMap<UpdateCinemaDto, Cinema>();
        }
    }
}

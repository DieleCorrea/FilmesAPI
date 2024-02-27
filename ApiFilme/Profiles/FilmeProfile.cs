using ApiFilme.Data.Dtos;
using ApiFilme.Models;
using AutoMapper;

namespace ApiFilme.Profiles
{
    public class FilmeProfile : Profile//profile extendo automapper 
    {
        //Aqui eu digo para o automapper o mapeamento possivel de um CreateFilmeDto para um Filme 
        public FilmeProfile()
        {
                CreateMap<CreateFilmeDto, Filme>();
                CreateMap<UpdateFilmeDto, Filme>();
                CreateMap<Filme, UpdateFilmeDto>();
                CreateMap<Filme, ReadFilmeDto>();
        }
    }
}

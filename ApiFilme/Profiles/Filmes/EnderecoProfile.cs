using ApiFilme.Data.Dtos.Filmes;
using ApiFilme.Models.Flmes;
using AutoMapper;

namespace ApiFilme.Profiles.Filmes
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>();
            CreateMap<UpdateEnderecoDto, Endereco>();
        }
    }
}

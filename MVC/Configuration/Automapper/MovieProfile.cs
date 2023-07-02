using ASPNETCORE.Data;
using AutoMapper;
using RazorPages.Viewmodel;

namespace ASPNETCORE.MVC.Configuration.Automapper;
public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<MovieViewmodel, Movie>().ReverseMap();
    }
}
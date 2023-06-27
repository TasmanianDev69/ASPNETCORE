using ASPNETCORE.Data;
using AutoMapper;
using RazorPages.Viewmodel;

namespace ASPNETCORE.RazorPages.Configuration.Automapper;
public class MovieProfile :Profile
{
    public MovieProfile()
    {
            CreateMap<MovieViewmodel,Movie>().ReverseMap();
    }
}
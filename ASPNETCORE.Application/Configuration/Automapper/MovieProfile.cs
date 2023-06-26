using ASPNETCORE.Logic.Models;
using AutoMapper;

namespace ASPNETCORE.Logic.Configuration.Automapper;
public class MovieProfile :Profile
{
    public MovieProfile()
    {
            CreateMap<Movie,MovieProfile>().ReverseMap();
    }
}
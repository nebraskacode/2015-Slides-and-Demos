using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using MovieFanatic.Domain.Model;
using MovieFanatic.Web.Models;

namespace MovieFanatic.Web.Infrastructure.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            Mapper.CreateMap<Movie, MovieIndexViewModel.Movie>()
                .ForMember(model => model.Genres, opt => opt.MapFrom(movie => movie.MovieGenres.Select(mg => mg.Genre.Name)))
                .ForMember(model => model.Actors, opt => opt.MapFrom(movie => movie.Characters.Select(ch => ch.Actor.Name)));

            Mapper.CreateMap<Movie, MovieDetailViewModel>()
                .ForMember(model => model.Statuses, opt => opt.Ignore());

            Mapper.CreateMap<MovieStatus, SelectListItem>()
                .ForMember(model => model.Text, opt => opt.MapFrom(stat => stat.Status))
                .ForMember(model => model.Value, opt => opt.MapFrom(stat => stat.Id.ToString()))
                .ForMember(model => model.Selected, opt => opt.Ignore());
        }
    }
}
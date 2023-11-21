using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webAPI.Data;
using webAPI.Dto;
using webAPI.Interfaces;
using webAPI.Models;

namespace webAPI.Controllers
{

    public class MoviesController : BaseController
    {
      private readonly IMapper mapper;
      private readonly IUnitOfWork uow;
        public MoviesController(IMapper mapper, IUnitOfWork uow)
        {
          this.mapper = mapper;
          this.uow=uow;

        }

        [HttpGet("")]
        public async Task<IActionResult> GetMovies()
        {
            var movies= await uow.MoviesRepository.GetMoviesAsync();

            var moviesDto = movies.Select(movie =>
            {
                var movieDto = mapper.Map<MoviesDto>(movie);
                return movieDto;
            }).ToList();
            return Ok(moviesDto);
        }

        [HttpPost("")]
        public async Task <IActionResult> PostLocations([FromBody] LocationHelper ReqObj)
        {
              var tids= await uow.TheaterRepository.FindTheaterIDs(ReqObj.locations);
              var movieIds= await uow.TMmapperRepository.FindMovieIDs(tids);
              var movieData=await uow.MoviesRepository.FindMoviesList(movieIds);
              return Ok(movieData);
            
        }

    }
}

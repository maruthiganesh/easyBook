using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webAPI.Dto;
using webAPI.Interfaces;

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

    }
}

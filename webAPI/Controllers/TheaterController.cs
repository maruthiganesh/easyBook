using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webAPI.Data.Interfaces;
using webAPI.Dto;
using webAPI.Interfaces;
using AutoMapper;

namespace webAPI.Controllers
{

    public class TheaterController : BaseController
    {
      private readonly IMapper mapper;
      private readonly IUnitOfWork uow;
        public TheaterController(IMapper mapper, IUnitOfWork uow)
        {
          this.mapper = mapper;
          this.uow=uow;

        }

        [HttpGet("")]
        public async Task<IActionResult> GetTheaters()
        {
            var theaters= await uow.TheaterRepository.GetTheatersAsync();
            var theaterDto= from t in theaters
                select new TheaterDto(){
                  Theater_id=t.Theater_id,
                  Theater_name= t.Theater_name,
                  // Screen_ids=t.Screen_ids,
                  Theater_location=t.Theater_location
                  // Movies=t.Movies
                };
            return Ok(theaterDto);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateTheaters(int id,TheaterDto theaterDto){
          var theaterFromDb=await uow.TheaterRepository.FindTheater(id);
          mapper.Map(theaterDto,theaterFromDb);
          await uow.SaveAsync();
          return StatusCode(200);

        }


    }
}

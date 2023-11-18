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

    public class ShowsController : BaseController
    {
        private readonly IMapper mapper;
      private readonly IUnitOfWork uow;
        public ShowsController(IMapper mapper, IUnitOfWork uow)
        {
          this.mapper = mapper;
          this.uow=uow;

        }

        [HttpGet("")]
        public async Task<IActionResult> GetShows()
        {
            var shows= await uow.ShowsRepository.GetShowsAsync();

            var ShowsDto = shows.Select(Show =>
            {
                var ShowDto = mapper.Map<ShowsDto>(Show);
                return ShowDto;
            }).ToList();
            return Ok(ShowsDto);
        }

    }
}

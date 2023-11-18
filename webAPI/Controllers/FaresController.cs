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

    public class FaresController : BaseController
    {
        private readonly IMapper mapper;
      private readonly IUnitOfWork uow;
        public FaresController(IMapper mapper, IUnitOfWork uow)
        {
          this.mapper = mapper;
          this.uow=uow;

        }

        [HttpGet("")]
        public async Task<IActionResult> GetFares()
        {
            var fares= await uow.FaresRepository.GetFaresAsync();

            var faresDto = fares.Select(fare =>
            {
                var fareDto = mapper.Map<FaresDto>(fare);
                return fareDto;
            }).ToList();
            return Ok(faresDto);
        }

    }
}

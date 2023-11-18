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

    public class SSmapperController : BaseController
    {
        private readonly IMapper mapper;
      private readonly IUnitOfWork uow;
        public SSmapperController(IMapper mapper, IUnitOfWork uow)
        {
          this.mapper = mapper;
          this.uow=uow;

        }

        [HttpGet("")]
        public async Task<IActionResult> GetSSmapper()
        {
            var SSmapper= await uow.SSmapperRepository.GetSSmapperAsync();

            var SSmapperDto = SSmapper.Select(SSmapper =>
            {
                var ssmapperDto = mapper.Map<SSmapperDto>(SSmapper);
                return ssmapperDto;
            }).ToList();
            return Ok(SSmapperDto);
        }

    }
}

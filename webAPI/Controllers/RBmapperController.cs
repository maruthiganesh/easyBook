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

    public class RBmapperController : BaseController
    {
        private readonly IMapper mapper;
      private readonly IUnitOfWork uow;
        public RBmapperController(IMapper mapper, IUnitOfWork uow)
        {
          this.mapper = mapper;
          this.uow=uow;

        }

        [HttpGet("")]
        public async Task<IActionResult> GetRBmapper()
        {
            var Rbm= await uow.RBmapperRepository.GetRBmapperAsync();

            var RbmDto = Rbm.Select(r =>
            {
                var rDto = mapper.Map<RBmapperDto>(r);
                return rDto;
            }).ToList();
            return Ok(RbmDto);
        }

    }
}

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

    public class ScreensController : BaseController
    {
        private readonly IMapper mapper;
      private readonly IUnitOfWork uow;
        public ScreensController(IMapper mapper, IUnitOfWork uow)
        {
          this.mapper = mapper;
          this.uow=uow;

        }

        [HttpGet("")]
        public async Task<IActionResult> GetScreens()
        {
            var screens= await uow.ScreensRepository.GetScreensAsync();

            var ScreensDto = screens.Select(Screen =>
            {
                var ScreenDto = mapper.Map<ScreensDto>(Screen);
                return ScreenDto;
            }).ToList();
            return Ok(ScreensDto);
        }

    }
}

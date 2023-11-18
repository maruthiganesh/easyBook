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

    public class ReservationsController : BaseController
    {
      private readonly IMapper mapper;
      private readonly IUnitOfWork uow;
        public ReservationsController(IMapper mapper, IUnitOfWork uow)
        {
          this.mapper = mapper;
          this.uow=uow;

        }

        [HttpGet("")]
        public async Task<IActionResult> GetReservations()
        {
            var Reser= await uow.ReservationsRepository.GetReservationsAsync();

            var ReserDto = Reser.Select(r =>
            {
                var ReDto = mapper.Map<ReservationsDto>(r);
                return ReDto;
            }).ToList();
            return Ok(ReserDto);
        }

    }
}

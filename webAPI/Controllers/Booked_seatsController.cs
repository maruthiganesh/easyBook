using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webAPI.Dto;
using webAPI.Interfaces;
using webAPI.Models;

namespace webAPI.Controllers
{

    public class Booked_seatsController : BaseController
    {
      private readonly IMapper mapper;
      private readonly IUnitOfWork uow;
        public Booked_seatsController(IMapper mapper, IUnitOfWork uow)
        {
          this.mapper = mapper;
          this.uow=uow;

        }

        [HttpGet("")]
        public async Task<IActionResult> GetBooked_seats()
        {
            var seats= await uow.Booked_seatsRepository.GetBooked_seatsAsync();

            var booked_seatsDto = seats.Select(s =>
            {
                var sDto = mapper.Map<Booked_seatsDto>(s);
                return sDto;
            }).ToList();
            return Ok(booked_seatsDto);
        }


    }
}

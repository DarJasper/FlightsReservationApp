using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightsApp.API.DTO_s;
using FlightsApp.API.ModelMapping;
using FlightsApp.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FlightsApp.API.Controllers
{
    public class FlightsAppController : ControllerBase
    {
        private IFlightsRepository _FlightsAppRepo;
        public FlightsAppController(IFlightsRepository flightRepository)
        {
            _FlightsAppRepo = flightRepository;
        }


        [Route("api/Flights")]
        public async Task<List<Flights_DTO>> GetAllFlights()
        {
            //var model = await _FlightsAppRepo.GetAllFlightsAsync();
            var model = await _FlightsAppRepo.GetAllFlightsAsync();
            List<Flights_DTO> model_DTO = new List<Flights_DTO>();
            //Hier is DTO <-> Entity mapping noodzakelijk
            model_DTO = FlightsMapper.ConvertFlightstoDTO(model, ref model_DTO);

            return model_DTO;
        }
    }
}
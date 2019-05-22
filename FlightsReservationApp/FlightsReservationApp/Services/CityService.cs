using FlightsReservationApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlightsReservationApp.Services
{
    public class CityService : ICityService
    {
        private readonly ICitiesRepository _repo;

        public CityService(ICitiesRepository cityrepo)
        {
            _repo = cityrepo;
        }

        public string GetImage(string city)
        {

            string img = Task.Run(() => _repo.GetAirportImage(city)).Result;
            return img;
        }
    }
}

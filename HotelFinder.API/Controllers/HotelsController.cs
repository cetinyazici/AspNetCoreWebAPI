using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns>List of hotels</returns>
        [HttpGet]
        public List<Hotel> GetHotels()
        {
            return _hotelService.GetAllHotels();
        }

        /// <summary>
        /// Get a hotel by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Hotel GetHotelById(int id)
        {
            return _hotelService.GetHotelById(id);
        }

        /// <summary>
        /// Create a new hotel.
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        public Hotel CreateHotel([FromBody] Hotel hotel)
        {
            return _hotelService.CreateHotel(hotel);
        }

        /// <summary>
        /// Update an existing hotel.
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        public Hotel UpdateHotel([FromBody] Hotel hotel)
        {
            return _hotelService.UpdateHotel(hotel);
        }

        /// <summary>
        /// Delete a hotel by its ID.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void DeleteHotel(int id)
        {
            _hotelService.DeleteHotelById(id);
        }
    }
}

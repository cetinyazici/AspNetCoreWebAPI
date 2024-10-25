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
        public async Task<IActionResult> GetHotels()
        {
            var hotels = await _hotelService.GetAllHotels();
            return Ok(hotels); //200 + data
        }

        /// <summary>
        /// Get a hotel by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetHotelById(int id)
        {
            var hotel = _hotelService.GetHotelById(id);
            if (hotel is not null)
            {
                return Ok(hotel); //200 + data
            }
            return NotFound();
        }

        /// <summary>
        /// Get a hotel by its Name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{name}")]
        public IActionResult GetHotelByName(string name)
        {
            var hotelName = _hotelService.GetHotelByName(name);
            if (hotelName is not null)
            {
                return Ok(hotelName);
            }
            return BadRequest();

        }

        /// <summary>
        /// Get a hotel by its Name or ID.
        /// </summary>
        /// <param name="name">The name of the hotel</param>
        /// <param name="id">The ID of the hotel</param>
        /// <returns>A hotel matching the name or ID</returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetHotelByNameOrId(string? name, int? id)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var hotelByName = _hotelService.GetHotelByName(name);
                if (hotelByName != null)
                {
                    return Ok(hotelByName);
                }
            }
            if (id.HasValue)
            {
                var hotelById = _hotelService.GetHotelById(id.Value);
                if (hotelById != null)
                {
                    return Ok(hotelById);
                }
            }
            return NotFound("No hotel found with the provided name or ID.");
        }

        /// <summary>
        /// Create a new hotel.
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateHotel([FromBody] Hotel hotel)
        {
            var createdHotel = _hotelService.CreateHotel(hotel); //201 + data
            return CreatedAtAction("GetHotelById", new { id = createdHotel.Id }, createdHotel);
        }

        /// <summary>
        /// Update an existing hotel.
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateHotel([FromBody] Hotel hotel)
        {
            if (_hotelService.GetHotelById(hotel.Id) != null)
            {
                return Ok(_hotelService.UpdateHotel(hotel)); //200 + data
            }
            return NotFound();
        }

        /// <summary>
        /// Delete a hotel by its ID.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult DeleteHotel(int id)
        {
            if (_hotelService.GetHotelById(id) != null)
            {
                _hotelService.DeleteHotelById(id);
                return Ok(); //200
            }
            return NotFound();
        }
    }
}

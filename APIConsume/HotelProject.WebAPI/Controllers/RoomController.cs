using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {                
        private readonly IRoomService _roomService;

        public RoomController(IRoomService RoomService)
        {
            _roomService = RoomService;
        }

        // GET metodu, bir kaynağın alınmasını istemek için kullanılır. Genellikle sunucudan bir kaynağı (HTML, resim, dosya vb.) istemek için kullanılır. Veri gövdesi olmayan güvenli bir istektir, yani sunucuya herhangi bir değişiklik yapmadan sadece bilgi almak için kullanılır.
        [HttpGet]
        public IActionResult RoomList()
        {
            var values = _roomService.TGetList();
            return Ok(values);
        }

        // POST metodu, sunucuya yeni bir kaynak oluşturulmasını veya mevcut bir kaynağı güncellenmesini istemek için kullanılır. Genellikle bir HTML formundan gelen verileri sunucuya göndermek için kullanılır. Veri gövdesine sahip olabilir ve sunucuda bir değişiklik yapabilir.
        [HttpPost]
        public IActionResult AddRoom(Room Room)
        {
            _roomService.TInsert(Room);
            return Ok();
        }

        // DELETE metodu, sunucuda belirtilen bir kaynağı silmek için kullanılır. Kaynak silindiğinde sunucu genellikle bir onay yanıtı döndürür.
        [HttpDelete]
        public IActionResult DeleteRoom(int id)
        {
            var values = _roomService.TGetByID(id);
            _roomService.TDelete(values);
            return Ok();
        }

        // PUT metodu, sunucuda belirtilen bir kaynağı güncellemek veya varsa oluşturmak için kullanılır. Genellikle tam bir kaynağı sunucuya göndermek için kullanılır. Eğer kaynak zaten varsa güncellenir, yoksa oluşturulur.
        [HttpPut]
        public IActionResult UpdateRoom(Room Room)
        {
            _roomService.TUpdate(Room);
            return Ok();
        }

        // Dışarıdan bir ID parametresi alacağı anlamına gelir.
        [HttpGet("{id}")]
        public IActionResult GetRoom(int id)
        {
            var values = _roomService.TGetByID(id);
            return Ok(values);
        }
    }
}

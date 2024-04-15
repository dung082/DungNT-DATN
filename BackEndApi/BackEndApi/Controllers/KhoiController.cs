using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndApi.Repository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KhoiController : ControllerBase
    {
        private readonly ILogger<KhoiController> _logger;
        public IKhoiRepository _ikhoiRepository { get; set; }
        public KhoiController(ILogger<KhoiController> logger, IKhoiRepository ikhoiRepository)
        {
            _logger = logger;
            _ikhoiRepository = ikhoiRepository;
        }

        [HttpGet]
        [Route("GetAllKhoi")]
        public async Task<ActionResult<List<Khoi>>> getAllKhoi()
        {
            var listKhoi = await _ikhoiRepository.GetAllKhoi();
            return Ok(listKhoi);
        }

        [HttpPost]
        [Route("CreateKhoi")]
        public IActionResult CreateKhoi(KhoiDto khoiDto)
        {
            return _ikhoiRepository.CreateKhoi(khoiDto);
        }
    }
}

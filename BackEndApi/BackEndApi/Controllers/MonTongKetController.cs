using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MonTongKetController : ControllerBase
    {
        private readonly ILogger<MonTongKetController> _logger;
        public IMonTongKetRepository _iMonTongKetRepository { get; set; }
        public MonTongKetController(ILogger<MonTongKetController> logger, IMonTongKetRepository iMonTongKetRepository)
        {
            _logger = logger;
            _iMonTongKetRepository = iMonTongKetRepository;
        }

        [HttpGet]
        [Route("LayMonTongKet")]
        public async Task<ActionResult> LayMonTongKet()
        {
            var result = await _iMonTongKetRepository.LayDanhSachMon();
            return Ok(result);
        }

        [HttpPost]
        [Route("ThemMonTongKet")]
        public async Task<ActionResult> ThemMonTongKet(MonTongKetDto monTongKetDto)
        {
            var result = await _iMonTongKetRepository.ThemMon(monTongKetDto);
            return Ok(result);
        }

    }
}

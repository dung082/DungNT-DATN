using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HocBaController : ControllerBase
    {
        private readonly ILogger<CaHocController> _logger;
        public IHocBaRepository _iHocBaRepository { get; set; }

        public HocBaController(ILogger<CaHocController> logger, IHocBaRepository iHocBaRepository)
        {
            _logger = logger;
            _iHocBaRepository = iHocBaRepository;
        }

        [HttpGet]
        [Route("LayHocBa")]
        public async Task<ActionResult> LayHocBa(string username,int lop)
        {
            var result = await _iHocBaRepository.GetHocBaByUserName(username,lop);
            return Ok(result);
        }

        [HttpPost]
        [Route("ThemHocBa")]
        public IActionResult ThemHocBa(HocBaDto hocBaDto)
        {
            var result = _iHocBaRepository.ThemDiemHocBa(hocBaDto);
            return Ok(result);
        }
    }
}

using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndApi.Repository;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CaHocController : ControllerBase
    {
        private readonly ILogger<CaHocController> _logger;
        public ICaHocRepository _iCaHocRepository { get; set; }
        public CaHocController(ILogger<CaHocController> logger, ICaHocRepository iCaHocRepository)
        {
            _logger = logger;
            _iCaHocRepository = iCaHocRepository;
        }
        [HttpGet]
        [Route("LayToanBoCaHoc")]
        public async Task<ActionResult<List<DanToc>>> LayToanBoCaHoc()
        {
            var listCaHoc = await _iCaHocRepository.LayToanBoCaHoc();
            return Ok(listCaHoc);
        }

        [HttpPost]
        [Route("ThemCaHoc")]
        public IActionResult ThemCaHoc([FromBody] CaHocDto caHocDto)
        {
            return _iCaHocRepository.ThemCaHoc(caHocDto);
        }
    }
}

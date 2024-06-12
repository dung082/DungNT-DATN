using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndApi.Repository;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TietHocController : ControllerBase
    {
        private readonly ILogger<TietHocController> _logger;
        public ITietHocRepository _iTietHocRepository { get; set; }
        public TietHocController(ILogger<TietHocController> logger, ITietHocRepository iTietHocRepository)
        {
            _logger = logger;
            _iTietHocRepository = iTietHocRepository;
        }
        [HttpGet]
        [Route("LayToanBoTietHoc")]
        public async Task<ActionResult<List<TietHoc>>> LayToanBoTietHoc()
        {
            var listTietHoc = await _iTietHocRepository.LayToanBoTietHoc();
            return Ok(listTietHoc);
        }

        [HttpPost]
        [Route("ThemTietHoc")]
        public IActionResult ThemTietHoc([FromBody] TietHocDto tietHocDto)
        {
            return _iTietHocRepository.ThemTietHoc(tietHocDto);
        }
    }
}

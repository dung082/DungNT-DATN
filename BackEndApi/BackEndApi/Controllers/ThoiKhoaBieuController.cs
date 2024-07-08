using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndApi.Repository;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThoiKhoaBieuController : ControllerBase
    {
        private readonly ILogger<ThoiKhoaBieuController> _logger;
        public IThoiKhoaBieuRepository _iThoiKhoaBieuRepository { get; set; }
        public ThoiKhoaBieuController(ILogger<ThoiKhoaBieuController> logger, IThoiKhoaBieuRepository iThoiKhoaBieuRepository)
        {
            _logger = logger;
            _iThoiKhoaBieuRepository = iThoiKhoaBieuRepository;
        }
        [HttpGet]
        [Route("LayThoiKhoaBieu")]
        public async Task<ActionResult> LayThoiKhoaBieu(DateTime? ngayHoc)
        {
            var lstTkb = await _iThoiKhoaBieuRepository.LayThoiKhoaBieu(ngayHoc);
            return Ok(lstTkb);
        }

        [HttpPost]
        [Route("ThemThoiKhoaBieu")]
        public async Task<ActionResult> ThemThoiKhoaBieu(ThoiKhoaBieuDto thoiKhoaBieuDto)
        {
            return await _iThoiKhoaBieuRepository.ThemThoiKhoaBieu(thoiKhoaBieuDto);
        }
    }
}

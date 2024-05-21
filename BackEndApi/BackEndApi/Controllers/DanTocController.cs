using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndApi.Repository;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DanTocController : ControllerBase
    {
        private readonly ILogger<DanTocController> _logger;
        public IDantocRepository _idantocRepository { get; set; }
        public DanTocController(ILogger<DanTocController> logger, IDantocRepository idantocRepository)
        {
            _logger = logger;
            _idantocRepository = idantocRepository;
        }
        [HttpGet]
        [Route("LayToanBoDanToc")]
        public async Task<ActionResult<List<DanToc>>> LayToanBoDanToc()
        {
            var listDanToc = await _idantocRepository.LayToanBoDanToc();
            return Ok(listDanToc);
        }

        [HttpPost]
        [Route("ThemDanToc")]
        public IActionResult ThemDanToc(DanTocDto dantocDto)
        {
            return _idantocRepository.ThemDanToc(dantocDto);
        }
    }
}

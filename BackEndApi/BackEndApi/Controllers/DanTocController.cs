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
        [Route("GetAllDanToc")]
        public async Task<ActionResult<List<DanToc>>> GetAllDanToc()
        {
            var listDanToc = await _idantocRepository.GetAllDanToc();
            return Ok(listDanToc);
        }

        [HttpPost]
        [Route("CreateDanToc")]
        public IActionResult CreateDanToc(DanTocDto dantocDto)
        {
            return _idantocRepository.CreateDanToc(dantocDto);
        }
    }
}

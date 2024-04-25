using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndApi.Repository;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NguoiDungController : ControllerBase
    {
        private readonly ILogger<NguoiDungController> _logger;
        public INguoiDungRepository _iNguoiDungRepository { get; set; }

        public NguoiDungController(ILogger<NguoiDungController> logger, INguoiDungRepository iNguoiDungRepository)
        {
            _logger = logger;
            _iNguoiDungRepository = iNguoiDungRepository;
        }

        [HttpGet]
        [Route("GetAllNguoiDung")]
        public async Task<ActionResult<List<NguoiDung>>> GetAllLop()
        {
            var listLop = await _iNguoiDungRepository.GetAllNguoiDung();
            return Ok(listLop);
        }

        [HttpGet]
        [Route("GetNguoiDungByIdLop")]
        public async Task<ActionResult<List<NguoiDung>>> GetNguoiDungByIdLop(Guid idLop)
        {
            var listLop = await _iNguoiDungRepository.GetNguoiDungByIdLop(idLop);
            return Ok(listLop);
        }

        [HttpPost]
        [Route("CreateNguoiDung")]
        public IActionResult CreateNguoiDung(NguoiDungDto nguoiDungDto)
        {
            var result = _iNguoiDungRepository.CreateNguoiDung(nguoiDungDto);
            return Ok(result);
        }
    }
}

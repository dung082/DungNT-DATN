using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndApi.Repository;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LopController : ControllerBase
    {
        private readonly ILogger<LopController> _logger;
        public ILopRepository _ilopRepository { get; set; }

        public LopController(ILogger<LopController> logger, ILopRepository ilopRepository)
        {
            _logger = logger;
            _ilopRepository = ilopRepository;
        }

        [HttpGet]
        [Route("GetAllLop")]
        public async Task<ActionResult<List<Lop>>> GetAllLop()
        {
            var listLop = await _ilopRepository.GetAllLop();
            return Ok(listLop);
        }
        [HttpPost]
        [Route("CreateLop")]
        public async Task<ActionResult> CreateLop(LopDto lopDto)
        {

            if (String.IsNullOrEmpty(lopDto.MaLop))
            {
                throw new Exception("Mã lớp không được để trống");
            }
            if (String.IsNullOrEmpty(lopDto.TenLop))
            {
                throw new Exception("Tên lớp không được để trống");
            }
            if (String.IsNullOrEmpty(lopDto.IdKhoi.ToString()))
            {
                throw new Exception("Tên lớp không được để trống");
            }
            var result = await _ilopRepository.CreateLop(lopDto);
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateLop")]
        public IActionResult UpdateLop(Lop lop)
        {
            return _ilopRepository.UpdateLop(lop);
        }

        [HttpPost]
        [Route("DeleteLop")]
        public IActionResult DeleteLop(Guid id)
        {
            return _ilopRepository.DeleteLop(id);
        }
    }
}

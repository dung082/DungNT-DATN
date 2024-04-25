using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndApi.Repository;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChiTietLopHocController
    {
        private readonly ILogger<ChiTietLopHocController> _logger;
        public IChiTietLopHocRepository _iChiTietLopHocRepository { get; set; }
        public ChiTietLopHocController(ILogger<ChiTietLopHocController> logger, IChiTietLopHocRepository iChiTietLopHocRepository)
        {
            _logger = logger;
            _iChiTietLopHocRepository = iChiTietLopHocRepository;
        }

        [HttpPost]
        [Route("CreateChiTietLopHoc")]
        public IActionResult CreateChiTietLopHoc(ChiTietLopHocDto chiTietLopHocDto)
        {
            return _iChiTietLopHocRepository.CreateChiTietLopHoc(chiTietLopHocDto);
        }
    }
}

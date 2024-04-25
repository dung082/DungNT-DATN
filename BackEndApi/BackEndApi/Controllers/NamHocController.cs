using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    public class NamHocController
    {
        private readonly ILogger<NamHocController> _logger;
        public INamHocRepository _iNamHocRepository { get; set; }
        public NamHocController(ILogger<NamHocController> logger, INamHocRepository iNamHocRepository)
        {
            _logger = logger;
            _iNamHocRepository = iNamHocRepository;
        }

        [HttpPost]
        [Route("CreateNamHoc")]
        public IActionResult CreateNamHoc(NamHocDto namHocDto)
        {
            return _iNamHocRepository.CreateNamHoc(namHocDto);
        }
    }
}

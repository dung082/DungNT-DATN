using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiemTongKetController : ControllerBase
    {
        private readonly ILogger<DiemTongKetController> _logger;
        public IDiemTongKetRepository _iDiemTongKetRepository { get; set; }

        public DiemTongKetController(ILogger<DiemTongKetController> logger, IDiemTongKetRepository iDiemTongKetRepository)
        {
            _logger = logger;
            _iDiemTongKetRepository = iDiemTongKetRepository;
        }

        [HttpGet]
        [Route("LayDiemTongKet")]
        public async Task<ActionResult> LayDiemTongKet(int type, string? username, Guid? kyHocId, Guid? monTongKet)
        {
            var result = await _iDiemTongKetRepository.LayDiemTongKet(type, username, kyHocId, monTongKet);
            return Ok(result);
        }

        [HttpGet]
        [Route("LayDiemHocBa")]
        public async Task<ActionResult> LayDiemHocBa(string username, int lop)
        {
            var result = await _iDiemTongKetRepository.LayDiemHocBa(username, lop);
            return Ok(result);
        }

        [HttpPost]
        [Route("ThemDiemTongKet")]
        public async Task<ActionResult> ThemDiemTongKet([FromBody] DiemTongKetDto diemTongKetDto)
        {
            var result = await _iDiemTongKetRepository.ThemDiemTongKet(diemTongKetDto);
            return Ok(result);
        }

        [HttpPost]
        [Route("ThemListDiemTongKetNon")]
        public async Task<ActionResult> ThemListDiemTongKetNon([FromBody] DiemTongKetAddDto diemTongKetDto)
        {
            var result = await _iDiemTongKetRepository.ThemListDiemTongKet(diemTongKetDto);
            return Ok(result);
        }

        [HttpPost]
        [Route("ThemListDiemTongKet")]
        public async Task<ActionResult> ThemListDiemTongKet([FromBody] DiemTongKetAddList diemTongKetDto)
        {
            var result = await _iDiemTongKetRepository.ThemListDiemTongKet(diemTongKetDto);
            return Ok(result);
        }

        [HttpPost]
        [Route("PhucKhaoDiemTongKet")]
        public async Task<ActionResult> PhucKhaoDiemTongKet(string username, string namHoc, Guid hocKyId, List<Guid> listMonTongKetId)
        {
            var result = await _iDiemTongKetRepository.BaoSaiSotDiemTongKet(username, namHoc, hocKyId, listMonTongKetId);
            return Ok(result);
        }

        [HttpPost]
        [Route("SuaDiemTongKet")]
        public async Task<ActionResult> SuaDiemTongKet(int type,Guid diemTongKetId , decimal diem)
        {
            var result = await _iDiemTongKetRepository.SuaDiemTongKet(type, diemTongKetId , diem);  
            return Ok(result);
        }

        [HttpGet]
        [Route("LayDiemTongKetTheoUser")]
        public async Task<ActionResult> LayDiemTongKetTheoUser(string username, Guid monTongKetId, Guid kyHocId)
        {
            var result = await _iDiemTongKetRepository.LayDiemTongKetTheoUser(username, monTongKetId, kyHocId);
            return Ok(result);
        }
    }
}

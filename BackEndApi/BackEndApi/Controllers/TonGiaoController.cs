using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndApi.Repository;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TonGiaoController : ControllerBase
    {
        private readonly ILogger<TonGiaoController> _logger;
        public ITonGiaoRepository _iTonGiaoRepository { get; set; }
        public TonGiaoController(ILogger<TonGiaoController> logger, ITonGiaoRepository iTonGiaoRepository)
        {
            _logger = logger;
            _iTonGiaoRepository = iTonGiaoRepository;
        }

        [HttpPost]
        [Route("ThemTonGiao")]
        public IActionResult ThemTonGiao(TonGiaoDto tonGiaoDto)
        {
            return _iTonGiaoRepository.ThemTonGiao(tonGiaoDto);
        }

        [HttpGet]
        [Route("LayToanBoTonGiao")]
        public async Task<ActionResult<List<TonGiao>>> LayToanBoTonGiao()
        {
            var listTonGiao = await _iTonGiaoRepository.LayToanBoTonGiao();
            return Ok(listTonGiao);
        }

        //[HttpGet]
        //[Route("LayNamHocTheoKhoaHocId")]
        //public Task<ActionResult<List<NamHoc>>> LayNamHocTheoKhoaHocId(Guid khoaHocId)
        //{
        //    return _iNamHocRepository.LayNamHocTheoKhoaHocId(khoaHocId);
        //}
    }
}

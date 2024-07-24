﻿using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiemDanhController : ControllerBase
    {
        private readonly ILogger<DiemDanhController> _logger;
        public IDiemDanhRepository _iDiemDanhRepository { get; set; }
        public DiemDanhController(ILogger<DiemDanhController> logger, IDiemDanhRepository iDiemDanhRepositoru)
        {
            _logger = logger;
            _iDiemDanhRepository = iDiemDanhRepositoru;
        }

        [HttpGet]
        [Route("LayDiemDanh")]
        public async Task<ActionResult> LayDiemDanh(DateTime? ngay , string username)
        {
            var result = await _iDiemDanhRepository.LayDanhSachDiemDanhTheoTuan(ngay, username);
            return Ok(result);
        }

        [HttpPost]
        [Route("ThemDiemDanh")]
        public async Task<ActionResult> ThemDiemDanh(DiemDanhDto diemDanhDto)
        {
            var result = await _iDiemDanhRepository.ThemDiemDanh(diemDanhDto);
            return Ok(result);
        }
    }
}

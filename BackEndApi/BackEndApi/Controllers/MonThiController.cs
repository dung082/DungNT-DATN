﻿using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MonThiController : ControllerBase
    {
        private readonly ILogger<MonThiController> _logger;
        public IMonThiRepository _iMonThiRepository { get; set; }
        public MonThiController(ILogger<MonThiController> logger, IMonThiRepository iMonThiRepository)
        {
            _logger = logger;
            _iMonThiRepository = iMonThiRepository;
        }

        [HttpGet]
        [Route("LayMonThi")]
        public async Task<ActionResult> LayMonThiTheoLop(Guid lopId)
        {
            var result = await _iMonThiRepository.LayMonThiTheoLopThi(lopId);
            return Ok(result);
        }

        [HttpPost]
        [Route("ThemDiemThi")]
        public async Task<ActionResult> ThemMonThi( MonThiDTO monThiDto)
        {
            var result = await _iMonThiRepository.ThemMonThi(monThiDto);
            return Ok(result);
        }

    }
}

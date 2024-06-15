using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaiKhoanController : ControllerBase
    {
        private readonly ILogger<TaiKhoanController> _logger;
        public ITaiKhoanRepository _iTaiKhoanRepository { get; set; }

        public TaiKhoanController(ILogger<TaiKhoanController> logger, ITaiKhoanRepository iTaiKhoanRepository)
        {
            _logger = logger;
            _iTaiKhoanRepository = iTaiKhoanRepository;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(TaiKhoanDto taiKhoanDto)
        {
            if(String.IsNullOrWhiteSpace(taiKhoanDto.Username))
            {
                throw new Exception("Tài khoản không được để trống");
            }
            if (String.IsNullOrWhiteSpace(taiKhoanDto.Password))
            {
                throw new Exception("Mật khẩu không được để trống");
            }
            var result = await _iTaiKhoanRepository.Login(taiKhoanDto);
            return Ok(result);
        }
    }
}

using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    public class UploadImageController : ControllerBase
    {
        private readonly ILogger<UploadImageController> _logger;
        public IUploadImageRepository _iUploadImageRepository { get; set; }
        public UploadImageController(ILogger<UploadImageController> logger, IUploadImageRepository iUploadImageRepository)
        {
            _logger = logger;
            _iUploadImageRepository = iUploadImageRepository;
        }

        [HttpPost]
        [Route("UploadImage")]
        public async Task<IActionResult> UploadImage(UploadImageDto uploadImageDto )
        {
            string baseUrl = $"{Request.Scheme}://{Request.Host}/";
            var result = await _iUploadImageRepository.UploadImage(uploadImageDto,baseUrl);

            return Ok(result);
        }

        public void EnsureImageFolderExists()
        {
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "image");
            if (!Directory.Exists(imagePath))
            {
                Directory.CreateDirectory(imagePath);
            }
        }
    }
}

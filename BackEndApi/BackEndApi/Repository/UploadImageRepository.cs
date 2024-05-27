using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Repository
{
    public class UploadImageRepository : IUploadImageRepository
    {
        public async Task<IActionResult> UploadImage(UploadImageDto uploadImageDto, string baseUrl)
        {
            if (uploadImageDto.file == null || uploadImageDto.file.Length == 0)
            {
                throw new Exception("Bạn phải thêm file để upload");
            }

            EnsureImageFolderExists();

            string fileName = Guid.NewGuid().ToString() + Path.GetFileName(uploadImageDto.file.FileName);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "image", fileName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await uploadImageDto.file.CopyToAsync(stream);
            }

            string imageUrl = $"{baseUrl}image/{fileName}";
            return new JsonResult(imageUrl);
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

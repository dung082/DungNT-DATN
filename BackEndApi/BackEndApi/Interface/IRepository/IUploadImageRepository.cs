using BackEndApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface IUploadImageRepository
    {
        public Task<IActionResult> UploadImage(UploadImageDto uploadImageDto, string baseUrl);
    }
}

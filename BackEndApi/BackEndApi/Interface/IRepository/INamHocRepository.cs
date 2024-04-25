using BackEndApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface INamHocRepository
    {
        public IActionResult CreateNamHoc(NamHocDto namHocDto);
    }
}

using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Repository
{
    public class HocBaRepository : IHocBaRepository
    {
        public ApplicationDbContext _context { get; set; }
        public HocBaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> GetHocBaByUserName(string userName, int lop)
        {
            if (String.IsNullOrWhiteSpace(userName))
            {
                throw new Exception("Tên đăng nhập không được để trống");
            }
            var nguoiDung = await _context.NguoiDungs.FirstOrDefaultAsync(item => item.Username == userName);
            if (String.IsNullOrWhiteSpace(lop.ToString()))
            {
                var hocba = await _context.HocBas.FirstOrDefaultAsync(item => item.Username == userName && item.Lop == 10);

                if (hocba == null)
                {
                    var result = new
                    {
                        Title = $"Hiện tại bạn chưa có học bạ lớp 10",
                        HocBa = ""
                    };
                    return new JsonResult(result);
                }
                HocBaDto hocbaDto = new HocBaDto()
                {
                    Username = userName,
                    DiemTKHK1 = hocba.DiemTKHK1,
                    DiemTKHK2 = hocba.DiemHKHK2,
                    DiemTKCN = hocba.DiemTKCN,
                    DiemHKHK1 = hocba.DiemHKHK1,
                    DiemHKHK2 = hocba.DiemHKHK2,
                    DiemHKCN = hocba.DiemHKCN,
                    DiemLyHK1 = hocba.DiemLyHK1,
                    DiemLyHK2 = hocba.DiemLyHK2,
                    DiemLyCN = hocba.DiemLyCN,
                    DiemHoaHK1 = hocba.DiemHoaHK1,
                    DiemHoaHK2 = hocba.DiemHoaHK2,
                    DiemHoaCN = hocba.DiemHoaCN,
                    DiemToanHK1 = hocba.DiemToanHK1,
                    DiemToanHK2 = hocba.DiemToanHK2,
                    DiemToanCN = hocba.DiemToanCN,
                    DiemVanHK1 = hocba.DiemToanHK1,
                    DiemVanHK2 = hocba.DiemVanHK2,
                    DiemVanCN = hocba.DiemVanCN,
                    SinhHK1 = hocba.SinhHK1,
                    SinhHK2 = hocba.SinhHK2,
                    SinhCN = hocba.SinhCN,
                    LichSuHK1 = hocba.LichSuHK1,
                    LichSuHK2 = hocba.LichSuHK2,
                    LichSuCN = hocba.LichSuCN,
                    DiaHK1 = hocba.DiaHK1,
                    DiaHK2 = hocba.DiaHK2,
                    DiaCN = hocba.DiaCN,
                    GDCDHK1 = hocba.GDCDHK1,
                    GDCDHK2 = hocba.GDCDHK2,
                    GDCDCN = hocba.GDCDCN,
                    NgoaiNguHK1 = hocba.NgoaiNguHK1,
                    NgoaiNguHK2 = hocba.NgoaiNguHK2,
                    NgoaiNguCN = hocba.NgoaiNguCN,
                    Lop = lop,
                    HoTen = nguoiDung.HoTen,
                    NgaySinh = nguoiDung.NgaySinh,
                };

                var result1 = new
                {
                    Title = $"Thông tin học bạ lớp 10",
                    HocBa = hocbaDto,
                };
                return new JsonResult(result1);
            }
            var hocba1 = await _context.HocBas.FirstOrDefaultAsync(item => item.Username == userName && item.Lop == lop);

            if (hocba1 == null)
            {
                var result2 = new
                {
                    Title = $"Hiện tại bạn chưa có học bạ lớp {lop}",
                    HocBa = ""
                };
                return new JsonResult(result2);
            }
            HocBaDto hocbaDto1 = new HocBaDto()
            {
                Username = userName,
                DiemTKHK1 = hocba1.DiemTKHK1,
                DiemTKHK2 = hocba1.DiemHKHK2,
                DiemTKCN = hocba1.DiemTKCN,
                DiemHKHK1 = hocba1.DiemHKHK1,
                DiemHKHK2 = hocba1.DiemHKHK2,
                DiemHKCN = hocba1.DiemHKCN,
                DiemLyHK1 = hocba1.DiemLyHK1,
                DiemLyHK2 = hocba1.DiemLyHK2,
                DiemLyCN = hocba1.DiemLyCN,
                DiemHoaHK1 = hocba1.DiemHoaHK1,
                DiemHoaHK2 = hocba1.DiemHoaHK2,
                DiemHoaCN = hocba1.DiemHoaCN,
                DiemToanHK1 = hocba1.DiemToanHK1,
                DiemToanHK2 = hocba1.DiemToanHK2,
                DiemToanCN = hocba1.DiemToanCN,
                DiemVanHK1 = hocba1.DiemToanHK1,
                DiemVanHK2 = hocba1.DiemVanHK2,
                DiemVanCN = hocba1.DiemVanCN,
                SinhHK1 = hocba1.SinhHK1,
                SinhHK2 = hocba1.SinhHK2,
                SinhCN = hocba1.SinhCN,
                LichSuHK1 = hocba1.LichSuHK1,
                LichSuHK2 = hocba1.LichSuHK2,
                LichSuCN = hocba1.LichSuCN,
                DiaHK1 = hocba1.DiaHK1,
                DiaHK2 = hocba1.DiaHK2,
                DiaCN = hocba1.DiaCN,
                GDCDHK1 = hocba1.GDCDHK1,
                GDCDHK2 = hocba1.GDCDHK2,
                GDCDCN = hocba1.GDCDCN,
                NgoaiNguHK1 = hocba1.NgoaiNguHK1,
                NgoaiNguHK2 = hocba1.NgoaiNguHK2,
                NgoaiNguCN = hocba1.NgoaiNguCN,
                Lop = lop,
                HoTen = nguoiDung.HoTen,
                NgaySinh = nguoiDung.NgaySinh,
            };

            var result3 = new
            {
                Title = $"Thông tin học bạ lớp 10",
                HocBa = hocbaDto1,
            };
            return new JsonResult(result3);
        }
    }

}

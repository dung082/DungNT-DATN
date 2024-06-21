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
            if (String.IsNullOrWhiteSpace(lop.ToString()) || lop == 0)
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
                HocBaDtoGet hocbaDto = new HocBaDtoGet()
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
            HocBaDtoGet hocbaDto1 = new HocBaDtoGet()
            {
                Username = userName,
                DiemTKHK1 = hocba1.DiemTKHK1,
                DiemTKHK2 = hocba1.DiemTKHK2,
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
                DiemVanHK1 = hocba1.DiemVanHK1,
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
                HocLucHK1 = hocba1.HocLucHK1,
                HocLucHK2 = hocba1.HocLucHK2,
                HocLucCN = hocba1.HocLucCN,
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

        public IActionResult ThemDiemHocBa(HocBaDto hocBaDto)
        {
            if (String.IsNullOrWhiteSpace(hocBaDto.Username))
            {
                throw new Exception("Tên tài khoản người dùng không được để trống");
            }
            if (String.IsNullOrWhiteSpace(hocBaDto.Lop.ToString()) || hocBaDto.Lop == 0)
            {
                throw new Exception("Lớp không được để trống");
            }

            HocBa hocba = new HocBa()
            {
                Id = Guid.NewGuid(),
                Username = hocBaDto.Username,
                Lop = hocBaDto.Lop,
                DiemToanHK1 = hocBaDto.DiemToanHK1,
                DiemToanHK2 = hocBaDto.DiemToanHK2,
                DiemToanCN = System.Math.Round((hocBaDto.DiemToanHK1 + hocBaDto.DiemToanHK2 * 2) / 3, 2),
                DiemVanHK1 = hocBaDto.DiemVanHK1,
                DiemVanHK2 = hocBaDto.DiemVanHK2,
                DiemVanCN = System.Math.Round((hocBaDto.DiemVanHK1 + hocBaDto.DiemVanHK2 * 2) / 3, 2),
                DiemLyHK1 = hocBaDto.DiemLyHK1,
                DiemLyHK2 = hocBaDto.DiemLyHK2,
                DiemLyCN = System.Math.Round((hocBaDto.DiemLyHK1 + hocBaDto.DiemLyHK2 * 2) / 3, 2),
                DiemHoaHK1 = hocBaDto.DiemHoaHK1,
                DiemHoaHK2 = hocBaDto.DiemHoaHK2,
                DiemHoaCN = System.Math.Round((hocBaDto.DiemHoaHK1 + hocBaDto.DiemHoaHK2 * 2) / 3, 2),
                SinhHK1 = hocBaDto.SinhHK1,
                SinhHK2 = hocBaDto.SinhHK2,
                SinhCN = System.Math.Round((hocBaDto.SinhHK1 + hocBaDto.SinhHK2 * 2) / 3, 2),
                LichSuHK1 = hocBaDto.LichSuHK1,
                LichSuHK2 = hocBaDto.LichSuHK2,
                LichSuCN = System.Math.Round((hocBaDto.LichSuHK1 + hocBaDto.LichSuHK2 * 2) / 3, 2),
                DiaHK1 = hocBaDto.DiaHK1,
                DiaHK2 = hocBaDto.DiaHK2,
                DiaCN = System.Math.Round((hocBaDto.DiaHK1 + hocBaDto.DiaHK2 * 2) / 3, 2),
                GDCDHK1 = hocBaDto.GDCDHK1,
                GDCDHK2 = hocBaDto.GDCDHK2,
                GDCDCN = System.Math.Round((hocBaDto.GDCDHK1 + hocBaDto.GDCDHK2 * 2) / 3, 2),
                NgoaiNguHK1 = hocBaDto.NgoaiNguHK1,
                NgoaiNguHK2 = hocBaDto.NgoaiNguHK2,
                NgoaiNguCN = System.Math.Round((hocBaDto.NgoaiNguHK1 + hocBaDto.NgoaiNguHK2 * 2) / 3, 2),
                DiemHKHK1 = hocBaDto.DiemHKHK1,
                DiemHKHK2 = hocBaDto.DiemHKHK2,
                DiemHKCN = hocBaDto.DiemHKCN,
                DiemTKHK1 = System.Math.Round((hocBaDto.DiemToanHK1 + hocBaDto.DiemVanHK1 + hocBaDto.DiemLyHK1 + hocBaDto.DiemHoaHK1 + hocBaDto.SinhHK1 + hocBaDto.LichSuHK1 + hocBaDto.DiaHK1 + hocBaDto.GDCDHK1 + hocBaDto.NgoaiNguHK1) / 9, 2),
                DiemTKHK2 = System.Math.Round((hocBaDto.DiemToanHK2 + hocBaDto.DiemVanHK2 + hocBaDto.DiemLyHK2 + hocBaDto.DiemHoaHK2 + hocBaDto.SinhHK2 + hocBaDto.LichSuHK2 + hocBaDto.DiaHK2 + hocBaDto.GDCDHK2 + hocBaDto.NgoaiNguHK2) / 9, 2),
                DiemTKCN = System.Math.Round((((hocBaDto.DiemToanHK1 + hocBaDto.DiemVanHK1 + hocBaDto.DiemLyHK1 + hocBaDto.DiemHoaHK1 + hocBaDto.SinhHK1 + hocBaDto.LichSuHK1 + hocBaDto.DiaHK1 + hocBaDto.GDCDHK1 + hocBaDto.NgoaiNguHK1) / 9) + ((hocBaDto.DiemToanHK2 + hocBaDto.DiemVanHK2 + hocBaDto.DiemLyHK2 + hocBaDto.DiemHoaHK2 + hocBaDto.SinhHK2 + hocBaDto.LichSuHK2 + hocBaDto.DiaHK2 + hocBaDto.GDCDHK2 + hocBaDto.NgoaiNguHK2) / 9) * 2) / 3, 2),
            };
            hocba.HocLucHK1 = XepLoaiHocLuc(hocba.DiemTKHK1);
            hocba.HocLucHK2 = XepLoaiHocLuc(hocba.DiemTKHK2);
            hocba.HocLucCN = XepLoaiHocLuc(hocba.DiemTKCN);


            _context.HocBas.Add(hocba);
            _context.SaveChanges();
            return new JsonResult(hocba);
        }

        private int XepLoaiHocLuc(decimal diemhk)
        {
            if (diemhk > 8.5M)
            {
                return 1;
            }
            else if (6.5M <= diemhk && diemhk < 8.5M)
            {
                return 2;
            }
            else if (5 <= diemhk && diemhk < 6.5M)
            {
                return 3;
            }
            else if (diemhk < 5)
            {
                return 4;
            }
            return 5;
        }
    }

}

using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace BackEndApi.Repository
{
    public class ChiTietLopHocRepository : IChiTietLopHocRepository
    {
        public ApplicationDbContext _context;
        public ChiTietLopHocRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ChuyenLop(ChiTietLopHocDto chiTietLopHocDto)
        {
            if (String.IsNullOrWhiteSpace(chiTietLopHocDto.LopId.ToString()))
            {
                throw new Exception("Mã lớp không được để trống");
            }
            if (String.IsNullOrWhiteSpace(chiTietLopHocDto.Username))
            {
                throw new Exception("Tên tài khoản không được để trống");
            }
            if (String.IsNullOrWhiteSpace(chiTietLopHocDto.NamHocId.ToString()))
            {
                throw new Exception("Mã năm học không được để trống");
            }
            if (!_context.Lops.Any(item => item.Id == chiTietLopHocDto.LopId))
            {
                throw new Exception("Không tồn tại mã lớp");
            }
            if (!_context.NguoiDungs.Any(item => item.Username == chiTietLopHocDto.Username))
            {
                throw new Exception("Không tồn tại tên tài khoản");
            }
            if (!_context.NamHocs.Any(item => item.Id == chiTietLopHocDto.NamHocId))
            {
                throw new Exception("Không tồn tại mã năm học");
            }
            if (_context.ChiTietLops.Any(item => item.LopId == chiTietLopHocDto.LopId && item.Username == chiTietLopHocDto.Username && item.NamHocId == chiTietLopHocDto.NamHocId))
            {
                throw new Exception("Học sinh đã có ở trong lớp");
            }
            var ct = _context.ChiTietLops.FirstOrDefault(item => item.Username == chiTietLopHocDto.Username && item.NamHocId == chiTietLopHocDto.NamHocId);
            if (ct == null)
            {
                throw new Exception("Bạn không thể chuyển lớp");
            }
            ct.LopId = chiTietLopHocDto.LopId;
            _context.ChiTietLops.Update(ct);
            _context.SaveChanges();

            return new JsonResult(ct);

        }

        public async Task<ActionResult> LayHocSinhTrongLop(Guid? namHocId, Guid? lopId)
        {
            string namhoc = "";
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            if (month >= 8)
            {
                namhoc = year + "-" + (year + 1);
            }
            else
            {
                namhoc = (year - 1) + "-" + year;
            }
            NamHoc namHoc = new NamHoc();
            Lop lopHoc = new Lop();
            if (String.IsNullOrWhiteSpace(namHocId.ToString()))
            {
                namHoc = await _context.NamHocs.FirstOrDefaultAsync(item => item.NameHoc == namhoc);
            }
            else
            {
                namHoc = await _context.NamHocs.FirstOrDefaultAsync(item => item.Id == namHocId);
            }

            if (String.IsNullOrWhiteSpace(lopId.ToString()))
            {
                throw new Exception("Mã lớp không được để trống");
            }
            else
            {
                lopHoc = await _context.Lops.FirstOrDefaultAsync(item => item.Id == lopId);
            }

            
            var listCtl = await _context.ChiTietLops.Where(item => item.NamHocId == namHoc.Id && item.LopId == lopId).ToListAsync();
            List<NguoiDung> listNguoiDung = new List<NguoiDung>();
            foreach (var hs in listCtl)
            {
                var nguoiDungHS = await _context.NguoiDungs.FirstOrDefaultAsync(item => item.Username == hs.Username && item.UserType == 2);
                listNguoiDung.Add(nguoiDungHS);
            }
            var lstNguoiDungSort = listNguoiDung.OrderBy(u => u.HoTen).ToList();
            var result = new
            {
                lopHocHienTai = lopHoc,
                listHocSinh = lstNguoiDungSort
            };
            return new JsonResult(result);
        }

        public IActionResult ThemHocSinhVaoLop(ChiTietLopHocDto chiTietLopHocDto)
        {
            if (String.IsNullOrWhiteSpace(chiTietLopHocDto.LopId.ToString()))
            {
                throw new Exception("Mã lớp không được để trống");
            }
            if (String.IsNullOrWhiteSpace(chiTietLopHocDto.Username))
            {
                throw new Exception("Tên tài khoản không được để trống");
            }
            if (String.IsNullOrWhiteSpace(chiTietLopHocDto.NamHocId.ToString()))
            {
                throw new Exception("Mã năm học không được để trống");
            }
            if (!_context.Lops.Any(item => item.Id == chiTietLopHocDto.LopId))
            {
                throw new Exception("Không tồn tại mã lớp");
            }
            if (!_context.NguoiDungs.Any(item => item.Username == chiTietLopHocDto.Username))
            {
                throw new Exception("Không tồn tại tên tài khoản");
            }
            if (!_context.NamHocs.Any(item => item.Id == chiTietLopHocDto.NamHocId))
            {
                throw new Exception("Không tồn tại mã năm học");
            }
            if (_context.ChiTietLops.Any(item => item.LopId == chiTietLopHocDto.LopId && item.Username == chiTietLopHocDto.Username && item.NamHocId == chiTietLopHocDto.NamHocId))
            {
                throw new Exception("Học sinh đã có ở trong lớp");
            }

            ChiTietLop ctl = new ChiTietLop()
            {
                Id = new Guid(),
                LopId = chiTietLopHocDto.LopId,
                Username = chiTietLopHocDto.Username,
                NamHocId = chiTietLopHocDto.NamHocId,
            };
            _context.ChiTietLops.Add(ctl);
            _context.SaveChanges();
            return new JsonResult(ctl);
        }

        public Task<ActionResult> TimKiemHocSinhTrongLop(string username, Guid? namHocId, Guid? lopId)
        {
            throw new NotImplementedException();
        }

        public IActionResult XoaHocSinhTrongLop(Guid chiTietLopHocId)
        {
            throw new NotImplementedException();
        }
    }
}

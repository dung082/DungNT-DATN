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
            if (String.IsNullOrWhiteSpace(chiTietLopHocDto.NamHoc))
            {
                throw new Exception("Năm học không được để trống");
            }
            if (!_context.Lops.Any(item => item.Id == chiTietLopHocDto.LopId))
            {
                throw new Exception("Không tồn tại mã lớp");
            }
            if (!_context.NguoiDungs.Any(item => item.Username == chiTietLopHocDto.Username))
            {
                throw new Exception("Không tồn tại tên tài khoản");
            }
            if (_context.ChiTietLops.Any(item => item.LopId == chiTietLopHocDto.LopId && item.Username == chiTietLopHocDto.Username && item.NamHoc == chiTietLopHocDto.NamHoc))
            {
                throw new Exception("Học sinh đã có ở trong lớp");
            }
            var ct = _context.ChiTietLops.FirstOrDefault(item => item.Username == chiTietLopHocDto.Username && item.Username == chiTietLopHocDto.Username);
            if (ct == null)
            {
                throw new Exception("Bạn không thể chuyển lớp");
            }
            ct.LopId = chiTietLopHocDto.LopId;
            _context.ChiTietLops.Update(ct);
            _context.SaveChanges();

            return new JsonResult(ct);

        }

        public async Task<ActionResult> LayHocSinhTrongLop(string username)
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
            Lop lopHoc = new Lop();
            ChiTietLop ctl = new ChiTietLop();
            if (String.IsNullOrWhiteSpace(username))
            {
                throw new Exception("Cần truyền tên đăng nhập");
            }
            else
            {
                ctl = await _context.ChiTietLops.FirstOrDefaultAsync(item => item.NamHoc == namhoc && item.Username == username);
            }

            if (ctl == null)
            {
                var resultNone = new
                {
                    lopHocHienTai = "Tài khoản hiện tại chưa được phân lớp",
                    namHocHienTai = namhoc,
                    listHocSinh = new List<NguoiDung>(),
                };
                return new JsonResult(resultNone);
            }

            lopHoc = await _context.Lops.FirstOrDefaultAsync(item => item.Id == ctl.LopId);
            var listCtl = await _context.ChiTietLops.Where(item => item.NamHoc == namhoc && item.LopId == ctl.LopId).ToListAsync();


            List<NguoiDung> listNguoiDung = new List<NguoiDung>();
            foreach (var hs in listCtl)
            {
                var nguoiDungHS = await _context.NguoiDungs.FirstOrDefaultAsync(item => item.Username == hs.Username && item.UserType == 2);
                listNguoiDung.Add(nguoiDungHS);
            }
            var lstNguoiDungSort = listNguoiDung.OrderBy(u => u.HoTen.Split()[u.HoTen.Split().Length - 1]).ToList();
            var result = new
            {
                lopHocHienTai = lopHoc,
                namHocHienTai = namhoc,
                listHocSinh = lstNguoiDungSort
            };
            return new JsonResult(result);
        }

        public async Task<ActionResult> LayHocSinhTrongLopById(string namhoc, Guid lopId)
        {
            var lisths = await _context.ChiTietLops.Where(i => i.NamHoc == namhoc && i.LopId == lopId).ToListAsync();
            List<NguoiDung> lstNgD = new List<NguoiDung>();
            if (lisths.Count == 0)
            {
                throw new Exception("Không có học sinh trong lớp vào năm học này");
            }
            else
            {
                foreach (var item in lisths)
                {
                    var ngd = await _context.NguoiDungs.FirstOrDefaultAsync(i => i.Username == item.Username);
                    if (ngd != null)
                    {
                        lstNgD.Add(ngd);
                    }
                }
            }

            lstNgD = lstNgD.OrderBy(u => u.HoTen.Split()[u.HoTen.Split().Length - 1]).ToList();

            return new JsonResult(lstNgD);
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
            if (String.IsNullOrWhiteSpace(chiTietLopHocDto.NamHoc))
            {
                throw new Exception("Năm học không được để trống");
            }
            if (!_context.Lops.Any(item => item.Id == chiTietLopHocDto.LopId))
            {
                throw new Exception("Không tồn tại mã lớp");
            }
            if (!_context.NguoiDungs.Any(item => item.Username == chiTietLopHocDto.Username))
            {
                throw new Exception("Không tồn tại tên tài khoản");
            }
            if (_context.ChiTietLops.Any(item => item.LopId == chiTietLopHocDto.LopId && item.Username == chiTietLopHocDto.Username && item.NamHoc == chiTietLopHocDto.NamHoc))
            {
                throw new Exception("Học sinh đã có ở trong lớp");
            }

            ChiTietLop ctl = new ChiTietLop()
            {
                Id = new Guid(),
                LopId = chiTietLopHocDto.LopId,
                Username = chiTietLopHocDto.Username,
                NamHoc = chiTietLopHocDto.NamHoc,
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

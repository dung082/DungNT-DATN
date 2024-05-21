using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace BackEndApi.Repository
{
    public class NguoiDungRepository : INguoiDungRepository
    {
        public ApplicationDbContext _context;
        string[] VietnameseSigns = new string[]
        {

            "aAeEoOuUiIdDyY",

            "áàạảãâấầậẩẫăắằặẳẵ",

            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

            "éèẹẻẽêếềệểễ",

            "ÉÈẸẺẼÊẾỀỆỂỄ",

            "óòọỏõôốồộổỗơớờợởỡ",

            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

            "úùụủũưứừựửữ",

            "ÚÙỤỦŨƯỨỪỰỬỮ",

            "íìịỉĩ",

            "ÍÌỊỈĨ",

            "đ",

            "Đ",

            "ýỳỵỷỹ",

            "ÝỲỴỶỸ"
        };
        string RemoveSign4VietnameseString(string str)
        {
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }
            return str;
        }

        public NguoiDungRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult ThemNguoiDung(NguoiDungDto nguoiDungDto)
        {
            if (String.IsNullOrWhiteSpace(nguoiDungDto.HoTen))
            {
                throw new Exception("Họ và tên không được để trống");
            }
            if (String.IsNullOrWhiteSpace(nguoiDungDto.NgaySinh.ToString()))
            {
                throw new Exception("Ngày sinh không được để trống");
            }
            if (String.IsNullOrWhiteSpace(nguoiDungDto.DiaChi.ToString()))
            {
                throw new Exception("Địa chỉ không được để trống");
            }
            if (String.IsNullOrWhiteSpace(nguoiDungDto.GioiTinh.ToString()))
            {
                throw new Exception("Giới tính không được để trống");
            }
            if (String.IsNullOrWhiteSpace(nguoiDungDto.DanTocId.ToString()))
            {
                throw new Exception("Dân tộc không được để trống");
            }
            //if (String.IsNullOrWhiteSpace(nguoiDungDto.DanTocId.ToString()))
            //{
            //    throw new Exception("Dân tộc không được để trống");
            //}

            var usernameRevert = RevertUserName(nguoiDungDto.HoTen);
            if (_context.NguoiDungs.Any(item => item.Username == usernameRevert))
            {
                throw new Exception("Tài khoản đã tồn tại");
            }

            var emailReverst = usernameRevert + "@thcshb.edu.vn";

            if (_context.NguoiDungs.Any(item => item.Email == emailReverst))
            {
                throw new Exception("Email đã tồn tại");
            }

            if (!String.IsNullOrWhiteSpace(nguoiDungDto.SoDienThoai) && _context.NguoiDungs.Any(item => item.SoDienThoai == nguoiDungDto.SoDienThoai))
            {
                throw new Exception("Số điện thoại đã tồn tại");
            }

            var passwordHash = HashPassword("");
            NguoiDung nguoiDung = new NguoiDung()
            {
                Id = new Guid(),
                HoTen = nguoiDungDto.HoTen,
                DiaChi = nguoiDungDto.DiaChi,
                DanTocId = nguoiDungDto.DanTocId,
                GioiTinh = nguoiDungDto.GioiTinh,
                NgaySinh = nguoiDungDto.NgaySinh,
                Email = emailReverst,
                SoDienThoai = nguoiDungDto.SoDienThoai,
                Propeties = nguoiDungDto.Propeties,
                UserType = nguoiDungDto.UserType,
                Username = usernameRevert,
                Status = 2,
            };

            TaiKhoan taiKhoan = new TaiKhoan()
            {
                Id = new Guid(),
                Username = usernameRevert,
                Password = passwordHash,
                UserType = nguoiDungDto.UserType
            };

            _context.NguoiDungs.Add(nguoiDung);
            _context.TaiKhoans.Add(taiKhoan);
            _context.SaveChanges();

            return new JsonResult(nguoiDung);
        }

        public IActionResult XoaNguoiDung(Guid idNguoiDung)
        {
            if (string.IsNullOrWhiteSpace(idNguoiDung.ToString()))
            {
                throw new Exception("Không được để trống mã người dùng");
            }
            var nguoiDung = _context.NguoiDungs.FirstOrDefault(item => item.Id == idNguoiDung);
            if (nguoiDung == null)
            {
                throw new Exception("Người dùng bạn muốn xóa không tồn tại");
            }
            _context.NguoiDungs.Remove(nguoiDung);
            _context.SaveChanges();
            return new JsonResult(nguoiDung);
        }

        public async Task<ActionResult<List<NguoiDung>>> LayTatCaNguoiDung()
        {
            return await _context.NguoiDungs.ToListAsync();
        }

        public async Task<ActionResult<List<NguoiDung>>> LayNguoiDungTheoIdLop(Guid idLop)
        {
            var listNguoiDungLop = _context.ChiTietLops.Where(item => item.LopId == idLop).ToList();
            var listNguoiDung = nguoiDungInLop(listNguoiDungLop);

            return listNguoiDung;
        }

        public IActionResult SuaNguoiDung(NguoiDung nguoiDung)
        {
            var user = _context.NguoiDungs.FirstOrDefault(item => item.Id == nguoiDung.Id);
            if (String.IsNullOrWhiteSpace(nguoiDung.HoTen))
            {
                throw new Exception("Họ và tên không được để trống");
            }
            if (String.IsNullOrWhiteSpace(nguoiDung.NgaySinh.ToString()))
            {
                throw new Exception("Ngày sinh không được để trống");
            }
            if (String.IsNullOrWhiteSpace(nguoiDung.DiaChi.ToString()))
            {
                throw new Exception("Địa chỉ không được để trống");
            }
            if (String.IsNullOrWhiteSpace(nguoiDung.GioiTinh.ToString()))
            {
                throw new Exception("Giới tính không được để trống");
            }
            if (String.IsNullOrWhiteSpace(nguoiDung.DanTocId.ToString()))
            {
                throw new Exception("Dân tộc không được để trống");
            }

            if (!String.IsNullOrWhiteSpace(nguoiDung.Email) && _context.NguoiDungs.Any(item => item.Email == nguoiDung.Email))
            {
                throw new Exception("Email đã tồn tại");
            }

            if (!String.IsNullOrWhiteSpace(nguoiDung.SoDienThoai) && _context.NguoiDungs.Any(item => item.SoDienThoai == nguoiDung.SoDienThoai))
            {
                throw new Exception("Số điện thoại đã tồn tại");
            }

            user.DanTocId = nguoiDung.DanTocId;
            user.DiaChi = nguoiDung.DiaChi;
            user.Status = nguoiDung.Status;
            user.Email = nguoiDung.Email;
            user.SoDienThoai = nguoiDung.SoDienThoai;
            user.Propeties = nguoiDung.Propeties;
            user.HoTen = nguoiDung.HoTen;
            user.NgaySinh = nguoiDung.NgaySinh;

            _context.NguoiDungs.Update(nguoiDung);
            _context.SaveChanges();

            return new JsonResult(nguoiDung);
        }

        public string RevertUserName(string username)
        {
            string nameRevert = "";
            var NameSplit = username.Split(' ');
            nameRevert = RemoveSign4VietnameseString(NameSplit[NameSplit.Length - 1]).ToLower();
            for (int i = 0; i < NameSplit.Length - 1; i++)
            {
                nameRevert += NameSplit[i].Substring(0, 1).ToLower();
            }
            List<int> nameId = new List<int>();
            foreach (var nguoiDung in _context.NguoiDungs)
            {
                if (nguoiDung.Username.StartsWith(nameRevert))
                {
                    var ktra = nguoiDung.Username.Substring(nameRevert.Length, nguoiDung.Username.Length - nameRevert.Length);
                    int number;
                    if (ktra == "" || ktra == null)
                    {
                        nameId.Add(0);
                    }
                    else
                    {
                        if (int.TryParse(nguoiDung.Username.Substring(nameRevert.Length, nguoiDung.Username.Length - nameRevert.Length), out number))
                        {
                            if (number != 0)
                            {
                                nameId.Add(number);
                            }
                        }

                    }
                }
            }
            if (nameId.Count > 0)
            {
                int max = nameId[0];
                foreach (int id in nameId)
                {
                    if (id >= max)
                    {
                        max = id;
                    }
                }
                nameRevert += (max + 1).ToString();
            }
            return nameRevert;
        }


        string HashPassword(string password)
        {
            if (String.IsNullOrWhiteSpace(password))
            {
                password = "hb@2024";
            }
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            data = System.Security.Cryptography.MD5.Create().ComputeHash(data);
            return Convert.ToBase64String(data);
        }

        List<NguoiDung> nguoiDungInLop(List<ChiTietLop> chiTietLops)
        {
            List<NguoiDung> nguoiDung = new List<NguoiDung>();
            for (int i = 0; i < chiTietLops.Count; i++)
            {
                var nguoidung = _context.NguoiDungs.Where(item => item.Username == chiTietLops[i].Username).FirstOrDefault();
                if (nguoidung != null)
                {
                    nguoiDung.Add(nguoidung);
                }
            }

            return nguoiDung;
        }

        public async Task<ActionResult<NguoiDung>> LayThongTinTaiKhoanDangNhap(string username)
        {
            NguoiDung nguoiDung = new NguoiDung();
            nguoiDung = await _context.NguoiDungs.FirstOrDefaultAsync(item => item.Username == username);
            return nguoiDung;
        }
    }
}

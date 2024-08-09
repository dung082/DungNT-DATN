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
            if (String.IsNullOrWhiteSpace(nguoiDungDto.TonGiaoId.ToString()))
            {
                throw new Exception("Mã tôn giáo không được để trống");
            }
            if (String.IsNullOrWhiteSpace(nguoiDungDto.UserType.ToString()))
            {
                throw new Exception("Loại tài khoản không được để trống");
            }
            //if (String.IsNullOrWhiteSpace(nguoiDungDto.DanTocId.ToString()))
            //{
            //    throw new Exception("Dân tộc không được để trống");
            //}

            var usernameRevert = RevertUserName(nguoiDungDto.HoTen, nguoiDungDto.UserType);


            var emailReverst = usernameRevert + "@thcshb.edu.vn";

            if (_context.NguoiDungs.Any(item => item.Email == emailReverst))
            {
                throw new Exception("Email đã tồn tại");
            }

            if (!String.IsNullOrWhiteSpace(nguoiDungDto.SoDienThoai) && _context.NguoiDungs.Any(item => item.SoDienThoai == nguoiDungDto.SoDienThoai))
            {
                throw new Exception("Số điện thoại đã tồn tại");
            }

            if (!String.IsNullOrWhiteSpace(nguoiDungDto.DanTocId.ToString()) && !_context.DanTocs.Any(item => item.Id == nguoiDungDto.DanTocId))
            {
                throw new Exception("Mã dân tộc không tồn tại");
            }

            if (!String.IsNullOrWhiteSpace(nguoiDungDto.TonGiaoId.ToString()) && !_context.TonGiaos.Any(item => item.Id == nguoiDungDto.TonGiaoId))
            {
                throw new Exception("Mã tôn giáo không tồn tại");
            }

            if (nguoiDungDto.UserType == 2)
            {
                if (String.IsNullOrWhiteSpace(nguoiDungDto.KhoaHocId.ToString()))
                {
                    throw new Exception("Khóa học không được để trống");
                }
                if (!String.IsNullOrWhiteSpace(nguoiDungDto.KhoaHocId.ToString()) && !_context.KhoaHocs.Any(item => item.Id == nguoiDungDto.KhoaHocId))
                {
                    throw new Exception("Khóa học không tồn tại");
                }
                if (String.IsNullOrWhiteSpace(nguoiDungDto.HoTenCha) || String.IsNullOrWhiteSpace(nguoiDungDto.HoTenMe))
                {
                    throw new Exception("Vui lòng điền thông tin cha mẹ");
                }
                else
                {
                    if (!String.IsNullOrWhiteSpace(nguoiDungDto.HoTenCha))
                    {
                        if (String.IsNullOrWhiteSpace(nguoiDungDto.DanTocIdCha.ToString()))
                        {
                            throw new Exception("Mã dân tộc của cha không được để trống");
                        }
                        if (String.IsNullOrWhiteSpace(nguoiDungDto.TonGiaoIdCha.ToString()))
                        {
                            throw new Exception("Mã tôn giáo của không được để trống");
                        }
                        if (String.IsNullOrWhiteSpace(nguoiDungDto.NamSinhCha.ToString()))
                        {
                            throw new Exception("Năm sinh cha không được để trống");
                        }
                        if (String.IsNullOrWhiteSpace(nguoiDungDto.DiaChiCha.ToString()))
                        {
                            throw new Exception("Địa chỉ của cha không được để trống");
                        }
                        if (String.IsNullOrWhiteSpace(nguoiDungDto.SoDienThoaiCha.ToString()))
                        {
                            throw new Exception("Mã dân tộc của cha không được để trống");
                        }
                        if (!String.IsNullOrWhiteSpace(nguoiDungDto.DanTocIdCha.ToString()) && !_context.DanTocs.Any(item => item.Id == nguoiDungDto.DanTocIdCha))
                        {
                            throw new Exception("Mã dân tộc của cha không tồn tại");
                        }

                        if (!String.IsNullOrWhiteSpace(nguoiDungDto.TonGiaoIdCha.ToString()) && !_context.TonGiaos.Any(item => item.Id == nguoiDungDto.TonGiaoIdCha))
                        {
                            throw new Exception("Mã tôn giáo của cha không tồn tại");
                        }
                    }
                    if (!String.IsNullOrWhiteSpace(nguoiDungDto.HoTenMe))
                    {
                        if (String.IsNullOrWhiteSpace(nguoiDungDto.DanTocIdMe.ToString()))
                        {
                            throw new Exception("Mã dân tộc của mẹ không được để trống");
                        }
                        if (String.IsNullOrWhiteSpace(nguoiDungDto.TonGiaoIdMe.ToString()))
                        {
                            throw new Exception("Mã tôn giáo của mẹ không được để trống");
                        }
                        if (String.IsNullOrWhiteSpace(nguoiDungDto.NamSinhMe.ToString()))
                        {
                            throw new Exception("Năm sinh mẹ không được để trống");
                        }
                        if (String.IsNullOrWhiteSpace(nguoiDungDto.DiaChiMe.ToString()))
                        {
                            throw new Exception("Địa chỉ của mẹ không được để trống");
                        }
                        if (String.IsNullOrWhiteSpace(nguoiDungDto.SoDienThoaiMe.ToString()))
                        {
                            throw new Exception("Mã dân tộc của mẹ không được để trống");
                        }
                        if (!String.IsNullOrWhiteSpace(nguoiDungDto.DanTocIdMe.ToString()) && !_context.DanTocs.Any(item => item.Id == nguoiDungDto.DanTocIdMe))
                        {
                            throw new Exception("Mã dân tộc của mẹ không tồn tại");
                        }

                        if (!String.IsNullOrWhiteSpace(nguoiDungDto.TonGiaoIdMe.ToString()) && !_context.TonGiaos.Any(item => item.Id == nguoiDungDto.TonGiaoIdMe))
                        {
                            throw new Exception("Mã tôn giáo của mẹ không tồn tại");
                        }
                    }
                }
            }
            else if (nguoiDungDto.UserType == 1)
            {
                if (String.IsNullOrEmpty(nguoiDungDto.CCCD))
                {
                    throw new Exception("Căn cước công dân của giáo viên không được để trống");
                }
                else
                {
                    if (_context.NguoiDungs.FirstOrDefault(item => item.CCCD == nguoiDungDto.CCCD) != null)
                    {
                        throw new Exception("Mã căn cước công dân đã tồn tại");
                    }
                }
            }


            var passwordHash = HashPassword("");
            NguoiDung nguoiDung = new NguoiDung()
            {
                Id = new Guid(),
                HoTen = nguoiDungDto.HoTen,
                DiaChi = nguoiDungDto.DiaChi,
                DanTocId = nguoiDungDto.DanTocId,
                KhoaHocId = nguoiDungDto.KhoaHocId,
                GioiTinh = nguoiDungDto.GioiTinh,
                NgaySinh = nguoiDungDto.NgaySinh,
                Email = emailReverst,
                SoDienThoai = nguoiDungDto.SoDienThoai,
                Propeties = nguoiDungDto.Propeties,
                UserType = nguoiDungDto.UserType,
                Username = usernameRevert,
                Status = 1,
                TonGiaoId = nguoiDungDto.TonGiaoId,
                CCCD = nguoiDungDto.CCCD,
                HoTenCha = nguoiDungDto.HoTenCha,
                NamSinhCha = nguoiDungDto.NamSinhCha,
                DanTocIdCha = nguoiDungDto.DanTocIdCha,
                DiaChiCha = nguoiDungDto.DiaChiCha,
                SoDienThoaiCha = nguoiDungDto.SoDienThoaiCha,
                TonGiaoIdCha = nguoiDungDto.TonGiaoIdCha,
                HoTenMe = nguoiDungDto.HoTenMe,
                NamSinhMe = nguoiDungDto.NamSinhMe,
                DanTocIdMe = nguoiDungDto.DanTocIdMe,
                DiaChiMe = nguoiDungDto.DiaChiMe,
                SoDienThoaiMe = nguoiDungDto.SoDienThoaiMe,
                TonGiaoIdMe = nguoiDungDto.TonGiaoIdMe,
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
            if (user == null)
            {
                throw new Exception("Không tìm thấy người dùng được sửa thông tin");
            }
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
            if (String.IsNullOrWhiteSpace(nguoiDung.TonGiaoId.ToString()))
            {
                throw new Exception("Tôn giáo không được để trống");
            }

            if (!String.IsNullOrWhiteSpace(nguoiDung.Email) && _context.NguoiDungs.Any(item => item.Email == nguoiDung.Email && item.Id != nguoiDung.Id))
            {
                throw new Exception("Email đã tồn tại");
            }

            if (!String.IsNullOrWhiteSpace(nguoiDung.SoDienThoai) && _context.NguoiDungs.Any(item => item.SoDienThoai == nguoiDung.SoDienThoai && item.Id != nguoiDung.Id))
            {
                throw new Exception("Số điện thoại đã tồn tại");

            }

            if (!String.IsNullOrWhiteSpace(nguoiDung.TonGiaoId.ToString()) && !_context.TonGiaos.Any(item => item.Id == nguoiDung.TonGiaoId))
            {
                throw new Exception("Mã tôn giáo không tồn tại");
            }

            if (nguoiDung.UserType == 2)
            {
                if (String.IsNullOrWhiteSpace(nguoiDung.KhoaHocId.ToString()))
                {
                    throw new Exception("Khóa học không được để trống");
                }
                if (!String.IsNullOrWhiteSpace(nguoiDung.KhoaHocId.ToString()) && !_context.KhoaHocs.Any(item => item.Id == nguoiDung.KhoaHocId))
                {
                    throw new Exception("Khóa học không tồn tại");
                }
                if (String.IsNullOrWhiteSpace(nguoiDung.HoTenCha) || String.IsNullOrWhiteSpace(nguoiDung.HoTenMe))
                {
                    throw new Exception("Vui lòng điền thông tin cha mẹ");
                }
                else
                {
                    if (!String.IsNullOrWhiteSpace(nguoiDung.HoTenCha))
                    {
                        if (String.IsNullOrWhiteSpace(nguoiDung.DanTocIdCha.ToString()))
                        {
                            throw new Exception("Mã dân tộc của cha không được để trống");
                        }
                        if (String.IsNullOrWhiteSpace(nguoiDung.TonGiaoIdCha.ToString()))
                        {
                            throw new Exception("Mã tôn giáo của không được để trống");
                        }
                        if (String.IsNullOrWhiteSpace(nguoiDung.NamSinhCha.ToString()))
                        {
                            throw new Exception("Năm sinh cha không được để trống");
                        }
                        if (String.IsNullOrWhiteSpace(nguoiDung.DiaChiCha))
                        {
                            throw new Exception("Địa chỉ của cha không được để trống");
                        }
                        if (String.IsNullOrWhiteSpace(nguoiDung.SoDienThoaiCha))
                        {
                            throw new Exception("Số điện thoại của cha không được để trống");
                        }
                        if (!String.IsNullOrWhiteSpace(nguoiDung.DanTocIdCha.ToString()) && !_context.DanTocs.Any(item => item.Id == nguoiDung.DanTocIdCha))
                        {
                            throw new Exception("Mã dân tộc của cha không tồn tại");
                        }

                        if (!String.IsNullOrWhiteSpace(nguoiDung.TonGiaoIdCha.ToString()) && !_context.TonGiaos.Any(item => item.Id == nguoiDung.TonGiaoIdCha))
                        {
                            throw new Exception("Mã tôn giáo của cha không tồn tại");
                        }
                    }
                    if (!String.IsNullOrWhiteSpace(nguoiDung.HoTenMe))
                    {
                        if (String.IsNullOrWhiteSpace(nguoiDung.DanTocIdMe.ToString()))
                        {
                            throw new Exception("Mã dân tộc của mẹ không được để trống");
                        }
                        if (String.IsNullOrWhiteSpace(nguoiDung.TonGiaoIdMe.ToString()))
                        {
                            throw new Exception("Mã tôn giáo của mẹ không được để trống");
                        }
                        if (String.IsNullOrWhiteSpace(nguoiDung.NamSinhMe.ToString()))
                        {
                            throw new Exception("Năm sinh mẹ không được để trống");
                        }
                        if (String.IsNullOrWhiteSpace(nguoiDung.DiaChiMe))
                        {
                            throw new Exception("Địa chỉ của mẹ không được để trống");
                        }
                        if (String.IsNullOrWhiteSpace(nguoiDung.SoDienThoaiMe))
                        {
                            throw new Exception("Số điện thoại mẹ không được để trống");
                        }
                        if (!String.IsNullOrWhiteSpace(nguoiDung.DanTocIdMe.ToString()) && !_context.DanTocs.Any(item => item.Id == nguoiDung.DanTocIdMe))
                        {
                            throw new Exception("Mã dân tộc của mẹ không tồn tại");
                        }

                        if (!String.IsNullOrWhiteSpace(nguoiDung.TonGiaoIdMe.ToString()) && !_context.TonGiaos.Any(item => item.Id == nguoiDung.TonGiaoIdMe))
                        {
                            throw new Exception("Mã tôn giáo của mẹ không tồn tại");
                        }
                    }
                }
            }
            else if (nguoiDung.UserType == 1)
            {
                if (String.IsNullOrEmpty(nguoiDung.CCCD))
                {
                    throw new Exception("Căn cước công dân của giáo viên không được để trống");
                }
                else
                {
                    if (_context.NguoiDungs.FirstOrDefault(item => item.CCCD == nguoiDung.CCCD && item.Id != nguoiDung.Id) != null)
                    {
                        throw new Exception("Mã căn cước công dân đã tồn tại");
                    }
                }
            }


            user.DanTocId = nguoiDung.DanTocId;
            user.DiaChi = nguoiDung.DiaChi;
            user.Status = nguoiDung.Status;
            user.SoDienThoai = nguoiDung.SoDienThoai;
            user.Propeties = nguoiDung.Propeties;
            user.HoTen = nguoiDung.HoTen;
            user.NgaySinh = nguoiDung.NgaySinh;
            user.KhoaHocId = nguoiDung.KhoaHocId;
            user.Avatar = nguoiDung.Avatar;
            user.CCCD = nguoiDung.CCCD;
            user.HoTenCha = nguoiDung.HoTenCha;
            user.NamSinhCha = nguoiDung.NamSinhCha;
            user.DanTocIdCha = nguoiDung.DanTocIdCha;
            user.DiaChiCha = nguoiDung.DiaChiCha;
            user.SoDienThoaiCha = nguoiDung.SoDienThoaiCha;
            user.TonGiaoIdCha = nguoiDung.TonGiaoIdCha;
            user.HoTenMe = nguoiDung.HoTenMe;
            user.NamSinhMe = nguoiDung.NamSinhMe;
            user.DanTocIdMe = nguoiDung.DanTocIdMe;
            user.DiaChiMe = nguoiDung.DiaChiMe;
            user.SoDienThoaiMe = nguoiDung.SoDienThoaiMe;
            user.TonGiaoIdMe = nguoiDung.TonGiaoIdMe;

            _context.NguoiDungs.Update(user);
            _context.SaveChanges();

            return new JsonResult(nguoiDung);
        }

        public string RevertUserName(string username, int userType)
        {
            string nameRevert = "";
            var NameSplit = username.Split(' ');
            nameRevert = RemoveSign4VietnameseString(NameSplit[NameSplit.Length - 1]).ToLower();
            for (int i = 0; i < NameSplit.Length - 1; i++)
            {
                nameRevert += RemoveSign4VietnameseString(NameSplit[i].Substring(0, 1).ToLower()).ToLower();
            }
            if (userType == 0)
            {
                nameRevert = @"admin_truong_" + nameRevert;
            }
            else if (userType == 1)
            {
                nameRevert = @"gv_" + nameRevert;
            }
            else if (userType == 2)
            {
                nameRevert = @"hs_" + nameRevert;
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

        public async Task<ActionResult> LayThongTinNguoiDung(Guid id)
        {
            string namhoc = "";
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            if (month >= 10)
            {
                namhoc = year + "-" + (year + 1);
            }
            else
            {
                namhoc = (year - 1) + "-" + year;
            }
            if (String.IsNullOrWhiteSpace(id.ToString()))
            {
                throw new Exception("Mã người dùng không được để trống");
            }
            NguoiDung nguoiDung = await _context.NguoiDungs.FirstOrDefaultAsync(item => item.Id == id);
            if (nguoiDung == null)
            {
                throw new Exception("Không tìm thấy người dùng");
            }
            var dantoc = await _context.DanTocs.FirstOrDefaultAsync(item => item.Id == nguoiDung.DanTocId);
            var tongiao = await _context.TonGiaos.FirstOrDefaultAsync(item => item.Id == nguoiDung.TonGiaoId);
            var khoahoc = await _context.KhoaHocs.FirstOrDefaultAsync(item => item.Id == nguoiDung.KhoaHocId);
            var dantocCha = await _context.DanTocs.FirstOrDefaultAsync(item => item.Id == nguoiDung.DanTocIdCha);
            var tongiaoCha = await _context.TonGiaos.FirstOrDefaultAsync(item => item.Id == nguoiDung.TonGiaoIdCha);
            var dantocMe = await _context.DanTocs.FirstOrDefaultAsync(item => item.Id == nguoiDung.DanTocIdMe);
            var tongiaoMe = await _context.TonGiaos.FirstOrDefaultAsync(item => item.Id == nguoiDung.TonGiaoIdMe);
            var ctl = await _context.ChiTietLops.FirstOrDefaultAsync(item => item.NamHoc == namhoc && item.Username == nguoiDung.Username);
            var lop = new Lop();
            if (ctl != null)
            {
                lop = await _context.Lops.FirstOrDefaultAsync(item => item.Id == ctl.LopId);
            }

            ThongTinNguoiDungDto thongTinNguoiDung = new ThongTinNguoiDungDto
            {
                Id = nguoiDung.Id,
                Username = nguoiDung.Username,
                Status = nguoiDung.Status,
                HoTen = nguoiDung.HoTen,
                NgaySinh = nguoiDung.NgaySinh,
                DiaChi = nguoiDung.DiaChi,
                GioiTinh = nguoiDung.GioiTinh,
                SoDienThoai = nguoiDung.SoDienThoai,
                UserType = nguoiDung.UserType,
                Email = nguoiDung.Email,
                Propeties = nguoiDung.Propeties,
                DanTocId = nguoiDung.DanTocId,
                TenDanToc = dantoc != null ? dantoc.TenDanToc : "",
                TonGiaoId = nguoiDung.TonGiaoId,
                TenTonGiao = tongiao != null ? tongiao.TenTonGiao : "",
                NamHocIdHienTai = namhoc,
                LopIdHienTai = lop != null ? lop.Id : null,
                MaLopHienTai = lop != null ? lop.MaLop : "",
                TenLopHienTai = lop != null ? lop.TenLop : "",
                KhoiHoc = lop.KhoiHoc,
                KhoaHocId = nguoiDung.KhoaHocId,
                TenKhoaHoc = khoahoc != null ? khoahoc.TenKhoaHoc : "",
                Avatar = nguoiDung.Avatar,
                CCCD = nguoiDung.CCCD,
                HoTenCha = nguoiDung.HoTenCha,
                NamSinhCha = nguoiDung.NamSinhCha,
                DiaChiCha = nguoiDung.DiaChiCha,
                DanTocIdCha = nguoiDung.DanTocIdCha,
                TenDanTocCha = dantocCha != null ? dantocCha.TenDanToc : "",
                TonGiaoIdCha = nguoiDung.TonGiaoIdCha,
                TenTonGiaoCha = tongiaoCha != null ? tongiaoCha.TenTonGiao : "",
                HoTenMe = nguoiDung.HoTenMe,
                NamSinhMe = nguoiDung.NamSinhMe,
                DiaChiMe = nguoiDung.DiaChiMe,
                DanTocIdMe = nguoiDung.DanTocIdMe,
                TenDanTocMe = dantocMe != null ? dantocMe.TenDanToc : "",
                TonGiaoIdMe = nguoiDung.TonGiaoIdMe,
                SoDienThoaiCha = nguoiDung.SoDienThoaiCha,
                SoDienThoaiMe = nguoiDung.SoDienThoaiMe,
                TenTonGiaoMe = tongiaoMe != null ? tongiaoMe.TenTonGiao : "",
            };
            return new JsonResult(thongTinNguoiDung);
        }

        public async Task<ActionResult> LayTatCaHocSinh()
        {
            string namhoc = "";
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            if (month >= 10)
            {
                namhoc = year + "-" + (year + 1);
            }
            else
            {
                namhoc = (year - 1) + "-" + year;
            }
            List<ThongTinNguoiDungDto> listNguoiDung = new List<ThongTinNguoiDungDto>();
            var lstHS = await _context.NguoiDungs.Where(i => i.UserType == 2).ToListAsync();
            foreach (var item in lstHS)
            {
                var dantoc = await _context.DanTocs.FirstOrDefaultAsync(i => i.Id == item.DanTocId);
                var tongiao = await _context.TonGiaos.FirstOrDefaultAsync(i => i.Id == item.TonGiaoId);
                var khoahoc = await _context.KhoaHocs.FirstOrDefaultAsync(i => i.Id == item.KhoaHocId);
                var dantocCha = await _context.DanTocs.FirstOrDefaultAsync(i => i.Id == item.DanTocIdCha);
                var tongiaoCha = await _context.TonGiaos.FirstOrDefaultAsync(i => i.Id == item.TonGiaoIdCha);
                var dantocMe = await _context.DanTocs.FirstOrDefaultAsync(i => i.Id == item.DanTocIdMe);
                var tongiaoMe = await _context.TonGiaos.FirstOrDefaultAsync(i => i.Id == item.TonGiaoIdMe);
                var ctl = await _context.ChiTietLops.FirstOrDefaultAsync(i => i.NamHoc == namhoc && item.Username == item.Username);
                var lop = new Lop();
                if (ctl != null)
                {
                    lop = await _context.Lops.FirstOrDefaultAsync(item => item.Id == ctl.LopId);
                }

                ThongTinNguoiDungDto thongTinNguoiDung = new ThongTinNguoiDungDto
                {
                    Id = item.Id,
                    Username = item.Username,
                    Status = item.Status,
                    HoTen = item.HoTen,
                    NgaySinh = item.NgaySinh,
                    DiaChi = item.DiaChi,
                    GioiTinh = item.GioiTinh,
                    SoDienThoai = item.SoDienThoai,
                    UserType = item.UserType,
                    Email = item.Email,
                    Propeties = item.Propeties,
                    DanTocId = item.DanTocId,
                    TenDanToc = dantoc != null ? dantoc.TenDanToc : "",
                    TonGiaoId = item.TonGiaoId,
                    TenTonGiao = tongiao != null ? tongiao.TenTonGiao : "",
                    NamHocIdHienTai = namhoc,
                    LopIdHienTai = lop != null ? lop.Id : null,
                    MaLopHienTai = lop != null ? lop.MaLop : "",
                    TenLopHienTai = lop != null ? lop.TenLop : "",
                    KhoiHoc = lop.KhoiHoc,
                    KhoaHocId = item.KhoaHocId,
                    TenKhoaHoc = khoahoc != null ? khoahoc.TenKhoaHoc : "",
                    Avatar = item.Avatar,
                    CCCD = item.CCCD,
                    HoTenCha = item.HoTenCha,
                    NamSinhCha = item.NamSinhCha,
                    DiaChiCha = item.DiaChiCha,
                    DanTocIdCha = item.DanTocIdCha,
                    TenDanTocCha = dantocCha != null ? dantocCha.TenDanToc : "",
                    TonGiaoIdCha = item.TonGiaoIdCha,
                    TenTonGiaoCha = tongiaoCha != null ? tongiaoCha.TenTonGiao : "",
                    HoTenMe = item.HoTenMe,
                    NamSinhMe = item.NamSinhMe,
                    DiaChiMe = item.DiaChiMe,
                    DanTocIdMe = item.DanTocIdMe,
                    TenDanTocMe = dantocMe != null ? dantocMe.TenDanToc : "",
                    TonGiaoIdMe = item.TonGiaoIdMe,
                    SoDienThoaiCha = item.SoDienThoaiCha,
                    SoDienThoaiMe = item.SoDienThoaiMe,
                    TenTonGiaoMe = tongiaoMe != null ? tongiaoMe.TenTonGiao : "",
                };
                listNguoiDung.Add(thongTinNguoiDung);
            }
            listNguoiDung = listNguoiDung.OrderBy(u => u.HoTen.Split()[u.HoTen.Split().Length - 1]).ToList();
            return new JsonResult(listNguoiDung);
        }
    }
}

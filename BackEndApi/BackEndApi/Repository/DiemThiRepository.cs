using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ExceptionServices;

namespace BackEndApi.Repository
{
    public class DiemThiRepository : IDiemThiRepository
    {
        public ApplicationDbContext _context { get; set; }

        public DiemThiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> LayDiemThi(int type, string? username, Guid? kyThiId)
        {
            DiemThi diemthi = new DiemThi();
            List<DiemThi> lstDiemThi = new List<DiemThi>();
            
            List<DiemThiDtoView> lstDiemThiView = new List<DiemThiDtoView>();
            Lop lop = new Lop();
            KyThi kythi = new KyThi();
            KyHoc kyhoc = new KyHoc();
            List<ChiTietLop> lstHs = new List<ChiTietLop>();
            var listKyThi = await _context.KyThis.ToListAsync();
            if (type == 0)
            {
                if (username == null)
                {
                    throw new Exception("Bạn phải nhập tên tài khoản cần xem điểm thi");
                }

                if (kyThiId == null)
                {
                    //kythi = await _context.KyThis.FirstOrDefaultAsync(item => item.NgayKetThuc < DateTime.Now);
                    kythi = TimKyThiGanNhat(DateTime.Now, listKyThi);
                    diemthi = await _context.DiemThis.FirstOrDefaultAsync(item => item.Username == username && item.KyThiId == kythi.Id);

                }
                else
                {
                    kythi = await _context.KyThis.FirstOrDefaultAsync(item => item.Id == kyThiId);
                    diemthi = await _context.DiemThis.FirstOrDefaultAsync(item => item.Username == username && item.KyThiId == kyThiId);
                }
                if (diemthi == null)
                {
                    throw new Exception($"Chưa có điểm của bạn ở kỳ thi {kythi.TenKyThi.Split("-")[kythi.TenKyThi.Split("-").Length - 1].ToLower()}");
                }
                var hs =await _context.NguoiDungs.FirstOrDefaultAsync(item => item.Username == username);
                DiemThiDtoView diemthiView = new DiemThiDtoView()
                {
                    Id = diemthi.Id,
                    Username = username,
                    HoTen = hs.HoTen,
                    LopId = diemthi.LopId,
                    diemMonToan = diemthi.diemMonToan,
                    diemMonVan = diemthi.diemMonVan,
                    diemNgoaiNgu = diemthi.diemNgoaiNgu,
                    diemVatLy = diemthi.diemVatLy,
                    diemHoaHoc = diemthi.diemHoaHoc,
                    diemSinhHoc = diemthi.diemSinhHoc,
                    diemLichSu = diemthi.diemLichSu,
                    diemDiaLi = diemthi.diemDiaLi,
                    diemGDCD = diemthi.diemGDCD,
                };
                lop = await _context.Lops.FirstOrDefaultAsync(item => item.Id == diemthi.LopId);
                kyhoc = await _context.KyHocs.FirstOrDefaultAsync(item => item.Id == kythi.KyHocId);

                var result = new
                {
                    kythi = kythi,
                    lop = lop,
                    namhoc = kyhoc.NamHoc,
                    diemthi = diemthiView,
                };
                return new JsonResult(result);
            }
            else if (type == 1)
            {

                if (kyThiId == null)
                {
                    //kythi = await _context.KyThis.FirstOrDefaultAsync(item => item.NgayKetThuc <= DateTime.Now);
                    kythi = TimKyThiGanNhat(DateTime.Now, listKyThi);
                    diemthi = await _context.DiemThis.FirstOrDefaultAsync(item => item.Username == username && item.KyThiId == kythi.Id);
                    if (diemthi == null)
                    {
                        throw new Exception($"Chưa có điểm của bạn ở kỳ thi {kythi.TenKyThi.Split("-")[kythi.TenKyThi.Split("-").Length - 1].ToLower()}");
                    }
                    kyhoc = await _context.KyHocs.FirstOrDefaultAsync(item => item.Id == kythi.KyHocId);
                    lstHs = await _context.ChiTietLops.Where(item => item.LopId == diemthi.LopId && item.NamHoc == kyhoc.NamHoc).ToListAsync();
                    foreach (var item in lstHs)
                    {
                        var diemThi = await _context.DiemThis.FirstOrDefaultAsync(item1 => item1.Username == item.Username && item1.KyThiId == kythi.Id);
                        if (diemThi != null)
                        {
                            var hsnew = await _context.NguoiDungs.FirstOrDefaultAsync(item2 => item2.Username == item.Username);
                            DiemThiDtoView diemthiView = new DiemThiDtoView()
                            {
                                Id = diemthi.Id,
                                Username = item.Username,
                                HoTen = hsnew.HoTen,
                                LopId = diemthi.LopId,
                                diemMonToan = diemthi.diemMonToan,
                                diemMonVan = diemthi.diemMonVan,
                                diemNgoaiNgu = diemthi.diemNgoaiNgu,
                                diemVatLy = diemthi.diemVatLy,
                                diemHoaHoc = diemthi.diemHoaHoc,
                                diemSinhHoc = diemthi.diemSinhHoc,
                                diemLichSu = diemthi.diemLichSu,
                                diemDiaLi = diemthi.diemDiaLi,
                                diemGDCD = diemthi.diemGDCD,
                            };
                            lstDiemThiView.Add(diemthiView);
                        }
                    }
                }
                else
                {
                    kythi = await _context.KyThis.FirstOrDefaultAsync(item => item.Id == kyThiId);
                    diemthi = await _context.DiemThis.FirstOrDefaultAsync(item => item.Username == username && item.KyThiId == kyThiId);
                    if (diemthi == null)
                    {
                        throw new Exception($"Chưa có điểm của bạn ở kỳ thi {kythi.TenKyThi.Split("-")[kythi.TenKyThi.Split("-").Length - 1].ToLower()}");

                    }
                    kyhoc = await _context.KyHocs.FirstOrDefaultAsync(item => item.Id == kythi.KyHocId);
                    lstHs = await _context.ChiTietLops.Where(item => item.LopId == diemthi.LopId && item.NamHoc == kyhoc.NamHoc).ToListAsync();
                    foreach (var item in lstHs)
                    {
                        var diemThi = await _context.DiemThis.FirstOrDefaultAsync(item1 => item1.Username == item.Username && item1.KyThiId == kythi.Id);
                        if (diemThi != null)
                        {
                            var hsnew = await _context.NguoiDungs.FirstOrDefaultAsync(item2 => item2.Username == item.Username);
                            DiemThiDtoView diemthiView = new DiemThiDtoView()
                            {
                                Id = diemthi.Id,
                                Username = item.Username,
                                HoTen = hsnew.HoTen,
                                LopId = diemthi.LopId,
                                diemMonToan = diemthi.diemMonToan,
                                diemMonVan = diemthi.diemMonVan,
                                diemNgoaiNgu = diemthi.diemNgoaiNgu,
                                diemVatLy = diemthi.diemVatLy,
                                diemHoaHoc = diemthi.diemHoaHoc,
                                diemSinhHoc = diemthi.diemSinhHoc,
                                diemLichSu = diemthi.diemLichSu,
                                diemDiaLi = diemthi.diemDiaLi,
                                diemGDCD = diemthi.diemGDCD,
                            };
                            lstDiemThiView.Add(diemthiView);
                        }
                    }
                }

                var lstDiemThiViewSort = lstDiemThiView.OrderBy(u => u.HoTen.Split()[u.HoTen.Split().Length - 1]).ToList();

                var result = new
                {
                    kythi = kythi,
                    lop = lop,
                    namhoc = kyhoc.NamHoc,
                    lstDiemThi = lstDiemThiViewSort,
                };
                return new JsonResult(result);
            }
            return new JsonResult(true);

        }

        public async Task<ActionResult> ThemDiemThi(DiemThiDto diemThiDto)
        {
            var kythi = await _context.KyThis.FirstOrDefaultAsync(item => item.Id == diemThiDto.KyThiId);
            if (kythi == null)
            {
                throw new Exception("Kỳ thi không tồn tại");
            }
            var kyhoc = await _context.KyHocs.FirstOrDefaultAsync(item => item.Id == kythi.KyHocId);
            if (kyhoc == null)
            {
                throw new Exception("Kỳ học không tồn tại");
            }
            if (await _context.DiemThis.FirstOrDefaultAsync(item => item.KyThiId == diemThiDto.KyThiId && item.Username == diemThiDto.Username && item.LopId == item.LopId) != null)
            {
                throw new Exception("Điểm thi của bạn đã có trong danh sách");
            }
            var hs = await _context.ChiTietLops.FirstOrDefaultAsync(item => item.NamHoc == kyhoc.NamHoc && item.Username == diemThiDto.Username && item.LopId == diemThiDto.LopId);
            if (hs == null)
            {
                throw new Exception("Không tồn tại học sinh trong lớp ở kỳ học hiện tịa để thêm điểm ");
            }

            DiemThi diemthi = new DiemThi()
            {
                Id = Guid.NewGuid(),
                Username = diemThiDto.Username,
                LopId = diemThiDto.LopId,
                KyThiId = diemThiDto.KyThiId,
                diemMonToan = diemThiDto.diemMonToan,
                diemMonVan = diemThiDto.diemMonVan,
                diemVatLy = diemThiDto.diemVatLy,
                diemHoaHoc = diemThiDto.diemHoaHoc,
                diemSinhHoc = diemThiDto.diemSinhHoc,
                diemLichSu = diemThiDto.diemLichSu,
                diemDiaLi = diemThiDto.diemDiaLi,
                diemGDCD = diemThiDto.diemGDCD,
                diemNgoaiNgu = diemThiDto.diemNgoaiNgu
            };

            _context.DiemThis.Add(diemthi);
            _context.SaveChanges();
            return new JsonResult(diemthi);
        }

        static KyThi TimKyThiGanNhat(DateTime ngayHienTai, List<KyThi> danhSachKyThi)
        {
            KyThi ngayGanNhat = danhSachKyThi[0]; // Giả sử phần tử đầu tiên là ngày gần nhất ban đầu

            foreach (var ngayItem in danhSachKyThi)
            {
                // Tính khoảng cách tuyệt đối giữa ngày hiện tại và Ngay của NgayItem
                TimeSpan khoangCach = ngayItem.NgayKetThuc - ngayHienTai;
                TimeSpan khoangCachGanNhat = ngayGanNhat.NgayKetThuc - ngayHienTai;

                // So sánh khoảng cách, nếu khoảng cách mới nhỏ hơn thì cập nhật NgayItem gần nhất
                if (Math.Abs(khoangCach.Days) < Math.Abs(khoangCachGanNhat.Days))
                {
                    ngayGanNhat = ngayItem;
                }
            }

            return ngayGanNhat;
        }
    }
}


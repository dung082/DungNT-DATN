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

        public async Task<ActionResult> LayDiemThi(int type, string? username, Guid? lopId, Guid? kyThiId)
        {
            DiemThi diemthi = new DiemThi();
            List<DiemThi> lstDiemThi = new List<DiemThi>();
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
                lop = await _context.Lops.FirstOrDefaultAsync(item => item.Id == diemthi.LopId);

                var result = new
                {
                    kythi = kythi,
                    lop = lop,
                    diemthi = diemthi,
                };
                return new JsonResult(result);
            }
            else if (type == 1)
            {
                if (String.IsNullOrWhiteSpace(lopId.ToString()))
                {
                    throw new Exception("Bạn phải chọn lớp cần xem điểm thi");
                }
                lop = await _context.Lops.FirstOrDefaultAsync(item => item.Id == lopId);
                if (kyThiId == null)
                {
                    //kythi = await _context.KyThis.FirstOrDefaultAsync(item => item.NgayKetThuc <= DateTime.Now);
                    kythi = TimKyThiGanNhat(DateTime.Now, listKyThi);
                    kyhoc = await _context.KyHocs.FirstOrDefaultAsync(item => item.Id == kythi.KyHocId);
                    lstHs = await _context.ChiTietLops.Where(item => item.LopId == lopId && item.NamHoc == kyhoc.NamHoc).ToListAsync();
                    foreach (var item in lstHs)
                    {
                        var diemThi = await _context.DiemThis.FirstOrDefaultAsync(item => username == item.Username && item.KyThiId == kythi.Id);
                        lstDiemThi.Add(diemThi);
                    }
                }
                else
                {
                    kyhoc = await _context.KyHocs.FirstOrDefaultAsync(item => item.Id == kyThiId);
                    lstHs = await _context.ChiTietLops.Where(item => item.LopId == lopId && item.NamHoc == kyhoc.NamHoc).ToListAsync();
                    foreach (var item in lstHs)
                    {
                        var diemThi = await _context.DiemThis.FirstOrDefaultAsync(item => username == item.Username && item.KyThiId == kythi.Id);
                        lstDiemThi.Add(diemThi);
                    }
                }

                var result = new
                {
                    kythi = kythi,
                    lop = lop,
                    lstDiemThi = lstDiemThi,
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


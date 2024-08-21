using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Storage;
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

        public async Task<ActionResult> LayDiemThi(int type, string? username, Guid? kyThiId, Guid? monThiId)
        {
            Lop lop = new Lop();
            KyThi kythi = new KyThi();
            KyHoc kyhoc = new KyHoc();
            MonThi monThi = new MonThi();
            List<ChiTietLop> lstHs = new List<ChiTietLop>();
            List<ChiTietLop> lstHsKhoi = new List<ChiTietLop>();
            DiemThi diemthi = new DiemThi();
            List<DiemThiDtoView> dtview = new List<DiemThiDtoView>();
            var listKyThi = await _context.KyThis.ToListAsync();
            if (type == 0)
            {
                if (String.IsNullOrWhiteSpace(kyThiId.ToString()))
                {
                    kythi = TimKyThiGanNhat(DateTime.Now, listKyThi);
                    kyhoc = await _context.KyHocs.FirstOrDefaultAsync(item => item.Id == kythi.KyHocId);
                    if (kyhoc == null)
                    {
                        throw new Exception("Kỳ học không tồn tại");
                    }
                    diemthi = await _context.DiemThis.FirstOrDefaultAsync(item => item.Username == username && item.KyThiId == kythi.Id);
                    if (diemthi == null)
                    {
                        var ctlops = await _context.ChiTietLops.FirstOrDefaultAsync(item => item.NamHoc == kyhoc.NamHoc && item.Username == username);
                        var lopHoc = await _context.Lops.FirstOrDefaultAsync(item => item.Id == ctlops.LopId);
                        var result = new
                        {
                            lop = lopHoc,
                            kyHoc = kyhoc,
                            kyThi = kythi,
                            MessageError = $"Chưa có điểm của bạn ở kỳ thi {kythi.TenKyThi.Split("-")[kythi.TenKyThi.Split("-").Length - 1].ToLower()}"
                        };

                        return new JsonResult(result);
                        //throw new Exception($"Chưa có điểm của bạn ở kỳ thi {kythi.TenKyThi.Split("-")[kythi.TenKyThi.Split("-").Length - 1].ToLower()}");
                    }
                    else
                    {
                        var lopHienTai = await _context.Lops.FirstOrDefaultAsync(item => item.Id == diemthi.LopId);
                        var diemThi = await _context.DiemThis.Where(item1 => item1.Username == username && item1.KyThiId == kythi.Id).ToListAsync();

                        foreach (var item in diemThi)
                        {
                            var mt = await _context.MonThis.FirstOrDefaultAsync(i => i.Id == item.MonThiId);
                            if (mt != null)
                            {

                                DiemThiDtoView dtDtoNew = new DiemThiDtoView()
                                {
                                    Id = item.Id,
                                    Diem = item.Diem,
                                    LopId = item.LopId,
                                    TenMonThi = mt.TenMonThi,
                                    MaMonThi = mt.MaMonThi,
                                    MonThi = item.MonThiId,
                                    KyThiId = item.KyThiId,
                                    Username = item.Username
                                };
                                dtview.Add(dtDtoNew);
                            }

                        }

                        var result = new
                        {
                            lop = lopHienTai,
                            listDT = dtview,
                            kyHoc = kyhoc,
                            kyThi = kythi,
                            diem = diemthi.Diem
                        };

                        return new JsonResult(result);
                    }
                }
                else
                {
                    kythi = await _context.KyThis.FirstOrDefaultAsync(item => item.Id == kyThiId);
                    kyhoc = await _context.KyHocs.FirstOrDefaultAsync(item => item.Id == kythi.KyHocId);
                    if (kyhoc == null)
                    {
                        throw new Exception("Kỳ học không tồn tại");
                    }
                    diemthi = await _context.DiemThis.FirstOrDefaultAsync(item => item.Username == username && item.KyThiId == kythi.Id);
                    if (diemthi == null)
                    {
                        var ctlops = await _context.ChiTietLops.FirstOrDefaultAsync(item => item.NamHoc == kyhoc.NamHoc && item.Username == username);
                        var lopHoc = await _context.Lops.FirstOrDefaultAsync(item => item.Id == ctlops.LopId);
                        var result = new
                        {
                            lop = lopHoc,
                            kyHoc = kyhoc,
                            kyThi = kythi,
                            MessageError = $"Chưa có điểm của bạn ở kỳ thi {kythi.TenKyThi.Split("-")[kythi.TenKyThi.Split("-").Length - 1].ToLower()}"
                        };

                        return new JsonResult(result);
                        //throw new Exception($"Chưa có điểm của bạn ở kỳ thi {kythi.TenKyThi.Split("-")[kythi.TenKyThi.Split("-").Length - 1].ToLower()}");
                    }
                    else
                    {
                        var lopHienTai = await _context.Lops.FirstOrDefaultAsync(item => item.Id == diemthi.LopId);
                        var diemThi = await _context.DiemThis.Where(item1 => item1.Username == username && item1.KyThiId == kythi.Id).ToListAsync();
                        foreach (var item in diemThi)
                        {
                            var mt = await _context.MonThis.FirstOrDefaultAsync(i => i.Id == item.MonThiId);
                            if (mt != null)
                            {

                                DiemThiDtoView dtDtoNew = new DiemThiDtoView()
                                {
                                    Id = item.Id,
                                    Diem = item.Diem,
                                    LopId = item.LopId,
                                    TenMonThi = mt.TenMonThi,
                                    MaMonThi = mt.MaMonThi,
                                    MonThi = item.MonThiId,
                                    KyThiId = item.KyThiId,
                                    Username = item.Username
                                };
                                dtview.Add(dtDtoNew);
                            }

                        }

                        var result = new
                        {
                            lop = lopHienTai,
                            listDT = dtview,
                            kyHoc = kyhoc,
                            kyThi = kythi,
                            diem = diemthi.Diem
                        };

                        return new JsonResult(result);
                    }
                }
            }
            else
            {

                int diem01Lop = 0;
                int diem12Lop = 0;
                int diem23Lop = 0;
                int diem34Lop = 0;
                int diem45Lop = 0;
                int diem56Lop = 0;
                int diem67Lop = 0;
                int diem78Lop = 0;
                int diem89Lop = 0;
                int diem910Lop = 0;
                int diem01Khoi = 0;
                int diem12Khoi = 0;
                int diem23Khoi = 0;
                int diem34Khoi = 0;
                int diem45Khoi = 0;
                int diem56Khoi = 0;
                int diem67Khoi = 0;
                int diem78Khoi = 0;
                int diem89Khoi = 0;
                int diem910Khoi = 0;
                int diemThiLoaiGioi = 0;
                int diemThiLoaiKha = 0;
                int diemThiLoaiTB = 0;
                int diemThiLoaiYeu = 0;
                int diemThiLoaiKem = 0;
                int diemThiLoaiGioiKhoi = 0;
                int diemThiLoaiKhaKhoi = 0;
                int diemThiLoaiTBKhoi = 0;
                int diemThiLoaiYeuKhoi = 0;
                int diemThiLoaiKemKhoi = 0;
                decimal diemTBlop = 0;
                decimal diemTBKhoi = 0;
                if (String.IsNullOrWhiteSpace(kyThiId.ToString()))
                {
                    kythi = TimKyThiGanNhat(DateTime.Now, listKyThi);
                    kyhoc = await _context.KyHocs.FirstOrDefaultAsync(item => item.Id == kythi.KyHocId);
                    if (kyhoc == null)
                    {
                        throw new Exception("Kỳ học không tồn tại");
                    }
                    diemthi = await _context.DiemThis.FirstOrDefaultAsync(item => item.Username == username && item.KyThiId == kythi.Id);
                    if (diemthi == null)
                    {
                        var ctlops = await _context.ChiTietLops.FirstOrDefaultAsync(item => item.NamHoc == kyhoc.NamHoc && item.Username == username);
                        var lopHoc = await _context.Lops.FirstOrDefaultAsync(item => item.Id == ctlops.LopId);
                        var result = new
                        {
                            lop = lopHoc,
                            kyHoc = kyhoc,
                            kyThi = kythi,
                            MessageError = $"Chưa có điểm của bạn ở kỳ thi {kythi.TenKyThi.Split("-")[kythi.TenKyThi.Split("-").Length - 1].ToLower()}"
                        };

                        return new JsonResult(result);
                        //throw new Exception($"Chưa có điểm của bạn ở kỳ thi {kythi.TenKyThi.Split("-")[kythi.TenKyThi.Split("-").Length - 1].ToLower()}");
                    }
                    lstHs = await _context.ChiTietLops.Where(item => item.LopId == diemthi.LopId && item.NamHoc == kyhoc.NamHoc).ToListAsync();
                    var lopHienTai = await _context.Lops.FirstOrDefaultAsync(item => item.Id == diemthi.LopId);
                    var listLopCungKhoiThi = await _context.Lops.Where(item => item.Khoi == lopHienTai.Khoi && item.KhoiHoc == lopHienTai.KhoiHoc).Select(i => i.Id).ToListAsync();
                    lstHsKhoi = await _context.ChiTietLops.Where(item => listLopCungKhoiThi.Contains(item.LopId) && item.NamHoc == kyhoc.NamHoc).ToListAsync();
                    if (String.IsNullOrWhiteSpace(monThiId.ToString()))
                    {
                        var listDiemThi = await _context.DiemThis.Where(item => item.KyThiId == kythi.Id && item.Username == username).ToListAsync();
                        decimal diemTBMon = 0;
                        decimal diemTBMonLop = 0;
                        decimal diemTBMonKhoi = 0;
                        if (listDiemThi.Count > 0)
                        {
                            foreach (var item in listDiemThi)
                            {
                                diemTBMon += item.Diem;
                            };
                            diemTBMon = System.Math.Round(diemTBMon / listDiemThi.Count, 2);
                        }
                        foreach (var item in lstHs)
                        {
                            decimal diem = 0;
                            var diemThi = await _context.DiemThis.Where(item1 => item1.Username == item.Username && item1.KyThiId == kythi.Id).ToListAsync();
                            if (diemThi.Count > 0)
                            {
                                foreach (var item1 in diemThi)
                                {
                                    diem += item1.Diem;
                                }
                                diem = System.Math.Round(diem / diemThi.Count, 2);
                                if (diem < 4)
                                {
                                    diemThiLoaiKem++;
                                }
                                else if (diem >= 4 && diem < 5.5M)
                                {
                                    diemThiLoaiYeu++;
                                }
                                if (diem >= 5.5M && diem < 7M)
                                {
                                    diemThiLoaiTB++;
                                }
                                if (diem >= 7 && diem < 8.5M)
                                {
                                    diemThiLoaiKha++;
                                }
                                if (diem >= 8.5M && diem < 10)
                                {
                                    diemThiLoaiGioi++;
                                }
                            }
                        }

                        int[] SLDiemThi = [diemThiLoaiGioi, diemThiLoaiKha, diemThiLoaiTB, diemThiLoaiYeu, diemThiLoaiKem];

                        foreach (var item in lstHsKhoi)
                        {
                            decimal diem = 0;
                            var diemThi = await _context.DiemThis.Where(item1 => item1.Username == item.Username && item1.KyThiId == kythi.Id).ToListAsync();
                            if (diemThi.Count > 0)
                            {
                                foreach (var item1 in diemThi)
                                {
                                    diem += item1.Diem;
                                }
                                diem = System.Math.Round(diem / diemThi.Count, 2);
                                if (diem < 4)
                                {
                                    diemThiLoaiKemKhoi++;
                                }
                                else if (diem >= 4 && diem < 5.5M)
                                {
                                    diemThiLoaiYeuKhoi++;
                                }
                                if (diem >= 5.5M && diem < 7M)
                                {
                                    diemThiLoaiTBKhoi++;
                                }
                                if (diem >= 7 && diem < 8.5M)
                                {
                                    diemThiLoaiKhaKhoi++;
                                }
                                if (diem >= 8.5M && diem < 10)
                                {
                                    diemThiLoaiGioiKhoi++;
                                }
                            }
                        }

                        int[] SLDiemThiKhoi = [diemThiLoaiGioiKhoi, diemThiLoaiKhaKhoi, diemThiLoaiTBKhoi, diemThiLoaiYeuKhoi, diemThiLoaiKemKhoi];


                        var result = new
                        {
                            slDiemThiKhoi = SLDiemThiKhoi,
                            slDiemThiLop = SLDiemThi,
                            lop = lopHienTai,
                            listDT = listDiemThi,
                            diemTbMon = diemTBMon,
                            kyHoc = kyhoc,
                            kyThi = kythi,
                            diem = diemthi.Diem
                        };

                        return new JsonResult(result);
                    }
                    else
                    {
                        diemthi = await _context.DiemThis.FirstOrDefaultAsync(item => item.Username == username && item.KyThiId == kythi.Id && item.MonThiId == monThiId);

                        //lop
                        foreach (var item in lstHs)
                        {
                            var diemThi = await _context.DiemThis.FirstOrDefaultAsync(item1 => item1.Username == item.Username && item1.KyThiId == kythi.Id && item1.MonThiId == monThiId);
                            if (diemThi == null)
                            {
                                diem01Lop++;
                            }
                            else
                            {
                                if (0 <= diemThi.Diem && diemThi.Diem < 1)
                                {
                                    diem01Lop++;
                                }
                                else if (1 <= diemThi.Diem && diemThi.Diem < 2)
                                {
                                    diem12Lop++;
                                }
                                else if (2 <= diemThi.Diem && diemThi.Diem < 3)
                                {
                                    diem23Lop++;
                                }
                                else if (3 <= diemThi.Diem && diemThi.Diem < 4)
                                {
                                    diem34Lop++;
                                }
                                else if (4 <= diemThi.Diem && diemThi.Diem < 5)
                                {
                                    diem45Lop++;
                                }
                                else if (5 <= diemThi.Diem && diemThi.Diem < 6)
                                {
                                    diem56Lop++;
                                }
                                else if (6 <= diemThi.Diem && diemThi.Diem < 7)
                                {
                                    diem67Lop++;
                                }
                                else if (7 <= diemThi.Diem && diemThi.Diem < 8)
                                {
                                    diem78Lop++;
                                }
                                else if (8 <= diemThi.Diem && diemThi.Diem < 9)
                                {
                                    diem89Lop++;
                                }
                                else if (9 <= diemThi.Diem && diemThi.Diem <= 10)
                                {
                                    diem910Lop++;
                                }
                                diemTBlop += diemThi.Diem;
                            }
                        }
                        diemTBlop = System.Math.Round(diemTBlop / lstHs.Count, 2);
                        int[] SLdiemTBLop = [diem01Lop, diem12Lop, diem23Lop, diem34Lop, diem45Lop, diem56Lop, diem67Lop, diem78Lop, diem89Lop, diem910Lop];
                        //khoi
                        foreach (var item in lstHsKhoi)
                        {
                            var diemThi = await _context.DiemThis.FirstOrDefaultAsync(item1 => item1.Username == item.Username && item1.KyThiId == kythi.Id && item1.MonThiId == monThiId);
                            if (diemThi == null)
                            {
                                diem01Khoi++;
                            }
                            else
                            {

                                if (0 <= diemThi.Diem && diemThi.Diem < 1)
                                {
                                    diem01Khoi++;
                                }
                                else if (1 <= diemThi.Diem && diemThi.Diem < 2)
                                {
                                    diem12Khoi++;
                                }
                                else if (2 <= diemThi.Diem && diemThi.Diem < 3)
                                {
                                    diem23Khoi++;
                                }
                                else if (3 <= diemThi.Diem && diemThi.Diem < 4)
                                {
                                    diem34Khoi++;
                                }
                                else if (4 <= diemThi.Diem && diemThi.Diem < 5)
                                {
                                    diem45Khoi++;
                                }
                                else if (5 <= diemThi.Diem && diemThi.Diem < 6)
                                {
                                    diem56Khoi++;
                                }
                                else if (6 <= diemThi.Diem && diemThi.Diem < 7)
                                {
                                    diem67Khoi++;
                                }
                                else if (7 <= diemThi.Diem && diemThi.Diem < 8)
                                {
                                    diem78Khoi++;
                                }
                                else if (8 <= diemThi.Diem && diemThi.Diem < 9)
                                {
                                    diem89Khoi++;
                                }
                                else if (9 <= diemThi.Diem && diemThi.Diem <= 10)
                                {
                                    diem910Khoi++;
                                }

                                diemTBKhoi += diemThi.Diem;
                            }
                        }
                        int[] SLdiemTBKhoi = [diem01Khoi, diem12Khoi, diem23Khoi, diem34Khoi, diem45Khoi, diem56Khoi, diem67Khoi, diem78Khoi, diem89Khoi, diem910Khoi];
                        diemTBKhoi = System.Math.Round(diemTBKhoi / lstHsKhoi.Count, 2);
                        var result = new
                        {
                            slDiemTBLop = SLdiemTBLop,
                            slDiemTBKhoi = SLdiemTBKhoi,
                            diemTblop = diemTBlop,
                            diemTbKhoi = diemTBKhoi,
                            lop = lopHienTai,
                            kyThi = kythi,
                            kyHoc = kyhoc,
                            diem = diemthi.Diem,
                        };

                        return new JsonResult(result);
                    }
                }
                else
                {
                    kythi = await _context.KyThis.FirstOrDefaultAsync(item => item.Id == kyThiId);
                    kyhoc = await _context.KyHocs.FirstOrDefaultAsync(item => item.Id == kythi.KyHocId);
                    if (kyhoc == null)
                    {
                        throw new Exception("Kỳ học không tồn tại");
                    }
                    diemthi = await _context.DiemThis.FirstOrDefaultAsync(item => item.Username == username && item.KyThiId == kythi.Id);
                    if (diemthi == null)
                    {
                        var ctlops = await _context.ChiTietLops.FirstOrDefaultAsync(item => item.NamHoc == kyhoc.NamHoc && item.Username == username);
                        var lopHoc = await _context.Lops.FirstOrDefaultAsync(item => item.Id == ctlops.LopId);
                        var result = new
                        {
                            lop = lopHoc,
                            kyHoc = kyhoc,
                            kyThi = kythi,
                            MessageError = $"Chưa có điểm của bạn ở kỳ thi {kythi.TenKyThi.Split("-")[kythi.TenKyThi.Split("-").Length - 1].ToLower()}"
                        };

                        return new JsonResult(result);
                        //throw new Exception($"Chưa có điểm của bạn ở kỳ thi {kythi.TenKyThi.Split("-")[kythi.TenKyThi.Split("-").Length - 1].ToLower()}");
                    }
                    lstHs = await _context.ChiTietLops.Where(item => item.LopId == diemthi.LopId && item.NamHoc == kyhoc.NamHoc).ToListAsync();
                    var lopHienTai1 = await _context.Lops.FirstOrDefaultAsync(item => item.Id == diemthi.LopId);
                    var listLopCungKhoiThi1 = await _context.Lops.Where(item => item.Khoi == lopHienTai1.Khoi && item.KhoiHoc == lopHienTai1.KhoiHoc).Select(i => i.Id).ToListAsync();
                    lstHsKhoi = await _context.ChiTietLops.Where(item => listLopCungKhoiThi1.Contains(item.LopId) && item.NamHoc == kyhoc.NamHoc).ToListAsync();
                    if (String.IsNullOrWhiteSpace(monThiId.ToString()))
                    {
                        var listDiemThi = await _context.DiemThis.Where(item => item.KyThiId == kythi.Id && item.Username == username).ToListAsync();
                        decimal diemTBMon = 0;
                        decimal diemTBMonLop = 0;
                        decimal diemTBMonKhoi = 0;
                        if (listDiemThi.Count > 0)
                        {
                            foreach (var item in listDiemThi)
                            {
                                diemTBMon += item.Diem;
                            };
                            diemTBMon = System.Math.Round(diemTBMon / listDiemThi.Count, 2);
                        }
                        foreach (var item in lstHs)
                        {
                            decimal diem = 0;
                            var diemThi = await _context.DiemThis.Where(item1 => item1.Username == item.Username && item1.KyThiId == kythi.Id).ToListAsync();
                            if (diemThi.Count > 0)
                            {
                                foreach (var item1 in diemThi)
                                {
                                    diem += item1.Diem;
                                }
                                diem = System.Math.Round(diem / diemThi.Count, 2);
                                if (diem < 4)
                                {
                                    diemThiLoaiKem++;
                                }
                                else if (diem >= 4 && diem < 5.5M)
                                {
                                    diemThiLoaiYeu++;
                                }
                                if (diem >= 5.5M && diem < 7M)
                                {
                                    diemThiLoaiTB++;
                                }
                                if (diem >= 7 && diem < 8.5M)
                                {
                                    diemThiLoaiKha++;
                                }
                                if (diem >= 8.5M && diem < 10)
                                {
                                    diemThiLoaiGioi++;
                                }
                            }
                        }

                        int[] SLDiemThi = [diemThiLoaiGioi, diemThiLoaiKha, diemThiLoaiTB, diemThiLoaiYeu, diemThiLoaiKem];

                        foreach (var item in lstHsKhoi)
                        {
                            decimal diem = 0;
                            var diemThi = await _context.DiemThis.Where(item1 => item1.Username == item.Username && item1.KyThiId == kythi.Id).ToListAsync();
                            if (diemThi.Count > 0)
                            {
                                foreach (var item1 in diemThi)
                                {
                                    diem += item1.Diem;
                                }
                                diem = System.Math.Round(diem / diemThi.Count, 2);
                                if (diem < 4)
                                {
                                    diemThiLoaiKemKhoi++;
                                }
                                else if (diem >= 4 && diem < 5.5M)
                                {
                                    diemThiLoaiYeuKhoi++;
                                }
                                if (diem >= 5.5M && diem < 7M)
                                {
                                    diemThiLoaiTBKhoi++;
                                }
                                if (diem >= 7 && diem < 8.5M)
                                {
                                    diemThiLoaiKhaKhoi++;
                                }
                                if (diem >= 8.5M && diem < 10)
                                {
                                    diemThiLoaiGioiKhoi++;
                                }
                            }
                        }

                        int[] SLDiemThiKhoi = [diemThiLoaiGioiKhoi, diemThiLoaiKhaKhoi, diemThiLoaiTBKhoi, diemThiLoaiYeuKhoi, diemThiLoaiKemKhoi];


                        var result = new
                        {
                            slDiemThiKhoi = SLDiemThiKhoi,
                            slDiemThiLop = SLDiemThi,
                            lop = lopHienTai1,
                            listDT = listDiemThi,
                            diemTbMon = diemTBMon,
                            kyHoc = kyhoc,
                            kyThi = kythi,
                            diem = diemthi.Diem,
                        };

                        return new JsonResult(result);
                    }
                    else
                    {
                        diemthi = await _context.DiemThis.FirstOrDefaultAsync(item => item.Username == username && item.KyThiId == kythi.Id && item.MonThiId == monThiId);

                        foreach (var item in lstHs)
                        {
                            var diemThi = await _context.DiemThis.FirstOrDefaultAsync(item1 => item1.Username == item.Username && item1.KyThiId == kythi.Id && item1.MonThiId == monThiId);
                            if (diemThi == null)
                            {
                                diem01Lop++;
                            }
                            else
                            {

                                if (0 <= diemThi.Diem && diemThi.Diem < 1)
                                {
                                    diem01Lop++;
                                }
                                else if (1 <= diemThi.Diem && diemThi.Diem < 2)
                                {
                                    diem12Lop++;
                                }
                                else if (2 <= diemThi.Diem && diemThi.Diem < 3)
                                {
                                    diem23Lop++;
                                }
                                else if (3 <= diemThi.Diem && diemThi.Diem < 4)
                                {
                                    diem34Lop++;
                                }
                                else if (4 <= diemThi.Diem && diemThi.Diem < 5)
                                {
                                    diem45Lop++;
                                }
                                else if (5 <= diemThi.Diem && diemThi.Diem < 6)
                                {
                                    diem56Lop++;
                                }
                                else if (6 <= diemThi.Diem && diemThi.Diem < 7)
                                {
                                    diem67Lop++;
                                }
                                else if (7 <= diemThi.Diem && diemThi.Diem < 8)
                                {
                                    diem78Lop++;
                                }
                                else if (8 <= diemThi.Diem && diemThi.Diem < 9)
                                {
                                    diem89Lop++;
                                }
                                else if (9 <= diemThi.Diem && diemThi.Diem <= 10)
                                {
                                    diem910Lop++;
                                }
                                diemTBlop += diemThi.Diem;
                            }
                        }
                        diemTBlop = System.Math.Round(diemTBlop / lstHs.Count, 2);
                        int[] SLdiemTBLop = [diem01Lop, diem12Lop, diem23Lop, diem34Lop, diem45Lop, diem56Lop, diem67Lop, diem78Lop, diem89Lop, diem910Lop];
                        //khoi
                        foreach (var item in lstHsKhoi)
                        {
                            var diemThi = await _context.DiemThis.FirstOrDefaultAsync(item1 => item1.Username == item.Username && item1.KyThiId == kythi.Id && item1.MonThiId == monThiId);
                            if (diemThi == null)
                            {
                                diem01Khoi++;
                            }
                            else
                            {

                                if (0 <= diemThi.Diem && diemThi.Diem < 1)
                                {
                                    diem01Khoi++;
                                }
                                else if (1 <= diemThi.Diem && diemThi.Diem < 2)
                                {
                                    diem12Khoi++;
                                }
                                else if (2 <= diemThi.Diem && diemThi.Diem < 3)
                                {
                                    diem23Khoi++;
                                }
                                else if (3 <= diemThi.Diem && diemThi.Diem < 4)
                                {
                                    diem34Khoi++;
                                }
                                else if (4 <= diemThi.Diem && diemThi.Diem < 5)
                                {
                                    diem45Khoi++;
                                }
                                else if (5 <= diemThi.Diem && diemThi.Diem < 6)
                                {
                                    diem56Khoi++;
                                }
                                else if (6 <= diemThi.Diem && diemThi.Diem < 7)
                                {
                                    diem67Khoi++;
                                }
                                else if (7 <= diemThi.Diem && diemThi.Diem < 8)
                                {
                                    diem78Khoi++;
                                }
                                else if (8 <= diemThi.Diem && diemThi.Diem < 9)
                                {
                                    diem89Khoi++;
                                }
                                else if (9 <= diemThi.Diem && diemThi.Diem <= 10)
                                {
                                    diem910Khoi++;
                                }

                                diemTBKhoi += diemThi.Diem;
                            }
                        }
                        int[] SLdiemTBKhoi = [diem01Khoi, diem12Khoi, diem23Khoi, diem34Khoi, diem45Khoi, diem56Khoi, diem67Khoi, diem78Khoi, diem89Khoi, diem910Khoi];
                        diemTBKhoi = System.Math.Round(diemTBKhoi / lstHsKhoi.Count, 2);
                        var result = new
                        {
                            slDiemTBLop = SLdiemTBLop,
                            slDiemTBKhoi = SLdiemTBKhoi,
                            diemTblop = diemTBlop,
                            diemTbKhoi = diemTBKhoi,
                            lop = lopHienTai1,
                            kyThi = kythi,
                            kyHoc = kyhoc,
                            diem = diemthi.Diem,
                        };

                        return new JsonResult(result);
                    }
                }
                return new JsonResult(true);
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
            var lop = await _context.Lops.FirstOrDefaultAsync(item => item.Id == diemThiDto.LopId);
            if (lop == null)
            {
                throw new Exception("Không tồn tại lớp để thêm điểm");
            }
            var monThi = await _context.MonThis.FirstOrDefaultAsync(item => item.Id == diemThiDto.MonThiId);
            if (monThi == null)
            {
                throw new Exception("Môn thi không tồn tại");
            }
            if (await _context.DiemThis.FirstOrDefaultAsync(item => item.KyThiId == diemThiDto.KyThiId && item.Username == diemThiDto.Username && item.LopId == diemThiDto.LopId && item.MonThiId == diemThiDto.MonThiId) != null)
            {
                throw new Exception("Điểm thi của bạn đã có trong danh sách");
            }
            var hs = await _context.ChiTietLops.FirstOrDefaultAsync(item => item.NamHoc == kyhoc.NamHoc && item.Username == diemThiDto.Username && item.LopId == diemThiDto.LopId);
            if (hs == null)
            {
                throw new Exception("Không tồn tại học sinh trong lớp ở kỳ học hiện tại để thêm điểm ");
            }
            if (monThi.KhoiThi != "" && monThi.KhoiThi != lop.KhoiHoc)
            {
                throw new Exception("Môn học không có trong tổ hợp thi của bạn");
            }


            DiemThi diemthi = new DiemThi()
            {
                Id = Guid.NewGuid(),
                Username = diemThiDto.Username,
                LopId = diemThiDto.LopId,
                KyThiId = diemThiDto.KyThiId,
                MonThiId = diemThiDto.MonThiId,
                Diem = diemThiDto.Diem,
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

        public async Task<ActionResult> ThemListDiemThi(ListDiemThiDto listDiemThiDto)
        {
            var kythi = await _context.KyThis.FirstOrDefaultAsync(i => i.Id == listDiemThiDto.KyThiId);
            var lop = await _context.Lops.FirstOrDefaultAsync(i => i.Id == listDiemThiDto.LopId);
            var monthi = await _context.MonThis.FirstOrDefaultAsync(i => i.Id == listDiemThiDto.MonThiId);
            List<DiemThiInListDiemThiResponse> listDiemThiDtoResponses = new List<DiemThiInListDiemThiResponse>();
            if (kythi == null)
            {
                throw new Exception("Kỳ thi không tồn tại");
            }
            if (lop == null)
            {
                throw new Exception("Lớp không tồn tại");
            }
            if (monthi == null)
            {
                throw new Exception("Môn thi không tồn tại");
            }

            foreach (var item in listDiemThiDto.listDiemThi)
            {
                var nguoiDung = await _context.NguoiDungs.FirstOrDefaultAsync(i => i.Username == item.username);
                DiemThiInListDiemThiResponse diemThiInListDiemThiResponse = new DiemThiInListDiemThiResponse();
                if (nguoiDung == null)
                {
                    diemThiInListDiemThiResponse.username = item.username;
                    diemThiInListDiemThiResponse.diem = item.diem;
                    diemThiInListDiemThiResponse.Message = "Học sinh không tồn tại";
                }
                else
                {
                    var diemthi = await _context.DiemThis.FirstOrDefaultAsync(i => i.Username == item.username && i.MonThiId == listDiemThiDto.MonThiId && i.KyThiId == listDiemThiDto.KyThiId && i.LopId == listDiemThiDto.LopId);
                    if (diemthi != null)
                    {
                        diemThiInListDiemThiResponse.username = item.username;
                        diemThiInListDiemThiResponse.diem = item.diem;
                        diemThiInListDiemThiResponse.hoTen = nguoiDung.HoTen;
                        diemThiInListDiemThiResponse.ngaySinh = nguoiDung.NgaySinh;
                        diemThiInListDiemThiResponse.gioiTinh = nguoiDung.GioiTinh;
                        diemThiInListDiemThiResponse.Message = "Điểm thi của học sinh đã tồn tại";
                    }
                    else
                    {
                        diemThiInListDiemThiResponse.username = item.username;
                        diemThiInListDiemThiResponse.diem = item.diem;
                        diemThiInListDiemThiResponse.Message = "Thêm điểm thành công";
                        diemThiInListDiemThiResponse.hoTen = nguoiDung.HoTen;
                        diemThiInListDiemThiResponse.ngaySinh = nguoiDung.NgaySinh;
                        diemThiInListDiemThiResponse.gioiTinh = nguoiDung.GioiTinh;
                        DiemThi dt = new DiemThi
                        {
                            Id = Guid.NewGuid(),
                            LopId = listDiemThiDto.LopId,
                            KyThiId = listDiemThiDto.KyThiId,
                            MonThiId = listDiemThiDto.MonThiId,
                            Diem = item.diem,
                            Username = item.username,
                        };
                        _context.DiemThis.Add(dt);
                        _context.SaveChanges();
                    }

                }
                listDiemThiDtoResponses.Add(diemThiInListDiemThiResponse);
            }

            ListDiemThiDtoResponse listDiemThiDtoResponse = new ListDiemThiDtoResponse
            {
                LopId = listDiemThiDto.LopId,
                KyThiId = listDiemThiDto.KyThiId,
                MonThiId = listDiemThiDto.MonThiId,
                listDiemThiResponse = listDiemThiDtoResponses
            };

            var kyhoc = await _context.KyHocs.FirstOrDefaultAsync(i => i.Id == kythi.KyHocId);

            ThongBao tb = new ThongBao
            {
                Id = Guid.NewGuid(),
                Content = $"Bạn đã có điểm môn thi môn {monthi.TenMonThi} của {kythi.TenKyThi} của năm học {kyhoc.NamHoc}",
                Link = "",
                LopId = lop.Id,
                NamHoc = kyhoc.NamHoc,
                NgayTao = DateTime.Now,
                Status = 0,
                Title = "Thông báo điểm thi",
                Username = ""
            };
            _context.ThongBaos.Add(tb);
            _context.SaveChanges();

            return new JsonResult(listDiemThiDtoResponses);
        }
    }
}


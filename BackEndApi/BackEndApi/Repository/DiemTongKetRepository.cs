using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Net.WebSockets;

namespace BackEndApi.Repository
{
    public class DiemTongKetRepository : IDiemTongKetRepository
    {
        private readonly ApplicationDbContext _context;

        public DiemTongKetRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> LayDiemHocBa(string username, int khoi)
        {
            var listLopTrongKhoi = await _context.Lops.Where(item => item.Khoi == khoi).Select(item => item.Id).ToListAsync();
            var lopHoc = await _context.ChiTietLops.FirstOrDefaultAsync(item => listLopTrongKhoi.Contains(item.LopId) && item.Username == username);
            return new JsonResult(true);
        }

        public async Task<ActionResult> LayDiemTongKet(int type, string? username, Guid? kyHocId, Guid? monTongKetId)
        {
            Lop lop = new Lop();
            KyHoc kyhoc = new KyHoc();
            MonThi monThi = new MonThi();
            List<ChiTietLop> lstHs = new List<ChiTietLop>();
            List<ChiTietLop> lstHsKhoi = new List<ChiTietLop>();
            DiemTongKet diemtongket = new DiemTongKet();
            var listKyHoc = await _context.KyHocs.ToListAsync();

            if (type == 0)
            {
                List<DiemTongKetView> lstDiemTkView = new List<DiemTongKetView>();
                if (String.IsNullOrWhiteSpace(kyHocId.ToString()))
                {
                    kyhoc = TimKyHocGanNhat(DateTime.Now, listKyHoc);
                    if (kyhoc == null)
                    {
                        throw new Exception("Kỳ học không tồn tại");
                    }
                    diemtongket = await _context.DiemTongKets.FirstOrDefaultAsync(item => item.Username == username && item.KyHocId == kyhoc.Id);
                    if (diemtongket == null)
                    {
                        var ctlops = await _context.ChiTietLops.FirstOrDefaultAsync(item => item.NamHoc == kyhoc.NamHoc && item.Username == username);
                        var lopHoc = await _context.Lops.FirstOrDefaultAsync(item => item.Id == ctlops.LopId);
                        var result1 = new
                        {
                            lop = lopHoc,
                            kyHoc = kyhoc,
                            MessageError = $"Chưa có điểm của bạn ở kỳ học {kyhoc.TenKyHoc.Split("-")[kyhoc.TenKyHoc.Split("-").Length - 1].ToLower()}"
                        };

                        return new JsonResult(result1);
                        //throw new Exception($"Chưa có điểm tổng kết của bạn ở kỳ học {kyhoc.TenKyHoc.Split("-")[kyhoc.TenKyHoc.Split("-").Length - 1].ToLower()}");
                    }


                    var listDiemTongKet = await _context.DiemTongKets.Where(item => item.KyHocId == kyhoc.Id && item.Username == username).ToListAsync();
                    var lopHienTai = await _context.Lops.FirstOrDefaultAsync(item => item.Id == diemtongket.LopId);

                    decimal diemTBMon = 0;

                    if (listDiemTongKet.Count > 0)
                    {
                        foreach (var item in listDiemTongKet)
                        {
                            var mtk = await _context.MonTongKets.FirstOrDefaultAsync(item1 => item1.Id == item.MonTongKetId);
                            if (mtk != null)
                            {
                                diemTBMon += item.Diem;
                                DiemTongKetView dtkview = new DiemTongKetView
                                {
                                    Id = item.Id,
                                    MonTongKetId = item.MonTongKetId,
                                    KyHocId = item.KyHocId,
                                    LopId = item.LopId,
                                    MaMon = mtk.MaMon,
                                    TenMon = mtk.TenMon,
                                    Username = item.Username,
                                    diem = System.Math.Round(item.Diem, 2),
                                };
                                lstDiemTkView.Add(dtkview);
                            }
                        };
                        diemTBMon = System.Math.Round(diemTBMon / listDiemTongKet.Count, 2);
                    }

                    var result = new
                    {
                        lop = lopHienTai,
                        listDT = lstDiemTkView,
                        diemTbMon = diemTBMon,
                        kyHoc = kyhoc,
                        diem = diemtongket.Diem
                    };

                    return new JsonResult(result);
                }
                else
                {
                    kyhoc = await _context.KyHocs.FirstOrDefaultAsync(item => item.Id == kyHocId);
                    if (kyhoc == null)
                    {
                        throw new Exception("Kỳ học không tồn tại");
                    }
                    diemtongket = await _context.DiemTongKets.FirstOrDefaultAsync(item => item.Username == username && item.KyHocId == kyhoc.Id);
                    if (diemtongket == null)
                    {
                        var ctlops = await _context.ChiTietLops.FirstOrDefaultAsync(item => item.NamHoc == kyhoc.NamHoc && item.Username == username);
                        var lopHoc = await _context.Lops.FirstOrDefaultAsync(item => item.Id == ctlops.LopId);
                        var result1 = new
                        {
                            lop = lopHoc,
                            kyHoc = kyhoc,
                            MessageError = $"Chưa có điểm của bạn ở kỳ học {kyhoc.TenKyHoc.Split("-")[kyhoc.TenKyHoc.Split("-").Length - 1].ToLower()}"
                        };

                        return new JsonResult(result1);
                        //throw new Exception($"Chưa có điểm tổng kết của bạn ở kỳ học {kyhoc.TenKyHoc.Split("-")[kyhoc.TenKyHoc.Split("-").Length - 1].ToLower()}");
                    }

                    var listDiemTongKet = await _context.DiemTongKets.Where(item => item.KyHocId == kyhoc.Id && item.Username == username).ToListAsync();
                    var lopHienTai = await _context.Lops.FirstOrDefaultAsync(item => item.Id == diemtongket.LopId);

                    decimal diemTBMon = 0;

                    if (listDiemTongKet.Count > 0)
                    {
                        foreach (var item in listDiemTongKet)
                        {
                            var mtk = await _context.MonTongKets.FirstOrDefaultAsync(item1 => item1.Id == item.MonTongKetId);
                            if (mtk != null)
                            {
                                diemTBMon += item.Diem;
                                DiemTongKetView dtkview = new DiemTongKetView
                                {
                                    Id = item.Id,
                                    MonTongKetId = item.MonTongKetId,
                                    KyHocId = item.KyHocId,
                                    LopId = item.LopId,
                                    MaMon = mtk.MaMon,
                                    TenMon = mtk.TenMon,
                                    Username = item.Username,
                                    diem = item.Diem,
                                };
                                lstDiemTkView.Add(dtkview);
                            }
                        };
                        diemTBMon = System.Math.Round(diemTBMon / listDiemTongKet.Count, 2);
                    }

                    var result = new
                    {
                        lop = lopHienTai,
                        listDT = lstDiemTkView,
                        diemTbMon = diemTBMon,
                        kyHoc = kyhoc,
                        diem = diemtongket.Diem
                    };

                    return new JsonResult(result);
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

                if (String.IsNullOrWhiteSpace(kyHocId.ToString()))
                {
                    kyhoc = TimKyHocGanNhat(DateTime.Now, listKyHoc);
                    if (kyhoc == null)
                    {
                        throw new Exception("Kỳ học không tồn tại");
                    }
                    diemtongket = await _context.DiemTongKets.FirstOrDefaultAsync(item => item.Username == username && item.KyHocId == kyhoc.Id);
                    if (diemtongket == null)
                    {
                        var ctlops = await _context.ChiTietLops.FirstOrDefaultAsync(item => item.NamHoc == kyhoc.NamHoc && item.Username == username);
                        var lopHoc = await _context.Lops.FirstOrDefaultAsync(item => item.Id == ctlops.LopId);
                        var result = new
                        {
                            lop = lopHoc,
                            kyHoc = kyhoc,
                            MessageError = $"Chưa có điểm của bạn ở kỳ học {kyhoc.TenKyHoc.Split("-")[kyhoc.TenKyHoc.Split("-").Length - 1].ToLower()}"
                        };

                        return new JsonResult(result);
                        //throw new Exception($"Chưa có điểm tổng kết của bạn ở kỳ học {kyhoc.TenKyHoc.Split("-")[kyhoc.TenKyHoc.Split("-").Length - 1].ToLower()}");
                    }
                    lstHs = await _context.ChiTietLops.Where(item => item.LopId == diemtongket.LopId && item.NamHoc == kyhoc.NamHoc).ToListAsync();
                    var lopHienTai = await _context.Lops.FirstOrDefaultAsync(item => item.Id == diemtongket.LopId);
                    var listLopCungKhoiThi = await _context.Lops.Where(item => item.Khoi == lopHienTai.Khoi && item.KhoiHoc == lopHienTai.KhoiHoc).Select(i => i.Id).ToListAsync();
                    lstHsKhoi = await _context.ChiTietLops.Where(item => item.NamHoc == kyhoc.NamHoc).ToListAsync();
                    if (String.IsNullOrWhiteSpace(monTongKetId.ToString()))
                    {
                        var listDiemTongKet = await _context.DiemTongKets.Where(item => item.KyHocId == kyhoc.Id && item.Username == username).ToListAsync();
                        decimal diemTBMon = 0;
                        decimal diemTBMonLop = 0;
                        decimal diemTBMonKhoi = 0;
                        if (listDiemTongKet.Count > 0)
                        {
                            foreach (var item in listDiemTongKet)
                            {
                                diemTBMon += item.Diem;
                            };
                            diemTBMon = System.Math.Round(diemTBMon / listDiemTongKet.Count, 2);
                        }
                        foreach (var item in lstHs)
                        {
                            decimal diem = 0;
                            var diemTongKet = await _context.DiemTongKets.Where(item1 => item1.Username == item.Username && item1.KyHocId == kyhoc.Id).ToListAsync();
                            if (diemTongKet.Count > 0)
                            {
                                foreach (var item1 in diemTongKet)
                                {
                                    diem += item1.Diem;
                                }
                                diem = System.Math.Round(diem / diemTongKet.Count, 2);
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
                            var diemTongKet = await _context.DiemTongKets.Where(item1 => item1.Username == item.Username && item1.KyHocId == kyhoc.Id).ToListAsync();
                            if (diemTongKet.Count > 0)
                            {
                                foreach (var item1 in diemTongKet)
                                {
                                    diem += item1.Diem;
                                }
                                diem = System.Math.Round(diem / diemTongKet.Count, 2);
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
                            listDT = listDiemTongKet,
                            diemTbMon = diemTBMon,
                            kyHoc = kyhoc,
                            diem = diemtongket.Diem
                        };

                        return new JsonResult(result);
                    }
                    else
                    {
                        diemtongket = await _context.DiemTongKets.FirstOrDefaultAsync(item => item.Username == username && item.KyHocId == kyhoc.Id && item.MonTongKetId == monTongKetId);

                        //lop
                        foreach (var item in lstHs)
                        {
                            var diemTongKet = await _context.DiemTongKets.FirstOrDefaultAsync(item1 => item1.Username == item.Username && item1.KyHocId == kyhoc.Id && item1.MonTongKetId == monTongKetId);
                            if (diemTongKet == null)
                            {
                                diem01Lop++;
                            }
                            else
                            {
                                if (0 <= diemTongKet.Diem && diemTongKet.Diem < 1)
                                {
                                    diem01Lop++;
                                }
                                else if (1 <= diemTongKet.Diem && diemTongKet.Diem < 2)
                                {
                                    diem12Lop++;
                                }
                                else if (2 <= diemTongKet.Diem && diemTongKet.Diem < 3)
                                {
                                    diem23Lop++;
                                }
                                else if (3 <= diemTongKet.Diem && diemTongKet.Diem < 4)
                                {
                                    diem34Lop++;
                                }
                                else if (4 <= diemTongKet.Diem && diemTongKet.Diem < 5)
                                {
                                    diem45Lop++;
                                }
                                else if (5 <= diemTongKet.Diem && diemTongKet.Diem < 6)
                                {
                                    diem56Lop++;
                                }
                                else if (6 <= diemTongKet.Diem && diemTongKet.Diem < 7)
                                {
                                    diem67Lop++;
                                }
                                else if (7 <= diemTongKet.Diem && diemTongKet.Diem < 8)
                                {
                                    diem78Lop++;
                                }
                                else if (8 <= diemTongKet.Diem && diemTongKet.Diem < 9)
                                {
                                    diem89Lop++;
                                }
                                else if (9 <= diemTongKet.Diem && diemTongKet.Diem <= 10)
                                {
                                    diem910Lop++;
                                }
                                diemTBlop += diemTongKet.Diem;
                            }
                        }
                        diemTBlop = System.Math.Round(diemTBlop / lstHs.Count, 2);
                        int[] SLdiemTBLop = [diem01Lop, diem12Lop, diem23Lop, diem34Lop, diem45Lop, diem56Lop, diem67Lop, diem78Lop, diem89Lop, diem910Lop];
                        //khoi
                        foreach (var item in lstHsKhoi)
                        {
                            var diemTongKet = await _context.DiemTongKets.FirstOrDefaultAsync(item1 => item1.Username == item.Username && item1.KyHocId == kyhoc.Id && item1.MonTongKetId == monTongKetId);
                            if (diemTongKet == null)
                            {
                                diem01Khoi++;
                            }
                            else
                            {

                                if (0 <= diemTongKet.Diem && diemTongKet.Diem < 1)
                                {
                                    diem01Khoi++;
                                }
                                else if (1 <= diemTongKet.Diem && diemTongKet.Diem < 2)
                                {
                                    diem12Khoi++;
                                }
                                else if (2 <= diemTongKet.Diem && diemTongKet.Diem < 3)
                                {
                                    diem23Khoi++;
                                }
                                else if (3 <= diemTongKet.Diem && diemTongKet.Diem < 4)
                                {
                                    diem34Khoi++;
                                }
                                else if (4 <= diemTongKet.Diem && diemTongKet.Diem < 5)
                                {
                                    diem45Khoi++;
                                }
                                else if (5 <= diemTongKet.Diem && diemTongKet.Diem < 6)
                                {
                                    diem56Khoi++;
                                }
                                else if (6 <= diemTongKet.Diem && diemTongKet.Diem < 7)
                                {
                                    diem67Khoi++;
                                }
                                else if (7 <= diemTongKet.Diem && diemTongKet.Diem < 8)
                                {
                                    diem78Khoi++;
                                }
                                else if (8 <= diemTongKet.Diem && diemTongKet.Diem < 9)
                                {
                                    diem89Khoi++;
                                }
                                else if (9 <= diemTongKet.Diem && diemTongKet.Diem <= 10)
                                {
                                    diem910Khoi++;
                                }

                                diemTBKhoi += diemTongKet.Diem;
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
                            kyHoc = kyhoc,
                            diem = diemtongket.Diem,
                        };

                        return new JsonResult(result);
                    }
                }
                else
                {
                    kyhoc = await _context.KyHocs.FirstOrDefaultAsync(item => item.Id == kyHocId);
                    if (kyhoc == null)
                    {
                        throw new Exception("Kỳ học không tồn tại");
                    }
                    diemtongket = await _context.DiemTongKets.FirstOrDefaultAsync(item => item.Username == username && item.KyHocId == kyhoc.Id);
                    if (diemtongket == null)
                    {
                        var ctlops = await _context.ChiTietLops.FirstOrDefaultAsync(item => item.NamHoc == kyhoc.NamHoc && item.Username == username);
                        var lopHoc = await _context.Lops.FirstOrDefaultAsync(item => item.Id == ctlops.LopId);
                        var result = new
                        {
                            lop = lopHoc,
                            kyHoc = kyhoc,
                            MessageError = $"Chưa có điểm của bạn ở kỳ học {kyhoc.TenKyHoc.Split("-")[kyhoc.TenKyHoc.Split("-").Length - 1].ToLower()}"
                        };

                        return new JsonResult(result);
                    }
                    lstHs = await _context.ChiTietLops.Where(item => item.LopId == diemtongket.LopId && item.NamHoc == kyhoc.NamHoc).ToListAsync();
                    var lopHienTai1 = await _context.Lops.FirstOrDefaultAsync(item => item.Id == diemtongket.LopId);
                    var listLopCungKhoiThi1 = await _context.Lops.Where(item => item.Khoi == lopHienTai1.Khoi && item.KhoiHoc == lopHienTai1.KhoiHoc).Select(i => i.Id).ToListAsync();
                    lstHsKhoi = await _context.ChiTietLops.Where(item => item.NamHoc == kyhoc.NamHoc).ToListAsync();
                    if (String.IsNullOrWhiteSpace(monTongKetId.ToString()))
                    {
                        var listDiemTongKet = await _context.DiemTongKets.Where(item => item.KyHocId == kyhoc.Id && item.Username == username).ToListAsync();
                        decimal diemTBMon = 0;
                        decimal diemTBMonLop = 0;
                        decimal diemTBMonKhoi = 0;
                        if (listDiemTongKet.Count > 0)
                        {
                            foreach (var item in listDiemTongKet)
                            {
                                diemTBMon += item.Diem;
                            };
                            diemTBMon = System.Math.Round(diemTBMon / listDiemTongKet.Count, 2);
                        }
                        foreach (var item in lstHs)
                        {
                            decimal diem = 0;
                            var diemTongKet = await _context.DiemTongKets.Where(item1 => item1.Username == item.Username && item1.KyHocId == kyhoc.Id).ToListAsync();
                            if (diemTongKet.Count > 0)
                            {
                                foreach (var item1 in diemTongKet)
                                {
                                    diem += item1.Diem;
                                }
                                diem = System.Math.Round(diem / diemTongKet.Count, 2);
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
                            var diemTongKet = await _context.DiemTongKets.Where(item1 => item1.Username == item.Username && item1.KyHocId == kyhoc.Id).ToListAsync();
                            if (diemTongKet.Count > 0)
                            {
                                foreach (var item1 in diemTongKet)
                                {
                                    diem += item1.Diem;
                                }
                                diem = System.Math.Round(diem / diemTongKet.Count, 2);
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
                            listDT = listDiemTongKet,
                            diemTbMon = diemTBMon,
                            kyHoc = kyhoc,
                            diem = diemtongket.Diem,
                        };

                        return new JsonResult(result);
                    }
                    else
                    {
                        diemtongket = await _context.DiemTongKets.FirstOrDefaultAsync(item => item.Username == username && item.KyHocId == kyhoc.Id && item.MonTongKetId == monTongKetId);

                        foreach (var item in lstHs)
                        {
                            var diemTongKet = await _context.DiemTongKets.FirstOrDefaultAsync(item1 => item1.Username == item.Username && item1.KyHocId == kyhoc.Id && item1.MonTongKetId == monTongKetId);
                            if (diemTongKet == null)
                            {
                                diem01Lop++;
                            }
                            else
                            {

                                if (0 <= diemTongKet.Diem && diemTongKet.Diem < 1)
                                {
                                    diem01Lop++;
                                }
                                else if (1 <= diemTongKet.Diem && diemTongKet.Diem < 2)
                                {
                                    diem12Lop++;
                                }
                                else if (2 <= diemTongKet.Diem && diemTongKet.Diem < 3)
                                {
                                    diem23Lop++;
                                }
                                else if (3 <= diemTongKet.Diem && diemTongKet.Diem < 4)
                                {
                                    diem34Lop++;
                                }
                                else if (4 <= diemTongKet.Diem && diemTongKet.Diem < 5)
                                {
                                    diem45Lop++;
                                }
                                else if (5 <= diemTongKet.Diem && diemTongKet.Diem < 6)
                                {
                                    diem56Lop++;
                                }
                                else if (6 <= diemTongKet.Diem && diemTongKet.Diem < 7)
                                {
                                    diem67Lop++;
                                }
                                else if (7 <= diemTongKet.Diem && diemTongKet.Diem < 8)
                                {
                                    diem78Lop++;
                                }
                                else if (8 <= diemTongKet.Diem && diemTongKet.Diem < 9)
                                {
                                    diem89Lop++;
                                }
                                else if (9 <= diemTongKet.Diem && diemTongKet.Diem <= 10)
                                {
                                    diem910Lop++;
                                }
                                diemTBlop += diemTongKet.Diem;
                            }
                        }
                        diemTBlop = System.Math.Round(diemTBlop / lstHs.Count, 2);
                        int[] SLdiemTBLop = [diem01Lop, diem12Lop, diem23Lop, diem34Lop, diem45Lop, diem56Lop, diem67Lop, diem78Lop, diem89Lop, diem910Lop];
                        //khoi
                        foreach (var item in lstHsKhoi)
                        {
                            var diemTongKet = await _context.DiemTongKets.FirstOrDefaultAsync(item1 => item1.Username == item.Username && item1.KyHocId == kyhoc.Id && item1.MonTongKetId == monTongKetId);
                            if (diemTongKet == null)
                            {
                                diem01Khoi++;
                            }
                            else
                            {

                                if (0 <= diemTongKet.Diem && diemTongKet.Diem < 1)
                                {
                                    diem01Khoi++;
                                }
                                else if (1 <= diemTongKet.Diem && diemTongKet.Diem < 2)
                                {
                                    diem12Khoi++;
                                }
                                else if (2 <= diemTongKet.Diem && diemTongKet.Diem < 3)
                                {
                                    diem23Khoi++;
                                }
                                else if (3 <= diemTongKet.Diem && diemTongKet.Diem < 4)
                                {
                                    diem34Khoi++;
                                }
                                else if (4 <= diemTongKet.Diem && diemTongKet.Diem < 5)
                                {
                                    diem45Khoi++;
                                }
                                else if (5 <= diemTongKet.Diem && diemTongKet.Diem < 6)
                                {
                                    diem56Khoi++;
                                }
                                else if (6 <= diemTongKet.Diem && diemTongKet.Diem < 7)
                                {
                                    diem67Khoi++;
                                }
                                else if (7 <= diemTongKet.Diem && diemTongKet.Diem < 8)
                                {
                                    diem78Khoi++;
                                }
                                else if (8 <= diemTongKet.Diem && diemTongKet.Diem < 9)
                                {
                                    diem89Khoi++;
                                }
                                else if (9 <= diemTongKet.Diem && diemTongKet.Diem <= 10)
                                {
                                    diem910Khoi++;
                                }

                                diemTBKhoi += diemTongKet.Diem;
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
                            kyHoc = kyhoc,
                            diem = diemtongket.Diem,
                        };

                        return new JsonResult(result);
                    }
                }
            }
            return new JsonResult(true);
        }

        public async Task<ActionResult> ThemDiemTongKet(DiemTongKetDto diemTongKetDto)
        {

            var kyhoc = await _context.KyHocs.FirstOrDefaultAsync(item => item.Id == diemTongKetDto.KyHocId);
            if (kyhoc == null)
            {
                throw new Exception("Kỳ học không tồn tại");
            }
            //var lop = await _context.Lops.FirstOrDefaultAsync(item => item.Id == diemThiDto.LopId);
            //if (lop == null)
            //{
            //    throw new Exception("Không tồn tại lớp để thêm điểm");
            //}
            var monThi = await _context.MonThis.FirstOrDefaultAsync(item => item.Id == diemTongKetDto.MonTongKetId);
            if (monThi == null)
            {
                throw new Exception("Môn tổng kết không tồn tại");
            }
            if (await _context.DiemTongKets.FirstOrDefaultAsync(item => item.KyHocId == diemTongKetDto.KyHocId && item.Username == diemTongKetDto.Username && item.LopId == diemTongKetDto.LopId && item.MonTongKetId == diemTongKetDto.MonTongKetId) != null)
            {
                throw new Exception("Điểm thi của bạn đã có trong danh sách");
            }
            var hs = await _context.ChiTietLops.FirstOrDefaultAsync(item => item.NamHoc == kyhoc.NamHoc && item.Username == diemTongKetDto.Username && item.LopId == diemTongKetDto.LopId);
            if (hs == null)
            {
                throw new Exception("Không tồn tại học sinh trong lớp ở kỳ học hiện tại để thêm điểm ");
            }


            DiemTongKet diemTongKet = new DiemTongKet()
            {
                Id = Guid.NewGuid(),
                Username = diemTongKetDto.Username,
                LopId = diemTongKetDto.LopId,
                KyHocId = diemTongKetDto.KyHocId,
                MonTongKetId = diemTongKetDto.MonTongKetId,
                Diem = diemTongKetDto.Diem,
            };

            _context.DiemTongKets.Add(diemTongKet);
            _context.SaveChanges();
            return new JsonResult(diemTongKet);
        }

        static KyHoc TimKyHocGanNhat(DateTime ngayHienTai, List<KyHoc> danhSachKyHoc)
        {
            KyHoc ngayGanNhat = danhSachKyHoc[0]; // Giả sử phần tử đầu tiên là ngày gần nhất ban đầu

            foreach (var ngayItem in danhSachKyHoc)
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

        public async Task<ActionResult> ThemListDiemTongKet(DiemTongKetAddDto diemTongKetAddDto)
        {

            DiemTongKetAddDtoResult diemTongKetAddDtoResult = new DiemTongKetAddDtoResult();
            var kyhoc = await _context.KyHocs.FirstOrDefaultAsync(i => i.Id == diemTongKetAddDto.KyHocId);
            if (kyhoc == null)
            {
                throw new Exception("Kỳ học không tồm tại");
            }

            var ngdung = await _context.NguoiDungs.FirstOrDefaultAsync(i => i.Username == diemTongKetAddDto.Username);
            if (ngdung == null)
            {
                throw new Exception("Người dùng không tồm tại");
            }

            var lophoc = await _context.Lops.FirstOrDefaultAsync(i => i.Id == diemTongKetAddDto.LopId);
            if (lophoc == null)
            {
                throw new Exception("Lớp học không tồm tại");
            }

            var hsInlop = await _context.ChiTietLops.FirstOrDefaultAsync(i => i.NamHoc == kyhoc.NamHoc && i.LopId == diemTongKetAddDto.LopId && i.Username == diemTongKetAddDto.Username);
            if (hsInlop == null)
            {
                throw new Exception("Học sinh không có trong lớp");
            }

            diemTongKetAddDtoResult.Username = diemTongKetAddDto.Username;
            diemTongKetAddDtoResult.LopId = diemTongKetAddDto.LopId;
            diemTongKetAddDtoResult.KyHocId = diemTongKetAddDto.KyHocId;
            diemTongKetAddDtoResult.DiemAddsResult = new List<DiemAddResultDto>();
            foreach (var item in diemTongKetAddDto.DiemAdds)
            {

                var montongket = await _context.MonTongKets.FirstOrDefaultAsync(i => i.Id == item.MonTongKetId);
                if (montongket == null)
                {
                    DiemAddResultDto diemAddResult = new DiemAddResultDto()
                    {
                        MonTongKetId = item.MonTongKetId,
                        Diem = item.Diem,
                        Message = "Môn tổng kết không tồn tại"
                    };
                    diemTongKetAddDtoResult.DiemAddsResult.Add(diemAddResult);
                }
                else
                {

                    var tontai = await _context.DiemTongKets.FirstOrDefaultAsync(i => i.MonTongKetId == item.MonTongKetId && i.KyHocId == diemTongKetAddDto.KyHocId && i.Username == diemTongKetAddDto.Username);
                    if (tontai != null)
                    {
                        DiemAddResultDto diemAddResult = new DiemAddResultDto()
                        {
                            MonTongKetId = item.MonTongKetId,
                            Diem = item.Diem,
                            Message = "Điểm tổng kết đã tồn tại"
                        };
                        diemTongKetAddDtoResult.DiemAddsResult.Add(diemAddResult);
                    }
                    else
                    {
                        DiemAddResultDto diemAddResult = new DiemAddResultDto()
                        {
                            MonTongKetId = item.MonTongKetId,
                            //Diem = item.Diem,
                            Diem = RandomDiem(),
                            Message = "Thêm điểm thành công"
                        };
                        diemTongKetAddDtoResult.DiemAddsResult.Add(diemAddResult);
                        DiemTongKet diemTongKet = new DiemTongKet()
                        {
                            Id = Guid.NewGuid(),
                            //Diem = item.Diem,
                            Diem = RandomDiem(),
                            KyHocId = diemTongKetAddDto.KyHocId,
                            MonTongKetId = item.MonTongKetId,
                            LopId = diemTongKetAddDto.LopId,
                            Username = diemTongKetAddDto.Username
                        };
                        _context.DiemTongKets.Add(diemTongKet);
                        _context.SaveChanges();
                    }
                }
                ThongBao tb = new ThongBao
                {
                    Id = Guid.NewGuid(),
                    Content = $"Bạn đã có điểm môn tổng kết môn {montongket.TenMon} của {kyhoc.TenKyHoc} của năm học {kyhoc.NamHoc}",
                    Link = "",
                    LopId = lophoc.Id,
                    NamHoc = kyhoc.NamHoc,
                    NgayTao = DateTime.Now,
                    Status = 0,
                    Title = "Thông báo điểm thi",
                    Username = ""
                };
                _context.ThongBaos.Add(tb);
                _context.SaveChanges();
            }
            return new JsonResult(diemTongKetAddDtoResult);

        }

        public static decimal RandomDiem()
        {
            Random random = new Random();
            var ran = random.NextDouble() * Math.Abs(4) + 6;
            return (decimal)ran;
        }

        public async Task<ActionResult> ThemListDiemTongKet(DiemTongKetAddList diemTongKetAddList)
        {
            var kyhoc = await _context.KyHocs.FirstOrDefaultAsync(i => i.Id == diemTongKetAddList.HocKyId);
            if (kyhoc == null)
            {
                throw new Exception("Kỳ học không tồn tại");
            }
            var lop = await _context.Lops.FirstOrDefaultAsync(i => i.Id == diemTongKetAddList.LopId);
            if (lop == null)
            {
                throw new Exception("Lớp không tồn tại");
            }
            var montongket = await _context.MonTongKets.FirstOrDefaultAsync(i => i.Id == diemTongKetAddList.MonTongKetId);
            if (montongket == null)
            {
                throw new Exception("Môn tổng kết không tồn tại");
            }

            List<DTRes> lstDiemTongKetResponse = new List<DTRes>();
            foreach (var item in diemTongKetAddList.listDT)
            {
                var nd = await _context.NguoiDungs.FirstOrDefaultAsync(i => i.Username == item.Username);
                DTRes dtkRes = new DTRes();
                if (nd == null)
                {
                    dtkRes.Username = item.Username;
                    dtkRes.Diem = item.Diem;
                    dtkRes.Message = "Học sinh không tồn tại";
                }
                else
                {
                    var dtk = await _context.DiemTongKets.FirstOrDefaultAsync(i => i.Username == item.Username && i.MonTongKetId == diemTongKetAddList.MonTongKetId && i.KyHocId == diemTongKetAddList.HocKyId);
                    if (dtk != null)
                    {
                        dtkRes.Username = item.Username;
                        dtkRes.Diem = item.Diem;
                        dtkRes.HoTen = nd.HoTen;
                        dtkRes.NgaySinh = nd.NgaySinh;
                        dtkRes.GioiTinh = nd.GioiTinh;
                        dtkRes.Message = "Điểm tổng kết của học sinh đã tồn tại";
                    }
                    else
                    {
                        dtkRes.Username = item.Username;
                        dtkRes.Diem = item.Diem;
                        dtkRes.Message = "Thêm điểm thành công";
                        dtkRes.HoTen = nd.HoTen;
                        dtkRes.NgaySinh = nd.NgaySinh;
                        dtkRes.GioiTinh = nd.GioiTinh;

                        DiemTongKet dt = new DiemTongKet
                        {
                            Id = Guid.NewGuid(),
                            LopId = diemTongKetAddList.LopId,
                            KyHocId = diemTongKetAddList.HocKyId,
                            MonTongKetId = diemTongKetAddList.MonTongKetId,
                            Diem = item.Diem,
                            Username = item.Username,
                        };
                        _context.DiemTongKets.Add(dt);
                        _context.SaveChanges();
                    }
                }
                lstDiemTongKetResponse.Add(dtkRes);
            }

            DiemTongKetAddListResponse dtkResponse = new DiemTongKetAddListResponse
            {
                LopId = diemTongKetAddList.LopId,
                HocKyId = diemTongKetAddList.HocKyId,
                MonTongKetId = diemTongKetAddList.MonTongKetId,
                listRes = lstDiemTongKetResponse
            };

            ThongBao tb = new ThongBao
            {
                Id = Guid.NewGuid(),
                Content = $"Bạn đã có điểm tổng kết môn {montongket.TenMon} của {kyhoc.TenKyHoc} của năm học {kyhoc.NamHoc}",
                Link = "",
                LopId = lop.Id,
                NamHoc = kyhoc.NamHoc,
                NgayTao = DateTime.Now,
                Status = 0,
                Title = "Thông báo điểm tổng kết",
                Username = ""
            };

            return new JsonResult(dtkResponse);
        }

        public async Task<ActionResult> BaoSaiSotDiemTongKet(string username, string namHoc, Guid hocKyId, List<Guid> listMonTongKetId)
        {
            var ngd = await _context.NguoiDungs.FirstOrDefaultAsync(i => i.Username == username);
            if (ngd == null)
            {
                throw new Exception("Không tồn tại người dùng");

            }
            var hocky = await _context.KyHocs.FirstOrDefaultAsync(i => i.Id == hocKyId);
            if (hocky == null)
            {
                throw new Exception("Không tồn tại học kỳ");

            }
            string tbaoString = $"Học sinh {ngd.Username} - {ngd.HoTen} phúc khảo môn tổng kết ";
            foreach (var item in listMonTongKetId)
            {
                var monTK = await _context.MonTongKets.FirstOrDefaultAsync(i => i.Id == item);
                if (monTK == null)
                {
                    throw new Exception("Không thể phúc khảo môn học không tồn tại");
                }
                tbaoString += monTK.TenMon.ToString();
                tbaoString += ", ";
            }
            tbaoString.Remove(tbaoString.Length - 2);
            tbaoString += ".";
            ThongBao thongBao = new ThongBao()
            {
                Id = Guid.NewGuid(),
                Content = tbaoString,
                Link = "",
                LopId = null,
                NamHoc = namHoc,
                NgayTao = DateTime.Now,
                Status = 0,
                Title = "Phúc khảo điểm tổng kết",
                Username = "admin",
            };
            _context.ThongBaos.Add(thongBao);
            _context.SaveChanges();

            return new JsonResult("Bạn đã phúc khảo thành công.Thầy cô sẽ kiểm tra lại và gửi lại cho bạn thông tin sớm nhất");
        }

        public async Task<ActionResult> SuaDiemTongKet(int type, Guid diemTongKetId, decimal diem)
        {
            var diemTongKet = await _context.DiemTongKets.FirstOrDefaultAsync(i => i.Id == diemTongKetId);
            if (diemTongKet == null)
            {
                throw new Exception("Không thể đổi điểm tổng kết");
            }

            diemTongKet.Diem = diem;
            _context.DiemTongKets.Update(diemTongKet);
            _context.SaveChanges();

            if (type == 1)
            {
                var ngd = await _context.NguoiDungs.FirstOrDefaultAsync(i => i.Username == diemTongKet.Username);
                var kyHoc = await _context.KyHocs.FirstOrDefaultAsync(i => i.Id == diemTongKet.KyHocId);
                var monTongKet = await _context.MonTongKets.FirstOrDefaultAsync(i => i.Id == diemTongKet.MonTongKetId);

                var str = $"Điểm tổng kết môn {monTongKet.TenMon} của kỳ học {kyHoc.TenKyHoc} đã được cập nhật sau đơn phúc khảo của bạn. Vui lòng vào trang xem điểm để xem kết quả.";
                ThongBao tb = new ThongBao()
                {
                    Id = Guid.NewGuid(),
                    Content = str,
                    Link = "",
                    LopId = null,
                    NamHoc = kyHoc.NamHoc,
                    NgayTao = DateTime.Now,
                    Status = 0,
                    Title = "Cập nhật điểm tổng kết sau phúc khảo",
                    Username = ngd.Username,
                };
                _context.ThongBaos.Add(tb);
                _context.SaveChanges();
            }
            return new JsonResult(diemTongKet);
        }

        public async Task<ActionResult> LayDiemTongKetTheoUser(string username, Guid monTongKetId, Guid kyHocId)
        {
            var ngDung = await _context.NguoiDungs.FirstOrDefaultAsync(i => i.Username == username);
            if (ngDung == null)
            {
                throw new Exception("Người dùng không tồn tại, Không thể lấy điểm tổng kết");
            }
            var montongket = await _context.MonTongKets.FirstOrDefaultAsync(i => i.Id == monTongKetId);
            if (montongket == null)
            {
                throw new Exception("Môn tổng kết không tồn tại.Không thể lấy điểm tổng kết");
            }
            var kyhoc = await _context.KyHocs.FirstOrDefaultAsync(i => i.Id == kyHocId);
            if (kyhoc == null)
            {
                throw new Exception("Kỳ học không tồn tại.Không thể lấy điểm tổng kết");
            }

            var diemTongKet = await _context.DiemTongKets.FirstOrDefaultAsync(i => i.Username == username && i.MonTongKetId == monTongKetId && i.KyHocId == kyHocId);

            return new JsonResult(diemTongKet);
        }
    }
}

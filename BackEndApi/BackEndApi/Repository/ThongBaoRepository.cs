using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Repository
{
    public class ThongBaoRepository : IThongBaoRepository
    {
        private readonly ApplicationDbContext _context;

        public ThongBaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<ActionResult> SuaThongBao(ThongBao thongBao)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult> ThemThongBao(ThongBaoDto thongBaoDto)
        {
            if (!String.IsNullOrWhiteSpace(thongBaoDto.Username))
            {
                if (await _context.NguoiDungs.FirstOrDefaultAsync(i => i.Username == thongBaoDto.Username) == null)
                {
                    throw new Exception("Người dùng không tôn tại");
                }
            }
            if (!String.IsNullOrWhiteSpace(thongBaoDto.LopId.ToString()))
            {
                if (await _context.Lops.FirstOrDefaultAsync(i => i.Id == thongBaoDto.LopId) == null)
                {
                    throw new Exception("Lớp học không tôn tại");
                }
            }

            ThongBao thongBao = new ThongBao()
            {
                Id = Guid.NewGuid(),
                Username = thongBaoDto.Username,
                LopId = thongBaoDto.LopId,
                Content = thongBaoDto.Content,
                Link = thongBaoDto.Link,
                NamHoc = thongBaoDto.NamHoc,
                NgayTao = DateTime.Now,
                Title = thongBaoDto.Title,
                Status = thongBaoDto.Status,
            };
            _context.ThongBaos.Add(thongBao);
            _context.SaveChanges();
            return new JsonResult(thongBao);
        }

        public async Task<ActionResult> XoaThongBao(Guid thongBaoId)
        {
            var tb = await _context.ThongBaos.FirstOrDefaultAsync(i => i.Id == thongBaoId);
            if (tb == null)
            {
                throw new Exception("Thông báo không tồn tại");
            }
            _context.ThongBaos.Remove(tb);
            _context.SaveChanges();
            return new JsonResult(tb);
        }

        public async Task<ActionResult> CapNhatTrangThaiThongBao(Guid thongBaoId)
        {
            var tb = await _context.ThongBaos.FirstOrDefaultAsync(i => i.Id == thongBaoId);
            if (tb == null)
            {
                throw new Exception("Thông báo không tồn tại");
            }
            tb.Status = 1;
            _context.ThongBaos.Update(tb);
            _context.SaveChanges();
            return new JsonResult(tb);
        }

        public async Task<ActionResult> LayThongBao(string username)
        {
            List<ThongBao> listTb = new List<ThongBao>();

            var listTbByUserName = await _context.ThongBaos.Where(i => i.Username == username).ToListAsync();
            if (listTbByUserName.Count > 0)
            {
                listTb.AddRange(listTbByUserName);
            }

            var listLop = await _context.ChiTietLops.Where(i => i.Username == username).Select(i => new { i.LopId, i.NamHoc }).ToListAsync();
            foreach (var item in listLop)
            {
                var listTbByLop = await _context.ThongBaos.Where(i => i.LopId == item.LopId && i.NamHoc == item.NamHoc).ToListAsync();
                if (listTbByLop.Count > 0)
                {
                    listTb.AddRange(listTbByLop);
                }
            }

            listTb = listTb.OrderByDescending(i => i.NgayTao).ToList();


            return new JsonResult(listTb);
        }

        public async Task<ActionResult> CapNhatTrangThaiListThongBao(List<Guid> listTbId)
        {
            foreach (var item in listTbId)
            {
                var tb = await _context.ThongBaos.FirstOrDefaultAsync(i => i.Id == item && i.Status == 0);
                if(tb != null)
                {
                    tb.Status = 1;
                    _context.ThongBaos.Update(tb);
                }
            }
            _context.SaveChanges();
            return new JsonResult(true);
        }
    }
}

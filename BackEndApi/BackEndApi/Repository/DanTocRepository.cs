﻿using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Repository
{
    public class DanTocRepository : IDantocRepository
    {
        public ApplicationDbContext _context;
        public DanTocRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult CreateDanToc(DanTocDto dantocDto)
        {
            if(String.IsNullOrWhiteSpace(dantocDto.TenDanToc))
            {
                throw new Exception("Tên dân tộc không được để trống");
            }
            DanToc dantoc = new DanToc()
            {
                Id = new Guid(),
                TenDanToc = dantocDto.TenDanToc
            };
            _context.Add(dantoc);
            _context.SaveChanges();
            return new JsonResult(dantoc);
        }

        public IActionResult DeleteDanToc(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<List<DanToc>>> GetAllDanToc()
        {
            return await _context.DanTocs.ToListAsync();
        }

        public IActionResult UpdateDanToc(DanToc dantoc)
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interface.IRepository
{
    public interface IHocBaRepository
    {
        public Task<ActionResult> GetHocBaByUserName(string userName , int lop);
    }
}

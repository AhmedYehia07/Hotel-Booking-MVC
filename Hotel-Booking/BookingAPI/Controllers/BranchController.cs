using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController(IBranchRepository branchRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<List<HotelBranch>> GetAllBranches()
        {
            var BranchList = await branchRepository.GetAllAsync(IncludeProperties: "HotelRooms");
            return BranchList;
        }
    }
}

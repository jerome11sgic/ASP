using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DistrictApi.Models;

namespace pr1_ElectionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly DistrictContext _context;

        public DistrictController(DistrictContext context)
        {
            _context = context;

            if (_context.DistrictDatas.Count() == 0)
            {
                _context.DistrictDatas.Add(new DistrictData { Name="Jaffna"});
                _context.DistrictDatas.Add(new DistrictData { Name = "Colombo" });
                _context.SaveChanges();
            }
        }

        // GET: api/DistrictDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DistrictData>>> GetDistrictDatas()
        {
            return await _context.DistrictDatas.ToListAsync();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DistrictData>> GetTodoItem(long id)
        {
            var districtData = await _context.DistrictDatas.FindAsync(id);

            if (districtData == null)
            {
                return NotFound();
            }

            return districtData;
        }
    }
}
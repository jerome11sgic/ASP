using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CandidateApi.Models;

namespace pr1_ElectionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly CandidateContext _context;

        public CandidateController(CandidateContext context)
        {
            _context = context;

            if (_context.CandidateDatas.Count() == 0)
            {
                _context.CandidateDatas.Add(new CandidateData { Name="abc",Party="SLFP"});
                _context.CandidateDatas.Add(new CandidateData { Name = "xyx",Party="UNP" });
                _context.SaveChanges();
            }
        }

        // GET: api/DistrictDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidateData>>> GetDistrictDatas()
        {
            return await _context.CandidateDatas.ToListAsync();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateData>> GetTodoItem(long id)
        {
            var candidateData = await _context.CandidateDatas.FindAsync(id);

            if (candidateData == null)
            {
                return NotFound();
            }

            return candidateData;
        }
    }
}
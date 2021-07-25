using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mutants31.Core;
using Mutants31.Model;
using Mutants31.Util;
using System.Linq;
using System.Threading.Tasks;

namespace Mutants31.Controllers
{
    [ApiController]
    [Route("api/mutant")]
    public class MutantsController : Controller
    {
        private readonly MutantDNA _mutantDNA;
        private readonly ApplicationDBContext _context;

        public MutantsController(ApplicationDBContext context)
        {
            _context = context;
            _mutantDNA = new MutantDNA();
        }

        [HttpPost]
        public async Task<IActionResult> IsMutant([FromBody] Mutant mutant)
        {
            bool isMutant = _mutantDNA.IsMutantDNA(mutant.dna);
            mutant.IsMutant = isMutant;

            mutant.SetDnaSecuence();

            _context.Add(mutant);
            await _context.SaveChangesAsync();

            return isMutant ? Ok() : StatusCode(403);
        }

        [HttpGet("stats")]
        public async Task<ActionResult<MutantStats>> GetMutantsHistory()
        {
            MutantStats mutantStats = new MutantStats();
            mutantStats.count_human_dna = await _context.MutantsHistory.Where(m => !m.IsMutant).CountAsync();
            mutantStats.count_mutant_dna = await _context.MutantsHistory.Where(m => m.IsMutant).CountAsync();
            mutantStats.ratio = mutantStats.GetRatio();

            return mutantStats;
        }
    }
}

using Domani;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class activitisApi(AppdbContext context) : BaseController
    {
        
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivitis()
        {
              return await context.Activities.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActiviti(string id)
        {
            var activiti = await context.Activities.FindAsync(id);
            if (activiti == null) return NotFound();
            return activiti;
        }
    }
}
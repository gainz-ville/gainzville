using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Gainzville.Server.Services;

namespace Gainzville.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IGainzService dataService;

        public ProfilesController(IGainzService dataService)
        {
            this.dataService = dataService;
        }

        // GET: api/Profiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shared.Profile>>> GetProfile()
        {
            //return await _context.Profile.AsNoTracking().Select(o => o.ToModel()).ToListAsync();
            return new ActionResult<IEnumerable<Shared.Profile>>(await this.dataService.GetProfiles());
        }

        //// GET: api/Profiles/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Profile>> GetProfile(Guid id)
        //{
        //    var profile = await _context.Profile.FindAsync(id);

        //    if (profile == null)
        //    {
        //        return NotFound();
        //    }

        //    return profile;
        //}

        //// PUT: api/Profiles/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProfile(Guid id, Profile profile)
        //{
        //    if (id != profile.ProfileId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(profile).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProfileExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Profiles
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        //public async Task<ActionResult<Profile>> PostProfile(Profile profile)
        //{
        //    _context.Profile.Add(profile);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetProfile", new { id = profile.ProfileId }, profile);
        //}

        //// DELETE: api/Profiles/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Profile>> DeleteProfile(Guid id)
        //{
        //    var profile = await _context.Profile.FindAsync(id);
        //    if (profile == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Profile.Remove(profile);
        //    await _context.SaveChangesAsync();

        //    return profile;
        //}

        //private bool ProfileExists(Guid id)
        //{
        //    return _context.Profile.Any(e => e.ProfileId == id);
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LogisticsWebApp.Data;
using LogisticsWebApp.Models;

namespace LogisticsWebApp.API
{
    [Route("api/tracking")]
    [ApiController]
    public class TracksAPIController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TracksAPIController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TracksAPI - Return all the available records in database
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Track>>> Gettbl_Track()
        {
            return await _context.tbl_Track.ToListAsync();
        }

        // GET: api/TracksAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Track>> GetTrack(int id)
        {
            var track = await _context.tbl_Track.Where(tr => tr.TrackingNumber == id.ToString()).FirstOrDefaultAsync();

            if (track == null)
            {
                return NotFound();
            }

            return track;
        }


        private bool TrackExists(int id)
        {
            return _context.tbl_Track.Any(e => e.Id == id);
        }
    }
}

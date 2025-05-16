﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduSyncwebapi.Data;
using EduSyncwebapi.Models;

namespace EduSyncwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultModelsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ResultModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ResultModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResultModel>>> GetResultModels()
        {
            return await _context.ResultModels.ToListAsync();
        }

        // GET: api/ResultModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResultModel>> GetResultModel(Guid id)
        {
            var resultModel = await _context.ResultModels.FindAsync(id);

            if (resultModel == null)
            {
                return NotFound();
            }

            return resultModel;
        }

        // PUT: api/ResultModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResultModel(Guid id, ResultModel resultModel)
        {
            if (id != resultModel.ResultId)
            {
                return BadRequest();
            }

            _context.Entry(resultModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResultModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ResultModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResultModel>> PostResultModel(ResultModel resultModel)
        {
            _context.ResultModels.Add(resultModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ResultModelExists(resultModel.ResultId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetResultModel", new { id = resultModel.ResultId }, resultModel);
        }

        // DELETE: api/ResultModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResultModel(Guid id)
        {
            var resultModel = await _context.ResultModels.FindAsync(id);
            if (resultModel == null)
            {
                return NotFound();
            }

            _context.ResultModels.Remove(resultModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResultModelExists(Guid id)
        {
            return _context.ResultModels.Any(e => e.ResultId == id);
        }
    }
}

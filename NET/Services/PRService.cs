using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NET.Domain;
using NET.Mappers;
using NET.Services.Interfaces;

namespace NET.Services
{
    public class PRService : IPrService
    {
        private readonly ApplicationDbContext _context;
        public PRService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PRDTO> CreatePRAsync(CreatePRDTO createPrDto)
        {
            var newPr = createPrDto.ToEntity();
            await _context.PRs.AddAsync(newPr);
            await _context.SaveChangesAsync();
            return newPr.ToDto();
        }

        public async Task<bool> DeletePRAsync(int id)
        {
            var pr = await _context.PRs.FindAsync(id);
            if (pr == null) return false;

            _context.PRs.Remove(pr);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PRDTO>> GetAllPRsAsync()
        {
            var prs = await _context.PRs.ToListAsync();
            return prs.Select(p => p.ToDto());
        }

        public async Task<PRDTO> GetPRByIdAsync(int id)
        {
            var pr = await _context.PRs.FindAsync(id);
            if (pr == null)
            {
                throw new Exception("PR not found");
            }
            return pr.ToDto();
        }

        public async Task<PRDTO> UpdatePRAsync(int id, UpdatePRDTO prDto)
        {
            var pr = await _context.PRs.FindAsync(id);
            if (pr == null)
            {
                throw new Exception("PR not found");
            }
            pr.UpdateEntity(prDto);
            await _context.SaveChangesAsync();
            return pr.ToDto();
        }
    }
}
using Ambev.DeveloperEvaluation.Domain.Services;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Services.SalesCart
{
    public class BranchService : IBranchService
    {
        private static readonly List<BranchInfo> _branches = new()
        {
            new BranchInfo { BranchId = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Filial São Paulo", Location = "São Paulo - SP" },
            new BranchInfo { BranchId = Guid.Parse("22222222-2222-2222-2222-222222222222"), Name = "Filial Rio de Janeiro", Location = "Rio de Janeiro - RJ" },
            new BranchInfo { BranchId = Guid.Parse("33333333-3333-3333-3333-333333333333"), Name = "Filial Belo Horizonte", Location = "Belo Horizonte - MG" },
            new BranchInfo { BranchId = Guid.Parse("44444444-4444-4444-4444-444444444444"), Name = "Filial Porto Alegre", Location = "Porto Alegre - RS" },
            new BranchInfo { BranchId = Guid.Parse("55555555-5555-5555-5555-555555555555"), Name = "Filial Salvador", Location = "Salvador - BA" },
            new BranchInfo { BranchId = Guid.Parse("66666666-6666-6666-6666-666666666666"), Name = "Filial Brasília", Location = "Brasília - DF" },
            new BranchInfo { BranchId = Guid.Parse("77777777-7777-7777-7777-777777777777"), Name = "Filial Recife", Location = "Recife - PE" },
            new BranchInfo { BranchId = Guid.Parse("88888888-8888-8888-8888-888888888888"), Name = "Filial Fortaleza", Location = "Fortaleza - CE" }
        };

        public Task<IEnumerable<BranchInfo>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<BranchInfo>>(_branches);
        }

        public Task<BranchInfo?> GetByIdAsync(Guid branchId)
        {
            var branch = _branches.FirstOrDefault(b => b.BranchId == branchId);
            return Task.FromResult(branch);
        }
    }
}

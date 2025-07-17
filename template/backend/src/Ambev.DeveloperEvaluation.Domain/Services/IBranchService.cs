using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public interface IBranchService
    {
        Task<BranchInfo?> GetByIdAsync(Guid branchId);
        Task<IEnumerable<BranchInfo>> GetAllAsync();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.ValueObjects
{
    public class BranchInfo
    {
        public Guid BranchId { get; private set; }
        public string Name { get; private set; }
        public string Location { get; private set; }

        public BranchInfo(Guid branchId, string name, string location)
        {
            if (branchId == Guid.Empty)
                throw new ArgumentException("Branch ID cannot be empty");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Branch name cannot be empty");

            BranchId = branchId;
            Name = name;
            Location = location ?? string.Empty;
        }

        // Construtor parameterless (MongoDB)
        public BranchInfo() { }
    }
}

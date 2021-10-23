using HRLeaveManagement.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Persistence.Contracts
{
    public interface IleaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
        Task<List<LeaveAllocation>> GetLeaveAllocationListWithDetails();
    }
}

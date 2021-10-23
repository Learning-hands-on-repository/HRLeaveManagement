using HRLeaveManagement.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveRequest>
    {
    }
}

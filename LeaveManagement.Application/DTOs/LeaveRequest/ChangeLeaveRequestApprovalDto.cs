using HRLeaveManagement.Application.DTOs.Common;

namespace HRLeaveManagement.Application.DTOs.LeaveRequest
{
    public class ChangeLeaveRequestApprovalDto : BaseDto
    {
        public bool? Approval { get; set; }
    }
}

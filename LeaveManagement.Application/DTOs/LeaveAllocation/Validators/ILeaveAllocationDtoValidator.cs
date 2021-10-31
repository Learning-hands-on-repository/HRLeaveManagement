using FluentValidation;
using HRLeaveManagement.Application.Persistence.Contracts;

namespace HRLeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public ILeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.NumberOfDays)
                            .NotEmpty().WithMessage("{PropertyName} is required")
                            .GreaterThan(0);

            RuleFor(p => p.LeaveTypeId)
                    .NotNull()
                    .GreaterThan(0)
                    .MustAsync(async (id, token) =>
                    {
                        var leaveTypeExist = await _leaveTypeRepository.Exists(id);
                        return !leaveTypeExist;
                    })
                    .WithMessage("{PropertyName} does not exist");
        }
    }
}

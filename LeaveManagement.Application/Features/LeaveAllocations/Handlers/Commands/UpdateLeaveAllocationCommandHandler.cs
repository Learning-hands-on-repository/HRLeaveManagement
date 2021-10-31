using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveAllocation.Validators;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly IleaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveAllocationCommandHandler(
            IleaveAllocationRepository leaveAllocationRepository,
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveAllocationDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateLeaveAllocationDto);

            if (validationResult.IsValid == false)
                throw new Exception();

            var leaveAllocation = await _leaveAllocationRepository.Get(request.UpdateLeaveAllocationDto.Id);

            _mapper.Map(request.UpdateLeaveAllocationDto, leaveAllocation);

            await _leaveAllocationRepository.Update(leaveAllocation);

            return Unit.Value;
        }
    }
}

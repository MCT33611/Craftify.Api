using Craftify.Application.Common.Interfaces.Persistence.IRepository;
using Craftify.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Craftify.Application.Plan.Commands.CreatePlan
{
    public class CreatePlanCommandHandler : IRequestHandler<CreatePlanCommand, ErrorOr<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePlanCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Guid>> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
        {
            // Check for duplication
            var existingPlan = _unitOfWork.Plan.GetAll().FirstOrDefault(p => p.Title == request.Title);
            if (existingPlan != null)
            {
                return Error.Conflict("DuplicatePlan", "A plan with the same title already exists.");
            }

            Domain.Entities.Plan plan = new()
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Price = request.Price,
                Duration = request.Duration,
            };

            _unitOfWork.Plan.Add(plan);
            await _unitOfWork.Save();

            return plan.Id;
        }
    }
}

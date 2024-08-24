﻿using Craftify.Application.Common.Interfaces.Persistence.IRepository;
using Craftify.Application.Profile.Common;
using Craftify.Domain.Constants;
using Craftify.Domain.Entities;
using ErrorOr;
using MediatR;
using Razorpay.Api;

namespace Craftify.Application.Profile.Queries.GetAllWorkers
{
    public class GetAllWorkersQueryHandler(
        IUnitOfWork _unitOfWork
        ) : IRequestHandler<GetAllWorkersQuery, ErrorOr<IEnumerable<WorkerResult>>>
    {
        public async Task<ErrorOr<IEnumerable<WorkerResult>>> Handle(GetAllWorkersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                await Task.CompletedTask;
                IList<Worker> workers = _unitOfWork.Worker.GetAll( includedProperties: "User").ToList();

                var result = workers.Select(w => new WorkerResult() { 
                    Id = w.Id,
                    UserId = w.UserId,
                    User = w.User,
                    ServiceTitle = w.ServiceTitle,
                    Description = w.Description,
                    CertificationUrl = w.CertificationUrl,
                    Skills = w.Skills,
                    HireDate = w.HireDate,
                    PerHourPrice =  w.PerHourPrice,
                    Approved = w.Approved,
                    LogoUrl = w.LogoUrl,
                    SmallPreviewImageUrl = w.SmallPreviewImageUrl,
                    MediumPreviewImageUrl = w.MediumPreviewImageUrl,
                    LargePreviewImageUrl = w.LargePreviewImageUrl
                }).ToList();

                return result;
            }
            catch (Exception)
            {
                return Error.NotFound("Profiles not found", "An error occurred while fetching profiles.");
            }
        }
    }
}



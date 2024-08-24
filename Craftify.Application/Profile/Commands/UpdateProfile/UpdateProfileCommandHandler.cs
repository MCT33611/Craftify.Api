﻿using Craftify.Application.Common.Interfaces.Persistence;
using Craftify.Application.Common.Interfaces.Persistence.IRepository;
using ErrorOr;
using MediatR;
using Craftify.Domain.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Craftify.Application.Common.Interfaces.Service;

namespace Craftify.Application.Profile.Commands.UpdateProfile
{
    public class UpdateProfileCommandHandler(
        IUnitOfWork _unitOfWrok,
        IDateTimeProvider _date
        ) : IRequestHandler<UpdateProfileCommand, ErrorOr<Unit>>
    {
        public async Task<ErrorOr<Unit>> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            // Retrieve user from repository
            var user = _unitOfWrok.User.GetUserById(request.Id);
            if (user == null)
                return Errors.User.InvaildCredetial;

            // Update user properties
            user.FirstName = request.Model.FirstName ?? user.FirstName;
            user.LastName = request.Model.LastName ?? user.LastName;
            user.StreetAddress = request.Model.StreetAddress ?? user.StreetAddress;
            user.City = request.Model.City ?? user.City;
            user.State = request.Model.State ?? user.State;
            user.PostalCode = request.Model.PostalCode ?? user.PostalCode;
            user.ProfilePicture = request.Model.ProfilePicture ?? user.ProfilePicture;
            user.UpdatedDate = _date.UtcNow;
            _unitOfWrok.User.Update(user);
            await _unitOfWrok.Save();
            return Unit.Value;

        }
    }
}

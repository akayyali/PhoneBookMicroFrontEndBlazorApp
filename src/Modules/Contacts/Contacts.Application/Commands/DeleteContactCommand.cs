using Contacts.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Application.Commands
{
    public record DeleteContactCommand(Guid ContactId) : IRequest;

}

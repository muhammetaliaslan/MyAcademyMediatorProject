using MediatR;
using System;

namespace MyAcademyMediatorProject.MediatorPattern.Commands.CampaignCommands
{
    public record RemoveCampaignCommand(Guid Id) : IRequest<Unit>;
}
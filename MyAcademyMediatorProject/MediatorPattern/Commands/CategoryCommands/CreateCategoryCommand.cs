using MediatR;

namespace MyAcademyMediatorProject.MediatorPattern.Commands.CategoryCommands;

    public record CreateCategoryCommand(string Name): IRequest;

  
 
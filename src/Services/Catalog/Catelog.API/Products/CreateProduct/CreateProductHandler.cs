using BuildingBlocks.CQRS;
using Catelog.API.Models;
using MediatR;

namespace Catelog.API.Products.CreateProduct;

public record CreateProductCommand(string Name
    , List<string> Category
    , string Description
    , string ImageFile
    , decimal Price)
    : ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id);
internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        // Create Product Entity from Command Object
        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };

        // TODO
        // Save to Database

        // return CreateProduct result
        return new CreateProductResult(Guid.NewGuid());
    }
}
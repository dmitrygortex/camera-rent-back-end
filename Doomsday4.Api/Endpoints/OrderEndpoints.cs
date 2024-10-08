using Doomsday4.Application.Order.Command;
using Doomsday4.Application.Order.Queries;
using Doomsday4.Application.User.Command;
using Doomsday4.Domain;
using Doomsday4.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Doomsday4.Api.Endpoints;

public static class OrderEndpoints
{
    public static WebApplication AddOrderEndpoints(this WebApplication app)
        {
            var endpoints = app.MapGroup("/order");
    
            endpoints.MapPost("/add", async (IMediator mediator,[FromBody] Order order) =>
            {
                var result = await mediator.Send(new AddNewOrder(order.UserId, order.StartDateTime, 
                    order.EndDateTime, order.Сost, order.Status));
                return Results.Ok(result);
            });
            
            endpoints.MapGet("/find-all", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new FindAllOrders());
                
                return Results.Ok(result);
            });
            
            endpoints.MapGet("/find-by-id/{id}", async (IMediator mediator,[FromBody] FindOrderById order) =>
            {
                var result = await mediator.Send(new FindOrderById(order.Id));
                
                return Results.Ok(result);
            });
            
            return app;
        }
}
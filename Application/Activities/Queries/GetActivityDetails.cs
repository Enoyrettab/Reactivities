using System;
using MediatR;
using Domain;
using Persistence;
using Microsoft.EntityFrameworkCore.Query;
using Application.Core;

namespace Application.Activities.Queries;

public class GetActivityDetails
{

	public class Query : IRequest<Result<ActivityDto>>
	{
		public required string Id { get; set; }
	}

	public class Handler(AppDbContext context) : IRequestHandler<Query, Result<ActivityDto>>
	{
		public async Task<Result<ActivityDto>> Handle(Query request, CancellationToken cancellationToken)
		{
			var activity = await context.Activities.FindAsync([request.Id], cancellationToken);
			if (activity == null) return Result<ActivityDto>.Failure("Activity not found", 404);
			return Result<ActivityDto>.Success(activity);
		}
	}
}

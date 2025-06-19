using System;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities.Queries;

public class GetActivityList
{
	public class Query : IRequest<List<ActivityDto>> { }

	public class Handler(AppDbContext context) : IRequestHandler<Query, List<ActivityDto>>
	{
		public async Task<List<ActivityDto>> Handle(Query request, CancellationToken cancellationToken)
		{
			return await context.Activities.ToListAsync(cancellationToken);
		}
	}
}

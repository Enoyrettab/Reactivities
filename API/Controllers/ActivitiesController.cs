using System;
using Microsoft.AspNetCore.Mvc;
using Domain;
using MediatR;
using Application.Activities.Queries;
using Application.Activities.Commands;
using Application.Activities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Application.Core;

namespace API.Controllers;

public class ActivitiesController() : BaseApiController
{
	[HttpGet]
	public async Task<ActionResult<PagedList<ActivityDto, DateTime?>>> GetActivities(
				[FromQuery] ActivityParams activityParams)
	{
		return HandleResult(await Mediator.Send(new GetActivityList.Query{Params = activityParams}));
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<ActivityDto>> GetActivityDetail(string id)
	{
		return HandleResult(await Mediator.Send(new GetActivityDetails.Query { Id = id }));
	}

	[HttpPost]
	public async Task<ActionResult<string>> CreateActivity(CreateActivityDto activityDto)
	{
		return HandleResult(await Mediator.Send(new CreateActivity.Command { ActivityDto = activityDto }));
	}

	[HttpPut]
	[Authorize(Policy = "IsActivityHost")]
	public async Task<ActionResult> EditActivity(EditActivityDto activity)
	{
		return HandleResult(await Mediator.Send(new EditActivity.Command { ActivityDto = activity }));
	}

	[HttpDelete("{id}")]
	[Authorize(Policy = "IsActivityHost")]
		public async Task<ActionResult> DeleteActivity(string id)
	{
		return HandleResult(await Mediator.Send(new DeleteActivity.Command { Id = id }));
	}

	[HttpPost("{id}/attend")]
	public async Task<ActionResult> Attend(string id)
	{
		return HandleResult(await Mediator.Send(new UpdateAttendance.Command { Id = id }));
	}
}

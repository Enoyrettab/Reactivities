using System;
using Application.Profiles;
using Application.Profiles.Commands;
using Application.Profiles.DTOs;
using Application.Profiles.Queries;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProfilesController : BaseApiController
{

	[HttpPost("add-photo")]
	public async Task<ActionResult<Photo>> AddPhoto([FromForm] IFormFile file) //AddPhoto.Command command)
	{
		return HandleResult(await Mediator.Send(new AddPhoto.Command { File = file }));
	}

	[HttpGet("{userId}/photos")]
	public async Task<ActionResult<List<Photo>>> GetPhotosForUser(string userId)
	{
		return HandleResult(await Mediator.Send(new GetProfilePhotos.Query { UserId = userId }));
	}

	[HttpDelete("{photoId}/photos")]
	public async Task<ActionResult> DeletePhotos(string photoId)
	{
		return HandleResult(await Mediator.Send(new DeletePhoto.Command { PhotoId = photoId }));
	}

	[HttpPut("{photoId}/setMainPhoto")]
	public async Task<ActionResult> SetMainPhoto(string photoId)
	{
		return HandleResult(await Mediator.Send(new SetMainPhoto.Command { PhotoId = photoId }));
	}

	[HttpGet("{userId}")]
	public async Task<ActionResult<UserProfile>> GetProfile(string userId)
	{
		return HandleResult(await Mediator.Send(new GetProfile.Query { UserId = userId }));
	}

	[HttpPost("{userId}/follow")]
	public async Task<ActionResult> FollowToggle(string userId)
	{
		return HandleResult(await Mediator
			.Send(new FollowToggle.Command { TargetUserId = userId }));
	}

	[HttpGet("{userId}/follow-list")]
	public async Task<ActionResult> GetFollowings(string userId, string predicate)
	{
		return HandleResult(await Mediator
			.Send(new GetFollowings.Query { UserId = userId, Predicate = predicate }));
	}

	[HttpGet("{userId}/activities")]
	public async Task<IActionResult> GetUserActivities(string userId, string filter)
	{
		return HandleResult(await Mediator
			.Send(new GetUserActivities.Query { UserId = userId, Filter = filter }));
	}

}

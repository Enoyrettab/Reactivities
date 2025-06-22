using System;

namespace Application.Profiles.DTOs;

public class UserProfile
{
	public required string id { get; set; }
	public required string DisplayName { get; set; }
	public string? Bio { get; set; }
	public string? ImageUrl { get; set; }
}

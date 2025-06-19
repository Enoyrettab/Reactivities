using System;
using Application.Activities.DTOs;
using AutoMapper;
using Domain;

namespace Application.Core;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<ActivityDto, ActivityDto>();
		CreateMap<CreateActivityDto, ActivityDto>();
		CreateMap<EditActivityDto, ActivityDto>();
	}
}

﻿using FoodOrder.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace FoodOrder.WebApi.Services
{
	public class CurrentUserService : ICurrentUserService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public CurrentUserService(IHttpContextAccessor httpContextAccessor) =>
			_httpContextAccessor = httpContextAccessor;

		public Guid UserId 
		{
			get
			{
				var id = _httpContextAccessor.HttpContext?.User?
					.FindFirstValue(ClaimTypes.NameIdentifier);

				return string.IsNullOrEmpty(id) ? Guid.Empty : Guid.Parse(id);
			}
		}
	}
}

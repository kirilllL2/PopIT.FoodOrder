﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Application.Interfaces
{
	public interface ICurrentUserService
	{
		Guid UserId { get; }
	}
}

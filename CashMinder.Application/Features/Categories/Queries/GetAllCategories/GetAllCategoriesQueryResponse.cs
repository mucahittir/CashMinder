﻿using CashMinder.Application.DTOs;

namespace CashMinder.Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryResponse
    {
        public string Name { get; set; }
        public UserDto User { get; set; }
    }
}

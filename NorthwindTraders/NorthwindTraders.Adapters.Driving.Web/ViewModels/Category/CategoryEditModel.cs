﻿using Microsoft.AspNetCore.Http;

namespace NorthwindTraders.Adapters.Driving.Web.ViewModels.Category
{
    public class CategoryEditModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public IFormFile Picture { get; set; }
    }
}

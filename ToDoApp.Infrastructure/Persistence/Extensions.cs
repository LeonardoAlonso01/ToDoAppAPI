using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Models;

namespace ToDoApp.Infrastructure.Persistence
{
    public static class Extensions
    {
        public static async Task<PaginationResult<T>> GetPaged<T>(
            this IQueryable<T> query,
            int Page,
            int PageSize) where T : class
        {
            var result = new PaginationResult<T>();

            result.Page = Page;
            result.PageSize = PageSize;
            result.ItemsCount = await query.CountAsync();

            var pageCount = (double)result.ItemsCount / PageSize;
            result.TotalPages = (int)Math.Ceiling(pageCount);

            var skip = (Page - 1) * PageSize;

            result.Data = await query.Skip(skip).Take(PageSize).ToListAsync();

            return result;
        }
    }
}

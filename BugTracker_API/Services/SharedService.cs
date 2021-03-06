﻿using BugTracker_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BugTracker_API.Services
{
    public class SharedService : ISharedService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SharedService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Issue> GetIssueAsync(Project project, int issueNumber)
        {
            return await _context.Issues
                .Where(issue => issue.Project == project)
                .Where(issue => issue.Number == issueNumber)
                .Include(issue => issue.User)
                .SingleOrDefaultAsync();
        }

        public int GetCurrentUserId()
        {
            return int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        public async Task<Project> GetProjectAsync(long projectId)
        {
            return await _context.Projects
                .Where(project => project.Id == projectId)
                .Include(project => project.User)
                .SingleOrDefaultAsync();
        }
    }
}

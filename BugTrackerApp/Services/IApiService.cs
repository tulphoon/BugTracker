﻿using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Threading.Tasks;

using BugTrackerApp.Models;
using Refit;

namespace BugTrackerApp.Services
{
    public interface IApiService
    {
        [Post("/auth/login")]
        Task<AuthToken> PostLogin([Body] AuthAccountDetails loginDetails);

        [Post("/auth/register")]
        Task<AuthId> PostRegister([Body] AuthAccountDetails registerDetails);

        [Get("/projects")]
        Task<List<Project>> GetProjects();

        [Get("/projects/{id}")]
        Task<Project> GetProject([AliasAs("id")] long projectId);

        [Post("/projects")]
        Task<Project> PostProject([Body] PostProject projectDetails, [Header("Authorization")] string bearerToken);

        [Get("/projects/{projectId}/issues")]
        Task<List<Issue>> GetIssues([AliasAs("projectId")] long projectId);

        [Post("/projects/{projectId}/issues")]
        Task<Issue> PostIssue([AliasAs("projectId")] long projectId, [Body] PostIssue issueDetails, [Header("Authorization")] string bearerToken);

        [Get("/projects/{projectId}/issues/{issueNumber}")]
        Task<Issue> GetIssue(long projectId, int issueNumber);

        [Get("/projects/{projectId}/issues/{issueNumber}/comments")]
        Task<List<Comment>> GetComments(long projectId, int issueNumber);

        [Post("/projects/{projectId}/issues/{issueNumber}/comments")]
        Task<Comment> PostComment(long projectId, int issueNumber, [Body] PostComment commentDetails, [Header("Authorization")] string bearerToken);
    }
}
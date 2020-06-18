﻿////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  BugTracker_API\Services\ISharedService.cs </file>
///
/// <copyright file="ISharedService.cs" company="MyCompany.com">
/// Copyright (c) 2020 MyCompany.com. All rights reserved.
/// </copyright>
///
/// <summary>   Declares the ISharedService interface. </summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Threading.Tasks;
using BugTracker_API.Models;

namespace BugTracker_API.Services
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Interface for shared service. </summary>
    ///
    /// <remarks>   Dawid, 18/06/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public interface ISharedService
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets issue asynchronous. </summary>
        ///
        /// <param name="project">      The project. </param>
        /// <param name="issueNumber">  The issue number. </param>
        ///
        /// <returns>   An asynchronous result that yields the issue. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Task<Issue> GetIssueAsync(Project project, int issueNumber);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets current user identifier. </summary>
        ///
        /// <returns>   The current user identifier. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int GetCurrentUserId();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets project asynchronous. </summary>
        ///
        /// <param name="projectId">    Identifier for the project. </param>
        ///
        /// <returns>   An asynchronous result that yields the project. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        Task<Project> GetProjectAsync(long projectId);
    }
}

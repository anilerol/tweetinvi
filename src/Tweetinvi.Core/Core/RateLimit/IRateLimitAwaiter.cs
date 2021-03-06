﻿using System;
using System.Threading.Tasks;
using Tweetinvi.Core.Client;
using Tweetinvi.Events;
using Tweetinvi.Models;

namespace Tweetinvi.Core.RateLimit
{
    /// <summary>
    /// Wait for the RateLimits before performing an operation.
    /// </summary>
    public interface IRateLimitAwaiter
    {
        /// <summary>
        /// Inform that a query is currently waiting in the RateLimitAwaiter
        /// for the appropriate RateLimits to be refreshed before being executed.
        /// </summary>
        event EventHandler<QueryAwaitingEventArgs> QueryAwaitingForRateLimit;

        /// <summary>
        /// Wait for the credentials' rate limits to be available for the specified query.
        /// </summary>
        Task WaitForCredentialsRateLimit(ITwitterRequest request);

        /// <summary>
        /// Wait for the credentials' rate limits to be available for the specified query.
        /// </summary>
        Task WaitForCredentialsRateLimit(string query, IReadOnlyTwitterCredentials credentials, ITwitterExecutionContext executionContext);

        /// <summary>
        /// Wait for the credentials' rate limits to be available for the specified endpoint.
        /// </summary>
        Task WaitForCredentialsRateLimit(IEndpointRateLimit queryRateLimit, IReadOnlyTwitterCredentials credentials, ITwitterExecutionContext executionContext);

        /// <summary>
        /// Get the duration to wait before executing the specified query.
        /// </summary>
        Task<TimeSpan> TimeToWaitBeforeTwitterRequest(string query, IReadOnlyTwitterCredentials credentials, ITwitterExecutionContext twitterExecutionContext);

        /// <summary>
        /// Get the duration (milliseconds) to wait before executing a query using the specified rate limits.
        /// </summary>
        TimeSpan GetTimeToWaitFromQueryRateLimit(IEndpointRateLimit queryRateLimit, ITwitterExecutionContext executionContext);
    }
}
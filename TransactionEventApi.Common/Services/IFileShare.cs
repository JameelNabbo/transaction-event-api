﻿using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Glasswall.Administration.K8.TransactionEventApi.Common.Services
{
    /// <summary>
    /// Provides abstraction of the underlying file share
    /// </summary>
    public interface IFileShare
    {
        /// <summary>
        /// Retrieves a list of paths matching the filter
        /// </summary>
        /// <param name="pathFilter">An object that takes the responsibility of recursing the directory</param>
        /// <returns>A list of path matches</returns>
        IAsyncEnumerable<string> ListAsync(IPathFilter pathFilter);

        /// <summary>
        /// Determines whether the path exists
        /// </summary>
        /// <param name="path">Path to check</param>
        /// <returns>True if so, false otherwise</returns>
        Task<bool> ExistsAsync(string path);

        /// <summary>
        /// Downloads the object at the path specified
        /// </summary>
        /// <param name="path">Path to the object</param>
        /// <returns>A memory stream containing the data</returns>
        Task<MemoryStream> DownloadAsync(string path);
    }

    public interface IPathFilter
    {
        PathAction DecideAction(string path);
    }
    
    public enum PathAction
    {
        Recurse,
        Collect,
        Stop
    }
}
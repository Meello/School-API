using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Models
{
    /// <summary>
    /// Represents a paged result of an operation.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedResult<T>
    {
        private PagedResult(IEnumerable<T> results, long totalRecords)
        {
            Results = results;
            TotalRecords = totalRecords;
        }
        /// <summary>
        /// The results itself.
        /// </summary>
        public IEnumerable<T> Results { get; }
        /// <summary>
        /// Total records.
        /// </summary>
        public long TotalRecords { get; }
        /// <summary>
        /// Create instance of PagedResult.
        /// </summary>
        public static PagedResult<T> Create(IEnumerable<T> data, int totalRecords) => new PagedResult<T>(data, totalRecords);
    }
}

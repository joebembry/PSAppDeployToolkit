﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace PSADT.WindowManagement
{
    /// <summary>
    /// Represents filtering options for retrieving window information.
    /// </summary>
    /// <remarks>This record provides criteria for filtering windows based on their titles, handles, or parent
    /// processes. Any of the filters can be null, indicating that the corresponding criterion should not be
    /// applied.</remarks>
    /// <param name="windowTitleFilter">An array of strings specifying window titles to match. Only windows with titles that match one of the strings in
    /// this array will be included. If null, no filtering by title is applied.</param>
    /// <param name="windowHandleFilter">An array of window handles (as <see langword="nint"/> values) to match. Only windows with handles that match one
    /// of the values in this array will be included. If null, no filtering by handle is applied.</param>
    /// <param name="parentProcessFilter">An array of strings specifying parent process names to match. Only windows associated with processes whose names
    /// match one of the strings in this array will be included. If null, no filtering by parent process is applied.</param>
    public sealed record WindowInfoOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowInfoOptions"/> class with optional filters for window
        /// titles, handles, and parent processes.
        /// </summary>
        /// <param name="windowTitleFilter">An optional array of strings specifying window titles to filter. If <see langword="null"/>, no filtering is
        /// applied based on window titles.</param>
        /// <param name="windowHandleFilter">An optional array of native window handles (<see cref="nint"/>) to filter. If <see langword="null"/>, no
        /// filtering is applied based on window handles.</param>
        /// <param name="parentProcessFilter">An optional array of strings specifying parent process names to filter. If <see langword="null"/>, no
        /// filtering is applied based on parent processes.</param>
        [JsonConstructor]
        public WindowInfoOptions(ReadOnlyCollection<string>? windowTitleFilter = null, ReadOnlyCollection<nint>? windowHandleFilter = null, ReadOnlyCollection<string>? parentProcessFilter = null)
        {
            WindowTitleFilter = windowTitleFilter;
            WindowHandleFilter = windowHandleFilter;
            ParentProcessFilter = parentProcessFilter;
        }

        /// <summary>
        /// Gets the filter criteria for window titles.
        /// </summary>
        [JsonProperty]
        public readonly IReadOnlyList<string>? WindowTitleFilter;

        /// <summary>
        /// Represents a filter for window handles used to determine which windows are included in certain operations.
        /// </summary>
        /// <remarks>This array contains the native integer (nint) values of window handles to be
        /// filtered. If the array is <see langword="null"/>, no filtering is applied.</remarks>
        [JsonProperty]
        public readonly IReadOnlyList<nint>? WindowHandleFilter;

        /// <summary>
        /// Represents a filter for parent process names used to determine specific conditions or behaviors.
        /// </summary>
        /// <remarks>This array contains the names of parent processes that are used as a filter. If the
        /// array is null or empty,  no filtering is applied. This member is intended for internal use and should not be
        /// accessed directly.</remarks>
        [JsonProperty]
        public readonly IReadOnlyList<string>? ParentProcessFilter;
    }
}

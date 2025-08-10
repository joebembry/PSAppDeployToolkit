﻿using System;
using System.Text.RegularExpressions;
using PSADT.Extensions;
using PSADT.LibraryInterfaces;
using Windows.Win32.System.LibraryLoader;

namespace PSADT.Utilities
{
    /// <summary>
    /// Public P/Invokes from the msi.dll library.
    /// </summary>
    public static class MsiUtilities
    {
        /// <summary>
        /// Retrieves the message string associated with an MSI exit code from the msimsg.dll resource.
        /// </summary>
        /// <param name="msiExitCode">The MSI exit code.</param>
        /// <returns>The message string associated with the given MSI exit code.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the library cannot be loaded or the message cannot be retrieved.</exception>
        public static string? GetMessageFromMsiExitCode(uint msiExitCode)
        {
            using var hMsiMsgDll = Kernel32.LoadLibraryEx("msimsg.dll", LOAD_LIBRARY_FLAGS.LOAD_LIBRARY_AS_DATAFILE);
            Span<char> bufspan = stackalloc char[4096];
            int len = User32.LoadString(hMsiMsgDll, msiExitCode, bufspan);
            var msiMsgString = bufspan.Slice(0, len).ToString().TrimRemoveNull();
            return !string.IsNullOrWhiteSpace(msiMsgString) ? Regex.Replace(msiMsgString, @"\s{2,}", " ") : null;
        }
    }
}


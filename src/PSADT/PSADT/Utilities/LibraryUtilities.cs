﻿using System;

namespace PSADT.Utilities
{
    /// <summary>
    /// A class containing utility methods for library operations.
    /// </summary>
    internal static class LibraryUtilities
    {
        /// <summary>
        /// Aligns the given value up to the nearest multiple of the system's pointer size.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        internal static int AlignUp(int value) => (value + IntPtr.Size - 1) & ~(IntPtr.Size - 1);
    }
}

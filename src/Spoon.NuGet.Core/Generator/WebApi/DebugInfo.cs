
namespace Spoon.NuGet.Core.Generator.WebApi
{
    using System;

    /// <summary>
    /// Debug info created during compile, written into generated files.
    /// </summary>
    [Flags]
    public enum DebugInfo
    {
        /// <summary>
        /// This Attribute will not add debug info when working with this attribute.
        /// </summary>
        No,
        /// <summary>
        /// If just one it will be included. None will win over All.
        /// </summary>
        All,
        /// <summary>
        /// If just one it will be excluded. None will win over All.
        /// </summary>
        None,
        /// <summary>
        /// This Attribute will add debug info when working with this attribute
        /// </summary>
        ThisOne,
    }
}
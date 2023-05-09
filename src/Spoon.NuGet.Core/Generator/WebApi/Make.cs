
namespace Spoon.NuGet.Core.Generator.WebApi
{
    using System;

    /// <summary>
    /// Parts to make
    /// </summary>
    [Flags]
    public enum Make
    {
        /// <summary>
        /// This value can be ignored
        /// </summary>
        Dummy = 0,
        /// <summary>
        /// Makes all endpoints
        /// </summary>
        All = 1 << 30,
        /// <summary>
        /// Prevent all Endpoints for being created
        /// </summary>
        None = 1 << 1,
        /// <summary>
        /// Creates WebAPI endpoint Search
        /// </summary>
        Search = 1 << 2,
        /// <summary>
        /// Creates WebAPI endpoint Create
        /// </summary>
        Create = 1 << 3,
        /// <summary>
        /// Creates WebAPI endpoint Update
        /// </summary>
        Update = 1 << 4,
        /// <summary>
        /// Creates WebAPI endpoint Delete
        /// </summary>
        Delete = 1 << 5,
        /// <summary>
        /// Creates WebAPI endpoint DeletePermanent
        /// </summary>
        DeletePermanent = 1 << 6,
        /// <summary>
        /// Creates WebAPI endpoint UnDelete
        /// </summary>
        UnDelete = 1 << 7,
        /// <summary>
        /// Creates WebAPI endpoint UnDelete
        /// </summary>
        EntityCommon = 1 << 8,

        /// <summary>
        /// Will not create a repository for the entry typ
        /// </summary>
        SkipRepository = 1 << 9,
        /// <summary>
        /// Will not make the file adding the Combined endpoints
        /// </summary>
        SkipEndpointExtensionsCommon = 1 << 10,
        /// <summary>
        /// 
        /// </summary>
        SearchPrettify = 1 << 11,
        /// <summary>
        /// 
        /// </summary>
        Get = 1 << 12,
        /// <summary>
        /// 
        /// </summary>
        DeleteSoft = 1 << 13,

    }
}
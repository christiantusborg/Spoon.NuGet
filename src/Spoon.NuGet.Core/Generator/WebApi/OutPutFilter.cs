namespace Spoon.NuGet.Core.Generator.WebApi
{
    /// <summary>
    /// 
    /// </summary>
    public enum OutputFilter
    {
        /// <summary>
        /// Not set
        /// </summary>
        Dummy=0,
        /// <summary>
        /// Output all
        /// </summary>
        All=  1 << 1,
        /// <summary>
        /// Output application parts
        /// </summary>
        Application = 1 << 2,
        /// <summary>
        /// Output Domain parts
        /// </summary>
        Domain = 1 << 3,
        /// <summary>
        /// Output Persistence parts
        /// </summary>
        Persistence = 1 << 4,
        /// <summary>
        /// Output Presentation.Api parts
        /// </summary>
        PresentationApi = 1 << 5,
        /// <summary>
        /// Output Presentation.Api.Contracts parts
        /// </summary>
        PresentationApiContracts = 1 << 6,
        /// <summary>
        /// Output Root parts
        /// </summary>
        Root = 1 << 7,

    }
}
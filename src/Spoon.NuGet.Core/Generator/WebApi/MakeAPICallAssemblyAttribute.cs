namespace Spoon.NuGet.Core.Generator.WebApi
{
    using System;

    /// <summary>
    /// Add to Auto create a Web Api Method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true)]
    public class MakeAPICallAssemblyAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public OutputFilter OutputFilter { get; set; } = OutputFilter.All;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputFilter"></param>
        public MakeAPICallAssemblyAttribute(OutputFilter outputFilter = OutputFilter.All)
        {
            this.OutputFilter = outputFilter;
        }

    }
}
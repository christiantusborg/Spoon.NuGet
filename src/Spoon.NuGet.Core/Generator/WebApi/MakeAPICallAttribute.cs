namespace Spoon.NuGet.Core.Generator.WebApi;

/// <summary>
///     Add to Auto create a Web Api Method.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true)]
public class MakeAPICallAttribute : Attribute
{
    /// <summary>
    /// </summary>
    public IdDataType IdDataType { get; set; } = IdDataType.GuidType;

    /// <summary>
    ///     Version number to be used.
    /// </summary>
    public string VersionNumber { get; set; } = "1.0";

    /// <summary>
    ///     The namespace to use, will be read from the class the attribute is placed above.
    /// </summary>
    public string NamespaceName { get; set; }

    /// <summary>
    ///     The application name to use, will be read from the class the attribute is placed above.
    /// </summary>
    public string AppName { get; set; }

    /// <summary>
    ///     Name and path to the DataDbContext, to be used.
    /// </summary>
    public string DataDbContext { get; set; }

    /// <summary>
    ///     Files to be skipped.
    /// </summary>
    public string SkipMake { get; set; }

    /// <summary>
    ///     Parts to make or not.
    /// </summary>
    public Make Make { get; set; }

    /// <summary>
    ///     Controls to write some debug info to the generated files.
    /// </summary>
    public DebugInfo DebugInfo { get; set; }

    /// <summary>
    ///     If multiply dtoName + repositoryItemName + versionNumber, this will be used for namespaceName and appName.
    /// </summary>
    public IsPrimary IsPrimary { get; set; }

    /// <summary>
    ///     The name that's will be used to med the class and method name exposed to the end user, if it ends with Dto the Dto
    ///     will be removed and rest of the name used.
    ///     If the attribute is placed over a class ending with DTO and this is null or empty, this will be filled with class
    ///     name.
    /// </summary>
    public string DtoName { get; set; }

    /// <summary>
    ///     The name of the item c
    ///     If the attribute is placed over a class not ending with DTO and this is null or empty, this will be filled with
    ///     class name.
    /// </summary>
    public string RepositoryItemName { get; set; }

    /// <summary>
    /// </summary>
    public List<string> SkipMakeList { get; internal set; } = new ();

    /// <summary>
    ///     Add to Auto create a Web Api Method.
    /// </summary>
    /// <param name="dtoName">
    ///     The name that's will be used to med the class and method name exposed to the end user, if it ends with Dto the Dto
    ///     will be removed and rest of the name used.
    ///     If the attribute is placed over a class ending with DTO and this is null or empty, this will be filled with class
    ///     name.
    /// </param>
    /// <param name="repositoryItemName">
    ///     If the attribute is placed over a class not ending with DTO and this is null or empty, this will be filled with
    ///     class name.
    /// </param>
    /// <param name="versionNumber">like 1.0</param>
    /// <param name="namespaceName">The namespace to use, will be read from the class the attribute is placed above.</param>
    /// <param name="appName">The application name to use, will be read from the class the attribute is placed above.</param>
    /// <param name="make">Parts to make or not, like Make.All | Make.SkipCreateInterfaceRepository</param>
    /// <param name="debugInfo">Controls to write some debug info to the generated files.</param>
    /// <param name="isPrimary">
    ///     If multiply dtoName + repositoryItemName + versionNumber, this will be used for namespaceName
    ///     and appName.
    /// </param>
    /// <param name="dataDbContext">Name and path to the DataDbContext, to be used.</param>
    /// <param name="skipMake">Files to be skipped.</param>
    /// <param name="idDataType ">idDataType .</param>
    public MakeAPICallAttribute(string dtoName = "",
        string repositoryItemName = "",
        string versionNumber = "1.0",
        string namespaceName = "",
        string appName = "",
        string dataDbContext = "DataDbContext",
        string skipMake = "",
        Make make = Make.All,
        DebugInfo debugInfo = DebugInfo.No,
        IsPrimary isPrimary = IsPrimary.NotSet,
        IdDataType idDataType = IdDataType.GuidType)
    {
        this.VersionNumber = versionNumber;
        this.NamespaceName = namespaceName;
        this.AppName = appName;
        this.DataDbContext = dataDbContext;
        this.SkipMake = skipMake;
        this.Make = make;
        this.DebugInfo = debugInfo;
        this.IsPrimary = isPrimary;
        this.IdDataType = idDataType;
        this.DtoName = dtoName;
        this.RepositoryItemName = repositoryItemName;
    }
}
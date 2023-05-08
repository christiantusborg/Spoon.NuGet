namespace Spoon.NuGet.Core.Tests.Presentation;

using Spoon.NuGet.Core.Presentation;

public class BaseCreateEndpointV1 : BaseEndpoint 
{

}
public class BaseGetEndpointV1 : BaseEndpoint 
{

}

public class BaseGetAllEndpointV1 : BaseEndpoint 
{

}

public class BaseSearchEndpointV1 : BaseEndpoint 
{

}

public class BaseDeleteEndpointV1 : BaseEndpoint 
{

}

public class BaseUnDeleteEndpointV1 : BaseEndpoint 
{

}

public class BaseDeletePermanentEndpointV1 : BaseEndpoint 
{

}

public class AdvancedCreateEndpointV1 : BaseEndpoint 
{

}

public class AdvancedCreateEndpointV1Name : BaseEndpoint, IEndpointName 
{
    public string GetEndpointName()
    {
        return "v1/overwrite";
    }
} 

public class AdvancedGetEndpointV1 : BaseEndpoint 
{

}

public class AdvancedGetEndpointV1Name : BaseEndpoint, IEndpointName 
{
    public string GetEndpointName()
    {
        return "v1/overwrite/{advancedId}";
    }
} 

public class AdvancedGetAllEndpointV1 : BaseEndpoint 
{

}

public class AdvancedGetAllEndpointV1Name : BaseEndpoint, IEndpointName 
{
    public string GetEndpointName()
    {
        return "v1/overwrite";
    }
} 

public class AdvancedSearchEndpointV1 : BaseEndpoint 
{

}

public class AdvancedSearchEndpointV1Name : BaseEndpoint, IEndpointName 
{
    public string GetEndpointName()
    {
        return "v1/overwrite/search";
    }
} 

public class AdvancedDeleteEndpointV1 : BaseEndpoint 
{

}

public class AdvancedDeleteEndpointV1Name : BaseEndpoint, IEndpointName 
{
    public string GetEndpointName()
    {
        return "v1/overwrite/{advancedId}";
    }
} 

public class AdvancedUnDeleteEndpointV1 : BaseEndpoint 
{

}

public class AdvancedUnDeleteEndpointV1Name : BaseEndpoint, IEndpointName 
{
    public string GetEndpointName()
    {
        return "v1/overwrite/{advancedId}/undelete";
    }
} 

public class AdvancedDeletePermanentEndpointV1 : BaseEndpoint 
{

}
public class AdvancedDeletePermanentEndpointV1Name : BaseEndpoint, IEndpointName 
{
    public string GetEndpointName()
    {
        return "v1/overwrite/{advancedId}/permanent";
    }
} 



public class BaseEndpointTests
{
    [Fact]
    
    public void BaseEndpoint_Naming_Create()
    {
        var endpoint = new BaseCreateEndpointV1();
        
        var result = endpoint.GetEndpointName();
        
        Assert.Equal("v1/base", result);
    }
    
    [Fact]
    
    public void BaseEndpoint_Naming_Create_Overwrite()
    {
        var endpoint = new AdvancedCreateEndpointV1();
        
        var result = endpoint.GetEndpointName();
        
        Assert.Equal("v1/overwrite", result);
    }    
    
    [Fact]
    public void BaseEndpoint_Naming_Get()
    {
        var endpoint = new BaseGetEndpointV1();
        
        var result = endpoint.GetEndpointName();
        
        Assert.Equal("v1/base/{baseId}", result);
    }    
    
    [Fact]
    public void BaseEndpoint_Naming_Get_Overwrite()
    {
        var endpoint = new AdvancedGetEndpointV1();
        
        var result = endpoint.GetEndpointName();
        
        Assert.Equal("v1/overwrite/{advancedId}", result);
    }  
    
    
    
    [Fact]
    public void BaseEndpoint_Naming_GetAll()
    {
        var endpoint = new BaseGetAllEndpointV1();
        
        var result = endpoint.GetEndpointName();
        
        Assert.Equal("v1/base", result);
    }     
    
    [Fact]
    public void BaseEndpoint_Naming_GetAll_Overwrite()
    {
        var endpoint = new AdvancedGetAllEndpointV1();
        
        var result = endpoint.GetEndpointName();
        
        Assert.Equal("v1/overwrite", result);
    }   
    
    [Fact]
    public void BaseEndpoint_Naming_Search()
    {
        var endpoint = new BaseSearchEndpointV1();
        
        var result = endpoint.GetEndpointName();
        
        Assert.Equal("v1/base/search", result);
    }    

    [Fact]
    public void BaseEndpoint_Naming_Search_Overwrite()
    {
        var endpoint = new AdvancedSearchEndpointV1();
        
        var result = endpoint.GetEndpointName();
        
        Assert.Equal("v1/overwrite/search", result);
    }     
    
    [Fact]
    public void BaseEndpoint_Naming_Delete()
    {
        var endpoint = new BaseDeleteEndpointV1();
        
        var result = endpoint.GetEndpointName();
        
        Assert.Equal("v1/base/{baseId}", result);
    }    
    
    [Fact]
    public void BaseEndpoint_Naming_Delete_Overwrite()
    {
        var endpoint = new AdvancedDeleteEndpointV1();
        
        var result = endpoint.GetEndpointName();
        
        Assert.Equal("v1/overwrite/{advancedId}", result);
    } 
    
  
    
    [Fact]
    public void BaseEndpoint_Naming_Undelete()
    {
        var endpoint = new BaseUnDeleteEndpointV1();
        
        var result = endpoint.GetEndpointName();
        
        Assert.Equal("v1/base/{baseId}/undelete", result);
    }    

    [Fact]
    public void BaseEndpoint_Naming_Undelete_Overwrite()
    {
        var endpoint = new AdvancedUnDeleteEndpointV1();
        
        var result = endpoint.GetEndpointName();
        
        Assert.Equal("v1/overwrite/{advancedId}/undelete", result);
    }     
    
    [Fact]
    public void BaseEndpoint_Naming_DeletePermanent()
    {
        var endpoint = new BaseDeletePermanentEndpointV1();
        
        var result = endpoint.GetEndpointName();
        
        Assert.Equal("v1/base/{baseId}/permanent", result);
    }    
    
    [Fact]
    public void BaseEndpoint_Naming_DeletePermanent_Overwrite()
    {
        var endpoint = new AdvancedDeletePermanentEndpointV1();
        
        var result = endpoint.GetEndpointName();
        
        Assert.Equal("v1/overwrite/{advancedId}/permanent", result);
    }    
}
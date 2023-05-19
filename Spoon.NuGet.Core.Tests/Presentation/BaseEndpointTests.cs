namespace Spoon.NuGet.Core.Tests.Presentation;

using BaseCreateEndpoint;
using BaseCreateEndpoint.Advanced;
using Spoon.NuGet.Core.Presentation;

public class BaseEndpointTests
{
    [Theory]
    [InlineData(typeof(BaseCreateEndpointV1),"v1/base")]
    [InlineData(typeof(BaseGetEndpointV1),"v1/base/{baseId}")]
    [InlineData(typeof(BaseGetAllEndpointV1),"v1/base")]
    [InlineData(typeof(BaseDeleteEndpointV1),"v1/base/{baseId}")]
    [InlineData(typeof(BaseDeletePermanentEndpointV1),"v1/base/{baseId}/permanent")]
    [InlineData(typeof(BaseUnDeleteEndpointV1),"v1/base/{baseId}/undelete")]
    [InlineData(typeof(BaseUpdateEndpointV1),"v1/base/{baseId}")]
    [InlineData(typeof(BaseUnknownEndpointV1),"Unknown action: Base Unknown")]
    public void GetEndpointName_ReturnsCorrectName(Type classType, string whenSuccess)
    {
        var endpoint = Activator.CreateInstance(classType);
        
        var result = ( (BaseEndpoint) endpoint).GetEndpointName();
        
        Assert.Equal(whenSuccess, result);
    }

    [Theory]
    [InlineData(typeof(AdvancedCreateEndpointV1),"v1/overwrite")]
    [InlineData(typeof(AdvancedGetEndpointV1),"v1/overwrite/{advancedId}")]
    [InlineData(typeof(AdvancedGetAllEndpointV1),"v1/overwrite")]
    [InlineData(typeof(AdvancedDeleteEndpointV1),"v1/overwrite/{advancedId}")]
    [InlineData(typeof(AdvancedDeletePermanentEndpointV1),"v1/overwrite/{advancedId}/permanent")]
    [InlineData(typeof(AdvancedUnDeleteEndpointV1),"v1/overwrite/{advancedId}/undelete")]
    [InlineData(typeof(AdvancedUpdateEndpointV1),"v1/overwrite/{advancedId}")]    
    public void GetEndpointNameOverwrite_ReturnsCorrectName(Type classType, string whenSuccess)
    {
        var endpoint = Activator.CreateInstance(classType);
        
        var result = ( (BaseEndpoint) endpoint).GetEndpointName();
        
        Assert.Equal(whenSuccess, result);
    }    
    
    [Theory]
    [InlineData(typeof(BaseCreateEndpointV1),"Creating a new Base")]
    [InlineData(typeof(BaseGetEndpointV1),"Get a Base by id")]
    [InlineData(typeof(BaseGetAllEndpointV1),"Get Base by search criteria")]
    [InlineData(typeof(BaseDeleteEndpointV1),"Delete a Base by id")]
    [InlineData(typeof(BaseDeletePermanentEndpointV1),"Delete permanently a Base by id")]
    [InlineData(typeof(BaseUnDeleteEndpointV1),"Undelete a Base by id")]
    [InlineData(typeof(BaseUpdateEndpointV1),"Update a Base by id")]
    [InlineData(typeof(BaseUnknownEndpointV1),"Unknown action: Base Unknown")]
    
    public void GetEndpointSummary_ReturnsCorrectSummary(Type classType, string whenSuccess)
    {
        var endpoint = Activator.CreateInstance(classType);
        
        
        var result = ( (BaseEndpoint) endpoint).GetEndpointSummary();
        
     
        Assert.Equal(whenSuccess, result);
    }
    
    [Theory]
    [InlineData(typeof(BaseCreateEndpointV1),"<h2>BaseCreateEndpointV1</h2> <div>Creating a new Base</i></div>")]
    [InlineData(typeof(BaseGetEndpointV1),"<h2>BaseGetEndpointV1</h2> <div>Get a <i>Base</i> by id</div>")]
    [InlineData(typeof(BaseGetAllEndpointV1),"<h2>BaseGetAllEndpointV1</h2> <div>Get <i>Base</i> by search criteria</div>")]
    [InlineData(typeof(BaseDeleteEndpointV1),"<h2>BaseDeleteEndpointV1</h2> <div>Delete a <i>Base</i> by id</div>")]
    [InlineData(typeof(BaseDeletePermanentEndpointV1),"<h2>BaseDeletePermanentEndpointV1</h2> <div>Delete permanently a <i>Base</i> by id</div>")]
    [InlineData(typeof(BaseUnDeleteEndpointV1),"<h2>BaseUnDeleteEndpointV1</h2> <div>Undelete a <i>Base</i> by id</div>")]
    [InlineData(typeof(BaseUpdateEndpointV1),"<h2>BaseUpdateEndpointV1</h2> <div>Update a <i>Base</i> by id</div>")]
    [InlineData(typeof(BaseUnknownEndpointV1),"Unknown action: Base Unknown")]
    public void GetEndpointDescription_ReturnsCorrectDescription(Type classType, string whenSuccess)
    {
        var endpoint = Activator.CreateInstance(classType);
        
        
        var result = ( (BaseEndpoint) endpoint).GetEndpointDescription();
        
     
        Assert.Equal(whenSuccess, result);
    }    
    
    [Theory]
    [InlineData(typeof(AdvancedCreateEndpointV1),"Overwrite - Creating a new Base")]
    public void GetEndpointSummary_ReturnsCorrectSummary_Overwrite(Type classType, string whenSuccess)
    {
        var endpoint = Activator.CreateInstance(classType);
        
        
        var result = ( (BaseEndpoint) endpoint).GetEndpointSummary();
        
     
        Assert.Equal(whenSuccess, result);
    }    
    
    [Theory]
    [InlineData(typeof(AdvancedCreateEndpointV1),"Overwrite Description - Creating a new Base")]
    //[InlineData(typeof(AdvancedGetEndpointV1),"Get a Base by id")]
    //[InlineData(typeof(AdvancedGetAllEndpointV1),"Get Base by search criteria")]
    //[InlineData(typeof(AdvancedDeleteEndpointV1),"Delete a Base by id")]
    //[InlineData(typeof(AdvancedDeletePermanentEndpointV1),"Delete permanently a Base by id")]
    //[InlineData(typeof(AdvancedUnDeleteEndpointV1),"Undelete a Base by id")]
    //[InlineData(typeof(AdvancedUpdateEndpointV1),"Update a Base by id")]
    public void GetEndpointDescription_ReturnsCorrectDescription_Overwrite(Type classType, string whenSuccess)
    {
        var endpoint = Activator.CreateInstance(classType);
        
        
        var result = ( (BaseEndpoint) endpoint).GetEndpointDescription();
        
     
        Assert.Equal(whenSuccess, result);
    }    
}
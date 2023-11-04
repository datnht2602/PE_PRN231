
using BusinessObject;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

partial class Program
    {
    private static IEdmModel GetEdmModel()
    {
        ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
        builder.EntitySet<Artworks>("Artworks");
        builder.EntitySet<Users>("Users");
        builder.EntitySet<Museums>("Museums");
        return builder.GetEdmModel();
    }
}


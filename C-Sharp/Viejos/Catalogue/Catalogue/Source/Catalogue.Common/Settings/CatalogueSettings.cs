using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using APIBase.Common.Settings;

namespace  Catalogue.Common.Settings
{
    [ExcludeFromCodeCoverage]
    public class CatalogueSettings : BaseSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ConnectionStrings
    {
        public string CatalogueConnectionString { get; set; }
    }
}

using System.Diagnostics.CodeAnalysis;
using APIBase.Common.Settings;

namespace  Catalogue2.Common.Settings
{
    [ExcludeFromCodeCoverage]
    public class Catalogue2Settings : BaseSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ConnectionStrings
    {
        public string Catalogue2ConnectionString { get; set; }
    }
}

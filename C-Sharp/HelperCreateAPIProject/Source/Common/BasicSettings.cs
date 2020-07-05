using System.Diagnostics.CodeAnalysis;
using APIBase.Common.Settings;

namespace  NameSpaceVar
{
    [ExcludeFromCodeCoverage]
    public class NameClassVar : BaseSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ConnectionStrings
    {
        public string DataBaseVarConnectionString { get; set; }
    }
}
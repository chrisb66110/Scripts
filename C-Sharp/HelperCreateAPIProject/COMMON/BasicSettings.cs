using System.Diagnostics.CodeAnalysis;

namespace  NameSpaceVar
{
    [ExcludeFromCodeCoverage]
    public class NameClassVar
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ConnectionStrings
    {
        public string DataBaseVarConnectionString { get; set; }
    }
}
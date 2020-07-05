using System.Diagnostics.CodeAnalysis;

namespace  DeployBothSystem.Common.Settings
{
    [ExcludeFromCodeCoverage]
    public class DeployBothSystemSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ConnectionStrings
    {
        public string DeployBothSystemConnectionString { get; set; }
    }
}

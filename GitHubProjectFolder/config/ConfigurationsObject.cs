using System.Collections.Generic;

namespace GitHub.config
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        //[CanBeNull] public string Email { get; set; }
    }

    public class Connections
    {
        public string DBConnectionStringEtoro { get; set; }

    }


    public class Url
    {
        public string EtoroEndPoint { get; set; }
        public string UserApiEndPoint { get; set; }
        public string POEditorUrl { get; set; }
        public string WatchListURL { get; set; }
        public string UserInfoUrl { get; set; }
        public string StsApiUrl { get; set; }
        public string StsBackApiUrl { get; set; }
        public string RegistrationApiUrl { get; set; }
        public string ComplianceApi { get; set; }
        public string AppDataApi { get; set; }
        public string ChineseEndPoint { get; set; }
        public string CCM { get; set; }
        public string EtoroxLoginAndEmbedRegistrationTestPage { get; set; }
    }

    public class Flags
    {
        public bool SilentLogin { get; set; }
    }

    public class GatewayAppId
    {
        public string eToro { get; set; }
    }


    public class DockerServerIP
    {
        public IpType Ip { get; set; }
    }

    public class IpType
    {
        public string Public { get; set; }
        public string Private { get; set; }
    }

    public class ConfigurationsObject
    {
        public Connections Connections { get; set; }
        public Dictionary<string, List<User>> Users { get; set; }
        public Dictionary<string, List<User>> SSOUsers { get; set; }
        public List<User> OptInUsers { get; set; }
        public Dictionary<string, List<User>> ChangeEmailUsers { get; set; }
        public Url Url { get; set; }
        public Flags Flags { get; set; }
        public GatewayAppId GatewayAppId { get; set; }
    }
}




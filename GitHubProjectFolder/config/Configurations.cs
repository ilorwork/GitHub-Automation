using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GitHub.config
{
    public class Configurations
    {
        public Url Url { get; }
        public Connections Connections { get; set; }
        public Dictionary<string, List<User>> Users { get; }
        public Dictionary<string, List<User>> SSOUsers { get; }
        public Dictionary<string, List<User>> ChangeEmailUsers { get; }
        public Flags Flags { get; set; }
        //public Environment Env { get; }
        public string CreatedBy { get; set; }
        public string Ip { get; }
        public string Category { get; set; }
        public bool Local { get; }
        public string HubUrl { get; }
        public string DBConnectionStringEtoro { get; }
        public GatewayAppId GatewayAppId { get; }
        public string DeviceName { get; }

        //public int Retries => GetParams("retries", 2);

        private ConfigurationsObject _configObject;

        

        public Configurations()
        {
            //Ip = GetIP();
            //Console.WriteLine($"IP={Ip}");
            //Local = IsLocal();
            //Env = GetEnvType();
            //HubUrl = $"http://{Ip}:4444/wd/hub";
            //CreatedBy = GetTestRunCreatedBy();
            //Category = GetCategory();
            _configObject = JsonConvert.DeserializeObject<ConfigurationsObject>(GetConfigurationFromRepo());
            //DBConnectionStringEtoro = _configObject.Connections.DBConnectionStringEtoro;
            //Get from Repo
            Users = _configObject.Users;
            SSOUsers = _configObject.SSOUsers;
            ChangeEmailUsers = _configObject.ChangeEmailUsers;
            Url = _configObject.Url;
            Flags = _configObject.Flags;
            //GatewayAppId = _configObject.GatewayAppId;
            DeviceName = GetParams("deviceName", null);

            // Override EtoroEndPoint if specified by an external parameter
            var overridingEndPoint = GetParams("etoroEndPoint", null);
            if (!string.IsNullOrWhiteSpace(overridingEndPoint) && !overridingEndPoint.Equals("none", StringComparison.InvariantCultureIgnoreCase))
                Url.EtoroEndPoint = overridingEndPoint;
        }

        private bool IsLocal()
        {
            return bool.Parse(GetParams("local", "false"));
        }

        public Size? GetBrowserResolution()
        {
            var resolution = GetParams("resolution", null);
            if (string.IsNullOrEmpty(resolution))
                return null;

            var sizeParts = resolution.Split('x');
            int width, height;
            try
            {
                height = int.Parse(sizeParts[0]);
                width = int.Parse(sizeParts[1]);
            }
            catch (Exception e)
            {
                throw new FormatException($"'resolution' parameter has invalid format. ExpectedFormat=\"<width>x<height>\" (e.g. \"1024x768\"). Given value is \"{resolution}\"", e);
            }

            return new Size(width, height);
        }

        // public string ReadJson(string path)
        // {
        //     using (StreamReader r = new StreamReader(path))
        //     {
        //         return r.ReadToEnd();
        //     }
        // }

        public string GetConfigurationFromRepo()
        {
            var configLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"config/jsconfig1.json");
            string configJson = File.ReadAllText(configLocation).Replace("\u200E", "");

            return configJson;
        }

        // public string GetDefaultUserData()
        // {
        //     var configLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"API/UserApi/UserCreationAndUpdate/RegistrationDataGeneration/DefaultUserData.json");
        //     string configJson = File.ReadAllText(configLocation).Replace("\u200E", "");
        //     return configJson;
        // }

        // private XmlDocument ReadXml(string xml)
        // {
        //     XmlDocument xmlDocument = new XmlDocument();
        //     xmlDocument.LoadXml(xml);
        //
        //     return xmlDocument;
        // }

        // private Environment GetEnvType()
        // {
        //     string env = GetParams("env", "Staging");
        //     return (Environment)Enum.Parse(typeof(Environment), IsDR(env));
        // }

        // private string IsDR(string env)////
        // {
        //     if (env == "DR")
        //     {
        //         env = "PRODUCTION";
        //     }
        //
        //     return env;
        // }

        private string GetCategory()
        {
            return GetParams("cat", "Experience Automation Client");
        }

        // private string GetIP()
        // {
        //     var ipFileLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ConfigurationFolder\\DockerServerIp.json").Replace("\\bin\\Debug", "");
        //     string configJson = File.ReadAllText(ipFileLocation).Replace("\u200E", "");
        //     DockerServerIP _ip = JsonConvert.DeserializeObject<DockerServerIP>(configJson);
        //     var ipParamValue = GetParams("IP", null);
        //     var publicIp = _ip.Ip.Public;
        //     var privateIp = _ip.Ip.Private;
        //
        //     if (ipParamValue == null)
        //         return IsLocal() ? publicIp : privateIp;
        //
        //     return ipParamValue.ToLower() == "public"
        //         ? publicIp
        //         : ipParamValue.ToLower() == "private"
        //             ? privateIp
        //             : ipParamValue;
        // }

        // public BrowserType GetBrowserType()
        // {
        //     var browser = GetParams("browser", "chrome");
        //     return (BrowserType)Enum.Parse(typeof(BrowserType), browser, true);
        // }

        private string GetTestRunCreatedBy()
        {
            return GetParams("createdBy", "");
        }

        private int GetParams(string param, int defaultV)
        {
            return TestContext.Parameters.Get(param, defaultV);
        }

        private string GetParams(string param, string defaultV)
        {
            return TestContext.Parameters.Get(param, defaultV);
        }

        // public bool IsMobileEmulation()
        // {
        //     return !string.IsNullOrWhiteSpace(DeviceName);
        // }

        public IEnumerable<User> GetUsersOfType(UserFactoryFromQueue.UserType userType)
        {
            return Users[userType.ToString()];
        }

        public IEnumerable<User> GetSSOUserOfType(UserFactoryFromQueue.SSOUserType userType)
        {
            return SSOUsers[userType.ToString()];
        }

        public IEnumerable<User> GetChangeEmailUserOfType(UserFactoryFromQueue.ChangeEmailUserType userType)
        {
            return ChangeEmailUsers[userType.ToString()];
        }

        // public bool IsMobile()
        // {
        //     return IsMobileEmulation();
        // }

        // [CanBeNull]
        // public KobitonSettings GetKobitonSettings()
        // {
        //     var kobitonSettingsFile = GetParams("kobitonSettingsFile", null);
        //     if (kobitonSettingsFile == null)
        //         return null;
        //
        //     return KobitonSettings.FromFile(kobitonSettingsFile);
        // }
    }
}

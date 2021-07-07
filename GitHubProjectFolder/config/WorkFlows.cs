using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using static System.Convert;
using static System.Text.Encoding;

namespace GitHub.config
{
    public class WorkFlows : BasePage
    {
        private static IUserManager _userManager;

        [ThreadStatic]
        private static Dictionary<User, UserFactoryFromQueue.UserType> _usersFromQueue;

        [TearDown]
        public void ReleaseUsers()
        {
            //Logger.Log("EtoroWorkFlows teardown started...");
            if (_usersFromQueue != null)
            {
                foreach (var userFromQueue in _usersFromQueue)
                {
                    _userManager.ReturnUser(userFromQueue.Key, userFromQueue.Value);
                    //Logger.Log($"Returned '{userFromQueue.Value}' user '{userFromQueue.Key.UserName}'");
                }

                _usersFromQueue.Clear();
            }
        }

        protected User GetUser()
        {
            return GetUser(UserFactoryFromQueue.UserType.Regular);
        }

        protected User GetUser(UserFactoryFromQueue.UserType userType)
        {
            var user = _userManager.GetUser(userType);
            _usersFromQueue = _usersFromQueue ?? new Dictionary<User, UserFactoryFromQueue.UserType>();
            _usersFromQueue.Add(user, userType);
            //Logger.Log($"Using '{userType}' user '{user.UserName}'");
            return user;
        }
    }
}

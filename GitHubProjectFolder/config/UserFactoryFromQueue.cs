using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using GitHub.helpers;

namespace GitHub.config
{
    public class UserFactoryFromQueue : IUserManager
    {
        public enum UserType
        {
            Level0,
            Level1,
            Level2,
            Level3,
            Chinese,
            USA,
            TwoFAUser,
            OptInUser,
            Suggest2FAVerifiedUser,
            Suggest2FAUnVerifiedUser,
            Insist2FAUser,
            Moderator
        }

        public enum SSOUserType
        {
            Google,
            Facebook
        }

        public enum ChangeEmailUserType
        {
            Level1,
            Level2,
            Level3,
        }

        private readonly Dictionary<UserType, ConcurrentQueue<User>> _userQueues = new Dictionary<UserType, ConcurrentQueue<User>>();

        public UserFactoryFromQueue(Configurations configurations)
        {
            ReadUsersQueuesFromConfig(configurations);
        }

        private void ReadUsersQueuesFromConfig(Configurations configurations)
        {
            foreach (UserType userType in Enum.GetValues(typeof(UserType)))
            {
                _userQueues[userType] = ReadUsersQueueFromConfig(configurations, userType);
            }
        }

        private static ConcurrentQueue<User> ReadUsersQueueFromConfig(Configurations configurations, UserType type)
        {
            var userType = ExtensionsMethods.GetDescription(type);
            var result = new ConcurrentQueue<User>();
            if (!configurations.Users.ContainsKey(userType))
                return result;

            foreach (var userName in configurations.Users[userType])
            {
                result.Enqueue(userName);
            }

            return result;
        }

        public User GetUser(UserType userType)
        {
            // TODO: change _userQueue to be a BlockingCollection instead of ConcurrentQueue
            // And define a timeout in the config file. Its value should depend on the number
            // of concurrent threads, the number of users in the pool and the mean test time
            if (!_userQueues[userType].TryDequeue(out var user))
                throw new Exception($"Users queue '{userType}' is empty");

            return user;
        }

        // public User GetFunnelUser(FunnelFormId funnelFromId, Countries country)
        // {
        //     throw new Exception("Users queue does not support funnel users yet.");
        // }

        public bool ReturnUser(User user, UserType userType)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            while (watch.Elapsed.TotalSeconds < 30)
            {
                try
                {
                    var userQueue = _userQueues[userType];
                    if (!userQueue.Contains(user))
                    {
                        userQueue.Enqueue(user);
                    }
                    return true;
                }
                catch (Exception exception)
                {
                    // Base.Logger.Log("ERROR: Could not get user name from automation API.");
                    // Base.Logger.Log("Stack Trace: " + exception.StackTrace);
                    Thread.Sleep(1000);
                }
            }
            return false;
        }
    }
}

namespace GitHub.config
{
    public interface IUserManager
    {
        User GetUser(UserFactoryFromQueue.UserType userType);
        //User GetFunnelUser(FunnelFormId funnelFromId, Countries country);

        bool ReturnUser(User user, UserFactoryFromQueue.UserType userType);
    }
}
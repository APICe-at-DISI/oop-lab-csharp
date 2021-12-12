using NUnit.Framework;

namespace Collections
{
    public class TestSocialNetworkUser
    {
        [Test]
        public void OrdinaryUsage()
        {
            ISocialNetworkUser<IUser> kbacon = new SocialNetworkUser<IUser>("Kevin Bacon", "kbacon", 56);
            ISocialNetworkUser<IUser> dwashington = new SocialNetworkUser<IUser>("Denzel Washington", "dwashington", 59);
            ISocialNetworkUser<IUser> mgladwell = new SocialNetworkUser<IUser>("Malcom Gladwell", "mgladwell", 51);
            ISocialNetworkUser<IUser> ntaleb = new SocialNetworkUser<IUser>("Nicholas Tale", "ntaleb", 54);
            IUser asmith = new User("Adam Smith", "asmith", null);
            
            mgladwell.AddFollowedUser("acquaintances", ntaleb);
            dwashington.AddFollowedUser("myths", asmith);
            dwashington.AddFollowedUser("writers", ntaleb);
            dwashington.AddFollowedUser("colleagues", kbacon);
            dwashington.AddFollowedUser("writers", mgladwell);
            
            Assert.IsFalse(asmith.IsAgeDefined);
            Assert.IsTrue(kbacon.IsAgeDefined);
            Assert.IsTrue(dwashington.IsAgeDefined);
            Assert.IsTrue(mgladwell.IsAgeDefined);
            Assert.IsTrue(ntaleb.IsAgeDefined);
            
            Assert.AreEqual(0, kbacon.GetFollowedUsersInGroup("Malcom").Count);
            Assert.AreEqual(0, mgladwell.GetFollowedUsersInGroup("Close Friends").Count);
            Assert.AreEqual(2, dwashington.GetFollowedUsersInGroup("writers").Count);
        }
    }
}

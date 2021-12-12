using System;
using System.Collections.Generic;

namespace Collections
{
    /// <summary>
    /// Represents the user of a social network. A user follows other users and of course can be followed as well.
    /// </summary>
    /// <typeparam name="TUser">a specific sub-type of <see cref="IUser"/></typeparam>
    public interface ISocialNetworkUser<TUser> : IUser
        where TUser : IUser
    {
        /// <summary>
        /// Adds a friend to the list of this user's current friends.
        /// </summary>
        /// <param name="group">the name of the group (circle) on which the user in going to be added</param>
        /// <param name="user">the user to be added as a user followed</param>
        /// <returns>false if the current user was already following <paramref name="user"/> in
        /// <paramref name="group"/>, true otherwise</returns>
        bool AddFollowedUser(string group, TUser user);
        
        /// <summary>
        /// The list of every person followed by this user, regardless of the group 
        /// </summary>
        IList<TUser> FollowedUsers { get; }

        /// <summary>
        /// Gets the list of followed people belonging to a given group.
        /// </summary>
        /// <param name="group">the name of the group</param>
        /// <returns>the collection of people followed by this user within the group named <paramref name="group"/></returns>
        ICollection<TUser> GetFollowedUsersInGroup(string group);
    }
}

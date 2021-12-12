namespace Collections
{
    /// <summary>
    /// Represents the contract for a generic user.
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// The age of the user, or null it the user specified no age upon registration
        /// </summary>
        uint? Age { get; }
        
        /// <summary>
        /// The full (first + last) name of the user, or null it the user provided no name upon registration
        /// </summary>
        string FullName { get; }
        
        /// <summary>
        /// The username of this user. Cannot be null.
        /// </summary>
        string Username { get; }
        
        /// <summary>
        /// Return true if the user has an age set
        /// </summary>
        bool IsAgeDefined { get; }
    }
}

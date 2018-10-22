namespace BlazorSpa.Shared
{
    /// <summary>
    /// Specifies which message box button that a user clicks. <see cref="T:BlazorSpa.Shared.MessageBoxResult" /> is returned by the Show method.
    /// </summary>
    public enum MessageBoxResult
    {
        /// <summary>
        /// The message box returns no result.
        /// </summary>
        None,
        /// <summary>
        /// The result value of the message box is OK.
        /// </summary>
        OK,
        /// <summary>
        /// The result value of the message box is Cancel.
        /// </summary>
        Cancel,
        /// <summary>
        /// The result value of the message box is Yes.
        /// </summary>
        Yes = 6,
        /// <summary>
        /// The result value of the message box is No.
        /// </summary>
        No
    }
}

namespace SensitiveWords.MS.Sanitizer.ProcedureIndex
{
    /// <summary>
    /// Static list of all POST Stored Procedures
    /// </summary>
    public static class PostProcedures
    {
        #region KeyWords        
        /// <summary>
        /// POST new key word
        /// </summary>
        /// <remarks>This stored procedure contains the logic for sanitizing words</remarks>
        public static string CreateNewKeyWord = "sp_POST_CreateNewKeyWord";
        #endregion KeyWords

        #region Messages        
        /// <summary>
        /// POST client message
        /// </summary>
        public static string PostClientMessage = "sp_POST_SaveClientMessage";
        #endregion Messages

    }
}

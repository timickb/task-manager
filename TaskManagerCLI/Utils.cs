using System.Linq;

namespace TaskManagerCLI
{
    /// <summary>
    /// Different useful methods for this application.
    /// </summary>
    public static class Utils
    {
        public static bool IsUserNameCorrect(string userName)
        {
            return userName.Length < 20;
        }

        /// <summary>
        /// Get next user id
        /// </summary>
        /// <returns>The next number after the greatest Id value in users list</returns>
        public static int GetNextUserId()
        {
            return TaskManager.GetInstance().Users.Select(user => user.Id).Prepend(0).Max() + 1;
        }
    }
}
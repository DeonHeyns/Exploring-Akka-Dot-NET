namespace ExploringRemoting.Common.Messages
{
    public class RandomTextMessage
    {
        public int UserId { get; private set; }

        public RandomTextMessage(int userId)
        {
            UserId = userId;
        }
    }
}

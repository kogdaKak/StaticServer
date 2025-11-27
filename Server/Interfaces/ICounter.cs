namespace Server.Interfaces
{
    public interface ICounter
    {
        int GetCount();
        void AddToCount(int value);
    }
}

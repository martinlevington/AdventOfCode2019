namespace SharedCode
{
    public interface IBuffer 
    {
        int Count { get; }
        bool IsEmpty { get; }
        void Add(long value);
        long GetValue();
    }
}
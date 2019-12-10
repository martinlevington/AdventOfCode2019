namespace SharedCode
{
    public interface IInputBuffer
    {
        int Count { get; }
        bool IsEmpty { get; }

        void Add(long value);
        long GetValue();
    }
}
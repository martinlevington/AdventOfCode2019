namespace SharedCode
{
    public interface IMemory
    {
        long Get(long index);
        void Reset();
        void Set(long index, long value);
        long[] ToArray();
    }
}
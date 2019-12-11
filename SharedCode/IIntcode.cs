namespace SharedCode
{
    public interface IIntcode
    {
        bool IsRunning();
        bool IsPaused();
        void Wake();
        bool Stopped();
        void Process();
        string CurrentState();
        string Output();
    }
}
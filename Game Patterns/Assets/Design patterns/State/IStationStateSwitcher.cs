namespace Design_patterns.State
{
    public interface IStationStateSwitcher
    {
        void SwitchState<T>() where T : BaseState;
    }
}
namespace Design_patterns.Command
{
    public interface ICommand 
    {
        void Execute();
        void ExecuteUndo();
    }
}

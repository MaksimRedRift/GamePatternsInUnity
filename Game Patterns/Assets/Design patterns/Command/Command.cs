
namespace Design_patterns.Command
{
    public class Command : ICommand
    {
        public virtual void Execute(){}
        public virtual void ExecuteUndo(){}
    }
}

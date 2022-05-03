using System;

namespace Decoupling_Patterns.Command_Queue_Event_Queue_
{
    public interface ICommand
    {
        Action OnFinished { get; set; }

        void Execute();
    }
}
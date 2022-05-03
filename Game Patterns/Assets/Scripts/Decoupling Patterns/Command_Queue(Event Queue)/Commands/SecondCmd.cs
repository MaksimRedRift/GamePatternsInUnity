using System;

namespace Decoupling_Patterns.Command_Queue_Event_Queue_.Commands
{
    public class SecondCmd : ICommand
    {
        private readonly GameController _owner;

        public SecondCmd(GameController owner)
        {
            _owner = owner;
        }

        public Action OnFinished { get; set; }

        public void Execute()
        {
            // activate gameobject
            _owner.secondPopup.gameObject.SetActive(true);

            // listen to its onClose event 
            _owner.secondPopup.ONClose += OnClose;
        }

        private void OnClose()
        {
            _owner.secondPopup.ONClose -= OnClose;

            // deactivate gameobject
            _owner.secondPopup.gameObject.SetActive(false);

            // rise the OnFinished event to say we're done with this command
            OnFinished?.Invoke();
        }
    }
}
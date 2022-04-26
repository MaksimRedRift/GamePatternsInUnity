using Design_patterns.Command.Commands;
using UnityEngine;

namespace Design_patterns.Command
{
    public class InputHandler : MonoBehaviour
    {
        private Command _buttonSpace;
        private Command _buttonF;

        private void Awake()
        {
            _buttonSpace = new JumpCommand();
            _buttonF = new FireCommand();

            SwitchButtons(ref _buttonSpace, ref _buttonF);
        }

        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if(Input.GetKeyDown(KeyCode.Space)) _buttonSpace.Execute();
            if(Input.GetKeyDown(KeyCode.F)) _buttonF.Execute();
        }
        
        private static void SwitchButtons(ref Command key1, ref Command key2) => (key1, key2) = (key2, key1);
    }
}

using UnityEngine;

namespace Design_patterns.Command.Commands
{
    public class JumpCommand : Command
    {
        public override void Execute() => Jump();
        
        private static void Jump() => Debug.Log("Jump");
    }
}

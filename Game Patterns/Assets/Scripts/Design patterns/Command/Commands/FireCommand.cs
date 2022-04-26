using UnityEngine;

namespace Design_patterns.Command.Commands
{
    public class FireCommand : Command
    {
        public override void Execute() => Fire();
        
        private static void Fire() => Debug.Log("Fire");
    }
}

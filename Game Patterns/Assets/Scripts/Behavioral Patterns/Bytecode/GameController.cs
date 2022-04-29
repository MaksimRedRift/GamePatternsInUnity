using UnityEngine;

namespace Behavioral_Patterns.Bytecode
{
    public class GameController : MonoBehaviour
    {
        private void Start()
        {
            // Test
            var bytecode = new[]
            {
                (int)Instruction.INST_LITERAL, 0, // Wizard id
                (int)Instruction.INST_LITERAL, 75, // Amount
                (int)Instruction.INST_SET_HEALTH
            };

            var vm = new VM(this);
            vm.Interpret(bytecode);
        }
        
        // 0 means the player's wizard and 1, 2, ... means the other wizards in the game
        // This way we can heal our own wizard while damage other wizards with the same method
        public static void SetHealth(int wizardID, int amount)
        {
            Debug.Log($"Wizard {wizardID} gets health {amount}");
        }

        public void SetWizard(int wizardID, int amount)
        {
            Debug.Log($"Wizard {wizardID} gets wisdom {amount}");
        }

        public void SetAgility(int wizardID, int amount)
        {
            Debug.Log($"Wizard {wizardID} gets agility {amount}");
        }

        public void PlaySound(int soundID)
        {
            Debug.Log($"Play sound {soundID}");
        }

        public void SpawnParticles(int particleType)
        {
            Debug.Log($"Spawn particle {particleType}");
        }

        public static int GetHealth(int wizardID)
        {
            return 50;
        }
    }
}

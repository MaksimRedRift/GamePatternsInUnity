using System.Collections.Generic;
using UnityEngine;

namespace Behavioral_Patterns.Bytecode
{
    public class VM
    {
        private GameController _gameController;
        // Will store values for later use in the switch statement
        private readonly Stack<int> _stackMachine = new Stack<int>();
        // The max size of the stack
        private const int MAXStack = 128;

        public VM(GameController gameController)
        {
            _gameController = gameController;
        }
        
        public void Interpret(int[] bytecode)
        {
            _stackMachine.Clear();

            // Read and execute the instructions
            for (var i = 0; i < bytecode.Length; i++)
            {
                //Convert from int to enum
                var instruction = (Instruction)bytecode[i];

                switch (instruction)
                {
                    case Instruction.INST_SET_HEALTH:
                    {
                        //Important to pop amount before wizard because we push wizard before amount onto the stack
                        var amount = Pop();
                        var wizard = Pop();
                        GameController.SetHealth(wizard, amount);
                        break;
                    }
                    case Instruction.INST_LITERAL:
                    {
                        ////Important that this i++ is not inside bytecode[i++] or it will not jump to next i
                        //i++;
                        //int value = bytecode[i];
                        //Push(value);
                        //this can be a oneliner
                        //in this case bytecode will use i+1 bytecode element
                        Push(bytecode[++i]);
                        break;
                    }
                    case Instruction.INST_GET_HEALTH:
                    {
                        var wizard = Pop();
                        Push(GameController.GetHealth(wizard));
                        break;
                    }
                    case Instruction.INST_ADD:
                    {
                        var b = Pop();
                        var a = Pop();
                        Push(a + b);
                        break;
                    }
                    default:
                    {
                        Debug.Log($"The VM couldn't find the instruction {instruction} :(");
                        break;
                    }
                }
            }
        }
        
        // Stack methods
        private int Pop()
        {
            if (_stackMachine.Count == 0)
            {
                Debug.LogError("The stack is empty :(");
            }
        
            return _stackMachine.Pop();
        }

        private void Push(int number)
        {
            // Check for stack overflow, which is useful because someone might make a mod that tries to break your game
            if (_stackMachine.Count + 1 > MAXStack)
            {
                Debug.LogError("Stack overflow is not just a place where you copy and paste code!");
            }
            _stackMachine.Push(number);
        }
    }
}

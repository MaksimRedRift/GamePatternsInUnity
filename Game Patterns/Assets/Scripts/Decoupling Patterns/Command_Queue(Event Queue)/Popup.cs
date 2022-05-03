using System;
using UnityEngine;

namespace Decoupling_Patterns.Command_Queue_Event_Queue_
{
    public class Popup : MonoBehaviour
    {
        public Action ONClose;

        public void Close() => ONClose?.Invoke();
    }
}

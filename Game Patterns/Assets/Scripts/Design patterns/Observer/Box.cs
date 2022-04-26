using Design_patterns.Observer.Events;
using UnityEngine;

namespace Design_patterns.Observer
{
    public class Box : Observer
    {
        //The box gameobject which will do something
        private readonly GameObject _boxObj;
        //What will happen when this box gets an event
        private readonly BoxEvents _boxEvent;
        
        public Box(GameObject boxObj, BoxEvents boxEvent)
        {
            _boxObj = boxObj;
            _boxEvent = boxEvent;
        }
        
        //What the box will do if the event fits it (will always fit but you will probably change that on your own)
        public override void OnNotify()
        {
            Jump(_boxEvent.GetJumpForce());
        }

        //The box will always jump in this case
        private void Jump(float jumpForce)
        {
            //If the box is close to the ground
            if (_boxObj.transform.position.y < 0.55f)
            {
                _boxObj.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
            }
        }
    }
}
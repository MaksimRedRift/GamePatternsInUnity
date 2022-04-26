using Design_patterns.Observer.Events;
using UnityEngine;

namespace Design_patterns.Observer
{
    public class GameController : MonoBehaviour
    {
        public GameObject sphereObj;
        //The boxes that will jump
        public GameObject box1Obj;
        public GameObject box2Obj;
        public GameObject box3Obj;

        //Will send notifications that something has happened to whoever is interested
        private readonly Subject _subject = new Subject();


        private void Start()
        {
            //Create boxes that can observe events and give them an event to do
            var box1 = new Box(box1Obj, new JumpLittle());
            var box2 = new Box(box2Obj, new JumpMedium());
            var box3 = new Box(box3Obj, new JumpHigh());

            //Add the boxes to the list of objects waiting for something to happen
            _subject.AddObserver(box1);
            _subject.AddObserver(box2);
            _subject.AddObserver(box3);
        }


        private void Update()
        {
            if (!(sphereObj.transform.position.magnitude < 0.5f)) return;
            _subject.Notify();
        }
    }
}

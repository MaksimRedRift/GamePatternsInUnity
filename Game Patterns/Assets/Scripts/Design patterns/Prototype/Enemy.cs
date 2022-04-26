using UnityEngine;

namespace Design_patterns.Prototype
{
    public class Enemy : MonoBehaviour, ICopyable
    {
        public ICopyable Copy()
        {
            return Instantiate(this);
        }
    }
}

using UnityEngine;

namespace Factory_Pattern
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private MobDescriptions _mobDescriptions;

        private Factory _factory;

        private void Start()
        {
            _factory = new Factory();
            _factory.Init(_mobDescriptions);

            _factory.CreateMobModel("ogre", 2);
        }
    }
}

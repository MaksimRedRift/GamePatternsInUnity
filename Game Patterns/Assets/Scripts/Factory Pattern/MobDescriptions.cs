using System.Collections.Generic;
using UnityEngine;

namespace Factory_Pattern
{
    [CreateAssetMenu(fileName = "MobDescriptions", menuName = "MobDescriptions", order = 51)]
    public class MobDescriptions : ScriptableObject
    {
        [SerializeField] private List<MobDescription> _listOgre;
        [SerializeField] private List<MobDescription> _listTroll;

        public List<MobDescription> ListOgre => _listOgre;
        public List<MobDescription> ListTroll => _listTroll;
    }
}
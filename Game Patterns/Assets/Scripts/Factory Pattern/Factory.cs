using System;
using System.Collections.Generic;

namespace Factory_Pattern
{
    public class Factory 
    {
        private Dictionary<string, Func<int, MobModel>> _mobFactory;

        public void Init(MobDescriptions descriptions)
        {
            _mobFactory = new Dictionary<string, Func<int, MobModel>>()
            {
                {"ogre", (level) => new MobModel(descriptions.ListOgre[level])},
                {"troll", (level) => new MobModel(descriptions.ListTroll[level])}
            };

        }

        public MobModel CreateMobModel(string nameMob, int level)
        {
            return _mobFactory[nameMob](level);
        }
    }
}

namespace Factory_Pattern
{
    public class MobModel 
    {
        private MobDescription _description;
        private float _currentHealth;
    
        public MobDescription Description => _description;

        public MobModel(MobDescription description){
            _description = description;
            _currentHealth = _description.MaxHealth;
        }
    }
}

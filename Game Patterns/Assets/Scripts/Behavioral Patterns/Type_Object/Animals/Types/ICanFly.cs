namespace Behavioral_Patterns.Type_Object.Animals.Types
{
    /// <summary>
    /// This type can fly.
    /// </summary>
    public class CanFly : IFlyingType
    {
        public bool CanIFly()
        {
            return true;
        }
    }
}

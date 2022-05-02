namespace Behavioral_Patterns.Type_Object.Animals.Types
{
    /// <summary>
    /// This type can't fly.
    /// </summary>
    public class CantFly : IFlyingType
    {
        public bool CanIFly()
        {
            return false;
        }
    }
}

namespace Behavioral_Patterns.Subclass_Sandbox
{
    /// <summary>
    /// Child class that defines a single superpower behavior.
    /// </summary>
    public class SkyLaunch : Superpower
    {
        public override void Activate()
        {
            PlaySound("Launch sound");
            SpawnParticles("Dust");
            Move("The sky");
        }
    }
}

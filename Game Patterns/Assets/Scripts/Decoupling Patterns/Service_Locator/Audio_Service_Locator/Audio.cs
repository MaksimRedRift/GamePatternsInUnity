namespace Decoupling_Patterns.Service_Locator.Audio_Service_Locator
{
    /// <summary>
    /// Service provider parent class.
    /// This is the abstract class that determines which methods the service will be exposing.
    /// </summary>
    public abstract class Audio 
    {
        public abstract void PlaySound(int soundID);
        public abstract void StopSound(int soundID);
        public abstract void StopAllSounds();
    }
}

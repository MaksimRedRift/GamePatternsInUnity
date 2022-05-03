namespace Decoupling_Patterns.Service_Locator.Audio_Service_Locator
{
    /// <summary>
    /// This is the service locator.
    /// </summary>
    public static class Locator
    {
        private static readonly NullAudio NullService;
        private static Audio _service;
        
        static Locator()
        {
            NullService = new NullAudio();
            //Init with null in case we forget to inject a reference to Audio
            _service = NullService;
        }
        
        //Does the locating
        public static Audio GetAudio()
        {        
            return _service;
        }

        //Use dependency injection to get a reference to the audio service we need
        //Call this method before you do anything else with the audio
        public static void Provide(Audio service)
        {
            //Sometimes we want to set it to null if we want to disable audio in the game
            if (service == null)
            {
                Locator._service = NullService;
            }
            else
            {
                Locator._service = service;
            }
        }
    }
}

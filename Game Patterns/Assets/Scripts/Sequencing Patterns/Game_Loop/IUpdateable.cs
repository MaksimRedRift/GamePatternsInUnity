namespace Sequencing_Patterns.Game_Loop
{
    /// <summary>
    /// Interface for base class for custom Update method.
    /// </summary>
    public interface IUpdateable
    {
        /// <summary>
        /// This is the custom update method.
        /// </summary>
        /// <param name="dt">Delta time.</param>
        void OnUpdate(float dt);
    }
}

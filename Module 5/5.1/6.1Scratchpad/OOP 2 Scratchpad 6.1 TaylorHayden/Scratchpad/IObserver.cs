namespace Scratchpad
{
    /// <summary>
    /// The interface that defines a contract for all observers.
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// Responds to an update of a subject.
        /// </summary>
        /// <param name="subject">The subject that was updated.</param>
        void Update(ISubject subject);
    }
}
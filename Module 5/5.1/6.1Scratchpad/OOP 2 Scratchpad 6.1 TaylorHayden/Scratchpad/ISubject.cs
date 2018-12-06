namespace Scratchpad
{
    /// <summary>
    /// The interface that defines a contract for all subjects.
    /// </summary>
    public interface ISubject
    {
        /// <summary>
        /// Registers an observer.
        /// </summary>
        /// <param name="observer">The observer to register.</param>
        void RegisterObserver(IObserver observer);

        /// <summary>
        /// Unregisters a previously-registered observer.
        /// </summary>
        /// <param name="observer">The observer to unregister.</param>
        void UnregisterObserver(IObserver observer);

        /// <summary>
        /// Notify all observers of a state change.
        /// </summary>
        void NotifyObservers();
    }
}
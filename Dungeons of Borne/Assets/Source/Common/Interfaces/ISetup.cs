
namespace Common
{
    namespace Interfaces
    {
        /// <summary>
        /// This interface can be implemented into any object if it is going to need "Setup" function.
        /// </summary>
        interface ISetup
        {
            /// <summary>
            /// Write your setup logic into this function.
            /// </summary>
            void Setup();
        }
    }
}
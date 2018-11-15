
using UnityEngine;

namespace Gameplay
{
    namespace Managers
    {
        /// <summary>
        /// This class manages the time , wooooooooaaaa spooky right ?
        /// </summary>
        class TimeManager : MonoBehaviour
        {
            private void Awake()
            {
                UnchainTheTime();
            }

            private void UnchainTheTime()
            {
                // Unchain my heaaaartthhh !!!!
                if ( Time.timeScale == 0.0f ) Time.timeScale = 1.0f;
            }
        }
    }
}
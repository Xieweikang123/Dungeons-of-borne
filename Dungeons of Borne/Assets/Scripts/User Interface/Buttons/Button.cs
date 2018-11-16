
using UnityEngine;

using Gameplay.Managers;

namespace UserInterface
{
    namespace Buttons
    {
        /// <summary>
        /// Base class for other buttons.
        /// </summary>
        [ DisallowMultipleComponent ]
        class Button : MonoBehaviour
        {
            public virtual void Action()
            {
                AudioManager.instance.PlayAudioSourceOneShot( AudioManager.instance.buttonClickAudio );
            }
        }
    }
}
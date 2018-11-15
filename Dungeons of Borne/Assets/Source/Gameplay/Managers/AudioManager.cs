
using System.Collections.Generic;

using UnityEngine;

namespace Gameplay
{
    namespace Managers
    {
        /// <summary>
        /// Handles all the audio stuff in scene.
        /// </summary>
        [ DisallowMultipleComponent ]
        class AudioManager : MonoBehaviour
        {
            [ Header( "Gameplay Sounds" ) ]
            public List< AudioSource > breakableAudioList   = new List< AudioSource >();
            public AudioSource potionConsumeAudio           = null;
            public List< AudioSource > entityAudioList      = new List< AudioSource >();
            public AudioSource explosionAudio               = null;
            public AudioSource descendAudio                 = null;
            public AudioSource sentryAttackAudio            = null;

            [ Space ]

            [ Header( "User Interface Sounds" ) ]
            public AudioSource buttonClickAudio             = null;

            /// <summary>
            /// Singleton.
            /// </summary>
            public static AudioManager instance = null;

            /// <summary>
            /// Unity's callback function that will run before scene's start event.
            /// </summary>
            private void Awake()
            {
                if ( instance == null ) instance = this;
                else                    Destroy( this.gameObject );
            }

            /// <summary>
            /// Plays the given audio source. (Can not play looping sounds)
            /// </summary>
            /// <param name="src"> Audio source to play. </param>
            public void PlayAudioSourceOneShot( AudioSource src )
            {
                if ( src.loop ) src.loop = false;
                src.Play();
            }

            /// <summary>
            /// Plays the given audio source with loop.
            /// </summary>
            /// <param name="src"> Audio source to play. </param>
            public void PlayAudioSourceLoop( AudioSource src )
            {
                if ( !src.loop ) src.loop = true;
                src.Play();
            }

            /// <summary>
            /// Stops playing the given audio source.
            /// </summary>
            /// <param name="src"> Audio source to stop. </param>
            public void StopAudioSource( AudioSource src )
            {
                src.Stop();
            }
        }
    }
}
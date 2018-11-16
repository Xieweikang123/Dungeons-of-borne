
using UnityEngine;

namespace Gameplay
{
    namespace Effects
    {
        /// <summary>
        /// Will destroy the particle effect when it is finishes.
        /// </summary>
        [ DisallowMultipleComponent ]
        [ RequireComponent( typeof( ParticleSystem ) ) ]
        class Explosion : MonoBehaviour
        {
            private ParticleSystem m_Particle = null;

            /// <summary>
            /// Unity's callback function that will run on scene's start event.
            /// </summary>
            private void Start()
            {
                m_Particle = GetComponent< ParticleSystem >();
            }

            /// <summary>
            /// Unity's callback function that will run on every frame.
            /// </summary>
            private void Update()
            {
                DestroyParticle();
            }

            /// <summary>
            /// Destroys the particle effect when it is over.
            /// </summary>
            private void DestroyParticle()
            {
                if ( !m_Particle.isPlaying ) Destroy( this.gameObject );
            }
        }
    }
}
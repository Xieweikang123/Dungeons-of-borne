
using UnityEngine;

using Gameplay.Managers;

namespace Gameplay
{
    namespace Items
    {
        namespace Explosive
        {
            /// <summary>
            /// Base class for other explosive items.
            /// </summary>
            class Explosive : MonoBehaviour
            {
                [ Header( "Derived from Explosive base class." ) ]

                [ SerializeField ] protected GameObject explosionEffect = null;
                [ SerializeField ] protected float      explosionRadius = 0.0f;
                [ SerializeField ] protected int        explosionDamage = 0;

                public virtual void OnExplode()
                {
                    // Overriden.
                    Instantiate( explosionEffect , transform.position , Quaternion.identity );
                    AudioManager.instance.PlayAudioSourceOneShot( AudioManager.instance.explosionAudio );
                    Destroy( this.gameObject );
                }
            }
        }
    }
}
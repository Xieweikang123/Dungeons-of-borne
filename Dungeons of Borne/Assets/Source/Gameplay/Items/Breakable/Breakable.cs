
using System.Collections.Generic;

using UnityEngine;

using Gameplay.Managers;

namespace Gameplay
{
    namespace Items
    {
        namespace Breakable
        {
            /// <summary>
            /// Base class for other breakable items.
            /// </summary>
            [ DisallowMultipleComponent ]
            [ RequireComponent( typeof( BoxCollider2D ) ) ]
            class Breakable : MonoBehaviour
            {
                [ Header( "Derived from Breakable base class" ) ]

                [ Tooltip( "Will determine how much hit can item take to break." ) ]
                public int breakCount = 0;

                [ Tooltip( "Visual brake effect to enhance gameplay." ) ]
                public GameObject breakEffect = null;

                [ Tooltip( "The sound effect that breakable objects can play." ) ]
                public List< AudioSource > breakableAudioList = new List< AudioSource >();

                /// <summary>
                /// Enables breakable items to take hits from player.
                /// </summary>
                public void TakeHit()
                {
                    breakCount--;
                    if ( breakCount <= 0 ) OnBreak();
                    else                   AudioManager.instance.PlayAudioSourceOneShot( breakableAudioList[ 0 ] );
                }

                /// <summary>
                /// What will happen when item is destroyed.
                /// </summary>
                public virtual void OnBreak()
                {
                    // Overriden.
                    Instantiate( breakEffect , transform.position , Quaternion.identity );
                    Destroy( this.gameObject );
                }
           } 
        }
    }
}

using UnityEngine;

using Gameplay.Entities;
using Gameplay.Items.Breakable;

namespace Gameplay
{
    namespace Managers
    {
        /// <summary>
        /// "CombatManager" is class that contains several functions to implement combat system into game.
        /// </summary>
        class CombatManager
        {
            /// <summary>
            /// Returns the type of game object is it entity or breakable item ?
            /// </summary>
            /// <param name="target"> Target gameo object. </param>
            /// <returns> Type of game object. </returns>
            public static string GetTargetType( GameObject target )
            {
                Entity e    = target.GetComponent< Entity >();
                if ( e  !=  null ) return ( "Entity" );
                else               return ( "Breakable" );
            }

            /// <summary>
            /// Damages the all the target colliders.
            /// </summary>
            /// <param name="caster"> The entity that is attacking. </param>
            /// <param name="targets"> Targets of entity. </param>
            public static void DamageTargets( Entity caster , Collider2D[] targets )
            {
                if ( targets.Length == 0 )
                {
                    // If there is no object in collider list , we want to play miss sound effect.
                    AudioManager.instance.PlayAudioSourceOneShot( caster.entityAudioList[ 0 ] );
                    return;
                }

                // If there is entities in list , we want to damage them.
                int i;
                for ( i = 0 ; i < targets.Length ; i++ )
                {
                    // First we need to check if target is enemy or breakable item.
                    if ( GetTargetType( targets[ i ].gameObject ) == "Entity" ) 
                    {
                        // If the target is entity.
                        Entity e = targets[ i ].GetComponent< Entity >();
                        AudioManager.instance.PlayAudioSourceOneShot( AudioManager.instance.entityAudioList[ 0 ] );
                        int damageTaken = e.TakeDamage( caster.damage );
                        EffectManager.instance.CreateFadingText( targets[ i ].transform.position , "-" + damageTaken , Color.red );
                    }
                    else
                    {
                        targets[ i ].GetComponent< Breakable >().TakeHit();
                    }
                }
            }

            /// <summary>
            /// Gets an entity array and damages all of them. (Directly) (Not calculating the armor)
            /// </summary>
            /// <param name="ents"> The entity array. </param>
            /// <param name="dmg"> Damage value. </param>
            public static void AreaDamage( Entity[] ents , int dmg )
            {
                if ( ents.Length > 0 )
                {
                    int i;
                    for ( i = 0 ; i < ents.Length ; i++ )
                    {
                        ents[ i ].TakeDirectDamage( dmg );
                        AudioManager.instance.PlayAudioSourceOneShot( AudioManager.instance.entityAudioList[ 0 ] );
                    }
                }
            }
        }
    }
}

using System.Collections.Generic;

using UnityEngine;

using Gameplay.Managers;
using Data;

namespace Gameplay
{
    namespace Items
    {
        namespace Breakable
        {
            /// <summary>
            /// Chest is breakable item that drops random consumable item when destroyed.
            /// </summary>
            class Chest : Breakable
            {
                public List< GameObject> loots = new List< GameObject >();

                /// <summary>
                /// Spawn random item.
                /// </summary>
                public override void OnBreak()
                {
                    AudioManager.instance.PlayAudioSourceOneShot( AudioManager.instance.breakableAudioList[ 0 ] );
                    int trig = Random.Range( 0 , 100 );
                    if ( trig > 30 )
                    {
                        // 70% chance to spawn loot.
                        // Spawn random loot here.
                        // ONE MOREEEEEEEEE MAGIC POTIOOOOOOOONNN !!!
                        // LET ME SEE THOSE HANDS IN DA AIR !!!!
                        // ONE MOREEEEEEEEE MAGIC POTIOOOOOOOONNN !!!
                        int rng = Random.Range( 0 , this.loots.Count );
                        Instantiate( this.loots[ rng ] , transform.position , Quaternion.identity );
                    }   
                    else
                    {
                        Debug.Log( "Not lucky enough to get loot from chest !" );
                    }

                    // Increment opened chests count.
                    GameObject.FindGameObjectWithTag( "Player" ).GetComponent< PlayerData >().chestsOpened++;

                    base.OnBreak();
                }
            }
        }
    }
}
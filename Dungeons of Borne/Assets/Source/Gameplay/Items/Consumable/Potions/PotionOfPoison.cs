
using UnityEngine;

using Gameplay.Managers;
using Gameplay.Entities;

namespace Gameplay
{
    namespace Items
    {
        namespace Consumable
        {
            namespace Potions
            {
                /// <summary>
                /// Damages the player on consume.
                /// </summary>
                class PotionOfPoison : Potion
                {
                    [ Header( "Private" ) ]

                    [ Tooltip( "Determines how much damage player will take by consuming this potion." ) ]
                    [ SerializeField ]
                    public int damageAmount = 0;

                    /// <summary>
                    /// Damages the player.
                    /// </summary>
                    public override void OnConsume()
                    {
                        base.OnConsume();
                        Entity e = GameObject.FindGameObjectWithTag( "Player" ).GetComponent< Entity >();                       
                        e.TakeDirectDamage( damageAmount );
                        EffectManager.instance.CreateFadingText( e.transform.position , ( "-" + damageAmount ) , Color.red );
                        PlayConsumeAudio();
                        Destroy( this.gameObject );
                    }

                }
            }
        }
    }
}
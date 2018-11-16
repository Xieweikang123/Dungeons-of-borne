
using UnityEngine;

using Gameplay.Entities;
using Gameplay.Managers;

using Data;

namespace Gameplay
{
    namespace Items
    {
        namespace Consumable
        {
            namespace Potions
            {
                /// <summary>
                /// Heals the player on consume.
                /// </summary>
                class PotionOfHealth : Potion
                {
                    [ Header( "Public" ) ]

                    [ Tooltip( "Determines the heal amount for player." ) ]
                    public int healAmount = 0;

                    /// <summary>
                    /// Heals the player.
                    /// </summary>
                    public override void OnConsume()
                    {
                        Entity e = GameObject.FindGameObjectWithTag( "Player" ).GetComponent< Entity >();

                        // First check if player is at max health. Don't consume potion if player at full health.
                        if ( e.IsFullHealth() ) return;

                        e.Heal( healAmount );
                        EffectManager.instance.CreateFadingText( e.transform.position , (  "+" + healAmount ) , Color.green );
                        PlayConsumeAudio();
                        base.OnConsume();
                        Destroy( this.gameObject );
                    }
                }
            }
        }
    }
}
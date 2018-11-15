
using UnityEngine;

using Gameplay.Managers;
using Gameplay.Mechanical;

namespace Gameplay
{
    namespace Items
    {
        namespace Consumable
        {
            namespace Potions
            {
                /// <summary>
                /// Increases the player's speed.
                /// </summary>
                class PotionOfSpeed : Potion
                {
                    [ Header( "Private" ) ]

                    [ Tooltip( "The value that will increase player's speed." ) ]
                    [ SerializeField ]
                    private float m_Boost    = 0.0f;

                    /// <summary>
                    /// Increase the player's speed for "Duration" seconds.
                    /// </summary>
                    public override void OnConsume()
                    {
                        PlayerController pc = GameObject.FindGameObjectWithTag( "Player" ).GetComponent< PlayerController >();

                        // First check if player is already reached max speed cap.
                        if ( pc.IsAtFullSpeed() ) return;

                        pc.movementSpeed += m_Boost;
                        EffectManager.instance.CreateFadingText( pc.transform.position , ( "+" + m_Boost + " Speed" ) , Color.cyan );
                        PlayConsumeAudio();
                        base.OnConsume();
                        Destroy( this.gameObject );
                    }
                }
            }
        }
    }
}
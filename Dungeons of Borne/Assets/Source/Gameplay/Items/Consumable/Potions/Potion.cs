
using UnityEngine;

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
                /// All other potions will derive from this class.
                /// </summary>
                class Potion : Consumable
                {
                    public override void OnConsume()
                    {
                        GameObject.FindGameObjectWithTag( "Player" ).GetComponent< PlayerData >().potionsConsumed++;
                    }

                    /// <summary>
                    /// Plays potion consume audio.
                    /// </summary>
                    public void PlayConsumeAudio()
                    {
                        AudioManager.instance.PlayAudioSourceOneShot( AudioManager.instance.potionConsumeAudio );
                    }
                }
            }
        }
    }
}
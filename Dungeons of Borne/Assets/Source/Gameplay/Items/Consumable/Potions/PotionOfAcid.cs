
using UnityEngine;

using Gameplay.Entities;
using Gameplay.Managers;

namespace Gameplay
{
    namespace Items
    {
        namespace Consumable
        {
            namespace Potions
            {
                /// <summary>
                /// On consume player will lose some armor.
                /// </summary>
                class PotionOfAcid : Potion
                {
                    public int armorLoss = 0;

                    public override void OnConsume()
                    {
                        Entity e = GameObject.FindGameObjectWithTag( "Player" ).GetComponent< Entity >();

                        if ( e.IsArmorOnBound() ) return;

                        e.armor -= armorLoss;
                        EffectManager.instance.CreateFadingText( e.transform.position , (  "-" + armorLoss + " Armor" ) , Color.gray );
                        PlayConsumeAudio();
                        base.OnConsume();
                        Destroy( this.gameObject );
                    }
                }
            }
        }
    }
}
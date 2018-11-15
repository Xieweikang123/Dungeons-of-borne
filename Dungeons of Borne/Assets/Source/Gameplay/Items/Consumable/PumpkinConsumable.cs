
using UnityEngine;

using Gameplay.Managers;

using Data;

namespace Gameplay
{
    namespace Items
    {
        namespace Consumable
        {
            class PumpkinConsumable : Consumable
            {
                public override void OnConsume()
                {
                    PlayerData pd = GameObject.FindGameObjectWithTag( "Player" ).GetComponent< PlayerData >();
                    pd.collectedPumpkins++;
                    Color orange = new Color( 255 , 140 , 0 );
                    EffectManager.instance.CreateFadingText( pd.transform.position , "+1 Pumpkin" , orange );
                    Destroy( this.gameObject );
                }
            }
        }
    }
}

using UnityEngine;

using Gameplay.Entities;
using Gameplay.Managers;

using Utilities;

namespace Gameplay
{
    namespace Items
    {
        namespace Explosive
        {
            /// <summary>
            /// Pumpkin will damage nearby entities on explode.
            /// </summary>
            class Pumpkin : Explosive
            {
                public override void OnExplode()
                {
                    Entity[] ents = ObjectExtensions.GetAllEntitiesInArea( transform.position , explosionRadius );

                    foreach ( Entity item in ents )
                    {
                        if ( item != null )
                        {
                            item.TakeDirectDamage( explosionDamage );
                            EffectManager.instance.CreateFadingText( item.transform.position , "-" + explosionDamage , Color.red );
                        }
                    }

                    base.OnExplode();
                }
            }
        }
    }
}
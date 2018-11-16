
using UnityEngine;

using Gameplay.Entities;
using Gameplay.Managers;

namespace Gameplay {

	namespace Items {

		namespace Breakable {

			/// <summary>
			/// OnBreak cauldron will damage nearby entities.
			/// </summary>
			class Cauldron : Breakable {

				[ Header( "Private" ) ]

				[ Tooltip( "Determines wow much damage entities will take." ) ]
				[ SerializeField ]
				private int damageAmount = 0;

				[ Tooltip( "Range of explosion damage." ) ]
				[ SerializeField ]
				private float radius     = 0.0f;

                [ Tooltip( "Determines which collider layers will get effected by cauldron." ) ]
                [ SerializeField ]
                private LayerMask entityLayer = 0;

				public override void OnBreak() {
                    Collider2D[] objects = Physics2D.OverlapCircleAll( transform.position , radius , entityLayer );

                    if ( objects.Length > 0 ) {
                        // If we truly have colliders in our array.
                        Entity[] ents = new Entity[ objects.Length ];
                        int i;
                        for ( i = 0 ; i < objects.Length ; i++ ) {
                            Entity tmp = objects[ i ].GetComponent< Entity >();
                            if ( tmp != null ) ents[ i ] = tmp;
                        }

                        // Damage all near entities.
                        CombatManager.AreaDamage( ents , damageAmount ); // Area damage is direct damage type. (No armor calculations)
                        // Create fading text effects for each entity.
                        EffectManager.instance.CreateFadingTextForEntities( ents , "-" + damageAmount , Color.red );
                    }

                    base.OnBreak();
				}

			}

		}
	} // items
} // gameplay

using UnityEngine;

using Gameplay.Managers;

namespace Gameplay
{
    namespace Items
    {
        namespace Consumable
        {
            /// <summary>
            /// Base class for other consumable items.
            /// </summary>
            class Consumable : MonoBehaviour
            {
                /// <summary>
                /// Unity's built-in function to check triggers for spesific objects.
                /// </summary>
                /// <param name="cl"> The collider parameter. </param>
                private void OnTriggerEnter2D( Collider2D cl )
                {
                    if ( cl.gameObject.tag == "Player" ) OnConsume();
                }

                /// <summary>
                /// What will happen when player consumes this item.
                /// </summary>
                public virtual void OnConsume()
                {
                    // Overriden.
                }
            }
        }
    }
}
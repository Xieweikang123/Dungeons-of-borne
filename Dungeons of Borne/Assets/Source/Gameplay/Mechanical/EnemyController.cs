
using UnityEngine;

using Gameplay.Mechanical;

namespace Gameplay {

    namespace Mechanical {

        /// <summary>
        /// Base class for other enemy controllers.
        /// </summary>
        [ RequireComponent( typeof( SpriteRenderer ) ) ]
        class EnemyController : Controller {

            [ Tooltip( "Drag & drop player here." ) ]
            [ SerializeField ]
            protected Transform m_Player = null;

            protected SpriteRenderer m_Renderer = null;

            protected bool m_facingRight = true;

            protected void LinkPlayer() {
                if ( m_Player == null ) m_Player = GameObject.FindGameObjectWithTag( "Player" ).transform;
            }

            /// <summary>
            /// Flips the enemy when required.
            /// </summary>
            public void Flip()
            {
                if ( m_Player == null ) return;

                if ( ( m_Player.transform.position.x > transform.position.x ) && ( !m_facingRight ) )
                {
                    m_Renderer.flipX = false;
                    m_facingRight    = true;
                }
                else if ( ( m_Player.transform.position.x < transform.position.x ) && ( m_facingRight ) )
                {
                    m_Renderer.flipX = true;
                    m_facingRight    = false;
                }
            }

            /// <summary>
            /// Move towards player.
            /// </summary>
            public override void Move() {
                if ( m_Player != null ) {
                    transform.position = Vector2.MoveTowards( transform.position , m_Player.position , ( Time.deltaTime * movementSpeed ) );
                }
            }
        }

    }

}
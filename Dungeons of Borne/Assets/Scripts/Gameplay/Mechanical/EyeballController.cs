
using UnityEngine;

using Gameplay.Entities;
using Gameplay.Managers;
using Gameplay.Mechanical;

namespace Gameplay {
    
    namespace Mechanical {

        /// <summary>
        /// Eyeball is basic enemy type that directly moves through player and explodes itself on collision.
        /// </summary>
        [ RequireComponent( typeof( SpriteRenderer ) ) ]
        class EyeballController : EnemyController { 

            private void Start() {
                m_Renderer    = GetComponent< SpriteRenderer >();
                m_Player      = GameObject.FindGameObjectWithTag( "Player" ).transform;
                movementSpeed = 1.0f;
            }

            private void Update() {
                Move();
                Flip();
            }

            /// <summary>
            /// Eyeball will deal damage to player on collision and will destroy itself.
            /// Damage type is direct.
            /// </summary>
            public override void Attack()
            {
                Entity e = m_Player.GetComponent< Entity >();
                Entity eyeball = this.GetComponent< Entity >();
                int takenDamage = e.TakeDamage( eyeball.damage );
                EffectManager.instance.CreateFadingText( e.transform.position , "-" + takenDamage , Color.red );
                AudioManager.instance.PlayAudioSourceOneShot( AudioManager.instance.entityAudioList[ 0 ] );
                eyeball.OnDeath();
            }

            private void OnCollisionEnter2D( Collision2D collision ) {
                if ( collision.gameObject.tag == "Player" ) Attack();
                else Physics2D.IgnoreCollision( this.GetComponent< Collider2D >() , collision.collider );
            }

        }

    } // mechanical

} // gameplay
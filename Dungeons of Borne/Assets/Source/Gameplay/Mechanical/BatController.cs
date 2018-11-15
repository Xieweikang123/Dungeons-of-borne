
using UnityEngine;

using Gameplay.Entities;
using Gameplay.Managers;

namespace Gameplay
{
    namespace Mechanical
    {
        class BatController : EnemyController
        {
            [ Header( "Private" ) ]
            [ SerializeField ] private float m_chargeTimer   = 0.0f;
            [ SerializeField ] private float m_chargedSpeed  = 0.0f;
            [ SerializeField ] private float m_sleepDuration = 0.0f;

            private void Start()
            {
                m_Player = GameObject.FindGameObjectWithTag( "Player" ).transform;
                m_Renderer = GetComponent< SpriteRenderer >();

                movementSpeed = 1.5f;
            }

            private void Update()
            {
                Move();
                Flip();
                Charge();
            }

            private void Charge()
            {
                m_chargeTimer -= Time.deltaTime;

                if ( m_chargeTimer <= 0.0f )
                {
                    // Stop the bat and wait for "sleep" seconds.
                    Sleep();
                }
            }

            private void Sleep()
            {
                m_sleepDuration -= Time.deltaTime;
                movementSpeed    = 0.0f;

                if ( m_sleepDuration <= 0.0f ) movementSpeed = m_chargedSpeed;
            }

            public override void Attack()
            {
                Entity e = m_Player.GetComponent< Entity >();
                Entity bat = this.GetComponent< Entity >();
                int takenDamage = e.TakeDamage( bat.damage );
                EffectManager.instance.CreateFadingText( e.transform.position , "-"  + takenDamage , Color.red );
                AudioManager.instance.PlayAudioSourceOneShot( AudioManager.instance.entityAudioList[ 0 ] );
                bat.OnDeath();
            }

            private void OnCollisionEnter2D( Collision2D collision )
            {
                if ( collision.gameObject.tag == "Player" ) Attack();
                else Physics2D.IgnoreCollision( this.GetComponent< Collider2D >() , collision.collider );
            }
        }
    }
}
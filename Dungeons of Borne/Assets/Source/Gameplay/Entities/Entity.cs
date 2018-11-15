
using System.Collections.Generic;

using UnityEngine;

using Data;

namespace Gameplay
{
    namespace Entities
    {
        /// <summary>
        /// Base class for other entities.
        /// </summary>
        [ DisallowMultipleComponent ]
        class Entity : MonoBehaviour
        {
            [ Header( "Derived from Entity base class" ) ]

            [ Tooltip( "The health of current entity." ) ]
            [ SerializeField ]
            protected int m_Health;

            [ Tooltip( "Max health of entity." ) ]
            [ SerializeField ]
            protected int m_maxHealth;

            [ Tooltip( "Damage will determine how much character will hurt other entities." ) ]
            [ SerializeField ]
            protected int m_Damage;

            [ SerializeField ]
            protected int m_Armor;

            [ SerializeField ]
            protected GameObject m_deathParticle = null;

            [ Tooltip( "The audio files that entity can play." ) ]
            public List< AudioSource > entityAudioList = new List< AudioSource >();

#region Properties
            public int damage { get { return ( m_Damage ); } set { m_Damage = value; } }
            public int health { get { return ( m_Health ); } set { m_Health = value; } }
            public int maxHealth { get { return ( m_maxHealth ); } }
            public int armor
            {
                get { return ( m_Armor ); }
                set
                {
                    const int bound = 10;
                    if ( value >= -bound && value <= bound ) m_Armor = value;
                }
            }
#endregion

            /// <summary>
            /// Entities will take damage via this function.
            /// </summary>
            /// <param name="dmg"> The damage that entity going to take. </param>
            public int TakeDamage( int dmg )
            {
                // !!! DECLARE AN ARMOR VARIABLE TO USE THIS FUNCTION !!! \\

                // Make sure damage is not negative.
                // Using Mathf.Abs causing some bugs on combot manager , don't know why but it's disabled for now.
                // Mathf.Abs( dmg );

                // --- Basic damage calculation ---
                // lastHealth = ( dmg * db ) - armor
                const byte db = 2;
                int damageTaken = ( ( dmg * db ) - m_Armor );
                m_Health -= damageTaken;

                // For now it can stay here.
                if ( m_Health <= 0 ) OnDeath();

                return ( damageTaken );
            }

            /// <summary>
            /// Enables entity to take damage without no armor calculations.
            /// </summary>
            /// <param name="dmg"> The damage amount. </param>
            public void TakeDirectDamage( int dmg )
            {
                m_Health -= dmg;
                if ( m_Health <= 0 ) OnDeath();
            }

            /// <summary>
            /// Checks if entity at risky health value.
            /// </summary>
            /// <returns> True if entity has low health. </returns>
            public bool IsLowHealth()
            {
                const int lowHealthBound = 20;

                if ( m_Health <= lowHealthBound ) return ( true );
                else                              return ( false );
            }

            /// <summary>
            /// Checks if entity at full health.
            /// </summary>
            /// <returns> True if overhealed or full health. </returns>
            public bool IsFullHealth()
            {
                if ( m_Health >= m_maxHealth ) return ( true );
                else                           return ( false );
            }

            public bool IsArmorOnBound()
            {
                if ( armor > -10 && armor < 10 ) return ( false );
                else                             return ( true );
            }

            /// <summary>
            /// Heals the entity while taking care of over healing.
            /// </summary>
            /// <param name="amount"> The heal amount. </param>
            public void Heal( int amount )
            {
                if ( m_Health < m_maxHealth )
                {
                    // If entity is wounded.
                    int absHeal  = Mathf.Abs( amount );
                    m_Health    += absHeal;
                    
                    // Check for overheal.
                    if ( IsFullHealth() )
                    {
                        int overHeal = ( m_Health - m_maxHealth );
                        m_Health    -= overHeal;
                    }
                }
            }

                public virtual void OnDeath()
                {
                    // Overriden.
                    Instantiate( m_deathParticle , transform.position , Quaternion.identity );
                    Destroy( this.gameObject );
                }
        }
    }
}
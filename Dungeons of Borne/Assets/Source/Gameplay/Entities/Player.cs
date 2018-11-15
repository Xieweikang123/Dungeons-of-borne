
using UnityEngine;

using Data;

using Gameplay.Managers;
using Gameplay.Animations;

namespace Gameplay
{
    namespace Entities
    {
        /// <summary>
        /// Player is entity that can deal and take damage.
        /// </summary>
        class Player : Entity
        {
            // public int health { get { return( m_Health ); } }

            [ Space ]

            [ Header( "Private" ) ]
            [ SerializeField ] private GameObject  m_Pumpkin     = null;
            [ SerializeField ] private PlayerData  m_playerData  = null;

            public System.Action OnDeathEvent = null;

            public override void OnDeath()
            {
                EffectManager.instance.CreateScreenEffect( EffectManager.instance.deathScreen );
                m_playerData.UpdateStatistics();
                m_playerData.UpdateHighScore();
                m_playerData.ResetData();
                if ( OnDeathEvent != null ) OnDeathEvent();
                base.OnDeath();
            }

            public void SpawnPumpkin()
            {
                if ( m_playerData.collectedPumpkins > 0 )
                {
                    Instantiate( m_Pumpkin , transform.position , Quaternion.identity );
                    m_playerData.collectedPumpkins--;
                    m_playerData.pumpkinsPlaced++;
                }
                else
                {
                    Color orange = new Color( 255 , 140 , 0 );
                    EffectManager.instance.CreateFadingText( transform.position , "Need more pumpkin !",  orange );
                }
            }
        }
    }
}
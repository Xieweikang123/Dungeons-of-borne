
using System.Collections.Generic;

using UnityEngine;

using Data;
using Utilities;

namespace Environment
{
    /// <summary>
    /// Rooms will handle events like OnPlayerEnter , OnPlayerExit.
    /// We can spawn items or enemies when player enters the room and we can hide/destroy them when player exits the room.
    /// </summary>
    class Room : MonoBehaviour
    {
        public RoomTrigger trigger = null;
        public RoomData roomData = null;
        public BoxCollider2D roomArea = null;
        public BoxCollider2D entityArea = null;

        [ SerializeField ]
        private ItemInfo m_itemInfo = new ItemInfo();

        [ SerializeField ]
        private EnemyInfo m_enemyInfo = new EnemyInfo();

        [ SerializeField ] private NeutralInfo m_neutralInfo = new NeutralInfo();

        [ System.Serializable ]
        private class ItemInfo
        {
            public bool canSummonItems = true;
            public List< GameObject > summonedItems = new List< GameObject >();
        }

        [ System.Serializable ]
        private class EnemyInfo
        {
            public bool canSummonEnemies = true;
            public List< GameObject > summonedEnemies = new List< GameObject >();
            public List< Vector2 > enemySummonPositions = new List< Vector2 >();
        }

        [ System.Serializable ]
        private class NeutralInfo
        {
            public bool CanSummonNeutrals = true;
            public List< GameObject > SummonedNeutrals = new List< GameObject >();
        }

        private void Start()
        {
            roomData = GameObject.Find( "Room Manager" ).GetComponent< RoomData >();

            if ( this.gameObject.name != "Main Room" ) roomData.createdRooms.Add( this );

            // Subscribe to events.
            trigger.enterEvents += OnPlayerEnter;
            trigger.exitEvents  += OnPlayerExit;
        }

        private void AdjustCamera()
        {
            // Locate the camera's position to current room position.
            const float z = -10.0f;
            Vector3 fixedPos = new Vector3( transform.position.x , transform.position.y , z );
            Camera.main.transform.position = fixedPos;
        }

        /// <summary>
        /// Returns a random location from inside of room.
        /// </summary>
        /// <returns> Random room location. </returns>
        public Vector2 GetRandomLocation( BoxCollider2D roomCollider )
        {
            // Get a random x value inside of collider.
            float randX = Random.Range( roomCollider.bounds.min.x , roomCollider.bounds.max.x );
            // Get a random y value inside of collider.
            float randY = Random.Range( roomCollider.bounds.max.y , roomCollider.bounds.min.y );

            Vector2 randLoc = new Vector2( randX , randY );
            return ( randLoc );
        }

        /// <summary>
        /// Summons 1-3 items at random location of room.
        /// </summary>
        private void SummonItems()
        {
            if ( m_itemInfo.canSummonItems )
            {
                int randomItemCount = Random.Range( 0 , 5 ); // Create 0-4 items.

                if ( randomItemCount != 0 )
                {
                    int i;
                    for ( i = 0 ; i < randomItemCount ; i++ )
                    {
                        Vector2 rndLoc = GetRandomLocation( entityArea );
                        GameObject item = Instantiate( roomData.summonableItems[ Random.Range( 0 , roomData.summonableItems.Count ) ] , rndLoc , Quaternion.identity );
                        m_itemInfo.summonedItems.Add( item );
                    }
                }
            }

            m_itemInfo.canSummonItems = false;
        }

        /// <summary>
        /// Summons neutral objects like totems. (Neutral : Have special effect for player and enemies)
        /// </summary>
        private void SummonNeutrals()
        {
            if ( m_neutralInfo.CanSummonNeutrals )
            {
                int randNeutralCount = Random.Range( 0 , 3 ); // will create 0 - 2 neutrals

                if ( randNeutralCount != 0 )
                {
                    int i;
                    for ( i = 0 ; i < randNeutralCount ; i++ )
                    {
                        Vector2 rndNeutralLoc = GetRandomLocation( entityArea );
                        GameObject neutral = Instantiate( roomData.summonableNeutrals[ Random.Range( 0 , roomData.summonableNeutrals.Count ) ] , rndNeutralLoc , Quaternion.identity );
                        m_neutralInfo.SummonedNeutrals.Add( neutral );
                    }
                }

                // Done spawning neutrals.
                m_neutralInfo.CanSummonNeutrals = false;
            }
        }

        private void SummonEnemies()
        {
            if ( m_enemyInfo.canSummonEnemies )
            {
                int randEnemyCount = Random.Range( 0 , 4 ); // Will create 0-4 enemies.

                if ( randEnemyCount != 0 )
                {
                    int i;
                    for ( i = 0 ; i < randEnemyCount ; i++ )
                    {
                        Vector2 rndLoc = GetRandomLocation( entityArea );
                        GameObject enemy = Instantiate( roomData.summonableEnemies[ Random.Range( 0 , roomData.summonableEnemies.Count ) ] , rndLoc , Quaternion.identity );
                        m_enemyInfo.summonedEnemies.Add( enemy );

                        // Load enemy positions into list so we can get their positions later.
                        m_enemyInfo.enemySummonPositions.Add( enemy.transform.position );
                    }
                }
            }

            m_enemyInfo.canSummonEnemies = false;
        }

        private void SetEnemyPositions()
        {
            if ( ( m_enemyInfo.summonedEnemies.Count > 0 ) && ( !m_enemyInfo.canSummonEnemies ) )
            {
                int i;
                for ( i = 0 ; i < m_enemyInfo.summonedEnemies.Count ; i++ )
                {
                    GameObject en = m_enemyInfo.summonedEnemies[ i ];
                    if ( en != null ) en.transform.position = m_enemyInfo.enemySummonPositions[ i ];
                }
            }
        }

        private void EnableNeutrals()
        {
            ObjectExtensions.EnableObjects( m_neutralInfo.SummonedNeutrals );
        }

        private void DisableNeutrals()
        {
            ObjectExtensions.DisableObjects( m_neutralInfo.SummonedNeutrals );
        }

        private void EnableEnemies()
        {
            ObjectExtensions.EnableObjects( m_enemyInfo.summonedEnemies );
        }

        private void DisableEnemies()
        {
            ObjectExtensions.DisableObjects( m_enemyInfo.summonedEnemies );
        }

        private void EnableItems()
        {
            ObjectExtensions.EnableObjects( m_itemInfo.summonedItems );
        }

        private void DisableItems()
        {
            ObjectExtensions.DisableObjects( m_itemInfo.summonedItems );
        }

        private void OnPlayerEnter()
        {
            AdjustCamera();

            if ( this.gameObject.name != "Main Room" )
            {
                // WTF
                SummonItems();
                SummonNeutrals();
                SummonEnemies();
                EnableItems();
                SummonEnemies();
                EnableNeutrals();
                EnableEnemies();
                SetEnemyPositions();
            }
        }

        private void OnPlayerExit()
        {
            if ( this.gameObject.name != "Main Room" )
            {
                DisableItems();
                DisableNeutrals();
                DisableEnemies();
            }
        }

        private void OnDestroy()
        {
            // Unsubscribe from events.
            trigger.enterEvents -= OnPlayerEnter;
            trigger.exitEvents  -= OnPlayerExit;
        }
    }

} // environment
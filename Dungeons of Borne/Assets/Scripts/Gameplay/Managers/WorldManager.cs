
using UnityEngine;

using Data;
using Environment;

namespace Gameplay
{
    namespace Managers
    {
        class WorldManager : MonoBehaviour
        {
            [ Header( "Private" ) ]
            [ SerializeField ] private GameObject m_Stair          = null;
            [ SerializeField ] private RoomData   m_roomData       = null;
            [ SerializeField ] private bool       m_isStairCreated = false;

            private void Start()
            {
                Invoke( "SummonStair" , 3.5f );
            }

            private void SummonStair()
            {
                // First check if minumum 4 rooms are created and we can still create stair.
                if ( ( m_roomData.createdRooms.Count >= 4 ) && ( !m_isStairCreated ) )
                {
                    // Get a random room to spawn stair.
                    int index      = Random.Range( 0 , m_roomData.createdRooms.Count );
                    Room randRoom  = m_roomData.createdRooms[ index ];

                    // Get a random location/point inside of random room.
                    Vector2 rndLoc = randRoom.GetRandomLocation( randRoom.entityArea );

                    // Spawn the stair at random location of random room.
                    Instantiate( m_Stair , rndLoc , Quaternion.identity );

                    m_isStairCreated = true;
                }
            }
        }
    }
}
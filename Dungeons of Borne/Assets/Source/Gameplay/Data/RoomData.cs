
using System.Collections.Generic;

using UnityEngine;

using Environment;

namespace Data {

    class RoomData : MonoBehaviour {

        public int currentWorldCount = 0;
        public int MAX_ROOMS_ALLOWED = 0;

        public List< GameObject > topRooms    = new List< GameObject >();
        public List< GameObject > bottomRooms = new List< GameObject >();
        public List< GameObject > leftRooms   = new List< GameObject >();
        public List< GameObject > rightRooms  = new List< GameObject >();

        [ Space ]

        public GameObject closedRoom = null;

        [ Space ]

        public List< GameObject > summonableItems    = new List< GameObject >();
        public List< GameObject > summonableEnemies  = new List< GameObject >();
        public List< GameObject > summonableNeutrals = new List< GameObject >();

        [ Space ]

        public List< Room > createdRooms = new List< Room >();
    }

} // data
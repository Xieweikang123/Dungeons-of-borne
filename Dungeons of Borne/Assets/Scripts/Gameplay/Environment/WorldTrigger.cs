using Common.Interfaces;
using Data;
using UnityEngine;

namespace Environment {

    [DisallowMultipleComponent]
    [RequireComponent (typeof (CircleCollider2D), typeof (Rigidbody2D))]
    class WorldTrigger : MonoBehaviour, ISetup {
        [Header ("Public")]

        public bool isCreated = false;

        [Space]

        [Header ("Private")]

        [SerializeField]
        private RoomData m_roomData = null;

        [SerializeField]
        private RoomDirections m_Direction;

        [System.Serializable]
        private enum RoomDirections { Top, Bottom, Left, Right };

        private System.Collections.IEnumerator Start () {
            Setup ();
            yield return new WaitForSeconds (0.5f);
            Invoke ("Spawn", 0.5f);
            // Spawn();
        }

        private void Spawn () {
            PreventOpenRooms ();

            // If we didn't created a room before and there is still space for new one.
            if ((!isCreated) && (IsCanCreateRoom ())) {
                // Check for direction to detect room type.
                switch (m_Direction) {
                    case (RoomDirections.Top):
                        // If world trigger is located at the top of the room it is need to create room with bottom door.
                        Instantiate (m_roomData.bottomRooms[Random.Range (0, m_roomData.bottomRooms.Count)], transform.position, Quaternion.identity);
                        break;

                    case (RoomDirections.Bottom):
                        // If world trigger is located at the bottom of the room it is need to create room with top door.
                        Instantiate (m_roomData.topRooms[Random.Range (0, m_roomData.topRooms.Count)], transform.position, Quaternion.identity);
                        break;

                    case (RoomDirections.Left):
                        // If world trigger is located at the left of the room it is need to create room with right door.
                        Instantiate (m_roomData.rightRooms[Random.Range (0, m_roomData.rightRooms.Count)], transform.position, Quaternion.identity);
                        break;

                    case (RoomDirections.Right):
                        // If world trigger is located at the right of the room it is need to create room with left door.
                        Instantiate (m_roomData.leftRooms[Random.Range (0, m_roomData.leftRooms.Count)], transform.position, Quaternion.identity);
                        break;

                    default:
                        Debug.Log ("An error occured while trying to create new room at : " + this.gameObject.name);
                        break;
                }

                UpdateRoomData ();
            } else {
                Debug.Log ("Can not create more rooms max. rooms created !");
                Destroy (this.gameObject);
            }
        }

        private void UpdateRoomData () {
            m_roomData.currentWorldCount++;
            // isCreated = true;
        }

        private bool IsCanCreateRoom () {
            // Returns true if there is still space to create rooms.
            if (m_roomData.currentWorldCount < m_roomData.MAX_ROOMS_ALLOWED) return (true);
            else
                return (false);
        }

        private void PreventOpenRooms () {
            // We have to close rooms that opens to empty space.
            // To do this we need to ;
            // 1) Check if we can still create room.
            // 2) If we can't then we need to spawn closed rooms for each unspawned world trigger.
            if (!IsCanCreateRoom () && !isCreated) {
                // If we can't create rooms anymore and we didn't created room before.
                // Spawn the closed room.
               GameObject InstObj= Instantiate (m_roomData.closedRoom, transform.position, Quaternion.identity);
                isCreated = true;
            
                // We don't need to update room data because it was all about fixing room bug with door to empty space.
            }
        }

        private void OnTriggerEnter2D (Collider2D collision) {
            if (collision.CompareTag ("World Trigger")) {
               //Debug.LogError(gameObject.name+"和"+collision.name+"重合");
                Destroy (this.gameObject);
            }
        }

        // Derived from ISetup interface.
        public void Setup () {
            m_roomData = GameObject.Find ("Room Manager").GetComponent<RoomData> ();
        }
    }

} // environment
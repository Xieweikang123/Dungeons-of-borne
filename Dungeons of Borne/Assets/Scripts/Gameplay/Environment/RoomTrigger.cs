using UnityEngine;

namespace Environment {
    [DisallowMultipleComponent]
    [RequireComponent (typeof (BoxCollider2D))]
    class RoomTrigger : MonoBehaviour {
        public System.Action enterEvents = null;
        public System.Action exitEvents = null;

        private void OnPlayerEnter () {
            if (enterEvents != null) enterEvents ();
        }

        private void OnPlayerExit () {
            if (exitEvents != null) exitEvents ();
        }

        private void OnTriggerEnter2D (Collider2D collision) {
            if (collision.tag == "Player")
             {
                OnPlayerEnter ();
            }
        }

        private void OnTriggerExit2D (Collider2D collision) {
            if (collision.tag == "Player") OnPlayerExit ();
        }
    }

} // environment
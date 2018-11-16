
using UnityEngine;

using UserInterface;

namespace Environment
{
    /// <summary>
    /// Stair will enable player to explore another dungeon.
    /// </summary>
    [ RequireComponent( typeof( BoxCollider2D ) ) ]
    class Stair : MonoBehaviour
    {
        [ Header( "Private" ) ]
        [ SerializeField ] private ConfirmBox    m_confirmBox = null;
        [ SerializeField ] private BoxCollider2D m_Collider   = null;

        private void Start()
        {
            m_Collider   = GetComponent< BoxCollider2D >();
            m_confirmBox = GameObject.FindGameObjectWithTag( "Descent Panel" ).GetComponent< ConfirmBox >();

            if ( !m_Collider.isTrigger ) m_Collider.isTrigger = true;
        }

        private void DisplayConfirmBox()
        {
            m_confirmBox.Show();
        }

        private void HideConfirmBox()
        {
            m_confirmBox.Hide();
        }

        private void OnPlayerEnter()
        {
            DisplayConfirmBox();
        }

        private void OnPlayerExit()
        {
            HideConfirmBox();
        }

        private void OnTriggerEnter2D( Collider2D cll )
        {
            if ( cll.CompareTag( "Player" ) ) OnPlayerEnter();
        }

        private void OnTriggerExit2D( Collider2D collision )
        {
            if ( collision.CompareTag( "Player" ) ) OnPlayerExit();
        }
    }
}
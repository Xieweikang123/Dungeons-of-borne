
#if UNITY_ANDROID

using UnityEngine;

using Gameplay.Entities;
using Gameplay.Mechanical;
using Gameplay.Enums;
using Gameplay.Managers;

namespace UserInterface
{
    /// <summary>
    /// Enables user to apply screen input to the game.
    /// </summary>
    [ DisallowMultipleComponent ]
    class ScreenControls : MonoBehaviour
    {
        [ Header( "Private" ) ]

        [ Tooltip( "Drag & drop player controller here." ) ]
        [ SerializeField ]
        private PlayerController m_Controller = null;

        [ SerializeField ] private Player m_Player = null;

        [ Tooltip( "Drag & drop player here." ) ]
        [ SerializeField ]
        private Entity m_Entity = null;

        /// <summary>
        /// Move the player upward if top button pressed.
        /// </summary>
        public void ButtonUpTap()
        {
            if ( ( m_Controller == null ) || ( m_Player == null ) ) return;

            m_Controller.direction = Directions.Up;
            m_Controller.canMove   = true;
            m_Controller.activity  = ActivityStates.Moving;
            AudioManager.instance.PlayAudioSourceLoop( m_Entity.entityAudioList[ 1 ] );
        }

        /// <summary>
        /// Move the player to bottom if bottom button pressed.
        /// </summary>
        public void ButtonDownTap()
        {
            if ( ( m_Controller == null ) || ( m_Player == null ) ) return;

            m_Controller.direction = Directions.Down;
            m_Controller.canMove   = true;
            m_Controller.activity  = ActivityStates.Moving;
            AudioManager.instance.PlayAudioSourceLoop( m_Entity.entityAudioList[ 1 ] );
        }

        /// <summary>
        /// Moves player to left.
        /// </summary>
        public void ButtonLeftTap()
        {
            if ( ( m_Controller == null ) || ( m_Player == null ) ) return;

            m_Controller.direction = Directions.Left;
            m_Controller.canMove   = true;
            m_Controller.activity  = ActivityStates.Moving;
            AudioManager.instance.PlayAudioSourceLoop( m_Entity.entityAudioList[ 1 ] );
        }

         /// <summary>
        /// Moves player to right.
        /// </summary>
        public void ButtonRightTap()
        {
            if ( ( m_Controller == null ) || ( m_Player == null ) ) return;

            m_Controller.direction = Directions.Right;
            m_Controller.canMove   = true;
            m_Controller.activity  = ActivityStates.Moving;
            AudioManager.instance.PlayAudioSourceLoop( m_Entity.entityAudioList[ 1 ] );
        }

        /// <summary>
        /// Enables player to attack.
        /// </summary>
        public void ButtonAttackTap()
        {
            if ( ( m_Controller == null ) || ( m_Player == null ) ) return;
            m_Controller.LinkAnimation();
        }

        public void PumpkinTap()
        {
            if ( ( m_Controller == null ) || ( m_Player == null ) ) return;
            if ( m_Player != null ) m_Player.SpawnPumpkin();
        }

        /// <summary>
        /// Sets the player's canMove to false and state to idle. Just a function to prevent code duplication.
        /// </summary>
        public void Release()
        {
            if ( ( m_Controller == null ) || ( m_Player == null ) ) return;

            m_Controller.canMove  = false;
            m_Controller.activity = ActivityStates.Idle;
            AudioManager.instance.StopAudioSource( m_Entity.entityAudioList[ 1 ] );
        }
    }
}
#endif
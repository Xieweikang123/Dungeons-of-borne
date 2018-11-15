
using UnityEngine;

using Gameplay.Enums;
using Gameplay.Mechanical;

namespace Gameplay
{
    namespace Animations
    {
        [ DisallowMultipleComponent ]
        [ RequireComponent( typeof( PlayerController ) ) ]
        [ RequireComponent( typeof( Animator ) ) ]
        class PlayerMotor : MonoBehaviour
        {
            [ Header( "Private" ) ]

            [ Tooltip( "PlayerController component that attached to player." ) ]
            [ SerializeField ]
            private PlayerController m_Controller = null;

            [ Tooltip( "Animator component of player." ) ]
            [ SerializeField ]
            private Animator m_Animator = null;

            /// <summary>
            /// Holds the parameter data for animations.
            /// </summary>
            private AnimationParameters m_aParams = new AnimationParameters();

            /// <summary>
            /// Contains names of animation parameters.
            /// </summary>
            private class AnimationParameters
            {
                public string horizontalSpeed  { get { return ( m_horizontalSpeed ); } }
                public string verticalSpeed    { get { return ( m_verticalSpeed ); } }

                public string horizontalAttack { get { return ( m_horizontalAttack ); } }
                public string verticalAttack   { get { return ( m_verticalAttack ); } }

                private string m_horizontalSpeed  = "HorizontalSpeed";
                private string m_verticalSpeed    = "VerticalSpeed";

                private string m_horizontalAttack = "HorizontalAttack";
                private string m_verticalAttack   = "VerticalAttack";
            }

            /// <summary>
            /// Unity's callback function that will run on scene's start event.
            /// </summary>
            private void Start()
            {
                m_Controller = GetComponent< PlayerController >();
                m_Animator   = GetComponent< Animator >();
            }

            /// <summary>
            /// Unity's callback function that will run after "Update" function.
            /// </summary>
            private void LateUpdate()
            {
                SetMovementAnimation();
                SetAttackAnimationsToDefault();
            }

            /// <summary>
            /// Changes the animation of player based on activity state.
            /// </summary>
            private void SetMovementAnimation()
            {
                ActivityStates act = m_Controller.activity;
                
                switch ( act )
                {
                    case ( ActivityStates.Idle ):
                        // Play idle animation.
                        m_Animator.SetInteger( m_aParams.horizontalSpeed , 0 );
                        m_Animator.SetInteger( m_aParams.verticalSpeed , 0 );
                      
                        break;

                    case ( ActivityStates.Moving ):
                        // Play moving animation.
                        // First check the direction of player
                        if ( m_Controller.direction == Directions.Up )    m_Animator.SetInteger( m_aParams.verticalSpeed , 1 );
                        if ( m_Controller.direction == Directions.Down )  m_Animator.SetInteger( m_aParams.verticalSpeed , -1 );
                        if ( m_Controller.direction == Directions.Right ) m_Animator.SetInteger( m_aParams.horizontalSpeed , 1 );
                        if ( m_Controller.direction == Directions.Left )  m_Animator.SetInteger( m_aParams.horizontalSpeed , -1 );
                        break;
                }
            }

            /// <summary>
            /// Sets animations the idle mode when player not attacking.
            /// </summary>
            private void SetAttackAnimationsToDefault()
            {
                // !!! OPTIMIZE HERE PLEASE !!!
                // The most embarrassing function of my life , i am sorry.
                if ( m_Animator.GetCurrentAnimatorStateInfo( 1 ).IsName( "Anim_Attack_Down" ) && m_Animator.GetCurrentAnimatorStateInfo( 1 ).normalizedTime >= 1.0f )
                {
                    m_Animator.SetInteger( m_aParams.verticalAttack , 0 );
        
                }

                if ( m_Animator.GetCurrentAnimatorStateInfo( 1 ).IsName( "Anim_Attack_Up" ) && m_Animator.GetCurrentAnimatorStateInfo( 1 ).normalizedTime >= 1.0f )
                {
                    m_Animator.SetInteger( m_aParams.verticalAttack , 0 );
                 
                }

                if ( m_Animator.GetCurrentAnimatorStateInfo( 1 ).IsName( "Anim_Attack_Left" ) && m_Animator.GetCurrentAnimatorStateInfo( 1 ).normalizedTime >= 1.0f )
                {
                    m_Animator.SetInteger( m_aParams.horizontalAttack , 0 );
                 
                }

                if ( m_Animator.GetCurrentAnimatorStateInfo( 1 ).IsName( "Anim_Attack_Right" ) && m_Animator.GetCurrentAnimatorStateInfo( 1 ).normalizedTime >= 1.0f )
                {
                    m_Animator.SetInteger( m_aParams.horizontalAttack , 0 );
                 
                }
            }

            /// <summary>
            /// Plays the attack animation of player based on direction.
            /// </summary>
            /// <param name="dir"> The direction player faces. </param>
            public void SetAttackAnimation( Directions dir )
            {
                switch ( dir )
                {
                    case ( Directions.Up ):
                        m_Animator.SetInteger( m_aParams.verticalAttack , 1 );
                        break;

                    case ( Directions.Down ):
                        m_Animator.SetInteger( m_aParams.verticalAttack , -1 );
                        break;

                    case ( Directions.Left ):
                        m_Animator.SetInteger( m_aParams.horizontalAttack , -1 );
                        break;

                    case ( Directions.Right ):
                        m_Animator.SetInteger( m_aParams.horizontalAttack , 1 );
                        break;

                    default:
                        return;
                }
            }

            public void TriggerDeathAnimation()
            {
                m_Animator.SetBool( "IsDead" , true );
            }
        }
    }
}
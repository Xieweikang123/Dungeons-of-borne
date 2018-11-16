
using UnityEngine;

namespace Gameplay
{
    namespace Mechanical
    {
        /// <summary>
        /// "Controller" is base class for other controllers in game.
        /// </summary>
        [ DisallowMultipleComponent ]
        [ RequireComponent( typeof( Rigidbody2D ) ) ]
        [ RequireComponent( typeof( BoxCollider2D ) ) ]
        class Controller : MonoBehaviour
        {
            [ Header( "Derived fields from Controller base class" ) ]

            [ Tooltip( "BoxCollider2D component attached to character." ) ]
            [ SerializeField ]
            protected BoxCollider2D m_Collider = null;

            [ Tooltip( "Determines if character can move or not." ) ]
            [ SerializeField ]
            protected bool          m_canMove  = false;

            [ Tooltip( "Determines how fast player can run." ) ]
            [ SerializeField ]
            protected float         m_maxSpeed = 4.5f;

            public float  movementSpeed
            {
                get
                {
                    return ( m_Speed );
                }
                set
                {
                    m_Speed = Mathf.Abs( value );
                }
            }

            public bool canMove { get { return ( m_canMove ); } set { m_canMove = value; } }

            private float m_Speed = 0.0f;

            /// <summary>
            /// Movement logic for character.
            /// </summary>
            public virtual void Move() { }

            /// <summary>
            /// Attack logic for character.
            /// </summary>
            public virtual void Attack() { }
        }
    }
}
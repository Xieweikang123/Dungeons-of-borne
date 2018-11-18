
using UnityEngine;

using Common.Interfaces;

using Gameplay.Animations;
using Gameplay.Entities;
using Gameplay.Enums;
using Gameplay.Managers;

namespace Gameplay
{
    namespace Mechanical
    {
        /// <summary>
        /// Handles input , movement and physical stuff for player.
        /// </summary>
        [DisallowMultipleComponent]
        [RequireComponent(typeof(PlayerMotor))]
        [RequireComponent(typeof(SpriteRenderer))]
        class PlayerController : Controller, ISetup
        {
            [Header("Public")]

            [Tooltip("Determines which layers will be targeted for player.")]
            public LayerMask targetLayer = 0;

            [Tooltip("Displays current activity type of player.")]
            public ActivityStates activity = ActivityStates.Idle;

            [Tooltip("Displays the direction of player.")]
            public Directions direction = Directions.Down;

            [Space]

            [Header("Private")]

            [Tooltip("PlayerMotor is component that manages player's animations.")]
            [SerializeField]
            private PlayerMotor m_Motor = null;

            [Tooltip("Position data about strike/attack positions.")]
            [SerializeField]
            private StrikePositions m_sPositions = new StrikePositions();

            [Tooltip("Current entity component for player.")]
            [SerializeField]
            private Entity m_Entity = null;

            [SerializeField]
            private GameObject minimap_obj;

            #region Private Fields
#if UNITY_STANDALONE
            /// <summary>
            /// Enables us to access the input data via custom "InputManager" class.
            /// </summary>                                 
            private InputManager m_Input = new InputManager();
#endif
            #endregion

            /// <summary>
            /// Contains axis data for input.
            /// </summary>
            private class InputManager
            {
                public float verticalAxisValue { get { return (Input.GetAxisRaw(m_verticalAxis)); } }
                public float horizontalAxisValue { get { return (Input.GetAxisRaw(m_horizontalAxis)); } }

                private string m_verticalAxis = "Vertical";
                private string m_horizontalAxis = "Horizontal";
            }

            /// <summary>
            /// Contains position data for player to attack/strike.
            /// </summary>
            [System.Serializable]
            private class StrikePositions
            {
                public Transform up = null;
                public Transform down = null;
                public Transform left = null;
                public Transform right = null;
            }

            #region Private Functions
            /// <summary>
            /// Unity's callback function that will run on scene's start event.
            /// </summary>
            private void Start()
            {
                Setup();
            }

            /// <summary>
            /// Unity's callback function that will run every frame.
            /// </summary>
            private void Update()
            {
                Move();
#if UNITY_STANDALONE
                Attack();
                //小地图
                OnOffMinimap();
#endif
            }

            /// <summary>
            /// Unity's callback function that will run after "Update" function.
            /// </summary>
            private void LateUpdate()
            {
                SetActivityState();
                SetDirection();
            }

            /// <summary>
            /// Sets the current direction of player.
            /// </summary>
            private void SetDirection()
            {
#if UNITY_STANDALONE
                float dx = m_Input.horizontalAxisValue;
                if (dx > 0.0f) direction = Directions.Right;
                if (dx < 0.0f) direction = Directions.Left;

                float dy = m_Input.verticalAxisValue;
                if (dy > 0.0f) direction = Directions.Up;
                if (dy < 0.0f) direction = Directions.Down;

                // Enable this line if you want to set player's direction to down while player is idle.
                // if ( ( dx == 0.0f ) && ( dy == 0.0f ) ) direction = Directions.Down;
#endif
            }

            /// <summary>
            /// Checks and sets current activity state of player.
            /// </summary>
            private void SetActivityState()
            {
#if UNITY_STANDALONE
                float actY = m_Input.verticalAxisValue;
                float actX = m_Input.horizontalAxisValue;

                if ((actX != 0.0f) || (actY != 0.0f)) activity = ActivityStates.Moving;
                else activity = ActivityStates.Idle;
#endif
            }
            #endregion

            #region Derived Functions
            /// <summary>
            /// Setups the player , components and loads default values. Implemented from "ISetup" interface.
            /// </summary>
            public void Setup()
            {
                // Load components.
                m_Collider = GetComponent<BoxCollider2D>();
                m_Motor = GetComponent<PlayerMotor>();
                m_Entity = GetComponent<Entity>();

                // Setup default values.
                movementSpeed = 4.0f;

                // Make sure we are player.
                if (this.gameObject.tag != "Player") this.gameObject.tag = "Player";
            }

            /// <summary>
            /// Moves the character. Implemented from "Controller" base class.
            /// </summary>
            public override void Move()
            {
#if UNITY_STANDALONE
                float dy = m_Input.verticalAxisValue;
                float dx = m_Input.horizontalAxisValue;

                //  print("horizontalAxisValue: " + dx);

                Vector2 vel = new Vector2(dx, dy);
                transform.Translate((vel) * (movementSpeed) * (Time.deltaTime));
#elif UNITY_ANDROID
                // This is special movement logic for Android.
                if ( m_canMove )
                {
                    switch ( direction )
                    {
                        case ( Directions.Up ):
                            // Move up.
                            transform.Translate(  ( Vector2.up )  * ( movementSpeed ) * ( Time.deltaTime ) );
                            break;

                        case ( Directions.Down ):
                            // Move down.
                            transform.Translate(  ( Vector2.down )  * ( movementSpeed ) * ( Time.deltaTime ) );
                            break;

                        case ( Directions.Left ):
                            // Move left.
                            transform.Translate(  ( Vector2.left )  * ( movementSpeed ) * ( Time.deltaTime ) );
                            break;

                        case ( Directions.Right):
                            // Move right.
                            transform.Translate(  ( Vector2.right )  * ( movementSpeed ) * ( Time.deltaTime ) );
                            break;
                    }
                }
#endif
            }

            /// <summary>
            /// Attack function for player. Implemented from "Controller" base class.
            /// </summary>
            public override void Attack()
            {
#if UNITY_STANDALONE
                // if ( Input.GetButtonDown( "Fire1" ) ) m_Motor.SetAttackAnimation( direction);
                if (Input.GetKeyDown(KeyCode.J)) {

                    m_Motor.SetAttackAnimation(direction);
                    print("攻击");

                }

#elif UNITY_ANDROID
                Collider2D[] colls = null;
                // Increase this "rad" value to kill enemies easy.
                const float  rad   = 0.5f;
                // Check player's direction and attack the target direction.
                switch ( direction )
                {
                    case ( Directions.Up ):
                        colls = Physics2D.OverlapCircleAll( m_sPositions.up.position , rad , targetLayer );
                        CombatManager.DamageTargets( m_Entity , colls );
                        break;

                    case ( Directions.Down ):
                        colls = Physics2D.OverlapCircleAll( m_sPositions.down.position , rad , targetLayer );
                        CombatManager.DamageTargets( m_Entity , colls );
                        break;

                    case ( Directions.Left ):
                        colls = Physics2D.OverlapCircleAll( m_sPositions.left.position , rad , targetLayer );
                        CombatManager.DamageTargets( m_Entity , colls );
                        break;

                    case ( Directions.Right ):
                        colls = Physics2D.OverlapCircleAll( m_sPositions.right.position , rad , targetLayer );
                        CombatManager.DamageTargets( m_Entity , colls );
                        break;

                    default:
                        return;
                }
#endif
            }

            #region Public Functions
            /// <summary>
            /// Links attack animation to motor.
            /// </summary>
            public void LinkAnimation()
            {
                m_Motor.SetAttackAnimation(direction);
            }

            /// <summary>
            /// Checks if player has reached the full speed.
            /// </summary>
            /// <returns> True if reached the full speed. </returns>
            public bool IsAtFullSpeed()
            {
                if (this.movementSpeed >= this.m_maxSpeed) return (true);
                else return (false);
            }
            #endregion
            #endregion
            private void OnOffMinimap(){
               if(Input.GetKeyDown(KeyCode.N)){
                    minimap_obj.SetActive(!minimap_obj.activeSelf);
                }
            }
        }
    }
}
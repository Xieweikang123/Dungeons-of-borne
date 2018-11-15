
using UnityEngine;

namespace UserInterface
{
    /// <summary>
    /// "Fade Image" is visual effect that fills the whole screen for several seconds and destroys itself after animation finishes.
    /// </summary>
    [ DisallowMultipleComponent ]
    [ RequireComponent( typeof( Animator ) ) ]
    [ RequireComponent( typeof( CanvasGroup ) ) ]
    [ RequireComponent( typeof( Stretch ) ) ]
    class FadeImage : MonoBehaviour
    {
        [ Header( "Private" ) ]

        [ Tooltip( "Animator component will be used to determine the animation stage." ) ]
        [ SerializeField ]
        private Animator m_Animator = null;

        /// <summary>
        /// Unity's callback function that will run on scene's start event.
        /// </summary>
        private void Start()
        {
            m_Animator = GetComponent< Animator >();
        }

        /// <summary>
        /// Unity's callback function that will run every frame.
        /// </summary>
        private void Update()
        {
            CheckAnimationStage();
        }

        /// <summary>
        /// Destroys the fading image after fade animation finishes.
        /// </summary>
        private void CheckAnimationStage()
        {
            if ( m_Animator.GetCurrentAnimatorStateInfo( 0 ).normalizedTime > 1.0f ) Destroy( this.gameObject );
        }
    }
}
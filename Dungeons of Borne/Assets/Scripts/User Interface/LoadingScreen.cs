
using System.Collections.Generic;

using UnityEngine;

using TMPro;
using Gameplay.Managers;

namespace UserInterface
{
    /// <summary>
    /// Displays loading screen at the start of game.
    /// </summary>
    [ RequireComponent( typeof( Animator ) ) ]
    class LoadingScreen : MonoBehaviour
    {
        [ Header( "Private" ) ]

        [ SerializeField ]
        private float m_Delay = 0;

        [ SerializeField ]
        private List< string > m_randomTexts = new List< string >();

        [ SerializeField ]
        private TextMeshProUGUI m_Text = null;

        [ SerializeField ]
        private Animator m_Animator = null;

        [ SerializeField ] private List< GameObject > musicManagers = new List< GameObject >();

        private System.Collections.IEnumerator Start()
        {
            m_Animator = GetComponent< Animator >();
            int rng = Random.Range( 0 , m_randomTexts.Count );
            m_Text.text = m_randomTexts[ rng ];
            yield return new WaitForSeconds( m_Delay );
            // Start playing fade animation.
            m_Animator.SetTrigger( "Fade" );
        }

        public void CreateMusicManager()
        {
            Instantiate( musicManagers[ Random.Range( 0 , musicManagers.Count ) ] , new Vector2( 0 , 0 ) , Quaternion.identity );
        }

        /// <summary>
        /// Will be called from animation events.
        /// </summary>
        public void PlayDescendAudio()
        {
            AudioManager.instance.PlayAudioSourceOneShot( AudioManager.instance.descendAudio );
        }

        public void Terminate()
        {
            Destroy( this.gameObject );
        }

    }

} // user interface

using UnityEngine;

using Utilities;

namespace Shared
{
    /// <summary>
    /// Used for load the game and manage the system.
    /// </summary>
    [ DisallowMultipleComponent ]
    [ RequireComponent( typeof( Low.Display ) ) ]
    [ RequireComponent( typeof( Scene ) ) ]
    class Initialization : MonoBehaviour
    {
        [ Header( "Public" ) ]

        [ Tooltip( "Delay determines how much time will pass at current scene." ) ]
        [ Range( 4.0f , 10.0f ) ]
        public float delay = 4.0f;

        [ Space ]

        [ Header( "Private" ) ]

        [ Tooltip( "Display component will manage the resolution." ) ]
        [ SerializeField ]
        private Low.Display m_Display = null;

        [ Tooltip( "This component will change into another scene after X seconds of delay." ) ]
        [ SerializeField ]
        private Scene       m_Scene   = null;

        /// <summary>
        /// Unity's callback function that will run on scene's start event.
        /// </summary>
        /// <returns></returns>
        private System.Collections.IEnumerator Start()
        {
            m_Scene   = GetComponent< Scene >();
            m_Display = GetComponent< Low.Display >();

            m_Display.AutoResolution();

            yield return new WaitForSeconds( delay );

            m_Scene.LoadScene( 1 );
        }
    }
}

using UnityEngine;

using Utilities;

namespace Shared
{
    namespace Low
    {
        /// <summary>
        /// Display class manages the game window and resolution.
        /// </summary>
        [ DisallowMultipleComponent ]
        class Display : MonoBehaviour
        {
            /// <summary>
            /// Window struct keeps window properties together.
            /// </summary>
            private struct Window
            {
                public int Width
                {
                    get
                    {
                        return ( m_Width );
                    }
                    set
                    {
                        m_Width = Mathf.Abs( value );
                    }
                }

                public int Height
                {
                    get
                    {
                        return ( m_Height );
                    }
                    set
                    {
                        m_Height = Mathf.Abs( value );
                    }
                }

                public bool FullScreen
                {
                    get
                    {
                        return ( m_fullScreen );
                    }
                    set
                    {
                        m_fullScreen = value;
                    }
                }

                private int  m_Width;
                private int  m_Height;
                private bool m_fullScreen;
            }

            /// <summary>
            /// Detects the current system's resolution and sets it as game's resolution.
            /// </summary>
            public void AutoResolution()
            {
                Window wnd     = new Window();

                wnd.Width      = Screen.currentResolution.width;
                wnd.Height     = Screen.currentResolution.height;
                wnd.FullScreen = true;

                Screen.SetResolution( wnd.Width , wnd.Height , wnd.FullScreen );

                // Save resolution into player prefs.
                PrefsExtensions.SaveInt( "Width" , wnd.Width );
                PrefsExtensions.SaveInt( "Height" , wnd.Height );
            }

            /// <summary>
            /// Enables us to get width of screen.
            /// </summary>
            /// <returns> Width of screen. </returns>
            public static int GetWidth()
            {
                int w = PrefsExtensions.LoadInt( "Width" );
                return ( w );
            }

            /// <summary>
            /// Enables us to get height of screen.
            /// </summary>
            /// <returns> Height of screen. </returns>
            public static int GetHeight()
            {
                int h = PrefsExtensions.LoadInt( "Height" );
                return ( h );
            }
        }
    }
}
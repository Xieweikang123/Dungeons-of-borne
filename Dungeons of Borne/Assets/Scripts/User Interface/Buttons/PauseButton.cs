
using UnityEngine;

namespace UserInterface
{
    namespace Buttons
    {
        class PauseButton : Button
        {
            [ Header( "Private" ) ]
            [ SerializeField ] private GameObject m_pauseMenu = null;

            private void SwitchGameState()
            {
                if ( Time.timeScale != 0.0f ) Time.timeScale = 0.0f;
                else                          Time.timeScale = 1.0f;
            }

            private void SwitchPauseMenuState()
            {
                if ( m_pauseMenu == null ) return;

                switch ( m_pauseMenu.activeSelf )
                {
                    case ( true ):
                        m_pauseMenu.SetActive( false );
                        break;

                    case ( false ):
                        m_pauseMenu.SetActive( true );
                        break;

                    default:
                        Debug.Log( "Whoops , something went really really wrong !" );
                        break;
                }
            }

            public override void Action()
            {
                base.Action();
                SwitchGameState();
                SwitchPauseMenuState();
            }
        }
    }
}
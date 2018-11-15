
using UnityEngine;

namespace UserInterface
{
    namespace Buttons
    {
        class UnPauseButton : Button
        {
            [ Header( "Private" ) ]
            [ SerializeField ] private GameObject m_pauseMenu = null;

            public override void Action()
            {
                base.Action();
                Time.timeScale = 1.0f;
                m_pauseMenu.SetActive( false );
            }
        }
    }
}

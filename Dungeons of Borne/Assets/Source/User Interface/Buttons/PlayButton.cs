
using UnityEngine;

using Gameplay.Managers;
using Utilities;

namespace UserInterface
{
    namespace Buttons
    {
        class PlayButton : Button
        {
            [ Header( "Private" ) ]
            [ SerializeField ] private Scene m_sceneManager = null;
            [ SerializeField ] private int   m_sceneIndex   = 0;

            public override void Action()
            {
                base.Action();
                m_sceneManager.LoadScene( m_sceneIndex );
            }
        }
    }
}
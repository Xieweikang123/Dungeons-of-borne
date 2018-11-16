
using UnityEngine;
using UnityEngine.SceneManagement;

using Utilities;

namespace UserInterface
{
    namespace Buttons
    {
        class RestartButton : Button
        {
            [ Header( "Private" ) ]
            [ SerializeField ] private Utilities.Scene m_sceneManager = null;

            public override void Action()
            {
                base.Action();
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                m_sceneManager.LoadScene( currentSceneIndex );
            }
        }
    }
}
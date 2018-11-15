
using System.Collections.Generic;

using UnityEngine;

using TMPro;

namespace UserInterface
{
    class DeathUI : MonoBehaviour
    {
        [ Header( "Private" ) ]
        [ SerializeField ] private TextMeshProUGUI         m_funnyDeathText = null;
        [ SerializeField ] private List< string >          m_funnyTexts     = new List< string >();

        private void Start()
        {
            AssignRandomText();
        }

        private void AssignRandomText()
        {
            m_funnyDeathText.text = m_funnyTexts[ Random.Range( 0 , m_funnyTexts.Count ) ];
        }

        public void SwitchToMainMenu()
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync( 1 );
        }
    }
}

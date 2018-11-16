
using UnityEngine;
using UnityEngine.SceneManagement;

using Data;
using Gameplay.Managers;

namespace UserInterface
{
    [ RequireComponent( typeof( CanvasGroup ) ) ]
    class ConfirmBox : MonoBehaviour
    {
        private CanvasGroup  cnv          = null;
        private PlayerData   m_pData      = null;

        private void Start()
        {
            cnv     = GetComponent< CanvasGroup >();
            m_pData = GameObject.FindGameObjectWithTag( "Player" ).GetComponent< PlayerData >();

            Hide();
        }

        public void Show()
        {
            cnv.alpha          = 1.0f;
            cnv.interactable   = true;
            cnv.blocksRaycasts = true;
            Time.timeScale     = 0.0f;
        }

        public void Hide()
        {
            cnv.alpha          = 0.0f;
            cnv.interactable   = false;
            cnv.blocksRaycasts = false;
            Time.timeScale     = 1.0f;
        }

        public void YesButtonTap()
        {
            AudioManager.instance.PlayAudioSourceOneShot( AudioManager.instance.buttonClickAudio );
            m_pData.deepestFloor++;

            // Save the statistics when player descends to new dungeon.
            m_pData.UpdateChestStatistic();
            m_pData.UpdatePotionsConsumedStatistic();
            m_pData.UpdatePumpkinsPlacedStatistic();

            m_pData.SaveData();
            SceneManager.LoadSceneAsync( 2 );
        }

        public void NoButtonTap()
        {
            // Disable the ConfirmBox and everything will be fine.
            AudioManager.instance.PlayAudioSourceOneShot( AudioManager.instance.buttonClickAudio );
            Hide();
        }
    }
}
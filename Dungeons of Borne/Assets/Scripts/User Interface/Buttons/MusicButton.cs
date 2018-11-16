
using UnityEngine;

using TMPro;

namespace UserInterface.Buttons
{
    class MusicButton : Button
    {
        [ Header( "Private" ) ]
        [ SerializeField ] private AudioSource     m_musicManager = null;
        [ SerializeField ] private TextMeshProUGUI m_buttonText   = null;

        private void Start()
        {
            m_musicManager = GameObject.FindGameObjectWithTag( "Music Manager" ).GetComponent< AudioSource >();
            SetText();
        }

        private void SetText()
        {
            if ( !m_musicManager.mute ) m_buttonText.text = "Music : On";
            else m_buttonText.text = "Music : Off";
        }

        private void SwitchMusicState()
        {
            if ( !m_musicManager.mute )
            {
                m_buttonText.text = "Music : Off";
                m_musicManager.mute = true;
            }
            else
            {
                m_buttonText.text = "Music : On";
                m_musicManager.mute = false;
            }
        }

        public override void Action()
        {
            SwitchMusicState();
            base.Action();
        }
    }
}
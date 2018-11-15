
using UnityEngine;

namespace UserInterface
{
    namespace Buttons
    {
        class CreditsButton : Button
        {
            [ SerializeField ] private GameObject m_Credits = null;

            public override void Action()
            {
                base.Action();
                if ( m_Credits.activeSelf ) m_Credits.SetActive( false );
                else m_Credits.SetActive( true );
            }
        }
    }
}

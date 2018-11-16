
using UnityEngine;

using TMPro;

using Utilities;

namespace UserInterface
{
    [ DisallowMultipleComponent ]
    class Statistics : MonoBehaviour
    {
        [ Header( "Private" ) ]
        [ SerializeField ] private TextMeshProUGUI m_deepestFloorText    = null;
        [ SerializeField ] private TextMeshProUGUI m_timesDiedText       = null;
        [ SerializeField ] private TextMeshProUGUI m_chestsOpenedText    = null;
        [ SerializeField ] private TextMeshProUGUI m_potionsConsumedText = null;
        [ SerializeField ] private TextMeshProUGUI m_pumpkinsPlacedText  = null;

        private void OnEnable()
        {
            AssignData();
        }

        private void AssignData()
        {
            m_deepestFloorText.text    = "Deepest Floor :" + PrefsExtensions.LoadInt( "High Score" ).ToString();
            m_timesDiedText.text       = "Times Died :" + PrefsExtensions.LoadInt( "Times Died" ).ToString();
            m_chestsOpenedText.text    = "Chests Opened :" + PrefsExtensions.LoadInt( "Chests Opened" ).ToString();
            m_potionsConsumedText.text = "Potions consumed :" + PrefsExtensions.LoadInt( "Potions Consumed" ).ToString();
            m_pumpkinsPlacedText.text  = "Pumpkins Planted :" + PrefsExtensions.LoadInt( "Pumpkins Placed" ).ToString();
        }
    }
}

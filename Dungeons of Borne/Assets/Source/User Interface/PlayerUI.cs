
using UnityEngine;

using TMPro;

using Data;

using Gameplay.Entities;

namespace UserInterface
{
    /// <summary>
    /// Displays player's information on screen.
    /// </summary>
    [ DisallowMultipleComponent ]
    [ RequireComponent( typeof( TextMeshProUGUI ) ) ]
    class PlayerUI : MonoBehaviour
    {
        [ Header( "Private" ) ]

        [ Tooltip( "Drag & drop player here to display statistics." ) ]
        [ SerializeField ]
        private Player m_Player = null;

        [ Tooltip( "This text component." ) ]
        [ SerializeField ]
        private TextMeshProUGUI m_healthText = null;

        [ SerializeField ] private TextMeshProUGUI m_pumpkinCountText = null;

        [ SerializeField ] private TextMeshProUGUI m_deepestFloorText = null;

        private PlayerData pd = null;

        /// <summary>
        /// Unity's callback function that will run on scene's start event.
        /// </summary>
        private void Start()
        {
            m_healthText = GetComponent< TextMeshProUGUI >();
            pd = GameObject.FindGameObjectWithTag( "Player" ).GetComponent< PlayerData >();
        }

        /// <summary>
        /// Unity's callback function that will run on every frame.
        /// </summary>
        private void Update()
        {
            DisplayStatistics();
            SetHealthTextColor();
        }

        /// <summary>
        /// Displays the player's statistics on screen.
        /// </summary>
        private void DisplayStatistics()
        {
            m_healthText.text = m_Player.health.ToString();
            m_pumpkinCountText.text = "x" + pd.collectedPumpkins.ToString();
            m_deepestFloorText.text = "x" + pd.deepestFloor.ToString();
            if ( m_Player.health < 0 ) m_Player.health = 0;
        }

        /// <summary>
        /// Sets the color of health text based on player's health.
        /// </summary>
        private void SetHealthTextColor()
        {
            if ( m_Player.health <= 50 && m_Player.health >= 30 ) m_healthText.color = Color.yellow;
            else if ( m_Player.health < 30 )                      m_healthText.color = Color.red;
            else m_healthText.color = Color.green;
        }
    }
}
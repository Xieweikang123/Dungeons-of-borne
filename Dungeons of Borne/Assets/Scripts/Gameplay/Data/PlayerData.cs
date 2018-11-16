
using UnityEngine;

using Gameplay.Entities;
using Gameplay.Mechanical;
using Utilities;

namespace Data
{
    class PlayerData : MonoBehaviour
    {
        [ Header( "Private" ) ]
        [ SerializeField ] private int              m_collectedPumpkins  = 0;
        [ SerializeField ] private int              m_deepestFloor       = 0;
        [ SerializeField ] private int              m_chestsOpened       = 0;
        [ SerializeField ] private int              m_potionsConsumed    = 0;
        [ SerializeField ] private int              m_pumpkinsPlaced     = 0;
        [ SerializeField ] private Player           m_Player             = null;
        [ SerializeField ] private PlayerController m_Controller         = null;
        [ SerializeField ] private DataKeys         m_dataKey            = new DataKeys();
       
        #region Properties
        public int collectedPumpkins { get { return ( m_collectedPumpkins ); } set { m_collectedPumpkins = value; } }
        public int deepestFloor      { get { return ( m_deepestFloor ); } set { m_deepestFloor = value; } }
        public int chestsOpened      { get { return ( m_chestsOpened ); } set { m_chestsOpened = value; } }
        public int potionsConsumed   { get { return ( m_potionsConsumed ); } set { m_potionsConsumed = value; } }
        public int pumpkinsPlaced    { get { return ( m_pumpkinsPlaced ); } set { m_pumpkinsPlaced = value; } }
        #endregion

        /// <summary>
        /// Contains string values for data keys.
        /// </summary>
        [ System.Serializable ]
        private class DataKeys
        {
            public string collectedPumpkinsKey = "Pumpkin";
            public string deepestFloorKey      = "Deepest Floor";
            public string timesDiedKey         = "Times Died";
            public string chestsOpenedKey      = "Chests Opened";
            public string potionsConsumedKey   = "Potions Consumed";
            public string pumpkinsPlacedKey    = "Pumpkins Placed";
            public string highScore            = "High Score";

            public string healthKey = "Health";
            public string armorKey  = "Armor";
            public string damageKey = "Damage";
            public string speedKey  = "Speed";
        }

        private void Start()
        {
            m_Player     = GetComponent< Player >();
            m_Controller = GetComponent< PlayerController >();

            LoadData();
        }

        public void ResetData()
        {
            collectedPumpkins          = 0;
            deepestFloor               = 0;

            m_Player.health            = 100;
            m_Player.armor             = 2;
            m_Player.damage            = 10;
            m_Controller.movementSpeed = 4.0f;

            SaveData();

            Debug.Log( "Game data has returned to default !" );
        }

        public void SaveData()
        {
            PrefsExtensions.SaveInt( m_dataKey.collectedPumpkinsKey , collectedPumpkins );
            PrefsExtensions.SaveInt( m_dataKey.deepestFloorKey , deepestFloor );
            PrefsExtensions.SaveInt( m_dataKey.healthKey , m_Player.health );
            PrefsExtensions.SaveInt( m_dataKey.armorKey , m_Player.armor );
            PrefsExtensions.SaveInt( m_dataKey.damageKey , m_Player.damage );
            PlayerPrefs.SetFloat( m_dataKey.speedKey , m_Controller.movementSpeed );
        }

        public void LoadData()
        {
            int cPumpkins     = PrefsExtensions.LoadInt( m_dataKey.collectedPumpkinsKey );
            collectedPumpkins = cPumpkins;

            int dFloor   = PrefsExtensions.LoadInt( m_dataKey.deepestFloorKey );
            deepestFloor = dFloor;

            int hp   = PrefsExtensions.LoadInt( m_dataKey.healthKey );
            if ( hp != 0 ) m_Player.health = hp;

            int pArmor = PrefsExtensions.LoadInt( m_dataKey.armorKey );
            m_Player.armor = pArmor;

            int pDmg = PrefsExtensions.LoadInt( m_dataKey.damageKey );
            m_Player.damage = pDmg;

            float spd = PlayerPrefs.GetFloat( m_dataKey.speedKey );
            m_Controller.movementSpeed = spd;
        }

        public void UpdateDiedTimesStatistic()
        {
            int dt = PrefsExtensions.LoadInt( m_dataKey.timesDiedKey );
            PrefsExtensions.SaveInt( m_dataKey.timesDiedKey , ( dt + 1 ) );
        }

        public void UpdateChestStatistic()
        {
            int co = PrefsExtensions.LoadInt( m_dataKey.chestsOpenedKey );
            PrefsExtensions.SaveInt( m_dataKey.chestsOpenedKey , ( co + chestsOpened ) );
        }

        public void UpdatePotionsConsumedStatistic()
        {
            int pc = PrefsExtensions.LoadInt( m_dataKey.potionsConsumedKey );
            PrefsExtensions.SaveInt( m_dataKey.potionsConsumedKey , ( pc + potionsConsumed ) );
        }

        public void UpdatePumpkinsPlacedStatistic()
        {
            int pp = PrefsExtensions.LoadInt( m_dataKey.pumpkinsPlacedKey );
            PrefsExtensions.SaveInt( m_dataKey.pumpkinsPlacedKey , ( pp + pumpkinsPlaced ) );
        }

        /// <summary>
        /// Player's statistics will be updated when player is dead.
        /// </summary>
        public void UpdateStatistics()
        {
            UpdateDiedTimesStatistic();
            UpdateChestStatistic();
            UpdatePotionsConsumedStatistic();
            UpdatePumpkinsPlacedStatistic();
        }

        public void UpdateHighScore()
        {
            // We want to update player's high score when player gets better score.
            // Get the high score from player prefs first.
            int hScore = PrefsExtensions.LoadInt( m_dataKey.highScore );
            // Compare the high score with current floor deep.
            if ( deepestFloor > hScore )
            {
                // We got a new high score here.
                // Update the high score.
                PrefsExtensions.SaveInt( m_dataKey.highScore , deepestFloor );
            }
        }
    }
}
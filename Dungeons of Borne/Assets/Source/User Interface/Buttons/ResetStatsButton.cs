
using UnityEngine;
using Utilities;

namespace UserInterface.Buttons
{
    class ResetStatsButton : Button
    {
        [ SerializeField ] private GameObject panel = null;

        private void ResetStats()
        {
            PrefsExtensions.SaveInt( "High Score" , 0 );
            PrefsExtensions.SaveInt( "Times Died" , 0 );
            PrefsExtensions.SaveInt( "Chests Opened" , 0 );
            PrefsExtensions.SaveInt( "Potions Consumed" , 0 );
            PrefsExtensions.SaveInt( "Pumpkins Placed" , 0 );

            UnityEngine.Debug.Log( "Data is gone !" );
        }

        public override void Action()
        {
            ResetStats();
            base.Action();
            panel.SetActive( false );
        }
    }
}
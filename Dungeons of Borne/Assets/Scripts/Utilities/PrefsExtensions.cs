
using UnityEngine;

namespace Utilities
{
    /// <summary>
    /// Custom class to enhance default player prefs functions.
    /// </summary>
    class PrefsExtensions
    {
        /// <summary>
        /// Checks if given value is saved already for given key.
        /// </summary>
        /// <param name="key"> The key you want to check. </param>
        /// <param name="value"> The value you want to check. </param>
        /// <returns> True if it is already saved into player prefs. </returns>
        private static bool IsAlreadySaved( string key , int value )
        {
            int tmp = PlayerPrefs.GetInt( key );
            
            if ( tmp == value ) return ( true );
            else                return ( false );
        }

        /// <summary>
        /// Saves an int value to given key.
        /// </summary>
        /// <param name="key"> Key to store int. value into player prefs. </param>
        /// <param name="value"> The value to store. </param>
        public static void SaveInt( string key , int value )
        {
            if ( !IsAlreadySaved( key , value ) )
            {
                PlayerPrefs.SetInt( key , value );
                PlayerPrefs.Save();
            }
        }

        /// <summary>
        /// Gets the value that stored into given key.
        /// </summary>
        /// <param name="key"> The key to get value from. </param>
        /// <returns> The value. </returns>
        public static int LoadInt( string key )
        {
            int result = PlayerPrefs.GetInt( key );
            return ( result );
        }
    }
}

using UnityEngine;

using TMPro;

namespace UserInterface
{
    /// <summary>
    /// Contains several functions for fading text components.
    /// </summary>
    [ DisallowMultipleComponent ]
    class FadingText : MonoBehaviour
    {
        /// <summary>
        /// Sets up new text for component.
        /// </summary>
        /// <param name="fText"> Text component. </param>
        /// <param name="text"> New text. </param>
        public void SetText( TextMeshProUGUI fText , string text )
        {
            fText.text = text;
        }

        /// <summary>
        /// Sets the color of text.
        /// </summary>
        /// <param name="fText"> Text. </param>
        /// <param name="newColor"> The new color of text. </param>
        public void SetColor( TextMeshProUGUI fText , Color newColor )
        {
            fText.color = newColor;
        }
    }
}
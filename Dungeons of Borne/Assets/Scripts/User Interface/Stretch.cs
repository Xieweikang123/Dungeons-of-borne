
using UnityEngine;

namespace UserInterface
{
    /// <summary>
    /// "Stretch" is effect that enables UI components to fill whole screen.
    /// </summary>
    [ DisallowMultipleComponent ]
    class Stretch : MonoBehaviour
    {
        /// <summary>
        /// Unity's callback function that will run on scene's start event.
        /// </summary>
        private void Start()
        {
            ApplyStretch();
        }

        /// <summary>
        /// Stretches the UI component.
        /// </summary>
        private void ApplyStretch()
        {
            // First check if current attached object is UI component.
            RectTransform t = GetComponent< RectTransform >();

            if ( t != null )
            {
                // It is UI component , get the screen width and height and apply it into image.
                int w = Shared.Low.Display.GetWidth();
                int h = Shared.Low.Display.GetHeight();

                t.sizeDelta = new Vector2( w , h );
               // print("t.size: " + t.sizeDelta);
            }
            else
            {
                string objName = this.gameObject.name;
                Debug.Log( objName + " is not an UI component , failed to stretch !" );
            }
        }
    }
}
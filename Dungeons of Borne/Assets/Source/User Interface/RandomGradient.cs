
using System.Collections.Generic;

using UnityEngine;

using TMPro;

namespace UserInterface
{
    /// <summary>
    /// Sets random gradient from list.
    /// </summary>
    class RandomGradient : MonoBehaviour
    {
        public List< TMP_ColorGradient > gradients = new List< TMP_ColorGradient >();

        /// <summary>
        /// Unity's callback function that will run before "Start" function.
        /// </summary>
        private void Awake()
        {
            int rng = Random.Range( 0 , gradients.Count );
            TextMeshProUGUI t = GetComponent< TextMeshProUGUI >();
            t.colorGradientPreset = gradients[ rng ];
        }
    }
}

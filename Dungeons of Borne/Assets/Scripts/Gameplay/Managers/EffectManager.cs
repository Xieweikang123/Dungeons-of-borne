
using UnityEngine;

using TMPro;

using Gameplay.Entities;

using UserInterface;

namespace Gameplay
{
    namespace Managers
    {
        /// <summary>
        /// Handles all the normal and UI based effects.
        /// </summary>
        [ DisallowMultipleComponent ]
        class EffectManager : MonoBehaviour
        {
            [ Header( "Public - UI" ) ]

            [ Tooltip( "Drag & drop world space canvas here." ) ]
            public Canvas worldSpaceCanvas = null;

            [ Tooltip( "Drag & drop Fading Text prefab here." ) ]
            public GameObject fadingText   = null;

            public GameObject deathScreen  = null;

            /// <summary>
            /// Singleton pattern.
            /// </summary>
            public static EffectManager instance = null;

            /// <summary>
            /// Unity's callback function that will run before scene's start event.
            /// </summary>
            private void Awake()
            {
                if ( instance == null ) instance = this;
                else                    Destroy( this.gameObject );
            }

            public void CreateScreenEffect( GameObject screenEffect )
            {
                GameObject tmp = Instantiate( screenEffect ) as GameObject;
                tmp.transform.SetParent( worldSpaceCanvas.transform , false );
            }

            /// <summary>
            /// Creates fading text effect. (Requires screen overlay canvas)
            /// </summary>
            /// <param name="pos"> The world space position of object. </param>
            /// <param name="text"> The text component of effect. </param>
            /// <param name="clr"> The color of text. </param>
            public void CreateFadingText( Vector2 pos , string text , Color clr )
            {
                // Create fading text and set its position from world space to screen space.
                GameObject tmp = Instantiate( fadingText ) as GameObject;
                tmp.transform.SetParent( worldSpaceCanvas.transform , false );
                Vector3 uiPos  = Camera.main.WorldToScreenPoint( pos );
                tmp.transform.position = uiPos;

                // Setup text properties.
                FadingText ft  = tmp.GetComponent< FadingText >();
                TextMeshProUGUI tMesh = tmp.GetComponent< TextMeshProUGUI >();
                ft.SetText( tMesh , text );
                ft.SetColor( tMesh , clr );
            }

            public void CreateFadingTextForEntities( Entities.Entity[] ents , string text , Color clr ) {
                // Creates fading text effect for each entity in array.
                if ( ents.Length > 0 ) {
                    foreach ( Entity item in ents ) {
                        CreateFadingText( item.transform.position , text , clr );
                    }
                }
            }
        }
    }
}
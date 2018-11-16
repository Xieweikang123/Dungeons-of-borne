
using System.Collections.Generic;

using UnityEngine;

using Gameplay.Entities;

namespace Utilities
{
    /// <summary>
    /// Class that offers several extension functions for game objects.
    /// </summary>
    class ObjectExtensions
    {
        /// <summary>
        /// Enables given game objects.
        /// </summary>
        /// <param name="objects"> Objects list to enable. </param>
        public static void EnableObjects( List< GameObject > objects )
        {
            if ( objects.Count > 0 )
            {
                int i;
                for ( i = 0 ; i < objects.Count ; i++ )
                {
                    GameObject obj = objects[ i ];
                    if ( obj != null ) obj.SetActive( true );
                }
            }
        }

        /// <summary>
        /// Disables the given game objects.
        /// </summary>
        /// <param name="objects"> Objects list to disable. </param>
        public static void DisableObjects( List< GameObject > objects )
        {
            if ( objects.Count > 0 )
            {
                int i;
                for ( i = 0 ; i < objects.Count ; i++ )
                {
                    GameObject obj = objects[ i ];
                    if ( obj != null ) obj.SetActive( false );
                }
            }
        }

        /// <summary>
        /// Gets the all entity objects in given radius.
        /// </summary>
        /// <param name="pos"> Position start casting from. </param>
        /// <param name="radius"> Range of circle cast. </param>
        /// <returns></returns>
        public static Entity[] GetAllEntitiesInArea( Vector2 pos , float radius )
        {
            Collider2D[] colls = Physics2D.OverlapCircleAll( pos , radius );

            if ( colls.Length > 0 )
            {
                Entity[] ents = new Entity[ colls.Length ];
                int i;
                for ( i = 0 ; i < colls.Length ; i++ )
                {
                    Entity e = colls[ i ].GetComponent< Entity >();
                    if ( e != null ) ents[ i ] = e;
                }

                return ( ents );
            }
            else
            {
                return ( null );
            }
        }
    }
}
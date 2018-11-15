
using UnityEngine.SceneManagement;

namespace Utilities
{
    /// <summary>
    /// "Scene" is custom class to handle scene management.
    /// </summary>
    [ UnityEngine.DisallowMultipleComponent ]
    class Scene : UnityEngine.MonoBehaviour
    {
        /// <summary>
        /// Loads the new scene with async.
        /// </summary>
        /// <param name="id"> The build index(id) of scene. </param>
        public void LoadScene( int id )
        {
            SceneManager.LoadScene( id );
        }
    }
}
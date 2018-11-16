
using UnityEngine;

namespace Utilities
{
    class Rotator : MonoBehaviour
    {
        [ SerializeField ] private float m_Speed     = 0.0f;

        private void Update()
        {
            transform.Rotate( Vector3.forward * m_Speed * Time.deltaTime );
        }
    }
}
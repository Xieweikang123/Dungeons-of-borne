
using UnityEngine;

using Data;

namespace Gameplay
{
    namespace Managers
    {
        class DataManager : MonoBehaviour
        {
            [ Header( "Private" ) ]
            [ SerializeField ] private PlayerData m_pData = null;

            private void Start()
            {
                m_pData = GameObject.FindGameObjectWithTag( "Player" ).GetComponent< PlayerData >();
            }

            private void OnApplicationQuit()
            {
                m_pData.ResetData();
            }
        }
    }
}
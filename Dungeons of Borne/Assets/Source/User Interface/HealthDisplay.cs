
using UnityEngine;

using TMPro;

using Gameplay.Entities;

namespace UserInterface {

    class HealthDisplay : MonoBehaviour {

        [ SerializeField ]
        private Entity ent = null;

        private TextMeshProUGUI m_healthText = null;

        private void Start() {
            m_healthText = GetComponent< TextMeshProUGUI >();
        }

        private void Update() {
            m_healthText.text = ent.health.ToString();

            if ( ent.health < 0 ) ent.health = 0;
        }

    }

}
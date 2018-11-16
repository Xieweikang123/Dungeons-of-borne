
using UnityEngine;

using Gameplay.Entities;
using Gameplay.Managers;

namespace Neutral {

	[ DisallowMultipleComponent ]
	[ RequireComponent( typeof( BoxCollider2D ) ) ]
	class Projectile : MonoBehaviour {

		[ Header( "Private" ) ]
		[ SerializeField ] private float velocity = 0.0f;
		[ SerializeField ] private float lifeTime = 0.0f;
		[ SerializeField ] private int   damage   = 0;
		[ SerializeField ] private GameObject explosionEffect = null;

		public Direction ProjectileDirection = Direction.None;

		public enum Direction { None , Top , Bottom , Left , Right };

		private void Start() {
			Destroy( this.gameObject , lifeTime );
		}

		private void Update() {
			if ( ProjectileDirection == Direction.Top ) transform.Translate( Vector2.up * velocity * Time.deltaTime );
			if ( ProjectileDirection == Direction.Bottom ) transform.Translate( Vector2.down * velocity * Time.deltaTime );
			if ( ProjectileDirection == Direction.Left ) transform.Translate( Vector2.left * velocity * Time.deltaTime );
			if ( ProjectileDirection == Direction.Right ) transform.Translate( Vector2.right * velocity * Time.deltaTime );
		}

		private void OnDestroy() {
			// Play destroy/explosion sound effect here.
			Instantiate( explosionEffect , transform.position , Quaternion.identity );
		}

		private void OnHitPlayer() {
			// Give some logic here.
			// Decrease the player's health and display damage done text.
			Player ply = GameObject.FindGameObjectWithTag( "Player" ).GetComponent< Player >();
			int damageTaken = ply.TakeDamage( damage );
			EffectManager.instance.CreateFadingText( ply.transform.position , "-" + damageTaken , Color.red );
			AudioManager.instance.PlayAudioSourceOneShot( AudioManager.instance.entityAudioList[ 0 ] );
			Instantiate( explosionEffect , transform.position , Quaternion.identity );
			Destroy( this.gameObject );
		}

		private void OnTriggerEnter2D( Collider2D targetCollider ) {
			if ( targetCollider != null ) {
				if ( targetCollider.CompareTag( "Player" ) ) OnHitPlayer();
			}
		}

	}

}

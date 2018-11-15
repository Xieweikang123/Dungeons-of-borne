
using UnityEngine;

using Neutral;
using Gameplay.Managers;

namespace Gameplay.Mechanical {

	class SentryController : EnemyController {

		[ Header( "Private" ) ]
		[ SerializeField ] private GameObject    projectile    = null;
		[ SerializeField ] private Transform[]   firePositions = new Transform[ 4 ];

		/// <summary>
		/// This attack function will be called via Animation Events feature.
		/// </summary>
		public override void Attack() {
			if ( projectile == null ) {
				Debug.LogError( this.gameObject.name + " can not instantiate bullets , reference is null !" );
				return;
			}

			AudioManager.instance.PlayAudioSourceOneShot( AudioManager.instance.sentryAttackAudio );

			// This piece of code requires optimazition. (25 - 38)
			// Atleast try to move direction set logic into Projectile class.
			GameObject temp   = null;
			Projectile bullet = null;

			int i;
			for ( i = 0 ; i < 4 ; i++ ) {
				temp = Instantiate( projectile , firePositions[ i ].position , Quaternion.identity );
				bullet = temp.GetComponent< Projectile >();
				if ( i == 0 ) bullet.ProjectileDirection = Projectile.Direction.Top;
				else if ( i == 1 ) bullet.ProjectileDirection = Projectile.Direction.Bottom;
				else if ( i == 2 ) bullet.ProjectileDirection = Projectile.Direction.Left;
				else if ( i == 3 ) bullet.ProjectileDirection = Projectile.Direction.Right;
				// else Debug.LogError( "Wtf is going on !" )
				temp = null;
				bullet = null;
			}
		}
	}

} // gameplay.mechanical

using System.Collections.Generic;

using UnityEngine;

using Gameplay.Entities;
using Gameplay.Managers;

namespace Gameplay.Mechanical
{
	/// <summary>
	/// Heal totem heals nearby entities (including player and other entities like bats and eyeballs) every x second.
	/// Heal totems are not an enemy (player can't attack and kill heal totems) but they will be derived from "EnemyController"
	/// class to fetch some useful functions.
	/// </summary>
	class HealTotemController : EnemyController
	{
		[ Header( "Private" ) ]
		[ SerializeField ] private int       healAmount      = 0;
		[ SerializeField ] private float     healRate        = 0;
		[ SerializeField ] private float     healRadius      = 0.0f;
		[ SerializeField ] private LayerMask healTargetLayer = 0;

		private void Start()
		{
			m_Player   = GameObject.FindGameObjectWithTag( "Player" ).GetComponent< Transform >();
			m_Renderer = GetComponent< SpriteRenderer >();

			InvokeRepeating( "Heal" , 0.0f , healRate );
		}

		private void Update()
		{
			Flip();
		}

		private List< Entity > FetchNearEntities()
		{
			Collider2D[] colls = Physics2D.OverlapCircleAll( transform.position , healRadius , healTargetLayer );

			if ( colls.Length > 0 )
			{

				List< Entity > entities = new List< Entity >();
				int i;
				for ( i = 0 ; i < colls.Length ; i++ )
				{
					Entity temp = colls[ i ].GetComponent< Entity >();
					if ( temp != null ) entities.Add( temp );
 				}
				
				if ( entities.Count > 0 ) return ( entities );
				else                      return ( null );
			}
			else
			{
				return ( null );
			}
		}

		private void Heal()
		{
			List< Entity > entities = FetchNearEntities();

			if ( entities != null )
			{
				foreach ( Entity entity in entities )
				{
					entity.Heal( healAmount );
					EffectManager.instance.CreateFadingText( entity.transform.position , "+" + healAmount , Color.green );
				}
			}
		}
	}
}
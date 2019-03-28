using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;

namespace Shapeshifter.Core.Shapeshifts
{
	public class LunaticCultistShapeshift : Shapeshift
	{
		public override string BossName => "Lunatic Cultist";
		public override string ShapeshiftName => "Lunatic Cultist Shapeshift";
		public override string ShapeDesc => "Using a catalyst, you can use the primordial principles of each essences of magic. Each one is a very potent magic that will allow you to bend the world laws.";

		public bool magicFocus;
		public bool primeFire;
		public bool primeEarth;
		public bool primeWater;
		public bool primeWind;
		public float primeTimer;

		public override void Activate()
		{
			magicFocus = false;
			primeFire = false;
			primeEarth = false;
			primeWater = false;
			primeWind = false;
			primeTimer = 0;
		}

		public override void Deactivate()
		{
			magicFocus = false;
			primeFire = false;
			primeEarth = false;
			primeWater = false;
			primeWind = false;
			primeTimer = 0;
		}

		public override void PreUpdateBuffs()
		{
			player.magicDamage += 0.7f;
			player.manaCost /= 3f;
		}

		public override void PostUpdateBuffs()
		{
			player.buffImmune[BuffID.Confused] = true;
			if (player.ownedProjectileCounts[mod.ProjectileType("PrimordialMissile")] > 0)
			{
				if(!magicFocus)
				{
					magicFocus = true;
					Projectile.NewProjectile(player.position.X+128, player.position.Y+10, 0f, 0f, mod.ProjectileType("PrimordialFire"), 0, 0, Main.myPlayer);
					Projectile.NewProjectile(player.position.X+4, player.position.Y+144, 0f, 0f, mod.ProjectileType("PrimordialEarth"), 0, 0, Main.myPlayer);
					Projectile.NewProjectile(player.position.X-130, player.position.Y+10, 0f, 0f, mod.ProjectileType("PrimordialWater"), 0, 0, Main.myPlayer);
					Projectile.NewProjectile(player.position.X-2, player.position.Y-128, 0f, 0f, mod.ProjectileType("PrimordialWind"), 0, 0, Main.myPlayer);
				}
			}
			else{magicFocus = false;}
			if(primeFire || primeEarth || primeWater || primeWind)
		   {
			   primeTimer--;
			   if(primeTimer <= 0)
			   {
				   primeTimer = 0f;
				   primeFire = false;
					primeEarth = false;
					primeWater = false;
					primeWind = false;
					string str = "Your mind blanks! You lose the understanding you had of the primordial magic.";
					Main.NewText( str, 201, 0, 172, false );
			   }
		   }
		}
	}
}

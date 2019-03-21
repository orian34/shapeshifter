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
	public class MoonLordShapeshift : Shapeshift
	{
		public override string BossName => "Moon Lord";
		public override string ShapeshiftName => "Moon Lord Shapeshift";
		public override string ShapeDesc => "You get insanely increased powers, are able to control your gravity incredibly easily, can see almost everything with ease and are protected by the Eye.";

		public override void Activate()
		{
		}

		public override void Deactivate()
		{
		}

		public override void PreUpdateBuffs()
		{
			player.minionDamage += 0.7f;
			player.thrownDamage += 0.7f;
			player.magicDamage -= 0.7f;
			player.meleeDamage += 0.7f;
			player.rangedDamage += 0.7f;
			player.endurance += 0.5f;
			player.releaseJump = true;
		}

		public override void PostUpdateBuffs()
		{
			player.buffImmune[BuffID.Darkness] = true;
			player.buffImmune[BuffID.Confused] = true;
			player.buffImmune[BuffID.Slow] = true;
			player.buffImmune[BuffID.Weak] = true;
			if(player.velocity.X != 0 && player.velocity.Y > 0 && !player.controlDown)
			{
				player.velocity.Y = 0;
			}
		}

		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			Main.PlaySound(3 , player.position, 1);
		}
	}
}

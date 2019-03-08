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
	public class EaterofWorldShapeshift : Shapeshift
	{
		public override string BossName => "Eater of Worlds";
		public override string ShapeshiftName => "Eater of Worlds Shapeshift";
		public override string ShapeDesc => "You get a stat boost in melee and ranged, as well as the power to summon small eaters when fighting, but you become very frail and can die easily from repeated hits.";

		public override void Activate()
		{
		}

		public override void Deactivate()
		{
		}

		public override void PreUpdateBuffs()
		{
			player.buffImmune[20] = true;
			player.buffImmune[24] = true;
			player.npcTypeNoAggro[6] = true;
			player.npcTypeNoAggro[94] = true;
			player.npcTypeNoAggro[7] = true;
			player.npcTypeNoAggro[8] = true;
			player.npcTypeNoAggro[9] = true;
			player.npcTypeNoAggro[98] = true;
			player.npcTypeNoAggro[99] = true;
			player.npcTypeNoAggro[100] = true;
			player.meleeSpeed += 0.1f;
			player.meleeDamage += 0.1f;
			player.rangedDamage += 0.15f;
			player.rangedCrit += 12;
		}

		public override void OnHitAnything(float x, float y, Entity victim)
		{
			if(Main.rand.Next(8) == 0)
			{
				Projectile.NewProjectile(x, y, 0.1f, 0.1f, ProjectileID.EatersBite, 22, 0, Main.myPlayer);
			}
		}

		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			double x = 0.1f*player.statLifeMax2;
			int b = (int)x;
			player.statLife -= b;
			Main.PlaySound(4 , player.position, 1);
			for (int i = 0; i < 7; i++)
			{
				Projectile.NewProjectile(player.position.X+Main.rand.Next(-1,2), player.position.Y+Main.rand.Next(-2,3), Main.rand.Next(-150,151)*0.01f, Main.rand.Next(-150,151)*0.01f, ProjectileID.TinyEater, 11, 0, Main.myPlayer);
			}
		}
	}
}

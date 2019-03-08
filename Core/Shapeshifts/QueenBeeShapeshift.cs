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
	public class QueenBeeShapeshift : Shapeshift
	{
		public override string BossName => "Queen Bee";
		public override string ShapeshiftName => "Queen Bee Shapeshift";
		public override string ShapeDesc => "The more bees you have, the more powerful and enduring you get, especially in ranged and throwing.";

		public bool queenSwarm;
		public bool queenSwarm2;

		public override void Activate()
		{
			queenSwarm = false;
			queenSwarm2 = false;
		}

		public override void Deactivate()
		{
			queenSwarm = false;
			queenSwarm2 = false;
		}

		public override void PreUpdateBuffs()
		{
			player.buffImmune[12] = true;
			player.buffImmune[22] = true;
			player.buffImmune[31] = true;
			player.buffImmune[37] = true;
			player.buffImmune[63] = true;
			player.npcTypeNoAggro[210] = true;
			player.npcTypeNoAggro[211] = true;
			player.npcTypeNoAggro[42] = true;
			player.npcTypeNoAggro[176] = true;
			player.npcTypeNoAggro[231] = true;
			player.npcTypeNoAggro[232] = true;
			player.npcTypeNoAggro[233] = true;
			player.npcTypeNoAggro[234] = true;
			player.npcTypeNoAggro[235] = true;
			player.npcTypeNoAggro[426] = true;
			player.npcTypeNoAggro[427] = true;
		}

		public override void PostUpdateBuffs()
		{
			double x = 0.004f*player.ownedProjectileCounts[181];
			double y = 0.008f*player.ownedProjectileCounts[566];
			double w = 0.012f*player.ownedProjectileCounts[469];
			double v = 0.005f*player.ownedProjectileCounts[373];
			float z = (float)x+(float)y+(float)w+(float)v;
			int h = (int)z*10;
			player.thrownDamage += z*0.36f;
			player.rangedDamage += z*0.78f;
			player.manaCost += z*3f;
			player.lifeRegenTime += h;
			player.lifeRegen += h;
			player.endurance += z*0.36f-0.33f;
			if(z>0.65f)
			{
				player.lifeMagnet = true;
				queenSwarm2 = true;
				queenSwarm = false;
			}
			else if(z > 0.45f)
			{
				queenSwarm = true;
				queenSwarm2 = false;
			}
			else 
			{ 
				queenSwarm = false; 
				queenSwarm2 = false;
			}
		}
		
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if(queenSwarm2)
			{
				if(Main.rand.Next(9) == 0)
				{
					target.AddBuff(BuffID.Venom, 789, true);
				}
				else
				{
					target.AddBuff(BuffID.Poisoned, 987, true);
				}
			}
			else if(queenSwarm)
			{
				if(Main.rand.Next(21) == 0) target.AddBuff(BuffID.Poisoned, 420, true);
			}
		}

		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			Main.PlaySound(3 , player.position, 1);
			if(queenSwarm2)
			{
				int num18 = 1;
				if (Main.rand.Next(3) == 0)
				{
					num18++;
				}
				if (Main.rand.Next(3) == 0)
				{
					num18++;
				}
				if (Main.rand.Next(3) == 0)
				{
					num18++;
				}
				for (int num19 = 0; num19 < num18; num19++)
				{
					float speedX = (float)Main.rand.Next(-35, 36) * 0.02f;
					float speedY = (float)Main.rand.Next(-35, 36) * 0.02f;
					Projectile.NewProjectile(player.position.X, player.position.Y, speedX, speedY, player.beeType(), player.beeDamage(7), player.beeKB(0f), Main.myPlayer, 0f, 0f);
				}
			}
		}
	}
}

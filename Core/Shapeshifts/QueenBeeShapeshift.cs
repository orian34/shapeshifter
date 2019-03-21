using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
		public override string ShapeDesc => "The more bees you have, the more powerful you get in ranged and throwing. You can produce bees by fighting, not moving creates more bees.";

		public bool queenSwarm;

		public override void Activate()
		{
			queenSwarm = false;
		}

		public override void Deactivate()
		{
			queenSwarm = false;
		}

		public override void PreUpdateBuffs()
		{
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
			player.endurance -= 0.33f;
		}

		public override void PostUpdateBuffs()
		{
			player.buffImmune[12] = true;
			player.buffImmune[22] = true;
			player.buffImmune[31] = true;
			player.buffImmune[37] = true;
			player.buffImmune[63] = true;
			double x = 4f*player.ownedProjectileCounts[ProjectileID.Bee] + 8f*player.ownedProjectileCounts[ProjectileID.GiantBee] + 12f*player.ownedProjectileCounts[ProjectileID.BeeArrow] + 5f*player.ownedProjectileCounts[ProjectileID.Hornet];
			float z = (float)Math.Sqrt(x)/150;
			///int h = (int)Math.Round(Math.Sqrt(x)/15, 0, MidpointRounding.AwayFromZero);
			player.thrownDamage += z;
			player.rangedDamage += z;
			player.pickSpeed -= 2f*z;
			player.manaCost += z*10f;
			///player.lifeRegenTime += h;
			///player.lifeRegen += h;
			if(z>0.2f)
			{
				player.lifeMagnet = true;
				player.strongBees = true;
				queenSwarm = true;
			}
			else 
			{ 
				queenSwarm = false;
			}
		}
		
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if((proj.ranged || proj.thrown) && target.CanBeChasedBy())
			{
				if(queenSwarm)
				{
					if(Main.rand.Next(31) == 0)
					{
						target.AddBuff(BuffID.Venom, 789, true);
					}
					else if(Main.rand.Next(19) == 0)
					{
						target.AddBuff(BuffID.Poisoned, 420, true);
					}
				}
				if(proj.type != ProjectileID.Bee && proj.type != ProjectileID.GiantBee && proj.type != ProjectileID.Hornet)
				{
					int num18 = 1;
					int dmg = (int)(7f*player.thrownDamage);
					if(player.velocity.X == 0 && player.velocity.Y == 0)
					{
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
					}
					for (int num19 = 0; num19 < num18; num19++)
					{
						float speedX = (float)Main.rand.Next(-35, 36) * 0.02f;
						float speedY = (float)Main.rand.Next(-35, 36) * 0.02f;
						Projectile.NewProjectile(player.position.X, player.position.Y, speedX, speedY, player.beeType(), player.beeDamage(dmg), player.beeKB(0f), Main.myPlayer, 0f, 0f);
					}
				}
			}
		}

		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			Main.PlaySound(3 , player.position, 35);
			int num18 = 2;
			int dmg = (int)(7f*player.rangedDamage);
			if(queenSwarm)
			{
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
			}
			for (int num19 = 0; num19 < num18; num19++)
			{
				float speedX = (float)Main.rand.Next(-35, 36) * 0.02f;
				float speedY = (float)Main.rand.Next(-35, 36) * 0.02f;
				Projectile.NewProjectile(player.position.X, player.position.Y, speedX, speedY, player.beeType(), player.beeDamage(dmg), player.beeKB(0f), Main.myPlayer, 0f, 0f);
			}
		}
	}
}

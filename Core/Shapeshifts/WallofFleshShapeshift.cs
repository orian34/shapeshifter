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
	public class WallofFleshShapeshift : Shapeshift
	{
		public override string BossName => "Wall of Flesh";
		public override string ShapeshiftName => "Wall of Flesh Shapeshift";
		public override string ShapeDesc => "The more enemies and the closer they are, the more powerful your abilities are, especially melee. But that strength comes at a price : it also weakens your health and nullifies most ways to heal. Melee attacks drains health, close combat weapon drains more health than projectiles.";

		public override void Activate()
		{
		}

		public override void Deactivate()
		{
		}

		public override void PreUpdateBuffs()
		{
			player.potionDelay = 2;
			player.npcTypeNoAggro[115] = true;
			player.npcTypeNoAggro[116] = true;
			player.npcTypeNoAggro[117] = true;
			player.npcTypeNoAggro[118] = true;
			player.npcTypeNoAggro[119] = true;
		}

		public override void PostUpdateBuffs()
		{
			float hungerCount = 0f;
			float hungerDist = 0f;
			float hungerCoef = 0f;
			float y = 0f;
			float x = 0f;
			for(int i = 0; i < 140; i++)
			{
			   NPC target = Main.npc[i];
			   if(!target.friendly && target.active)
			   {
				   float lookToX = target.position.X + (float)target.width * 0.5f - player.Center.X;
				   float lookToY = target.position.Y - player.Center.Y;
				   float distance = (float)System.Math.Sqrt((double)(lookToX * lookToX + lookToY * lookToY));
				   if(distance < 571f && !target.friendly && target.active)
				   {
					   hungerCount += 1f;
					   hungerDist += distance;
				   }
			   }
			}
			if(hungerDist > 0)
			{
				hungerCoef = (hungerDist/hungerCount)/570;
				y = hungerCount*0.01f;
				x = 1f-hungerCoef;
				player.meleeSpeed += x*0.47f+y;
				player.meleeDamage += x*0.51f+y;
				player.thrownDamage -= x*0.47f+y;
				player.rangedDamage -= x*0.47f+y;
				player.magicDamage -= x*0.47f+y;
				player.minionDamage -= x*0.47f+y;
				player.moveSpeed += x*0.76f+y;
				if(player.lifeRegenTime > 0)
				{
					player.lifeRegenTime = 0;
				}
				if(player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				if(player.lifeRegenCount > 0)
				{
					player.lifeRegenCount = 0;
				}
				player.lifeRegen -= (int)(x*55f)+(int)(y*250f);
				if (Main.rand.Next(400) <= (int)(x*5f+y*25f))
				{
					Main.PlaySound(29, player.position, Main.rand.Next(24, 26));
				}
			}
		}
		
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if(proj.melee)
			{
				double x = 0.012f*damage;
				int b = (int)x;
				float c = (float)player.statLifeMax2*0.04f;
				if(b > (int)c)
				{
					b = (int)c;
				}
				player.statLife += b;
				player.HealEffect(b);
				if (player.statLife > player.statLifeMax2)
				{
					player.statLife = player.statLifeMax2;
				}
			}
		}

		public override void OnHitNPC (Item item, NPC target, int damage, float knockback, bool crit)
		{
			if(item.melee)
			{
				double x = 0.3f*damage;
				int b = (int)x;
				float c = (float)player.statLifeMax2*0.08f;
				if(b > (int)c)
				{
					b = (int)c;
				}
				player.statLife += b;
				player.HealEffect(b);
				if (player.statLife > player.statLifeMax2)
				{
					player.statLife = player.statLifeMax2;
				}
			}
		}

		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			Main.PlaySound(3 , player.position, 1);
		}
	}
}

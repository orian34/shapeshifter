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
	public class DukeFishronShapeshift : Shapeshift
	{
		public override string BossName => "Duke Fishron";
		public override string ShapeshiftName => "Duke Fishron Shapeshift";
		public override string ShapeDesc => "You can only breathe correctly if you are in water, but rain can do the job as well. Sharknados come to your aid and you spit bubbles when you use minions or throwing weapons.";

		public float dukeBreath;

		public override void Activate()
		{
			dukeBreath = 1000f;
		}

		public override void Deactivate()
		{
			dukeBreath = 1000f;
		}

		public override void PreUpdateBuffs()
		{
			player.npcTypeNoAggro[65] = true;
			player.npcTypeNoAggro[372] = true;
			player.npcTypeNoAggro[373] = true;
			player.npcTypeNoAggro[542] = true;
			player.npcTypeNoAggro[543] = true;
			player.npcTypeNoAggro[544] = true;
			player.npcTypeNoAggro[545] = true;
			player.npcTypeNoAggro[170] = true;
			player.npcTypeNoAggro[171] = true;
			player.npcTypeNoAggro[180] = true;
			player.maxMinions += 5;
		}

		public override void PostUpdateBuffs()
		{
			if (player.ownedProjectileCounts[ProjectileID.Tempest] < 3)
			{
				int d = (int)(player.minionDamage*75);
				Projectile.NewProjectile(player.position.X, player.position.Y, 0f, 0f, ProjectileID.Tempest, d, 0, Main.myPlayer);
			}
			if (player.ownedProjectileCounts[ProjectileID.Tempest] > 0)
            {
                player.sharknadoMinion = true;
            }
			if(!player.wet && (!player.ZoneOverworldHeight || !Main.raining && player.ZoneOverworldHeight))
			{
				dukeBreath--;
				if(dukeBreath <= 0)
				{
					dukeBreath = 0f;
					player.lifeRegenTime = 0;
					player.magicDamage -= 0.35f;
					player.meleeDamage -= 0.35f;
					player.rangedDamage -= 0.35f;
					if(Main.rand.Next(2) == 0)
					{
						player.statLife--;
					}
					if (player.statLife <= 0)
					{
						player.statLife = 0;
						player.KillMe(PlayerDeathReason.ByCustomReason("Death by asphyxia"), 10.0, 0, false);
					}
					if (Main.rand.Next(120) == 0)
					{
						Main.PlaySound(3, player.position, 14);
					}
				}
				else
				{
					player.thrownDamage += 0.20f;
					player.minionDamage += 0.25f;
				}
			}
			else
			{
				dukeBreath += 3f;
				player.thrownDamage += 0.40f;
				player.minionDamage += 0.55f;
				if(dukeBreath > 1000)
				{
					dukeBreath = 1000f;
				}
				player.breath += 3;
				if (player.breath > player.breathMax)
				{
					player.breath = player.breathMax;
				}
				player.breathCD = 0;
			}
		}
		
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if((proj.minion || proj.thrown || proj.type == 408) && proj.type != mod.ProjectileType("DukeBubble"))
			{
				int j = (int)(player.thrownDamage*71f);
				Projectile.NewProjectile(player.position, (Vector2.Normalize(player.position-target.position))*-15, mod.ProjectileType("DukeBubble"), j, 0, Main.myPlayer);
			}
		}

		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			Main.PlaySound(4 , player.position, 17);
		}
	}
}

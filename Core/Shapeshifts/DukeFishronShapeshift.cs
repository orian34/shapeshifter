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
		public override string ShapeDesc => "You can only breathe correctly if you are in water, but rain can do the job as well. Sharknados come to your aid and you spit bubbles when you use minions or throwing weapons. Weakness to thunder.";

		public float dukeBreath;
		public float choking;
		public bool refill;
		public bool filled;

		public override void Activate()
		{
			dukeBreath = 1000f;
			choking = 0f;
			refill = false;
			filled = false;
		}

		public override void Deactivate()
		{
			dukeBreath = 2000f;
			choking = 0f;
			refill = false;
			filled = false;
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
			player.maxMinions += 4;
			player.gills = true;
		}

		public override void PostUpdateBuffs()
		{
			player.buffImmune[BuffID.Chilled] = true;
			int x = (int)player.position.X/16;
            int y = (int)player.position.Y/16;
			if (player.FindBuffIndex(BuffID.Electrified) != -1)	
			{
				if(Main.rand.Next(2) == 0)
				{
					player.statLife -= 1;
				}
				if (player.statLife <= 0)
				{
					player.statLife = 0;
				}
			}
			if (player.ownedProjectileCounts[ProjectileID.Tempest] < 2)
			{
				int dmg = (int)(player.minionDamage*75);
				int newProj = Projectile.NewProjectile(player.position.X, player.position.Y, 0f, 0f, ProjectileID.Tempest, dmg, 0, Main.myPlayer);
				Main.projectile[newProj].usesIDStaticNPCImmunity = true;
				Main.projectile[newProj].idStaticNPCHitCooldown = 10;
			}
			if (player.ownedProjectileCounts[ProjectileID.Tempest] > 0)
            {
                player.sharknadoMinion = true;
            }
			if(!player.wet && !player.dripping && (!player.ZoneOverworldHeight || player.ZoneOverworldHeight && (!Main.raining || Main.tile[x,y].wall > 0)) && player.armor[0].type != 250)
			{
				dukeBreath--;
				if(dukeBreath < 1)
				{
					dukeBreath = 0f;
					player.lifeRegenTime = 0;
					player.meleeSpeed -= 0.3f;
					player.moveSpeed -= 0.3f;
					player.meleeDamage -= 0.35f;
					player.thrownDamage -= 0.35f;
					player.rangedDamage -= 0.35f;
					player.magicDamage -= 0.35f;
					player.minionDamage -= 0.35f;
					choking += 0.02f;
					player.statLife -= (int)choking;
					if(choking > 1) {choking = 0;}
					if (player.statLife <= 0)
					{
						player.statLife = 0;
						player.KillMe(PlayerDeathReason.ByCustomReason("Death by asphyxia"), 10.0, 0, false);
					}
					if (Main.rand.Next(160) == 0)
					{
						Main.PlaySound(3, player.position, 14);
					}
				}
				else
				{
					player.thrownDamage += 0.1f;
					player.minionDamage += 0.15f;
				}
			}
			else
			{
				dukeBreath += 7f;
				player.thrownDamage += 0.3f;
				player.minionDamage += 0.4f;
				if(dukeBreath > 2000)
				{
					dukeBreath = 2000f;
					if(!refill)
					{
						refill = true;
						filled = true;
					}
				}
				else {refill = false;}
			}
		}
		
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if((proj.minion || proj.thrown || proj.type == 408) && proj.type != mod.ProjectileType("DukeBubble"))
			{
				int dmg = (int)(player.thrownDamage*71f);
				Projectile.NewProjectile(player.position, (Vector2.Normalize(player.position-target.position))*-15, mod.ProjectileType("DukeBubble"), dmg, 0, Main.myPlayer);
			}
		}

		public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit,
			ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			playSound = false;
			return true;
		}

		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			int r = (int)Main.rand.Next(39,41);
			Main.PlaySound(29 , player.position, r);
		}
		
		public override void FrameEffects()
		{
			player.head = mod.GetEquipSlot("DukeFishronShapemask", EquipType.Head);
			player.body = mod.GetEquipSlot("DukeFishronShapeplate", EquipType.Body);
			player.legs = mod.GetEquipSlot("DukeFishronShapelegs", EquipType.Legs);
			if(filled)
			{
				for (int i = 0; i < 20; i++)
				{
					int newDust = Dust.NewDust(player.position, player.width + 4, player.height + 4, 34, 0f, -1f, 0, default(Color));
				}
				Main.PlaySound(29 , player.position, 20);
				filled = false;
			}
		}
	}
}

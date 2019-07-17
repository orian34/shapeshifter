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
	public class MechamalgamShapeshift : Shapeshift
	{
		public override string BossName => "Mechamalgam";
		public override string ShapeshiftName => "Mechamalgam Shapeshift";
		public override string ShapeDesc => "The greater your velocity is, the more energy you gain. Your speed, building, minion and ranged ability gradually increase with your energy charge. Weakness to water.";

		public float energyCount;
		public bool megaCharged;
		public bool charged;

		public override void Activate()
		{
			megaCharged = false;
			charged = false;
			energyCount = 0f;
		}

		public override void Deactivate()
		{
			megaCharged = false;
			charged = false;
			energyCount = 0f;
		}

		public override void PreUpdateBuffs()
		{
			player.nightVision = true;
		}

		public override void PostUpdateBuffs()
		{
			player.buffImmune[20] = true;
			player.buffImmune[31] = true;
			player.buffImmune[32] = true;
			int num16 = (int)(1f + Main.player[Main.myPlayer].velocity.Length() * 6f);
			if (num16 > Main.player[Main.myPlayer].speedSlice.Length)
			{
				num16 = Main.player[Main.myPlayer].speedSlice.Length;
			}
			float num17 = 0f;
			for (int m = num16 - 1; m > 0; m--)
			{
				Main.player[Main.myPlayer].speedSlice[m] = Main.player[Main.myPlayer].speedSlice[m - 1];
			}
			Main.player[Main.myPlayer].speedSlice[0] = Main.player[Main.myPlayer].velocity.Length();
			for (int n = 0; n < Main.player[Main.myPlayer].speedSlice.Length; n++)
			{
				if (n < num16)
				{
					num17 += Main.player[Main.myPlayer].speedSlice[n];
				}
				else
				{
					Main.player[Main.myPlayer].speedSlice[n] = num17 / (float)num16;
				}
			}
			num17 /= (float)num16;
			if(num17 > 0)
			{
				energyCount += num17;
			}
			if (player.FindBuffIndex(BuffID.Electrified) != -1)	{energyCount += 100;}
			int x = (int)player.position.X/16;
            int y = (int)player.position.Y/16;
			if(player.wet || Main.raining && player.ZoneOverworldHeight && Main.tile[x,y].wall == 0)
			{
				energyCount -= 10;
				int r = 7;
				if(player.wet) {r=1;}
				if(Main.rand.Next(r) == 0)
				{
					player.statLife--;
				}
				if (player.statLife <= 0)
				{
					player.statLife = 0;
					Main.PlaySound(4 , player.position, 14);
					player.KillMe(PlayerDeathReason.ByCustomReason("Hydrolic Surcharge! System Shut Down."), 10.0, 0, false);
				}
				if (Main.rand.Next(120) == 0)
				{
					Main.PlaySound(3 , player.position, 53);
				}
			}
			if(energyCount > 0) 
			{
				energyCount -= 3;
			}
			if(energyCount < 0) {energyCount = 0;}
			if(energyCount > 3000)
			{
				charged = true;
				if(energyCount > 35000) {energyCount = 35000;}
				float e = energyCount/1000f;
				int m = (int)Math.Round(e/5f, 0, MidpointRounding.AwayFromZero);
				player.maxRunSpeed += e/9f;
				player.maxMinions += m;
				player.minionDamage += e/150f;
				player.rangedDamage += e/150f;
				player.wallSpeed +=  e/10f;
				player.tileSpeed +=  e/10f;
				Player.tileRangeX += m+1;
				Player.tileRangeY += m+1;
				if(energyCount > 15000) {megaCharged = true;}
				else { megaCharged = false; }
			}
			else
			{
				player.meleeSpeed -= 0.6f;
				player.meleeDamage -= 0.24f;
				player.thrownDamage -= 0.26f;
				player.rangedDamage -= 0.26f;
				player.magicDamage -= 0.27f;
				player.minionDamage -= 0.26f;
				charged = false;
				megaCharged = false;
			}
		}
		
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if(charged && (proj.ranged || proj.minion) && target.CanBeChasedBy())
			{
				if(megaCharged)
				{
					int dmg = (int)(366f*player.minionDamage);
					int dmg2 = (int)(222f*player.rangedDamage);
					if(Main.rand.Next(8) == 0)
					{
						int newProj = Projectile.NewProjectile(player.position, (Vector2.Normalize(player.position-target.position))*-6, mod.ProjectileType("MechInferno"), dmg, 0, Main.myPlayer);
						int newProj2 = Projectile.NewProjectile(player.position, (Vector2.Normalize(player.position-target.position))*-8, mod.ProjectileType("MechLaser"), dmg2, 0, Main.myPlayer);
						int newProj3 = Projectile.NewProjectile(player.position, (Vector2.Normalize(player.position-target.position))*-6, mod.ProjectileType("MechLaser"), dmg2, 0, Main.myPlayer);
						energyCount -= 1399f;
						Main.projectile[newProj].timeLeft = 900;
						Main.projectile[newProj2].timeLeft = 300;
						Main.projectile[newProj3].timeLeft = 350;
					}
				}
				else
				{
					int dmg = (int)(211f*player.minionDamage);
					int dmg2 = (int)(88f*player.rangedDamage);
					if(Main.rand.Next(11) == 0)
					{
						int newProj = Projectile.NewProjectile(player.position, (Vector2.Normalize(player.position-target.position))*-6, mod.ProjectileType("MechInferno"), dmg, 0, Main.myPlayer);
						int newProj2 = Projectile.NewProjectile(player.position, (Vector2.Normalize(player.position-target.position))*-8, mod.ProjectileType("MechLaser"), dmg2, 0, Main.myPlayer);
						energyCount -= 699f;
						Main.projectile[newProj].timeLeft = 900;
						Main.projectile[newProj2].timeLeft = 300;
					}
				}
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
			Main.PlaySound(3 , player.position, 4);
			if(charged)
			{
				Main.PlaySound(3 , player.position, 53);
				energyCount -= 2000f;
				if(energyCount < 0)
				{
					energyCount = 0f;
				}
			}
		}

		public override void FrameEffects()
		{
			player.head = mod.GetEquipSlot("MechamalgamShapemask", EquipType.Head);
			player.body = mod.GetEquipSlot("MechamalgamShapeplate", EquipType.Body);
			player.legs = mod.GetEquipSlot("MechamalgamShapelegs", EquipType.Legs);
			if(charged)
			{
				Lighting.AddLight(player.Center, 1f, 0f, 0f);
				if(Main.rand.Next(11) == 0)
				{
					int newDust = Dust.NewDust(player.position, player.width, player.height, 226, 0f, -1f, 0, default(Color));
					Main.dust[newDust].noGravity = true;
				}
			}
		}
	}
}

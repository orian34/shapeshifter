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
		public override string ShapeDesc => "The greater your velocity is, the more energy you gain. Once you are powered enough, your speed, minion slots and ranged damage gradually increase with your energy charge.";

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
			player.buffImmune[20] = true;
			player.buffImmune[31] = true;
			player.buffImmune[32] = true;
			player.nightVision = true;

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
		}

		public override void PostUpdateBuffs()
		{
			if(energyCount > 3000)
			{
				charged = true;
				player.maxRunSpeed += energyCount/1200f;
				int m = (int)(energyCount/4000f);
				player.maxMinions += m;
				player.rangedDamage += energyCount/1200f;
				player.wallSpeed +=  energyCount/9000f;
				player.tileSpeed +=  energyCount/10000f;
				Player.tileRangeX += m;
				Player.tileRangeY += m+1;
				if(energyCount > 15000)
				{
					megaCharged = true;
				}
				else { megaCharged = false; }
			}
			else
			{
				player.meleeSpeed -= 0.6f;
				player.meleeDamage -= 0.44f;
				player.thrownDamage -= 0.46f;
				player.rangedDamage -= 0.56f;
				player.magicDamage -= 0.57f;
				player.minionDamage -= 0.56f;
				charged = false;
				megaCharged = false;
			}
			if(energyCount > 0)
			{
				energyCount -= 3;
			}
			if(energyCount < 0)
			{
				energyCount = 0;
			}
		}
		
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if(charged && (proj.ranged || proj.minion))
			{
				if(megaCharged)
				{
					if(Main.rand.Next(6) == 0)
					{
						Projectile.NewProjectile(player.position, (Vector2.Normalize(player.position-target.position))*-6, mod.ProjectileType("MechInferno"), 566, 0, Main.myPlayer);
						Projectile.NewProjectile(player.position, (Vector2.Normalize(player.position-target.position))*-8, mod.ProjectileType("MechLaser"), 355, 0, Main.myPlayer);
						Projectile.NewProjectile(player.position, (Vector2.Normalize(player.position-target.position))*-7, mod.ProjectileType("MechLaser"), 355, 0, Main.myPlayer);
						this.energyCount -= 1678f;
					}
				}
				else
				{
					if(Main.rand.Next(8) == 0)
					{
						Projectile.NewProjectile(player.position, (Vector2.Normalize(player.position-target.position))*-8, mod.ProjectileType("MechLaser"), 233, 0, Main.myPlayer);
						Projectile.NewProjectile(player.position, (Vector2.Normalize(player.position-target.position))*-6, mod.ProjectileType("MechInferno"), 355, 0, Main.myPlayer);
						this.energyCount -= 999f;
					}
				}
			}
		}

		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			Main.PlaySound(3 , player.position, 4);
			if(charged)
			{
				Main.PlaySound(3 , player.position, 53);
				this.energyCount -= 1000f;
				if(this.energyCount < 0)
				{
					this.energyCount = 0f;
				}
			}
		}

		public override void FrameEffects()
		{
			if(charged)
			{
				Lighting.AddLight(player.Center, 1f, 0f, 0f);
				if(Main.rand.Next(13) == 0)
				{
					int newDust = Dust.NewDust(player.position, player.width, player.height, 226, 0f, -1f, 0, default(Color));
					Main.dust[newDust].noGravity = true;
				}
			}
		}
	}
}

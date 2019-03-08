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
	public class KingSlimeShapeshift : Shapeshift
	{
		public override string BossName => "King Slime";
		public override string ShapeshiftName => "King Slime Shapeshift";
		public override string ShapeDesc => "Grants you 2 slimes to fight for you. You can do a power jump if you charge it holding DOWN. Bounce on enemies. Weakness to fire.";

		public float slimeJump;
		public bool slimeFire;

		public override void Activate()
		{
			slimeJump = 0f;
			slimeFire = false;
		}

		public override void Deactivate()
		{
			slimeFire = false;
			slimeJump = 0f;
		}

		public override void PreUpdateBuffs()
		{
			player.maxMinions += 2;
			player.extraFall += 15;
			
			if(player.velocity.Y == 0 && !player.mount.Active)
			{
				if(player.controlDown)
				{
					slimeJump += 15f;
					if(slimeJump >= 3000)
					{
						slimeJump = 3000f;
					}
				}
			}
			else
			{
				if(slimeJump > 0 && !player.mount.Active)
				{
					for (int i = 0; i < 50; i++)
					{
						Dust.NewDust(new Vector2(player.position.X, player.position.Y+34), 16, 4, 103, 0f, -1f, 0, default(Color));
					}
				}
				slimeJump = 0f;
			}
			int j = (int)(slimeJump/100f)-2;
			Player.jumpHeight += j;
			if(slimeJump > 0)
			{
				player.drippingSlime = true;
			}
			if(player.lavaWet || player.FindBuffIndex(BuffID.OnFire) != -1)
			{
				slimeFire = true;
			}
		}

		public override void PostUpdateBuffs()
		{
			if (player.ownedProjectileCounts[266] < 2 && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X, player.position.Y, 0f, 0f, 266, 8, 0, player.whoAmI);
			}
			if (player.ownedProjectileCounts[266] > 0)
            {
                player.slime = true;
            }
			if (player.velocity.Y > 0f && !player.mount.Active)
			  {
				Rectangle rect = player.getRect();
				rect.Offset(0, player.height - 1);
				rect.Height =  2;
				rect.Inflate(8, 3);
				for (int i = 0; i < 200; i++)
				{
				  NPC target = Main.npc[i];
				  if (target.active && !target.dontTakeDamage && !target.friendly && target.immune[player.whoAmI] == 0)
				  {
					Rectangle rect2 = target.getRect();
					if (rect.Intersects(rect2) && (target.noTileCollide || Collision.CanHit(player.position, player.width, player.height, target.position, target.width, target.height)))
					{
					  float num = 40f * player.minionDamage;
					  float knockback = 5f;
					  int direction = player.direction;
					  if (player.velocity.X < 0f) direction = -1;
					  if (player.velocity.X > 0f) direction = 1;
					  if (player.whoAmI == Main.myPlayer) 
					  {
						target.StrikeNPC((int)num, knockback, direction, false, false, false);
						 if (Main.netMode != 0) NetMessage.SendData(28, -1, -1, null, i, num, knockback, (float)direction, 0, 0, 0);
						 for (int i2 = 0; i2 < 30; i2++)
						{
							Dust.NewDust(new Vector2(player.position.X, player.position.Y+34), 16, 4, 103, 0f, -1f, 0, default(Color));
						}
					  }
					  target.immune[player.whoAmI] = 10;
					  player.velocity.Y = -10f;
					  player.immune = true;
					  player.immuneTime = 6;
					  break;
					}
				  }
				}
			  }
			if(slimeFire)
			{
				if(Main.rand.Next(2) == 0) player.statLife--;
				if (player.statLife <= 0) player.statLife = 0;
			}
		}

		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			Main.PlaySound(3 , player.position, 1);
		}

		public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			if(slimeFire)
			{
				int newProj = Projectile.NewProjectile(player.position.X, player.position.Y, 0, 0, ProjectileID.Dynamite, 400, 0, player.whoAmI);
				Main.projectile[newProj].timeLeft = 1;
			}
			return true;
		}
	}
}

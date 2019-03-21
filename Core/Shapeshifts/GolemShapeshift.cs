using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Shapeshifter.Core.Shapeshifts
{
	public class GolemShapeshift : Shapeshift
	{
		public override string BossName => "Golem";
		public override string ShapeshiftName => "Golem Shapeshift";
		public override string ShapeDesc => "You can dodge death with a 1 min cooldown, but you are weakened during the regeneration state. You shoot lasers, magic and melee powers are increased.";

		public float dangerTimer;
		public float laserTimer;
		public bool dangerMode;

		public override void Activate()
		{
			dangerTimer = 1200f;
			laserTimer = 600f;
			dangerMode = true;
		}

		public override void Deactivate()
		{
			laserTimer = 600f;
			dangerTimer = 3600f;
			dangerMode = true;
		}

		public override void PreUpdateBuffs()
		{
			player.npcTypeNoAggro[198] = true;
			player.npcTypeNoAggro[199] = true;
			player.npcTypeNoAggro[226] = true;
			player.thrownDamage -= 0.75f;
			player.rangedDamage -= 0.75f;
			player.minionDamage -= 0.75f;

			if (dangerTimer > 0)
			{
				dangerTimer--;
				player.meleeDamage -= 0.75f;
				player.magicDamage -= 0.75f;
			}
			else
			{
				dangerMode = false;
				player.meleeDamage += 0.1f;
				player.magicDamage += 0.1f;
			}
			laserTimer--;
			if (laserTimer > 1 && dangerMode)
			{
				laserTimer -= 2f;
			}
		}

		public override void PostUpdateBuffs()
		{
			if (laserTimer == 0)
			{
				for (int i = 0; i < 200; i++)
				{
					NPC target = Main.npc[i];
					if (!target.friendly && target.active)
					{
						float lookToX = target.position.X + (float)target.width * 0.5f - player.Center.X;
						float lookToY = target.position.Y - player.Center.Y;
						float distance = (float)Math.Sqrt((double)(lookToX * lookToX + lookToY * lookToY));
						if (distance < 999f && !target.friendly && target.active)
						{
							Projectile.NewProjectile(player.position, (Vector2.Normalize(player.position - target.position)) * -8, mod.ProjectileType("GolemLaser"), 444, 0, Main.myPlayer);
							break;
						}
					}
				}
				laserTimer = 600f;
			}
		}

		public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			if (!dangerMode)
			{
				dangerMode = true;
				dangerTimer += 3600f;
				player.statLife = 100;
				Main.PlaySound(3, player.position, 34);
				return false;
			}

			return true;
		}

		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			Main.PlaySound(3 , player.position, 7);
		}

		public override void FrameEffects()
		{
			if (dangerMode)
			{
				Lighting.AddLight((int)(player.position.X + (float)(player.width / 2)) / 16, (int)(player.position.Y + (float)(player.height / 2)) / 16, 1.2f, 0f, 0f);
				if(player.armor[10].headSlot < 0) {player.head = mod.GetEquipSlot("GolemShapemaskDanger", EquipType.Head);}
				if(player.armor[11].bodySlot < 0) {player.body = mod.GetEquipSlot("GolemShapeplateDanger", EquipType.Body);}
			}
			else
			{
				Lighting.AddLight((int)(player.position.X + (float)(player.width / 2)) / 16, (int)(player.position.Y + (float)(player.height / 2)) / 16, 0.8f, 0.95f, 1f);
			}
		}
	}
}

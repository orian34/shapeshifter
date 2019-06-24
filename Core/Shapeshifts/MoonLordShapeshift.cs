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
	public class MoonLordShapeshift : Shapeshift
	{
		public override string BossName => "Moon Lord";
		public override string ShapeshiftName => "Moon Lord Shapeshift";
		public override string ShapeDesc => "You get insanely increased powers, are able to control your gravity incredibly easily, can see almost everything with ease and are protected by the Eye.";

		public override void Activate()
		{
		}

		public override void Deactivate()
		{
		}

		public override void PreUpdateBuffs()
		{
			player.minionDamage += 0.3f;
			player.thrownDamage += 0.3f;
			player.magicDamage -= 0.7f;
			player.meleeDamage += 0.3f;
			player.rangedDamage += 0.3f;
			player.endurance += 0.2f;
		}

		public override void PostUpdateBuffs()
		{
			player.buffImmune[BuffID.Darkness] = true;
			player.buffImmune[BuffID.Confused] = true;
			player.buffImmune[BuffID.Slow] = true;
			player.buffImmune[BuffID.Weak] = true;
			player.buffImmune[BuffID.Gravitation] = true;
			player.buffImmune[BuffID.VortexDebuff] = true;
			if(Main.rand.Next(80) == 0)
			{
				float closer = 666f;
				int closest = 0;
				bool aiming = false;
				for(int i = 0; i < 200; i++)
				{
				   NPC target = Main.npc[i];
				   if(target.CanBeChasedBy())
				   {
					   float lookToX = target.position.X + (float)target.width * 0.5f - player.Center.X;
					   float lookToY = target.position.Y - player.Center.Y;
					   float distance = (float)System.Math.Sqrt((double)(lookToX * lookToX + lookToY * lookToY));
					   if(distance < closer)
						{
							closer = distance;
							closest = i;
							aiming = true;
						}
				   }
				}
				if(aiming)
				{
					NPC target2 = Main.npc[closest];
					int dmg = (int)(player.minionDamage*200f);
					Projectile.NewProjectile(player.position, (Vector2.Normalize(player.position-target2.position))*-12, mod.ProjectileType("MoonEye"), dmg, 0, Main.myPlayer);
				}
			}
			player.gravity = 0;
			player.canCarpet = false;
			player.rocketTime = 0;
			player.wingTime = 0f;
			player.maxRunSpeed = 10f;
			player.maxFallSpeed = 20f;
			if (player.controlUp || player.controlJump)
			{
				if (player.velocity.Y > 0f)
				{
					player.velocity.Y = 0f;
				}
				if (player.velocity.Y < -10f)
				{
					player.velocity.Y -= 0.03f;
				}
				else{player.velocity.Y -= 0.5f;}
			}
			else if (player.controlDown)
			{
				if (player.velocity.Y < 0f)
				{
					player.velocity.Y = 0f;
				}
				if (player.velocity.Y > 10f)
				{
					player.velocity.Y += 0.03f;
				}
				else{player.velocity.Y += 0.5f;}
			}
			else
			{
				player.velocity.Y = 0f;
			}
			if (player.controlLeft && !player.controlRight)
			{
				if (player.velocity.X > 0f)
				{
					player.velocity.X = 0f;
				}
				if (player.velocity.X < -10f)
				{
					player.velocity.X -= 0.03f;
				}
				else{player.velocity.X -= 0.5f;}
			}
			else if (player.controlRight && !player.controlLeft)
			{
				if (player.velocity.X < 0f)
				{
					player.velocity.X = 0f;
				}
				if (player.velocity.X > 10f)
				{
					player.velocity.X += 0.03f;
				}
				else{player.velocity.X += 0.5f;}
			}
			else
			{
				player.velocity.X = 0f;
			}
		}

		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if(proj.type == mod.ProjectileType("MoonEye"))
			{
				int b = (int)(damage*0.04f);
				float c = (float)player.statLifeMax2*0.05f;
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

		public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit,
			ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			playSound = false;
			return true;
		}

		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			Main.PlaySound(3 , player.position, 1);
		}
		
		public override void FrameEffects()
		{
			player.head = mod.GetEquipSlot("MoonLordShapemask", EquipType.Head);
			player.body = mod.GetEquipSlot("MoonLordShapeplate", EquipType.Body);
			player.legs = mod.GetEquipSlot("MoonLordShapelegs", EquipType.Legs);
			player.shoe = 0;
		}
	}
}

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
	public class SkeletronShapeshift : Shapeshift
	{
		public override string BossName => "Skeletron";
		public override string ShapeshiftName => "Skeletron Shapeshift";
		public override string ShapeDesc => "Curses you during the night. The more wounded you are, the more the curse will leak. Increases your throwing and magic power, you also summon skulls and can inflict various debuffs by using your curse. Weakness to day time.";

		public bool skeletronCursed;

		public override void Activate()
		{
			skeletronCursed = false;
		}

		public override void Deactivate()
		{
			skeletronCursed = false;
		}

		public override void PreUpdateBuffs()
		{
			player.npcTypeNoAggro[21] = true;
			player.npcTypeNoAggro[31] = true;
			player.npcTypeNoAggro[32] = true;
			player.npcTypeNoAggro[33] = true;
			player.npcTypeNoAggro[34] = true;
			player.npcTypeNoAggro[83] = true;
			player.npcTypeNoAggro[84] = true;
			player.npcTypeNoAggro[179] = true;
			if(!Main.dayTime)
			{
				skeletronCursed = true;
				player.thrownDamage += 0.13f;
				player.magicDamage += 0.13f;
				player.thrownCrit += 15;
			}
			else 
			{ 
				skeletronCursed = false; 
				player.meleeSpeed -= 0.6f;
				player.meleeDamage -= 0.44f;
				player.thrownDamage -= 0.46f;
				player.rangedDamage -= 0.56f;
				player.magicDamage -= 0.57f;
				player.minionDamage -= 0.56f;
			}
		}

		public override void PostUpdateBuffs()
		{
			player.buffImmune[20] = true;
			player.buffImmune[24] = true;
			player.buffImmune[39] = true;
			player.buffImmune[31] = true;
			player.buffImmune[70] = true;
			player.buffImmune[153] = true;
			if(skeletronCursed)
			{
				player.AddBuff(BuffID.WaterCandle, 2, false);
				int num = (int)(((double)player.statLife/(double)player.statLifeMax2) * 80f+8);
				if(Main.rand.Next(num) == 0)
				{
					int dmg = (int)(60f*player.magicDamage);
					float speedX = (float)Main.rand.Next(-150, 151) * 0.1f;
					float speedY = (float)Main.rand.Next(-150, 151) * 0.1f;
					float num92 = (float)Main.rand.Next(10, 80) * 0.001f;
					if (Main.rand.Next(2) == 0)
					{
						num92 *= -1f;
					}
					float num93 = (float)Main.rand.Next(10, 80) * 0.001f;
					if (Main.rand.Next(2) == 0)
					{
						num93 *= -1f;
					}
					Projectile.NewProjectile(player.position.X+4, player.position.Y+10, speedX, speedY, ProjectileID.ShadowFlame, dmg, 0, Main.myPlayer, num92, num93);
				}
			}
		}

		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if(skeletronCursed && target.CanBeChasedBy())
			{
				if(proj.type == ProjectileID.BoneGloveProj || proj.type == ProjectileID.Bone || proj.type == ProjectileID.Skull || proj.type == ProjectileID.ShadowFlame)
				{ 
					if(Main.rand.Next(13) == 0) target.AddBuff(BuffID.ShadowFlame, 156, true);
					if(Main.rand.Next(13) == 0) target.AddBuff(BuffID.OnFire, 260, true);
					if(Main.rand.Next(13) == 0) target.AddBuff(BuffID.CursedInferno, 156, true);
					if(Main.rand.Next(13) == 0) target.AddBuff(BuffID.Frostburn, 260, true);
					if(Main.rand.Next(13) == 0) target.AddBuff(BuffID.Ichor, 156, true);
				}
				else if((proj.magic || proj.thrown) && Main.rand.Next(5) == 0)
				{
					int num = Main.rand.Next(100, 300);
					int num2 = Main.rand.Next(100, 300);
					if (Main.rand.Next(2) == 0)
					{
						num -= Main.maxScreenW / 2 + num;
					}
					else
					{
						num += Main.maxScreenW / 2 - num;
					}
					if (Main.rand.Next(2) == 0)
					{
						num2 -= Main.maxScreenH / 2 + num2;
					}
					else
					{
						num2 += Main.maxScreenH / 2 - num2;
					}
					num += (int)target.position.X;
					num2 += (int)target.position.Y;
					float num3 = 8f;
					Vector2 vector = new Vector2((float)num, (float)num2);
					float num4 = target.position.X - vector.X;
					float num5 = target.position.Y - vector.Y;
					float num6 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
					num6 = num3 / num6;
					num4 *= num6*3f;
					num5 *= num6*3f;
					int dmg = (int)(50f*player.thrownDamage);
					int newProj = Projectile.NewProjectile((float)num, (float)num2, num4, num5, ProjectileID.Skull, dmg, 0, Main.myPlayer);
					Main.projectile[newProj].tileCollide = false;
					Main.projectile[newProj].timeLeft = 300;
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
			Main.PlaySound(SoundID.NPCHit2 , player.position);
		}
		
		public override void FrameEffects()
		{
			if(skeletronCursed)
			{
				if(player.armor[10].headSlot < 0) {player.head = mod.GetEquipSlot("SkeletronShapemaskCursed", EquipType.Head);}
				Lighting.AddLight(player.position, 0f, 0f, 1f);
				if(Main.rand.Next(13) == 0)
				{
					int newDust = Dust.NewDust(player.position, player.width, player.height, 27, 0f, -1f, 0, default(Color));
					Main.dust[newDust].noGravity = true;
				}
				if(Main.rand.Next(2) == 0)
				{
					int newDust = Dust.NewDust(player.position, player.width + 4, player.height + 4, 27, 0f, -1f, 0, default(Color));
					Main.dust[newDust].noGravity = true;
				}
			}
		}
	}
}

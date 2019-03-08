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
		public override string ShapeDesc => "Curses you during the night. Increases your throwing and magical powers in spite of all else. Increases your throwing and magic power when cursed. You also summon skulls when hurt and can inflict shadowflame if you use bone weapons.";

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
			player.buffImmune[20] = true;
			player.buffImmune[24] = true;
			player.buffImmune[39] = true;
			player.buffImmune[31] = true;
			player.buffImmune[70] = true;
			player.buffImmune[153] = true;
			player.npcTypeNoAggro[21] = true;
			player.npcTypeNoAggro[31] = true;
			player.npcTypeNoAggro[32] = true;
			player.npcTypeNoAggro[33] = true;
			player.npcTypeNoAggro[34] = true;
			if(!Main.dayTime)
			{
				skeletronCursed = true;
				player.thrownDamage += 0.16f;
				player.magicDamage += 0.2f;
				player.thrownCrit += 8;
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

		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if(skeletronCursed)
			{
				if(proj.type == ProjectileID.BoneGloveProj || proj.type == ProjectileID.Bone || proj.type == ProjectileID.Skull)
				{ 
					if(Main.rand.Next(9) == 0) target.AddBuff(153, 120, true);
				}
			}
		}

		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			Main.PlaySound(SoundID.NPCHit2 , player.position);
			if(skeletronCursed)
			{
				Projectile.NewProjectile(player.position.X, player.position.Y, Main.rand.Next(-150,151)*0.01f, Main.rand.Next(-150,151)*0.01f, ProjectileID.Skull, 19, 0, Main.myPlayer);
			}
		}
		
		public override void FrameEffects()
		{
			if(skeletronCursed)
			{
				player.head = mod.GetEquipSlot("SkeletronShapemaskCursed", EquipType.Head);
				Lighting.AddLight(player.position, 0f, 0f, 1f);
				if(Main.rand.Next(13) == 0)
				{
					int newDust = Dust.NewDust(player.position, player.width, player.height, 59, 0f, -1f, 0, default(Color));
					Main.dust[newDust].noGravity = true;
				}
				if(Main.rand.Next(2) == 0)
				{
					int newDust = Dust.NewDust(player.position, player.width + 4, player.height + 4, 59, 0f, -1f, 0, default(Color));
					Main.dust[newDust].noGravity = true;
				}
			}
		}
	}
}

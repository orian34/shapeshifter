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
		public override string ShapeDesc => "Enemies make you hungry, and you'll need to feed off by fighting in close combat. Most ways of healing are rendered moot besides feeding, you can lower the hunger by eating normal food, but it's not enough to fully satiate you.";

		public float hitCount;
		public float Fedness;
		
		public override void Activate()
		{
			hitCount = 3f;
			Fedness = 0f;
		}

		public override void Deactivate()
		{
			hitCount = 0f;
			Fedness = 0f;
		}

		public override void PreUpdateBuffs()
		{
			player.potionDelay = 2;
			player.killClothier = true;
			player.killGuide = true;
			player.npcTypeNoAggro[115] = true;
			player.npcTypeNoAggro[116] = true;
			player.npcTypeNoAggro[117] = true;
			player.npcTypeNoAggro[118] = true;
			player.npcTypeNoAggro[119] = true;
		}

		public override void PostUpdateBuffs()
		{
			double l = player.statLifeMax2*1.45f;
			player.statLifeMax2 += (int)l;
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
			float hungerCount = 0f;
			float hungerDist = 0f;
			float hungerCoef = 0f;
			float y = 0f;
			float x = 0f;
			for(int i = 0; i < 200; i++)
			{
			   NPC target = Main.npc[i];
			   if(target.CanBeChasedBy())
			   {
				   float lookToX = target.position.X + (float)target.width * 0.5f - player.Center.X;
				   float lookToY = target.position.Y - player.Center.Y;
				   float distance = (float)System.Math.Sqrt((double)(lookToX * lookToX + lookToY * lookToY));
				   if(distance < 471f)
				   {
					   hungerCount += 1f;
					   hungerDist += distance;
				   }
			   }
			}
			if(hungerCount > 0)
			{
				hungerCoef = (hungerDist/hungerCount)/470;
				y = hungerCount*0.01f;
				x = 1f-hungerCoef;
				player.meleeSpeed += x*0.17f+y;
				player.meleeDamage += x*0.21f+y;
				player.moveSpeed += x*0.46f+y;
				if (Main.rand.Next(400) <= (int)(x*5f+y*25f))
				{
					Main.PlaySound(29, player.position, Main.rand.Next(24, 26));
				}
			}
			if(hitCount > 8) {hitCount = 8;}
			float h = 0.002f;
			int index = player.FindBuffIndex(BuffID.WellFed);
			if (index != -1 && player.buffTime[index] > 9){h=0f;}
			hitCount -= h+x*0.05f+y*0.3f;
			if(hitCount < -5) {hitCount = -5;}
			if(hitCount > 0)
			{
				if(index < 0) {player.AddBuff(BuffID.WellFed, 2, false);}
				Fedness += hitCount*0.02f;
				player.statLife += (int)Fedness;
				if(Fedness > 1) {Fedness = 0;}
			}
			else {player.lifeRegen += (int)hitCount;}
			if(hitCount < 0) {hitCount += 0.001f;}
		}
		
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if(proj.melee)
			{
				hitCount += 0.7f;
			}
		}

		public override void OnHitNPC (Item item, NPC target, int damage, float knockback, bool crit)
		{
			if(item.melee)
			{
				hitCount += 2.4f;
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
			Main.PlaySound(3 , player.position, 9);
		}
		
		public override void FrameEffects()
		{
			player.head = mod.GetEquipSlot("WallofFleshShapemask", EquipType.Head);
			player.body = mod.GetEquipSlot("WallofFleshShapeplate", EquipType.Body);
			player.legs = mod.GetEquipSlot("WallofFleshShapelegs", EquipType.Legs);
		}
	}
}

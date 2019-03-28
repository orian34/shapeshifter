using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter
{
	public class ShapeGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}
		public bool overgenerous;	
		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			if (overgenerous)
			{
				if(npc.lifeMax < 850)
				{
					npc.life -= npc.life-1;
					npc.StrikeNPCNoInteraction(1, 0f, -npc.direction, true);
				}
				else
				{
					if (npc.lifeRegen > 0)
					{
						npc.lifeRegen = 0;
					}
					int loss = (int)((npc.lifeMax/850)*0.77f);
					npc.life -= loss;	
					if(npc.life < 0)
					{
						npc.life = 1;
						npc.StrikeNPCNoInteraction(1, 0f, -npc.direction, true);
					}
					if(npc.life > 0)
					{
						for(int i = 0; i < 200; i++)
						{
						   NPC target = Main.npc[i];
						   if(target.active && target != npc)
						   {
							   float lookToX = target.position.X + (float)target.width * 0.5f - npc.position.X;
							   float lookToY = target.position.Y - npc.position.Y;
							   float distance = (float)System.Math.Sqrt((double)(lookToX * lookToX + lookToY * lookToY));
							   if(distance < 222f)
							   {
								   target.life += loss*5;
								   if (target.life > target.lifeMax)
									{
										target.life = target.lifeMax;
									}
							   }
						   }
						}
					}
				}
			}
		}
		public override void DrawEffects(NPC npc, ref Color drawColor)
		{
			if (overgenerous)
			{
				if (Main.rand.Next(5) < 4)
				{
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 135, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					if (Main.rand.Next(4) == 0)
					{
						Main.dust[dust].noGravity = false;
						Main.dust[dust].scale *= 0.5f;
					}
				}
				Lighting.AddLight(npc.position, 1f, 1f, 2f);
			}
		}
		
		public override void ResetEffects(NPC npc)
		{
			overgenerous = false;
		}
	}
}
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Projectiles
{
    public class PrimordialGravity : ModProjectile
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("PrimordialGravity");
		}
		
		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.ignoreWater = true;    
			projectile.tileCollide = true;  
			projectile.penetrate = -1;
			projectile.timeLeft = 361;
			projectile.width = 30;
			projectile.height = 30;
			projectile.alpha = 0;
		}
		public override void AI()
		{
			for(int i = 0; i < 200; i++)
			{
			   NPC target = Main.npc[i];
			   if(!target.friendly && target.active && !target.boss)
			   {
				   float goToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
				   float goToY = target.position.Y - projectile.Center.Y;
				   float distance = (float)System.Math.Sqrt((double)(goToX * goToX + goToY * goToY));
				   if(distance < 444f)
				   {
					   distance = 3f / distance;
					   goToX *= distance * -1;
						goToY *= distance * -1;
					   target.velocity.X = goToX;
						target.velocity.Y = goToY;
				   }
			   }
			}
			for(int i = 0; i < 1000; i++)
			{
			   Projectile target = Main.projectile[i];
			   if(target.type != projectile.type)
			   {
				   float goToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
				   float goToY = target.position.Y - projectile.Center.Y;
				   float distance = (float)System.Math.Sqrt((double)(goToX * goToX + goToY * goToY));
				   if(distance < 444f)
				   {
					   distance = 3f / distance;
					   goToX *= distance * -1;
						goToY *= distance * -1;
					   target.velocity.X = goToX;
						target.velocity.Y = goToY;
				   }
			   }
			}
			for(int i = 0; i < 6000; i++)
			{
			   Dust target = Main.dust[i];
			   float goToX = target.position.X - projectile.Center.X;
			   float goToY = target.position.Y - projectile.Center.Y;
			   float distance = (float)System.Math.Sqrt((double)(goToX * goToX + goToY * goToY));
			   if(distance < 444f)
			   {
				   distance = 3f / distance;
				   goToX *= distance * -1;
					goToY *= distance * -1;
				   target.velocity.X = goToX;
					target.velocity.Y = goToY;
			   }
			}
			for(int i = 0; i < 400; i++)
			{
			   Item target = Main.item[i];
			   float goToX = target.position.X - projectile.Center.X;
			   float goToY = target.position.Y - projectile.Center.Y;
			   float distance = (float)System.Math.Sqrt((double)(goToX * goToX + goToY * goToY));
			   if(distance < 444f)
			   {
				   distance = 3f / distance;
				   goToX *= distance * -1;
					goToY *= distance * -1;
				   target.velocity.X = goToX;
					target.velocity.Y = goToY;
			   }
			}
			for(int i = 0; i < 500; i++)
			{
			   Gore target = Main.gore[i];
			   float goToX = target.position.X - projectile.Center.X;
			   float goToY = target.position.Y - projectile.Center.Y;
			   float distance = (float)System.Math.Sqrt((double)(goToX * goToX + goToY * goToY));
			   if(distance < 444f)
			   {
				   distance = 3f / distance;
				   goToX *= distance * -1;
					goToY *= distance * -1;
				   target.velocity.X = goToX;
					target.velocity.Y = goToY;
			   }
			}
		   Lighting.AddLight(projectile.Center, 2f, 1f, 1f);
		   float alph = 1f-(projectile.timeLeft/361f);
			projectile.alpha = (int)(250*alph);
		}

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
			// TODO: dust
			return true;
        }
    }
}
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Projectiles
{
    public class PrimordialShield : ModProjectile
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Primordial Shield");
		}
		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.ignoreWater = true;    
			projectile.tileCollide = false;  
			projectile.penetrate = -1;
			projectile.timeLeft = 241;
			projectile.alpha = 0;
			projectile.width = 67;
			projectile.height = 67;
		}
		public override void AI()
		{
			Player player = Main.player[projectile.owner];
		   projectile.velocity = player.velocity;
		   projectile.position.X = player.position.X-23;
		   projectile.position.Y = player.position.Y-15;
		   for(int i = 0; i < 1001; i++)
			{
			   Projectile target = Main.projectile[i];
			   if(target.type != projectile.type && target.type != mod.ProjectileType("PrimordialMissile"))
			   {
				   if(projectile.getRect().Intersects(target.getRect()))
				   {
					   target.Kill();
				   }
			   }
			}
			float alph = 1f-(projectile.timeLeft/241f);
			projectile.alpha = (int)(250*alph);
		}
	}
}
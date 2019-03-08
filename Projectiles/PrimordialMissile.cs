using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Projectiles
{
    public class PrimordialMissile : ModProjectile
    {
		public override string Texture
		{
			get
			{
				return "Terraria/Projectile_51";
			}
		}
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Primordial Missile");
		}
		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.ignoreWater = true;    
			projectile.tileCollide = false;  
			projectile.penetrate = -1;
			projectile.timeLeft = 2;
			projectile.alpha = 332;
			projectile.width = 1;
			projectile.height = 1;
		}
		public override void AI()
		{
			projectile.rotation++;
			Player player = Main.player[projectile.owner];
			LunaticCultistShapeshift sp = (LunaticCultistShapeshift)player.GetModPlayer<ShapeshifterPlayer>().Shapeshift;
		   float shootToX = Main.MouseWorld.X - projectile.Center.X;
		   float shootToY = Main.MouseWorld.Y - projectile.Center.Y;
		   float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
		   distance = 3f / distance;
		   shootToX *= distance * 8;
		   shootToY *= distance * 8;
		   projectile.velocity.X = shootToX;
		   projectile.velocity.Y = shootToY;
		   if(Main.mouseLeft)
		   {
			   projectile.timeLeft = 2;
		   }
		   if(sp.primeFire || sp.primeEarth || sp.primeWater || sp.primeWind)
		   {
			   projectile.timeLeft = 0;
		   }
		   if(Main.rand.Next(3) == 0)
			{
				int num127 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, 173, 0f, 0f, 0, default(Color), 1f);
				Main.dust[num127].noGravity = true;
			}
		}
	}
}
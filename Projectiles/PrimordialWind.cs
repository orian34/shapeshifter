using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Projectiles
{
    public class PrimordialWind : ModProjectile
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Primordial Wind");
		}
		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.ignoreWater = true;    
			projectile.tileCollide = false;  
			projectile.penetrate = -1;
			projectile.timeLeft = 601;
			projectile.alpha = 53;
			projectile.width = 28;
			projectile.height = 26;
		}
		public override void AI()
		{
			if(Main.rand.Next(9) == 0)
			{
				int newDust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 63, 0f, -1f, 0, default(Color));
				Main.dust[newDust].noGravity = true;
			}
			Player player = Main.player[projectile.owner];
			LunaticCultistShapeshift sp = (LunaticCultistShapeshift)player.GetModPlayer<ShapeshifterPlayer>().Shapeshift;
			if (sp.magicFocus)
			{
				projectile.timeLeft = 2;
			}
		   projectile.velocity = player.velocity;
		   projectile.position.X = player.position.X-2;
		   projectile.position.Y = player.position.Y-128;
		   Lighting.AddLight(projectile.Center, 0.66f, 0.66f, 0.66f);
		   for(int i = 0; i < 1001; i++)
			{
			   Projectile target = Main.projectile[i];
			   if(target.type == mod.ProjectileType("PrimordialMissile") && target.owner == projectile.owner)
			   {
				   if(projectile.getRect().Intersects(target.getRect()))
				   {
					   if(!sp.primeWind)
					   {
						   string str = "You get infused with the knowledge of primordial movement. You can now create shock waves that travel at high speed!";
							Main.NewText( str, 150, 150, 150, false );
					   }
					   sp.primeWind = true;
					   sp.primeTimer = 600f;
					   Main.PlaySound(2 , player.position, 123);
				   }
			   }
			}
		}
	}
}
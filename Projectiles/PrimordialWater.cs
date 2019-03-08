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
    public class PrimordialWater : ModProjectile
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Primordial Water");
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
			projectile.width = 26;
			projectile.height = 24;
		}
		public override void AI()
		{
			if(Main.rand.Next(9) == 0)
			{
				int newDust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 59, 0f, -1f, 0, default(Color));
				Main.dust[newDust].noGravity = true;
			}
			Player player = Main.player[projectile.owner];
			LunaticCultistShapeshift sp = (LunaticCultistShapeshift)player.GetModPlayer<ShapeshifterPlayer>().Shapeshift;
			if (sp.magicFocus)
			{
				projectile.timeLeft = 2;
			}
		   projectile.velocity = player.velocity;
		   projectile.position.X = player.position.X-130;
		   projectile.position.Y = player.position.Y+10;
		   Lighting.AddLight(projectile.Center, 0f, 0f, 2f);
		   for(int i = 0; i < 1001; i++)
			{
			   Projectile target = Main.projectile[i];
			   if(target.type == mod.ProjectileType("PrimordialMissile") && target.owner == projectile.owner)
			   {
				   if(projectile.getRect().Intersects(target.getRect()))
				   {
					   if(!sp.primeWater)
					   {
						   string str = "You get infused with the knowledge of primordial structure. You can now reassemble the air around you to create a shield!";
							Main.NewText( str, 0, 50, 250, false );
					   }
					   sp.primeWater = true;
					   sp.primeTimer = 600f;
					   Main.PlaySound(2 , player.position, 123);
				   }
			   }
			}
		}
	}
}
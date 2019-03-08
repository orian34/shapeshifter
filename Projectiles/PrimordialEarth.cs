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
    public class PrimordialEarth : ModProjectile
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Primordial Earth");
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
			projectile.width = 18;
			projectile.height = 26;
		}
		public override void AI()
		{
			if(Main.rand.Next(9) == 0)
			{
				int newDust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 60, 0f, -1f, 0, default(Color));
				Main.dust[newDust].noGravity = true;
			}
			Player player = Main.player[projectile.owner];
			LunaticCultistShapeshift sp = (LunaticCultistShapeshift)player.GetModPlayer<ShapeshifterPlayer>().Shapeshift;
			if (sp.magicFocus)
			{
				projectile.timeLeft = 2;
			}
		   projectile.velocity = player.velocity;
		   projectile.position.X = player.position.X+4;
		   projectile.position.Y = player.position.Y+144;
		   Lighting.AddLight(projectile.Center, 2f, 0f, 0f);
		   for(int i = 0; i < 1001; i++)
			{
			   Projectile target = Main.projectile[i];
			   if(target.type == mod.ProjectileType("PrimordialMissile") && target.owner == projectile.owner)
			   {
				   if(projectile.getRect().Intersects(target.getRect()))
				   {
					   if(!sp.primeEarth)
					   {
						   string str = "You get infused with the knowledge of primordial intensity. You can now concentrate a gravitational orb that crushes enemies to dust!";
							Main.NewText( str, 250, 0, 0, false );
					   }
						sp.primeEarth = true;
						sp.primeTimer = 600f;
						Main.PlaySound(2 , player.position, 123);
				   }
			   }
			}
		}
	}
}
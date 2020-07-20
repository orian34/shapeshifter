using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Projectiles
{
    public class PrimordialShield : ModProjectile
    {
		public override string Texture => "Terraria/Projectile_" + ProjectileID.ShadowBeamFriendly;	// I.e. an invisible sprite

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
			drawHeldProjInFrontOfHeldItemAndArms = true;
		}
		public override void AI()
		{
		   Player player = Main.player[projectile.owner];
		   projectile.velocity = player.velocity;
		   projectile.position.X = player.position.X-23;
		   projectile.position.Y = player.position.Y-15;
		   player.heldProj = projectile.whoAmI;
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

			if (projectile.ai[0] < 1f) projectile.ai[0] += 0.1f;
			if (projectile.ai[0] >= 1f) projectile.ai[1]++;
			if (projectile.ai[1] >= 227) projectile.ai[0] -= 0.2f;
		}

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
			spriteBatch.End();
#pragma warning disable CS0618 // Type or member is obsolete
			spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointWrap, DepthStencilState.Default, RasterizerState.CullNone, null, Main.Transform);
#pragma warning restore CS0618 // Type or member is obsolete

			Vector2 plrScrPos = Main.player[projectile.owner].Center - Main.screenPosition;
			DrawData drwdt = new DrawData(ModContent.GetTexture("Terraria/Misc/Perlin"), plrScrPos, new Rectangle(0, 0, 600, 600), new Color(150, 237, 255) * projectile.ai[0], 0f, new Vector2(300f, 300f), 4f * 0.05f, SpriteEffects.FlipHorizontally, 0);
			GameShaders.Misc["ShapeshifterForceField"].UseColor(new Vector3(0.95f + 0.95f * 0.5f));
			GameShaders.Misc["ShapeshifterForceField"].Apply(drwdt);
			drwdt.Draw(spriteBatch);
			return false;
        }
    }
}
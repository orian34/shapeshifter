using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class MoonLordShapeplate : ModItem
	{
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moon Lord Shapeplate");
			Tooltip.SetDefault("Increases your max number of minions by 4. The Eye is protecting you. \n[c/99FFCC:2/3 Moon Lord Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 18;
			item.value = 800000*5;
			item.rare = 10;
			item.defense = 30;
		}
		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 4;
			if(Main.rand.Next(80) == 0)
			{
				float closer = 666f;
				int closest = 0;
				bool aiming = false;
				for(int i = 0; i < 200; i++)
				{
				   NPC target = Main.npc[i];
				   if(target.CanBeChasedBy())
				   {
					   float lookToX = target.position.X + (float)target.width * 0.5f - player.Center.X;
					   float lookToY = target.position.Y - player.Center.Y;
					   float distance = (float)System.Math.Sqrt((double)(lookToX * lookToX + lookToY * lookToY));
					   if(distance < closer)
						{
							closer = distance;
							closest = i;
							aiming = true;
						}
				   }
				}
				if(aiming)
				{
					NPC target2 = Main.npc[closest];
					int dmg = (int)(player.minionDamage*200f);
					Projectile.NewProjectile(player.position, (Vector2.Normalize(player.position-target2.position))*-12, mod.ProjectileType("MoonEye"), dmg, 0, Main.myPlayer);
				}
			}
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SuspiciousLookingTentacle);
			recipe.AddIngredient(ItemID.FragmentStardust,20);
			recipe.AddIngredient(ItemID.LunarBar,16);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool DrawBody()
		{
			return false;
		}
	}
}

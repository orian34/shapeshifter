using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class WallofFleshShapeplate : ModItem
	{
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wall of Flesh Shapeplate");
			Tooltip.SetDefault("Increases your constitution potential");
		}
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 18;
			item.value = 42800*5;
			item.rare = 4;
			item.defense = 8;
		}
		public override void UpdateEquip(Player player)
		{
			double x = player.statLifeMax2*1.45f;
			int b = (int)x;
			player.statLifeMax2 += b;
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
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(490);
			recipe.AddIngredient(null, "EyeofCthulhuShapeplate");
			recipe.AddRecipeGroup("anyTier1Bar", 20);
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

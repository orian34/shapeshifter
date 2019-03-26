using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class GolemShapeplate : ModItem
	{
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golem Shapeplate");
			Tooltip.SetDefault("Greatly increases life regen when not moving \n[c/F6D013:2/3 Golem Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 18;
			item.value = 48000*5;
			item.rare = 8;
			item.defense = 32;
		}
		public override void UpdateEquip(Player player)
		{
			player.shinyStone = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ShinyStone);
			recipe.AddIngredient(ItemID.LunarTabletFragment,12);
			recipe.AddIngredient(ItemID.LihzahrdPowerCell,2);
			recipe.AddTile(TileID.LihzahrdFurnace);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	public class GolemShapeplateDanger : EquipTexture
	{
		public override bool DrawBody()
		{
			return false;
		}
	}
}

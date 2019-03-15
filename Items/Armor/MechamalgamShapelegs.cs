using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class MechamalgamShapelegs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mechamalgam Shapelegs");
			Tooltip.SetDefault("Improved movement speed potential if powered");
		}
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 18;
			item.value = 30000*5;
			item.rare = 5;
			item.defense = 13;
		}
		public override void UpdateEquip(Player player)
		{
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HermesBoots);
			recipe.AddIngredient(ItemID.DestroyerMask);
			recipe.AddIngredient(ItemID.MechanicalWagonPiece);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

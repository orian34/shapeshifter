using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class DukeFishronShapelegs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Duke Fishron Shapelegs");
			Tooltip.SetDefault("6% increased throwing damage and critical strike chance \n[c/00FFFF:3/3 Duke Fishron Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 18;
			item.value = 36000*5;
			item.rare = 9;
			item.defense = 10;
		}
		public override void UpdateEquip(Player player)
		{
			player.thrownDamage += 0.06f;
			player.thrownCrit += 6;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SharkFin,4);
			recipe.AddIngredient(ItemID.Bacon);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

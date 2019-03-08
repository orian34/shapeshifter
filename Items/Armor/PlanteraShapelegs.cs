using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class PlanteraShapelegs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plantera Shapelegs");
			Tooltip.SetDefault("4% increased melee damage and critical strike chance");
		}
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 18;
			item.value = 36000*5;
			item.rare = 7;
			item.defense = 10;
		}
		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.04f;
			player.meleeCrit += 4;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar,18);
			recipe.AddIngredient(ItemID.JungleSpores,7);
			recipe.AddIngredient(ItemID.Vine,4);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

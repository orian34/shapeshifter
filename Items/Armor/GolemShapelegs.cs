using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class GolemShapelegs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golem Shapelegs");
			Tooltip.SetDefault("6% increased melee damage and critical strike chance");
		}
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 18;
			item.value = 36000*5;
			item.rare = 8;
			item.defense = 10;
		}
		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.06f;
			player.meleeCrit += 6;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarTabletFragment,6);
			recipe.AddIngredient(ItemID.LihzahrdPowerCell);
			recipe.AddTile(TileID.LihzahrdFurnace);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

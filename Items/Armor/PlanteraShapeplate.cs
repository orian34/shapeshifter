using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class PlanteraShapeplate : ModItem
	{
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plantera Shapeplate");
			Tooltip.SetDefault("Summons spores over time that will damage enemies");
		}
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 18;
			item.value = 48000*5;
			item.rare = 7;
			item.defense = 13;
		}
		public override void UpdateEquip(Player player)
		{
			player.SporeSac();
			player.sporeSac = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SporeSac);
			recipe.AddIngredient(ItemID.ChlorophyteBar,24);
			recipe.AddIngredient(ItemID.JungleSpores,9);
			recipe.AddIngredient(ItemID.Vine,5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

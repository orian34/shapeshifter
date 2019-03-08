using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class MechamalgamShapeplate : ModItem
	{
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mechamalgam Shapeplate");
			Tooltip.SetDefault("Increases your minions and building potential if powered");
		}
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 18;
			item.value = 50000*5;
			item.rare = 5;
			item.defense = 17;
		}
		public override void UpdateEquip(Player player)
		{
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SkeletronShapeplate");
			recipe.AddIngredient(ItemID.SkeletronPrimeMask);
			recipe.AddIngredient(3356);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

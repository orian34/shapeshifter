using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Items.Emblem
{
	public class PlanteraEmblem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plantera Emblem");
			Tooltip.SetDefault("'This emblem shows your evergrowing plant mastery.' \nSummons spores over time that will damage enemies \n6% increased melee and ranged damage. \n[c/FF33FF:Plantera Shape]");
		}
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = 134000*5;
			item.rare = 7;
			item.defense = 2;
			item.accessory = true;
		}
		public override void UpdateEquip(Player player)
		{
			player.SporeSac();
			player.sporeSac = true;
			player.meleeDamage += 0.06f;
			player.rangedDamage += 0.06f;
            player.GetModPlayer<ShapeshifterPlayer>().ActivateShapeshift(typeof(PlanteraShapeshift));
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "PlanteraShapemask");
			recipe.AddIngredient(null, "PlanteraShapeplate");
			recipe.AddIngredient(null, "PlanteraShapelegs");
			recipe.AddIngredient(ItemID.PlanteraTrophy);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

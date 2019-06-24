using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Items.Emblem
{
	public class SkeletronEmblem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skeletron Emblem");
			Tooltip.SetDefault("'This emblem shows your cursed guardian mastery.' \n33% chance to not consume throwing item \n6% increased throwing and magic damage. \n[c/C0AE90:Skeletron Shape]");
		}
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = 105500*5;
			item.rare = 3;
			item.defense = 2;
			item.accessory = true;
		}
		public override void UpdateEquip(Player player)
		{
			player.thrownCost33 = true;
			player.thrownDamage += 0.06f;
			player.magicDamage += 0.06f;
            player.GetModPlayer<ShapeshifterPlayer>().ActivateShapeshift(typeof(SkeletronShapeshift));
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SkeletronShapemask");
			recipe.AddIngredient(null, "SkeletronShapeplate");
			recipe.AddIngredient(null, "SkeletronShapelegs");
			recipe.AddIngredient(ItemID.SkeletronTrophy);
			recipe.AddTile(TileID.BoneWelder);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

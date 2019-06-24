using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Items.Emblem
{
	public class EyeofCthulhuEmblem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eye of Cthulhu Emblem");
			Tooltip.SetDefault("'This emblem shows your raging eye mastery.' \nHunger draws you to your enemies \n6% increased melee and movement speed \n[c/FF3333:Eye of Cthulhu Shape]");
		}
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = 105500*5;
			item.rare = 1;
			item.defense = 2;
			item.accessory = true;
		}
		public override void UpdateEquip(Player player)
		{
			player.dash = 2;
			player.moveSpeed += 0.06f;
			player.meleeSpeed += 0.06f;
            player.GetModPlayer<ShapeshifterPlayer>().ActivateShapeshift(typeof(EyeofCthulhuShapeshift));
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "EyeofCthulhuShapemask");
			recipe.AddIngredient(null, "EyeofCthulhuShapeplate");
			recipe.AddIngredient(null, "EyeofCthulhuShapelegs");
			recipe.AddIngredient(ItemID.EyeofCthulhuTrophy);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

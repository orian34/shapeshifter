using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Items.Emblem
{
	public class WallofFleshEmblem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wall of Flesh Emblem");
			Tooltip.SetDefault("'This emblem shows your mutant fish mastery.' \nGrants you improved mobility in water \n6% increased melee damage and speed \n[c/00FFFF:Duke Fishron Shape]");
		}
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = 122800*5;
			item.rare = 4;
			item.defense = 2;
			item.accessory = true;
		}
		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.06f;
			player.meleeSpeed += 0.06f;
            player.GetModPlayer<ShapeshifterPlayer>().ActivateShapeshift(typeof(WallofFleshShapeshift));
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "WallofFleshShapemask");
			recipe.AddIngredient(null, "WallofFleshShapeplate");
			recipe.AddIngredient(null, "WallofFleshShapelegs");
			recipe.AddIngredient(ItemID.WallofFleshTrophy);
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

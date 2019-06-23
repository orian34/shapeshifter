using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Items.Emblem
{
	public class KingSlimeEmblem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("King Slime Emblem");
			Tooltip.SetDefault("'This emblem has a slimy feeling.' \nIncreased number of Minions \n8% increased magic and minion damage \n[c/0066CC:King Slime Shape]");
		}
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = 25600*5;
			item.rare = 1;
			item.defense = 2;
			item.accessory = true;
		}
		public override void UpdateEquip(Player player)
		{
			player.maxMinions++;
			player.magicDamage += 0.08f;
			player.minionDamage += 0.08f;
            player.GetModPlayer<ShapeshifterPlayer>().ActivateShapeshift(typeof(KingSlimeShapeshift));
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "KingSlimeShapemask");
			recipe.AddIngredient(null, "KingSlimeShapeplate");
			recipe.AddIngredient(null, "KingSlimeShapelegs");
			recipe.AddIngredient(ItemID.KingSlimeTrophy);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

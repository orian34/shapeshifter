using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class WallofFleshShapemask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wall of Flesh Shapemask");
			Tooltip.SetDefault("'This mask is full of hunger.' \n4% increased melee damage");
		}
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 17;
			item.value = 30000*5;
			item.rare = 4;
			item.defense = 10;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("WallofFleshShapeplate") && legs.type == mod.ItemType("WallofFleshShapelegs");
		}
		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.04f;
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Your body is shaping as of a hungry abomination";
            player.GetModPlayer<ShapeshifterPlayer>().ActivateShapeshift(typeof(WallofFleshShapeshift));
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FleshMask);
			recipe.AddIngredient(null, "EyeofCthulhuShapemask");
			recipe.AddRecipeGroup("anyTier1Bar", 10);
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

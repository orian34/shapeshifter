using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class MoonLordShapemask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moon Lord Shapemask");
			Tooltip.SetDefault("'This mask transcends your mind.' \n15% Increased ranged critical chance. Improved vision. \n[c/99FFCC:1/3 Moon Lord Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 17;
			item.value = 1000000*5;
			item.rare = 10;
			item.defense = 30;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("MoonLordShapeplate") && legs.type == mod.ItemType("MoonLordShapelegs");
		}
		public override void UpdateEquip(Player player)
		{
			player.rangedCrit += 15;
			player.findTreasure = true;
			player.nightVision = true;
			player.detectCreature = true;
			player.dangerSense = true;
			player.sonarPotion = true;
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Your body is shaping as of an eldritch god";
            player.GetModPlayer<ShapeshifterPlayer>().ActivateShapeshift(typeof(MoonLordShapeshift));
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BossMaskMoonlord);
			recipe.AddIngredient(ItemID.FragmentVortex, 10);
			recipe.AddIngredient(ItemID.LunarBar,8);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

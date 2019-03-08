using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class GolemShapemask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golem Shapemask");
			Tooltip.SetDefault("'This mask is quietly humming.' \n7% Increased magic damage and improved mana regeneration");
		}
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 17;
			item.value = 60000*5;
			item.rare = 8;
			item.defense = 23;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("GolemShapeplate") && legs.type == mod.ItemType("GolemShapelegs");
		}
		public override void UpdateEquip(Player player)
		{
			player.magicDamage += 0.07f;
			player.manaRegenDelayBonus++;
			player.manaRegenBonus += 25;
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Your body is shaping as of an ancient construct";
            player.GetModPlayer<ShapeshifterPlayer>().ActivateShapeshift(typeof(GolemShapeshift));
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GolemMask);
			recipe.AddIngredient(ItemID.LunarTabletFragment,4);
			recipe.AddIngredient(ItemID.LihzahrdPowerCell);
			recipe.AddTile(TileID.LihzahrdFurnace);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	public class GolemShapemaskDanger : EquipTexture
	{
		public override bool DrawHead()
		{
			return false;
		}
	}
}

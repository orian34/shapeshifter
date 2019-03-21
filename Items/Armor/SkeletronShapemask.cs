using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Shapeshifter.Core;
using Shapeshifter.Core.Shapeshifts;

namespace Shapeshifter.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class SkeletronShapemask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skeletron Shapemask");
			Tooltip.SetDefault("'This mask is cursed.' \n4% increased throwing damage \n[c/C0AE90:1/3 Skeletron Set Piece]");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 22;
			item.value = 152500;
			item.rare = 3;
			item.defense = 5;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("SkeletronShapeplate") && legs.type == mod.ItemType("SkeletronShapelegs");
		}
		public override void UpdateEquip(Player player)
		{
			player.thrownDamage += 0.04f;
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Your body is shaping as of the cursed guardian";
            player.GetModPlayer<ShapeshifterPlayer>().ActivateShapeshift(typeof(SkeletronShapeshift));
		}
		public override void AddRecipes()
		{
			ModRecipe skeletronshapemask = new ModRecipe(mod);
			skeletronshapemask.AddIngredient(ItemID.SkeletronMask);
			skeletronshapemask.AddIngredient(ItemID.WaterCandle);
			skeletronshapemask.AddTile(TileID.BoneWelder);
			skeletronshapemask.SetResult(this);
			skeletronshapemask.AddRecipe();
		}
	}
	public class SkeletronShapemaskCursed : EquipTexture
	{
		public override bool DrawHead()
		{
			return false;
		}
	}
}

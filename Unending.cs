using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;
using Terraria.Graphics;

namespace Unending
{
	class Unending : Mod
	{
		public static DynamicSpriteFont unendFont;

		//private UserInterface _overdriveBarUserInterface;

		//internal UserInterface ExamplePersonUserInterface;
		//internal OverdriveBar OverdriveBar;

		public Unending()
		{
			//OverdriveBar = new OverdriveBar();
			//OverdriveBar.Activate();
			//_overdriveBarUserInterface = new UserInterface();
			//_overdriveBarUserInterface.SetState(OverdriveBar);
			//OverdriveBar.visible = true;
		}

		public override void Load()
		{
			// Will show up in client.log under the ExampleMod name
			/*
			Logger.InfoFormat("{0} Unending Log", Name);
			if (FontExists("Fonts/ExampleFont"))
				unendFont = GetFont("Fonts/UnendFont");
			if (!Main.dedServ)
			{
				OverdriveBar.visible = false;
				OverdriveBar.barFrame = null;
			}
			*/
		}
		/*
		public override void UpdateUI(GameTime gameTime)
		{
			if (OverdriveBar.visible)
			{
				_overdriveBarUserInterface?.Update(gameTime);
			}
			ExamplePersonUserInterface?.Update(gameTime);
		}
		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
			if (resourceBarIndex != -1)
			{
				layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
					"Unending: Overdrive Bar",
					delegate {
						if (OverdriveBar.visible)
						{
							_overdriveBarUserInterface.Draw(Main.spriteBatch, new GameTime());
						}
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
		}
		*/

	}
}

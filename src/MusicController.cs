using System;
using Microsoft.VisualBasic;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using SwinGameSDK;
using System.IO;

static class MusicController
{
	private static readonly string [] _menuStructure = { "Default", "Epic", "Cinematic", "Quit" };

	private const int MENU_TOP = 575;
	private const int MENU_LEFT = 30;
	private const int MENU_GAP = 0;
	private const int BUTTON_WIDTH = 75;
	private const int BUTTON_HEIGHT = 15;
	private const int BUTTON_SEP = BUTTON_WIDTH + MENU_GAP;

	private const int TEXT_OFFSET = 0;

	private const int MUSIC_DEFAULT_BUTTON = 0;
	private const int MUSIC_HARMONY_BUTTON = 1;
	private const int MUSIC_AGREESIVE_BUTTON = 2;
	private const int MUSIC_QUIT_BUTTON = 3;

	private static readonly Color MENU_COLOR = SwinGame.RGBAColor (2, 167, 252, 255);

	public static void DrawMusicList () {
		int btnTop = 0;
		btnTop = MENU_TOP - (MENU_GAP + BUTTON_HEIGHT) * 0;
		int i = 0;
		for (i = 0; i <= _menuStructure.Length - 1; i++) {
			int btnLeft = 0;
			btnLeft = MENU_LEFT + BUTTON_SEP * (i + 0);
			//SwinGame.FillRectangle(Color.White, btnLeft, btnTop, BUTTON_WIDTH, BUTTON_HEIGHT)
			SwinGame.DrawTextLines (_menuStructure [i], MENU_COLOR, Color.Black, GameResources.GameFont ("Menu"), FontAlignment.AlignCenter, btnLeft + TEXT_OFFSET, btnTop + TEXT_OFFSET, BUTTON_WIDTH, BUTTON_HEIGHT);
		}
	}

	public static void HandleMusicInput ()
	{
		if (SwinGame.KeyTyped (KeyCode.vk_ESCAPE) || SwinGame.KeyTyped (KeyCode.vk_RETURN)) {
			GameController.EndCurrentState ();
		} else if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
			int i = 0;
			for (i = 0; i <= _menuStructure.Length - 1; i++) {
				//IsMouseOver the i'th button of the menu
				if (IsMouseOverMenu (i, 0, 0)) {
					PerformMusicAction (i);
				}
			}
		}
	}

	private static bool IsMouseOverMenu (int button, int level, int xOffset)
	{
		int btnTop = MENU_TOP - (MENU_GAP + BUTTON_HEIGHT) * level;
		int btnLeft = MENU_LEFT + BUTTON_SEP * (button + xOffset);

		return UtilityFunctions.IsMouseInRectangle (btnLeft, btnTop, BUTTON_WIDTH, BUTTON_HEIGHT);
	}

	private static void PerformMusicAction (int button)
	{
		switch (button) {
			case MUSIC_DEFAULT_BUTTON:
				SwinGame.PlayMusic (GameResources.GameMusic ("Background"));
				break;
			case MUSIC_HARMONY_BUTTON:
				SwinGame.PlayMusic (GameResources.GameMusic ("Epic"));
				break;
			case MUSIC_AGREESIVE_BUTTON:
				SwinGame.PlayMusic (GameResources.GameMusic ("Cinematic"));
				break;
			case MUSIC_QUIT_BUTTON:
				GameController.EndCurrentState();
				break;
		}
	}
}

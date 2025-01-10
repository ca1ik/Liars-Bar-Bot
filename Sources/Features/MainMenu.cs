using System;
using System.Linq;
using System.Runtime.CompilerServices;
using ub0.utilities;
using UnityEngine;

namespace ub0.features
{
	// Token: 0x0200000A RID: 10
	[linked]
	public class MainMenu : MonoBehaviour
	{
		// Token: 0x06000024 RID: 36 RVA: 0x0000273E File Offset: 0x0000093E
		public void Start()
		{
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002740 File Offset: 0x00000940
		public void FixedUpdate()
		{
			if (Input.GetKeyDown(282))
			{
				this.menuOpened = !this.menuOpened;
			}
			if (Input.GetKeyDown(283))
			{
				this.showPlayer1Options = false;
				this.showPlayer2Options = false;
				this.showPlayer3Options = false;
				this.showPlayer4Options = false;
				this.menuOpened = false;
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002798 File Offset: 0x00000998
		private void OnGUI()
		{
			if (this.menuOpened)
			{
				this.menuRect = GUI.Window(69, this.menuRect, new GUI.WindowFunction(this.cheatMenu), "The TruthBar Menu | By Nallraen | v0.2");
			}
			if (this.lastBulletString.Equals("Error"))
			{
				GUI.Window(5, new Rect((float)(MainMenu.ScreenX / 2), (float)(MainMenu.ScreenY / 2), 350f, 100f), new GUI.WindowFunction(this.errorMessage), "Error...");
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000281C File Offset: 0x00000A1C
		private void cheatMenu(int wId)
		{
			this.scrollPos = GUILayout.BeginScrollView(this.scrollPos, new GUILayoutOption[]
			{
				GUILayout.Width((float)MainMenu.menuX),
				GUILayout.Height((float)MainMenu.menuY)
			});
			GUIStyle guistyle = new GUIStyle(GUI.skin.button);
			guistyle.richText = true;
			guistyle.padding = new RectOffset(10, 10, 5, 5);
			guistyle.alignment = 4;
			this.CenteredLabel("On which bullet would you die?", 280f);
			this.lastBulletString = GUILayout.TextField(this.lastBulletString, new GUILayoutOption[]
			{
				GUILayout.Width(100f)
			});
			this.CenteredButton("Move the bullet!", delegate
			{
				this.lastBulletString = this.ValidateNumber(this.lastBulletString);
				if (!this.lastBulletString.Equals("Error"))
				{
					this.lastBulleValue = int.Parse(this.lastBulletString);
					this.ModifyBullet(this.lastBulleValue);
				}
			}, 250f);
			GUILayout.Space((float)MainMenu.separatorSize);
			string str = (gameUtils.getPlayerById(0) != null) ? gameUtils.getPlayerById(0).PlayerName : "DefaultName";
			this.CenteredButton(str + " Card options", delegate
			{
				this.showPlayer1Options = !this.showPlayer1Options;
			}, 250f);
			if (this.showPlayer1Options)
			{
				if (gameUtils.isGameStarted())
				{
					PlayerStats pStats = gameUtils.getPlayerById(0);
					this.CenteredButton("Set all cards as <color=red>Kings</color>", delegate
					{
						this.EditCards(pStats, 1);
					}, 250f);
					this.CenteredButton("Set all cards as <color=purple>Queens</color>", delegate
					{
						this.EditCards(pStats, 2);
					}, 250f);
					this.CenteredButton("Set all cards as <color=orange>Aces</color>", delegate
					{
						this.EditCards(pStats, 3);
					}, 250f);
					this.CenteredButton("Set all cards as Jokers", delegate
					{
						this.EditCards(pStats, 4);
					}, 250f);
				}
				else
				{
					this.CenteredLabel("You must be in a game to modify cards values!", 280f);
				}
			}
			string str2 = (gameUtils.getPlayerById(1) != null) ? gameUtils.getPlayerById(1).PlayerName : "DefaultName";
			this.CenteredButton(str2 + " Card Options", delegate
			{
				this.showPlayer2Options = !this.showPlayer2Options;
			}, 250f);
			if (this.showPlayer2Options)
			{
				if (gameUtils.isGameStarted())
				{
					PlayerStats pStats = (gameUtils.getPlayerById(1) != null) ? gameUtils.getPlayerById(1) : null;
					this.CenteredButton("Set all cards as <color=red>Kings</color>", delegate
					{
						this.EditCards(pStats, 1);
					}, 250f);
					this.CenteredButton("Set all cards as <color=purple>Queens</color>", delegate
					{
						this.EditCards(pStats, 2);
					}, 250f);
					this.CenteredButton("Set all cards as <color=orange>Aces</color>", delegate
					{
						this.EditCards(pStats, 3);
					}, 250f);
					this.CenteredButton("Set all cards as Jokers", delegate
					{
						this.EditCards(pStats, 4);
					}, 250f);
				}
				else
				{
					this.CenteredLabel("You must be in a game to modify cards values!", 280f);
				}
			}
			string str3 = (gameUtils.getPlayerById(2) != null) ? gameUtils.getPlayerById(2).PlayerName : "DefaultName";
			this.CenteredButton(str3 + " Card Options", delegate
			{
				this.showPlayer3Options = !this.showPlayer3Options;
			}, 250f);
			if (this.showPlayer3Options)
			{
				if (gameUtils.isGameStarted())
				{
					if (gameUtils.getPlayers().Count<PlayerStats>() >= 3)
					{
						PlayerStats pStats = (gameUtils.getPlayerById(2) != null) ? gameUtils.getPlayerById(2) : null;
						this.CenteredButton("Set all cards as <color=red>Kings</color>", delegate
						{
							this.EditCards(pStats, 1);
						}, 250f);
						this.CenteredButton("Set all cards as <color=purple>Queens</color>", delegate
						{
							this.EditCards(pStats, 2);
						}, 250f);
						this.CenteredButton("Set all cards as <color=orange>Aces</color>", delegate
						{
							this.EditCards(pStats, 3);
						}, 250f);
						this.CenteredButton("Set all cards as Jokers", delegate
						{
							this.EditCards(pStats, 4);
						}, 250f);
					}
					else
					{
						this.CenteredLabel("There is no 3rd player.", 280f);
					}
				}
				else
				{
					this.CenteredLabel("You must be in a game to modify cards values!", 280f);
				}
			}
			string str4 = (gameUtils.getPlayerById(3) != null) ? gameUtils.getPlayerById(3).PlayerName : "DefaultName";
			this.CenteredButton(str4 + " Card Options", delegate
			{
				this.showPlayer4Options = !this.showPlayer4Options;
			}, 250f);
			if (this.showPlayer4Options)
			{
				if (gameUtils.isGameStarted())
				{
					if (gameUtils.getPlayers().Count<PlayerStats>() == 4)
					{
						PlayerStats pStats = (gameUtils.getPlayerById(3) != null) ? gameUtils.getPlayerById(3) : null;
						this.CenteredButton("Set all cards as <color=red>Kings</color>", delegate
						{
							this.EditCards(pStats, 1);
						}, 250f);
						this.CenteredButton("Set all cards as <color=purple>Queens</color>", delegate
						{
							this.EditCards(pStats, 2);
						}, 250f);
						this.CenteredButton("Set all cards as <color=orange>Aces</color>", delegate
						{
							this.EditCards(pStats, 3);
						}, 250f);
						this.CenteredButton("Set all cards as Jokers", delegate
						{
							this.EditCards(pStats, 4);
						}, 250f);
					}
					else
					{
						this.CenteredLabel("There is no 4th player.", 280f);
					}
				}
				else
				{
					this.CenteredLabel("You must be in a game to modify cards values!", 280f);
				}
			}
			GUILayout.Space((float)MainMenu.separatorSize);
			this.CenteredButton("Rank Menu", delegate
			{
				this.showRankMenu = !this.showRankMenu;
			}, 250f);
			if (this.showRankMenu)
			{
				this.CenteredButton("<color=#938400>Truth Teller</color>", delegate
				{
					MainMenu.<>c.<<cheatMenu>b__20_6>d <<cheatMenu>b__20_6>d;
					<<cheatMenu>b__20_6>d.<>t__builder = AsyncVoidMethodBuilder.Create();
					<<cheatMenu>b__20_6>d.<>1__state = -1;
					<<cheatMenu>b__20_6>d.<>t__builder.Start<MainMenu.<>c.<<cheatMenu>b__20_6>d>(ref <<cheatMenu>b__20_6>d);
				}, 250f);
				this.CenteredButton("<color=#937103>Rookie</color>", delegate
				{
					MainMenu.<>c.<<cheatMenu>b__20_7>d <<cheatMenu>b__20_7>d;
					<<cheatMenu>b__20_7>d.<>t__builder = AsyncVoidMethodBuilder.Create();
					<<cheatMenu>b__20_7>d.<>1__state = -1;
					<<cheatMenu>b__20_7>d.<>t__builder.Start<MainMenu.<>c.<<cheatMenu>b__20_7>d>(ref <<cheatMenu>b__20_7>d);
				}, 250f);
				this.CenteredButton("<color=#9A6C16>Trickster</color>", delegate
				{
					MainMenu.<>c.<<cheatMenu>b__20_8>d <<cheatMenu>b__20_8>d;
					<<cheatMenu>b__20_8>d.<>t__builder = AsyncVoidMethodBuilder.Create();
					<<cheatMenu>b__20_8>d.<>1__state = -1;
					<<cheatMenu>b__20_8>d.<>t__builder.Start<MainMenu.<>c.<<cheatMenu>b__20_8>d>(ref <<cheatMenu>b__20_8>d);
				}, 250f);
				this.CenteredButton("<color=#9B4814>Hustler</color>", delegate
				{
					MainMenu.<>c.<<cheatMenu>b__20_9>d <<cheatMenu>b__20_9>d;
					<<cheatMenu>b__20_9>d.<>t__builder = AsyncVoidMethodBuilder.Create();
					<<cheatMenu>b__20_9>d.<>1__state = -1;
					<<cheatMenu>b__20_9>d.<>t__builder.Start<MainMenu.<>c.<<cheatMenu>b__20_9>d>(ref <<cheatMenu>b__20_9>d);
				}, 250f);
				this.CenteredButton("<color=#9B4814>Con Artist</color>", delegate
				{
					MainMenu.<>c.<<cheatMenu>b__20_10>d <<cheatMenu>b__20_10>d;
					<<cheatMenu>b__20_10>d.<>t__builder = AsyncVoidMethodBuilder.Create();
					<<cheatMenu>b__20_10>d.<>1__state = -1;
					<<cheatMenu>b__20_10>d.<>t__builder.Start<MainMenu.<>c.<<cheatMenu>b__20_10>d>(ref <<cheatMenu>b__20_10>d);
				}, 250f);
				this.CenteredButton("<color=#9F002E>Silver Tongued Devil</color>", delegate
				{
					MainMenu.<>c.<<cheatMenu>b__20_11>d <<cheatMenu>b__20_11>d;
					<<cheatMenu>b__20_11>d.<>t__builder = AsyncVoidMethodBuilder.Create();
					<<cheatMenu>b__20_11>d.<>1__state = -1;
					<<cheatMenu>b__20_11>d.<>t__builder.Start<MainMenu.<>c.<<cheatMenu>b__20_11>d>(ref <<cheatMenu>b__20_11>d);
				}, 250f);
				this.CenteredButton("<color=#9F002E>Master of Deception</color>", delegate
				{
					MainMenu.<>c.<<cheatMenu>b__20_12>d <<cheatMenu>b__20_12>d;
					<<cheatMenu>b__20_12>d.<>t__builder = AsyncVoidMethodBuilder.Create();
					<<cheatMenu>b__20_12>d.<>1__state = -1;
					<<cheatMenu>b__20_12>d.<>t__builder.Start<MainMenu.<>c.<<cheatMenu>b__20_12>d>(ref <<cheatMenu>b__20_12>d);
				}, 250f);
			}
			GUILayout.EndScrollView();
			GUI.DragWindow();
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002ECC File Offset: 0x000010CC
		private void EditCards(PlayerStats player, int cardType)
		{
			foreach (GameObject gameObject in player.GetComponent<BlorfGamePlay>().Cards)
			{
				Component[] components = gameObject.GetComponents(typeof(Component));
				foreach (Card card in components.OfType<Card>())
				{
					card.cardtype = cardType;
					card.SetCard();
				}
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002F74 File Offset: 0x00001174
		private void errorMessage(int wId)
		{
			GUI.Label(new Rect(20f, 20f, 300f, 70f), "Please enter a valid number between 0 and 999.");
			if (GUI.Button(new Rect(125f, 75f, 100f, 20f), "Close"))
			{
				this.lastBulletString = "0";
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002FD4 File Offset: 0x000011D4
		private string ValidateNumber(string number)
		{
			string text = "";
			foreach (char c in number)
			{
				if (char.IsDigit(c))
				{
					text += c.ToString();
				}
			}
			if (text.Equals(""))
			{
				return "Error";
			}
			int num = int.Parse(text);
			return Mathf.Clamp(num, 0, 999).ToString();
		}

		// Token: 0x0600002B RID: 43 RVA: 0x0000304C File Offset: 0x0000124C
		private void ModifyBullet(int value)
		{
			PlayerStats mainPlayer = gameUtils.getMainPlayer();
			mainPlayer.GetComponent<BlorfGamePlay>().Networkrevolverbulllet = value;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x0000306C File Offset: 0x0000126C
		private string getLastBulletToString()
		{
			return gameUtils.getMainPlayer().GetComponent<BlorfGamePlay>().Networkrevolverbulllet.ToString();
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00003090 File Offset: 0x00001290
		private void CenteredLabel(string label, float width = 280f)
		{
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			GUILayout.FlexibleSpace();
			GUILayout.Label(label, new GUILayoutOption[]
			{
				GUILayout.Width(width)
			});
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000030C0 File Offset: 0x000012C0
		private void CenteredButton(string label, Action onClick, float width = 250f)
		{
			GUIStyle guistyle = new GUIStyle(GUI.skin.button);
			guistyle.richText = true;
			guistyle.padding = new RectOffset(10, 10, 5, 5);
			guistyle.alignment = 4;
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			GUILayout.FlexibleSpace();
			if (GUILayout.Button(label, guistyle, new GUILayoutOption[]
			{
				GUILayout.Width(width)
			}))
			{
				onClick();
			}
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00003134 File Offset: 0x00001334
		private GUIStyle getButtonStyle()
		{
			return new GUIStyle(GUI.skin.button)
			{
				richText = true,
				padding = new RectOffset(10, 10, 5, 5),
				alignment = 4
			};
		}

		// Token: 0x0400000D RID: 13
		private static int ScreenX = Screen.width;

		// Token: 0x0400000E RID: 14
		private static int ScreenY = Screen.height;

		// Token: 0x0400000F RID: 15
		private static int menuX = 300;

		// Token: 0x04000010 RID: 16
		private static int menuY = 500;

		// Token: 0x04000011 RID: 17
		private static int menuXOffset = MainMenu.ScreenX - MainMenu.menuX - 10;

		// Token: 0x04000012 RID: 18
		private static int menuYOffset = 0;

		// Token: 0x04000013 RID: 19
		private static int separatorSize = 10;

		// Token: 0x04000014 RID: 20
		private Rect menuRect = new Rect((float)MainMenu.menuXOffset, (float)MainMenu.menuYOffset, (float)MainMenu.menuX, (float)MainMenu.menuY);

		// Token: 0x04000015 RID: 21
		private Vector2 scrollPos = Vector2.zero;

		// Token: 0x04000016 RID: 22
		private string lastBulletString = "0";

		// Token: 0x04000017 RID: 23
		private int lastBulleValue;

		// Token: 0x04000018 RID: 24
		private bool menuOpened;

		// Token: 0x04000019 RID: 25
		private bool showPlayer1Options;

		// Token: 0x0400001A RID: 26
		private bool showPlayer2Options;

		// Token: 0x0400001B RID: 27
		private bool showPlayer3Options;

		// Token: 0x0400001C RID: 28
		private bool showPlayer4Options;

		// Token: 0x0400001D RID: 29
		private bool showRankMenu;
	}
}

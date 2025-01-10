using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ub0.utilities;
using UnityEngine;

namespace ub0.features
{
	// Token: 0x0200000D RID: 13
	[linked]
	public class PlayerCards : MonoBehaviour
	{
		// Token: 0x0600003D RID: 61 RVA: 0x0000330A File Offset: 0x0000150A
		public void Start()
		{
		}

		// Token: 0x0600003E RID: 62 RVA: 0x0000330C File Offset: 0x0000150C
		public void FixedUpdate()
		{
			PlayerCards.<FixedUpdate>d__17 <FixedUpdate>d__;
			<FixedUpdate>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<FixedUpdate>d__.<>4__this = this;
			<FixedUpdate>d__.<>1__state = -1;
			<FixedUpdate>d__.<>t__builder.Start<PlayerCards.<FixedUpdate>d__17>(ref <FixedUpdate>d__);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00003344 File Offset: 0x00001544
		public void OnGUI()
		{
			if (this.cardOnTable.Count<string>() >= 1)
			{
				float num = (float)Screen.height;
				float num2 = (float)Screen.width;
				this.playedCardWindowRect = GUI.Window(2, this.playedCardWindowRect, new GUI.WindowFunction(this.cardsPlayedWindow), "Cards on the table");
			}
			if (this.Players.Count != 0)
			{
				this.playerCardWindowRect = GUI.Window(1, this.playerCardWindowRect, new GUI.WindowFunction(this.playerCardsWindow), "Player Cards");
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000033C0 File Offset: 0x000015C0
		private void resetPlayerCards()
		{
			this.Player1_Cards.Clear();
			this.Player2_Cards.Clear();
			this.Player3_Cards.Clear();
			this.Player4_Cards.Clear();
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000033F0 File Offset: 0x000015F0
		private void getPlayerCards(List<Card> cards, int i)
		{
			int num = 0;
			foreach (Card card in cards)
			{
				string text = this.ConvertIntToCard(card.cardtype);
				if (i == 0)
				{
					this.Player1_Cards.Add(card.cardtype.ToString() + "cardName: " + text);
				}
				else if (i == 1)
				{
					this.Player2_Cards.Add(card.cardtype.ToString() + "cardName: " + text);
				}
				else if (i == 2)
				{
					this.Player3_Cards.Add(card.cardtype.ToString() + "cardName: " + text);
				}
				else if (i == 3)
				{
					this.Player4_Cards.Add(card.cardtype.ToString() + "cardName: " + text);
				}
				if (num == 0)
				{
					this.addPlayerData("Card1", text, i);
				}
				else if (num == 1)
				{
					this.addPlayerData("Card2", text, i);
				}
				else if (num == 2)
				{
					this.addPlayerData("Card3", text, i);
				}
				else if (num == 3)
				{
					this.addPlayerData("Card4", text, i);
				}
				else if (num == 4)
				{
					this.addPlayerData("Card5", text, i);
				}
				num++;
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00003554 File Offset: 0x00001754
		private void addPlayerData(string valueType, string value, int playerId)
		{
			if (playerId == 0)
			{
				this.Player1_Datas[valueType] = value;
				return;
			}
			if (playerId == 1)
			{
				this.Player2_Datas[valueType] = value;
				return;
			}
			if (playerId == 2)
			{
				this.Player3_Datas[valueType] = value;
				return;
			}
			if (playerId == 3)
			{
				this.Player4_Datas[valueType] = value;
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000035A8 File Offset: 0x000017A8
		private string ConvertIntToCard(int cardType)
		{
			switch (cardType)
			{
			case -1:
				return "DEVIL";
			case 1:
				return "K";
			case 2:
				return "Q";
			case 3:
				return "A";
			case 4:
				return "J";
			}
			return cardType.ToString();
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00003608 File Offset: 0x00001808
		private void cardsPlayedWindow(int wId)
		{
			this.cardOnTable = this.formatCardColor(this.cardOnTable);
			GUIStyle guistyle = new GUIStyle(GUI.skin.label);
			guistyle.richText = true;
			GUI.Label(new Rect(10f, 30f, 100f, 30f), string.Join(", ", this.cardOnTable) ?? "", guistyle);
			GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00003694 File Offset: 0x00001894
		private void playerCardsWindow(int wId)
		{
			this.Player1_Cards = this.formatCardColor(this.Player1_Cards);
			this.Player2_Cards = this.formatCardColor(this.Player2_Cards);
			this.Player3_Cards = this.formatCardColor(this.Player3_Cards);
			this.Player4_Cards = this.formatCardColor(this.Player4_Cards);
			GUIStyle guistyle = new GUIStyle(GUI.skin.label);
			guistyle.richText = true;
			GUI.Label(new Rect(10f, 30f, 400f, 30f), string.Concat(new string[]
			{
				this.Player1_Datas["PlayerName"],
				" >> Cards : ",
				string.Join(" | ", this.Player1_Cards),
				" | ",
				(this.Players[0].GetComponent<BlorfGamePlay>().Networkrevolverbulllet - this.Players[0].GetComponent<BlorfGamePlay>().Networkcurrentrevoler == 0) ? "Dead on next!" : string.Format("{0} / {1}", this.Players[0].GetComponent<BlorfGamePlay>().Networkcurrentrevoler, this.Players[0].GetComponent<BlorfGamePlay>().Networkrevolverbulllet + 1)
			}), guistyle);
			GUI.Label(new Rect(10f, 60f, 400f, 30f), string.Concat(new string[]
			{
				this.Player2_Datas["PlayerName"],
				" >> Cards : ",
				string.Join(" | ", this.Player2_Cards),
				" | ",
				(this.Players[1].GetComponent<BlorfGamePlay>().Networkrevolverbulllet - this.Players[1].GetComponent<BlorfGamePlay>().Networkcurrentrevoler == 0) ? "Dead on next!" : string.Format("{0} / {1}", this.Players[1].GetComponent<BlorfGamePlay>().Networkcurrentrevoler, this.Players[1].GetComponent<BlorfGamePlay>().Networkrevolverbulllet + 1)
			}), guistyle);
			GUI.Label(new Rect(10f, 90f, 400f, 30f), string.Concat(new string[]
			{
				this.Player3_Datas["PlayerName"],
				" >> Cards : ",
				string.Join(" | ", this.Player3_Cards),
				" | ",
				(this.Players[2].GetComponent<BlorfGamePlay>().Networkrevolverbulllet - this.Players[2].GetComponent<BlorfGamePlay>().Networkcurrentrevoler == 0) ? "Dead on next!" : string.Format("{0} / {1}", this.Players[2].GetComponent<BlorfGamePlay>().Networkcurrentrevoler, this.Players[2].GetComponent<BlorfGamePlay>().Networkrevolverbulllet + 1)
			}), guistyle);
			GUI.Label(new Rect(10f, 120f, 400f, 30f), string.Concat(new string[]
			{
				this.Player4_Datas["PlayerName"],
				" >> Cards : ",
				string.Join(" | ", this.Player4_Cards),
				" | ",
				(this.Players[3].GetComponent<BlorfGamePlay>().Networkrevolverbulllet - this.Players[3].GetComponent<BlorfGamePlay>().Networkcurrentrevoler == 0) ? "Dead on next!" : string.Format("{0} / {1}", this.Players[3].GetComponent<BlorfGamePlay>().Networkcurrentrevoler, this.Players[3].GetComponent<BlorfGamePlay>().Networkrevolverbulllet + 1)
			}), guistyle);
			GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00003A8C File Offset: 0x00001C8C
		private List<string> formatCardColor(List<string> cards)
		{
			List<string> list = new List<string>();
			foreach (string text in cards)
			{
				if (text.Equals("Q"))
				{
					list.Add("<color=purple>Q</color>");
				}
				else if (text.Equals("A"))
				{
					list.Add("<color=orange>A</color>");
				}
				else if (text.Equals("K"))
				{
					list.Add("<color=red>K</color>");
				}
				else if (text.Equals("J"))
				{
					list.Add("<color=white>J</color>");
				}
				else if (text.Equals("DEVIL"))
				{
					list.Add("<color=red>DEVIL</color>");
				}
				else
				{
					list.Add(text);
				}
			}
			return list;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003B6C File Offset: 0x00001D6C
		private void initDict()
		{
			this.Player1_Datas.Add("PlayerName", "");
			this.Player1_Datas.Add("Card1", "");
			this.Player1_Datas.Add("Card2", "");
			this.Player1_Datas.Add("Card3", "");
			this.Player1_Datas.Add("Card4", "");
			this.Player1_Datas.Add("Card5", "");
			this.Player2_Datas.Add("PlayerName", "");
			this.Player2_Datas.Add("Card1", "");
			this.Player2_Datas.Add("Card2", "");
			this.Player2_Datas.Add("Card3", "");
			this.Player2_Datas.Add("Card4", "");
			this.Player2_Datas.Add("Card5", "");
			this.Player3_Datas.Add("PlayerName", "");
			this.Player3_Datas.Add("Card1", "");
			this.Player3_Datas.Add("Card2", "");
			this.Player3_Datas.Add("Card3", "");
			this.Player3_Datas.Add("Card4", "");
			this.Player3_Datas.Add("Card5", "");
			this.Player4_Datas.Add("PlayerName", "");
			this.Player4_Datas.Add("Card1", "");
			this.Player4_Datas.Add("Card2", "");
			this.Player4_Datas.Add("Card3", "");
			this.Player4_Datas.Add("Card4", "");
			this.Player4_Datas.Add("Card5", "");
		}

		// Token: 0x04000020 RID: 32
		private BlorfGamePlayManager gamePlayManager = new BlorfGamePlayManager();

		// Token: 0x04000021 RID: 33
		private List<PlayerStats> Players = new List<PlayerStats>();

		// Token: 0x04000022 RID: 34
		private List<int> CardInfo = new List<int>();

		// Token: 0x04000023 RID: 35
		private List<string> cardOnTable = new List<string>();

		// Token: 0x04000024 RID: 36
		private List<string> PlayerNames = new List<string>();

		// Token: 0x04000025 RID: 37
		private List<string> Player1_Cards = new List<string>();

		// Token: 0x04000026 RID: 38
		private List<string> Player2_Cards = new List<string>();

		// Token: 0x04000027 RID: 39
		private List<string> Player3_Cards = new List<string>();

		// Token: 0x04000028 RID: 40
		private List<string> Player4_Cards = new List<string>();

		// Token: 0x04000029 RID: 41
		private Dictionary<string, string> Player1_Datas = new Dictionary<string, string>();

		// Token: 0x0400002A RID: 42
		private Dictionary<string, string> Player2_Datas = new Dictionary<string, string>();

		// Token: 0x0400002B RID: 43
		private Dictionary<string, string> Player3_Datas = new Dictionary<string, string>();

		// Token: 0x0400002C RID: 44
		private Dictionary<string, string> Player4_Datas = new Dictionary<string, string>();

		// Token: 0x0400002D RID: 45
		private Rect playerCardWindowRect = new Rect(10f, 300f, 400f, 160f);

		// Token: 0x0400002E RID: 46
		private Rect playedCardWindowRect = new Rect(10f, 200f, 200f, 60f);

		// Token: 0x0400002F RID: 47
		private bool gameStarted;
	}
}

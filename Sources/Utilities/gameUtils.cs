using System;
using System.Collections.Generic;
using Steamworks;
using UnityEngine;

namespace ub0.utilities
{
	// Token: 0x02000003 RID: 3
	public class gameUtils
	{
		// Token: 0x06000005 RID: 5 RVA: 0x00002150 File Offset: 0x00000350
		public static bool isGameStarted()
		{
			return gameUtils.getPlayers().Count != 0;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002164 File Offset: 0x00000364
		public static List<PlayerStats> getPlayers()
		{
			List<PlayerStats> list = new List<PlayerStats>();
			foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Player"))
			{
				if (gameObject.GetComponent<PlayerStats>() != null && !list.Contains(gameObject.GetComponent<PlayerStats>()))
				{
					list.Add(gameObject.GetComponent<PlayerStats>());
				}
			}
			return list;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000021C0 File Offset: 0x000003C0
		public static PlayerStats getPlayerByName(string name)
		{
			PlayerStats result = null;
			List<PlayerStats> players = gameUtils.getPlayers();
			foreach (PlayerStats playerStats in players)
			{
				if (playerStats.PlayerName.Equals(name))
				{
					result = playerStats;
				}
			}
			return result;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002220 File Offset: 0x00000420
		public static PlayerStats getPlayerById(int id)
		{
			PlayerStats result;
			try
			{
				List<PlayerStats> players = gameUtils.getPlayers();
				result = ((id < players.Count) ? players[id] : null);
			}
			catch (Exception ex)
			{
				logger.print(ex.Message, 7);
				result = null;
			}
			return result;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000226C File Offset: 0x0000046C
		public static PlayerStats getOtherById(int id)
		{
			List<PlayerStats> players = gameUtils.getPlayers();
			PlayerStats playerStats = (gameUtils.getMainPlayer() != null) ? gameUtils.getMainPlayer() : null;
			if (playerStats == null)
			{
				return null;
			}
			foreach (PlayerStats playerStats2 in players)
			{
				if (playerStats2.PlayerName.Equals(gameUtils.getMainPlayer().PlayerName))
				{
					players.Remove(playerStats2);
				}
			}
			if (id >= players.Count)
			{
				return null;
			}
			return players[id];
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002310 File Offset: 0x00000510
		public static string getPlayerNameByID(int id)
		{
			List<PlayerStats> players = gameUtils.getPlayers();
			foreach (PlayerStats playerStats in players)
			{
				if (playerStats.PlayerName.Equals(gameUtils.getMainPlayer().PlayerName))
				{
					players.Remove(playerStats);
				}
			}
			PlayerStats playerStats2 = players[id];
			return playerStats2.PlayerName;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000238C File Offset: 0x0000058C
		public static PlayerStats getMainPlayer()
		{
			List<PlayerStats> list = new List<PlayerStats>();
			PlayerStats result = new PlayerStats();
			list = gameUtils.getPlayers();
			foreach (PlayerStats playerStats in list)
			{
				if (playerStats.PlayerName.Equals(SteamFriends.GetPersonaName()))
				{
					result = playerStats;
				}
			}
			return result;
		}
	}
}

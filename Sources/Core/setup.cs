using System;
using ub0.utilities;
using UnityEngine;

namespace ub0.core
{
	// Token: 0x02000010 RID: 16
	[linked]
	public class Setup : MonoBehaviour
	{
		// Token: 0x06000050 RID: 80 RVA: 0x0000400C File Offset: 0x0000220C
		public void Start()
		{
		}

		// Token: 0x06000051 RID: 81 RVA: 0x0000400E File Offset: 0x0000220E
		public void FixedUpdate()
		{
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00004010 File Offset: 0x00002210
		public void OnGUI()
		{
			if (this.welcome)
			{
				this.welcomeWindowRect = GUI.Window(0, this.welcomeWindowRect, new GUI.WindowFunction(this.WelcomeWindow), "Welcome!");
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00004040 File Offset: 0x00002240
		private void WelcomeWindow(int wId)
		{
			GUI.Label(new Rect((float)(Setup.windowX / 2 - 150), 20f, 300f, (float)Setup.windowY), "Welcome to the TruthBar!!!!\n\nTo turn on card views, press 'L' while in-game!\nTo close PlayerCards window press 'P' in lobby.\nBy pressing F1 you'll open the cheat menu!\nIn case of akward UI bug with menu press F2 to reset it.\n\nYou can also move windows. Just press escape first to unlock your mouse.\n\nEnjoy");
			if (GUI.Button(new Rect((float)(Setup.windowX / 2 - 50), (float)(Setup.windowY - 25), 100f, 20f), "Close"))
			{
				this.welcome = false;
			}
			GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
		}

		// Token: 0x04000033 RID: 51
		private static int windowX = 400;

		// Token: 0x04000034 RID: 52
		private static int windowY = 250;

		// Token: 0x04000035 RID: 53
		private Rect welcomeWindowRect = new Rect((float)(Screen.width / 2 - Setup.windowX / 2), (float)(Screen.height / 2 - Setup.windowY / 2), (float)Setup.windowX, (float)Setup.windowY);

		// Token: 0x04000036 RID: 54
		private bool welcome = true;
	}
}

using System;
using System.IO;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace ub0.utilities
{
	// Token: 0x02000005 RID: 5
	public class logger
	{
		// Token: 0x0600000E RID: 14
		public static bool alloc()
		{
			if (!memory.AllocConsole())
			{
				return false;
			}
			memory.AttachConsole(uint.MaxValue);
			if (!memory.SetConsoleTitle("Liar's Bar - Cheat Console"))
			{
				return false;
			}
			Console.SetOut(new StreamWriter(new FileStream(new SafeFileHandle(memory.GetStdHandle(-11), true), FileAccess.Write), Encoding.ASCII)
			{
				AutoFlush = true
			});
			return true;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002463 File Offset: 0x00000663
		public static bool free()
		{
			return memory.FreeConsole();
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000246A File Offset: 0x0000066A
		public static void print(string szPrint, ushort usColor = 7)
		{
			memory.SetConsoleTextAttribute(memory.GetStdHandle(-11), logger.FOREGROUND_YELLOW);
			Console.Write("nall-root$> ");
			memory.SetConsoleTextAttribute(memory.GetStdHandle(-11), usColor);
			Console.WriteLine(szPrint);
		}

		// Token: 0x04000001 RID: 1
		public static ushort FOREGROUND_RED = 4;

		// Token: 0x04000002 RID: 2
		public static ushort FOREGROUND_GREEN = 2;

		// Token: 0x04000003 RID: 3
		public static ushort FOREGROUND_BLUE = 1;

		// Token: 0x04000004 RID: 4
		public static ushort FOREGROUND_WHITE = logger.FOREGROUND_RED | logger.FOREGROUND_BLUE | logger.FOREGROUND_GREEN;

		// Token: 0x04000005 RID: 5
		public static ushort FOREGROUND_YELLOW = logger.FOREGROUND_RED | logger.FOREGROUND_GREEN;

		// Token: 0x04000006 RID: 6
		public static ushort FOREGROUND_CYAN = logger.FOREGROUND_BLUE | logger.FOREGROUND_GREEN;

		// Token: 0x04000007 RID: 7
		public static ushort FOREGROUND_MAGENTA = logger.FOREGROUND_RED | logger.FOREGROUND_BLUE;

		// Token: 0x04000008 RID: 8
		public static ushort FOREGROUND_BLACK = 0;
	}
}

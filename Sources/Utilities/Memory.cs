using System;
using System.Runtime.InteropServices;

namespace ub0.utilities
{
	// Token: 0x02000006 RID: 6
	public class memory
	{
		// Token: 0x06000013 RID: 19
		[DllImport("kernel32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AllocConsole();

		// Token: 0x06000014 RID: 20
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool AttachConsole(uint dwProcessId);

		// Token: 0x06000015 RID: 21
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool FreeConsole();

		// Token: 0x06000016 RID: 22
		[DllImport("kernel32.dll")]
		public static extern bool SetConsoleTitle(string lpConsoleTitle);

		// Token: 0x06000017 RID: 23
		[DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr GetStdHandle(int nStdHandle);

		// Token: 0x06000018 RID: 24
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool SetConsoleTextAttribute(IntPtr hConsoleOutput, ushort wAttributes);

		// Token: 0x06000019 RID: 25
		[DllImport("kernel32.dll")]
		public static extern IntPtr GetConsoleWindow();

		// Token: 0x0600001A RID: 26 RVA: 0x00002514 File Offset: 0x00000714
		public unsafe static void abs_jump(IntPtr pSite, IntPtr pTarget)
		{
			byte* ptr = (byte*)pSite.ToPointer();
			*ptr = 73;
			ptr[1] = 187;
			*(long*)(ptr + 2) = pTarget.ToInt64();
			ptr[10] = 65;
			ptr[11] = byte.MaxValue;
			ptr[12] = 227;
		}
	}
}

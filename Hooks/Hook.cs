using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Microsoft.CSharp.RuntimeBinder;

namespace ub0.hooks
{
	// Token: 0x02000009 RID: 9
	public class hook
	{
		// Token: 0x06000020 RID: 32 RVA: 0x00002594 File Offset: 0x00000794
		public unsafe hook(IntPtr pSource, IntPtr pDestination)
		{
			this.pSource = pSource;
			this.pDestination = pDestination;
			byte* ptr = (byte*)pSource.ToPointer();
			for (int i = 0; i < 13; i++)
			{
				this.oBytes[i] = ptr[i];
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000025E4 File Offset: 0x000007E4
		public unsafe hook([NotNull] dynamic pSource, [NotNull] dynamic pDestination)
		{
			if (hook.<>o__4.<>p__0 == null)
			{
				hook.<>o__4.<>p__0 = CallSite<Func<CallSite, object, IntPtr>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(IntPtr), typeof(hook)));
			}
			this.pSource = hook.<>o__4.<>p__0.Target(hook.<>o__4.<>p__0, pSource);
			if (hook.<>o__4.<>p__1 == null)
			{
				hook.<>o__4.<>p__1 = CallSite<Func<CallSite, object, IntPtr>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(IntPtr), typeof(hook)));
			}
			this.pDestination = hook.<>o__4.<>p__1.Target(hook.<>o__4.<>p__1, pDestination);
			byte* ptr = (byte*)this.pSource.ToPointer();
			for (int i = 0; i < 13; i++)
			{
				this.oBytes[i] = ptr[i];
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000026B8 File Offset: 0x000008B8
		public unsafe void install()
		{
			byte* ptr = (byte*)this.pSource.ToPointer();
			*ptr = 73;
			ptr[1] = 187;
			*(UIntPtr)ptr[2] = this.pDestination.ToInt64();
			ptr[10] = 65;
			ptr[11] = byte.MaxValue;
			ptr[12] = 227;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x0000270C File Offset: 0x0000090C
		public unsafe void uninstall()
		{
			byte* ptr = (byte*)this.pSource.ToPointer();
			for (int i = 0; i < 13; i++)
			{
				ptr[i] = this.oBytes[i];
			}
		}

		// Token: 0x0400000A RID: 10
		public IntPtr pSource;

		// Token: 0x0400000B RID: 11
		public IntPtr pDestination;

		// Token: 0x0400000C RID: 12
		public byte[] oBytes = new byte[13];
	}
}

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ub0.utilities;
using UnityEngine;
//
namespace ub0.features
{
	// Token: 0x0200000C RID: 12
	[linked]
	public class LastBullet : MonoBehaviour
	{
		// Token: 0x0600003A RID: 58 RVA: 0x000032BB File Offset: 0x000014BB
		public void Start()
		{
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000032C0 File Offset: 0x000014C0
		public void FixedUpdate()
		{
			LastBullet.<FixedUpdate>d__3 <FixedUpdate>d__;
			<FixedUpdate>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<FixedUpdate>d__.<>4__this = this;
			<FixedUpdate>d__.<>1__state = -1;
			<FixedUpdate>d__.<>t__builder.Start<LastBullet.<FixedUpdate>d__3>(ref <FixedUpdate>d__);
		}

		// Token: 0x0400001E RID: 30
		private bool debug;

		// Token: 0x0400001F RID: 31
		private List<PlayerStats> Players = new List<PlayerStats>();
	}
}

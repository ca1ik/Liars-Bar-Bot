using System;
using System.Collections.Generic;
using ub0.features;
using ub0.utilities;
using UnityEngine;

namespace ub0.core
{
	// Token: 0x0200000F RID: 15
	public class manager : MonoBehaviour
	{
		// Token: 0x0600004C RID: 76 RVA: 0x00003F6C File Offset: 0x0000216C
		public void Awake()
		{
			logger.print("added " + this.listFeatures.Count.ToString() + " feature(s) to the gameobject manager....", 7);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003FA1 File Offset: 0x000021A1
		public void OnGUI()
		{
			this.listFeatures.ForEach(delegate(ifeature feature)
			{
				feature.on_render();
			});
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00003FCD File Offset: 0x000021CD
		public void FixedUpdate()
		{
			this.listFeatures.ForEach(delegate(ifeature feature)
			{
				feature.on_update();
			});
		}

		// Token: 0x04000032 RID: 50
		public List<ifeature> listFeatures = new List<ifeature>();
	}
}

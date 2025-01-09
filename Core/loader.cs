using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ub0.hooks;
using ub0.utilities;
using UnityEngine;

namespace ub0.core
{
	// Token: 0x0200000E RID: 14
	public class loader
	{
		// Token: 0x06000049 RID: 73 RVA: 0x00003E54 File Offset: 0x00002054
		public static void load()
		{
			logger.alloc();
			logger.print("console allocated.....", 7);
			loader.h_manager = new manager();
			logger.print("created hooking manager...", 7);
			loader.g_loaded = new GameObject();
			loader.g_loaded.AddComponent<manager>();
			logger.print("loaded gameobject..", 7);
			List<Type> list = Assembly.GetExecutingAssembly().GetTypes().ToList<Type>();
			list.RemoveAll((Type l) => !l.IsDefined(typeof(linked), false));
			list.ForEach(delegate(Type type)
			{
				loader.g_loaded.AddComponent(type);
			});
			logger.print("linked " + list.Count.ToString() + " types in our assembly.", 7);
			Object.DontDestroyOnLoad(loader.g_loaded);
			logger.print("initialized successfully", 7);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00003F3A File Offset: 0x0000213A
		public static void unload()
		{
			logger.print("uninitializing", 7);
			Object.Destroy(loader.g_loaded);
			logger.print("uninitialized loaded gameobject", 7);
			logger.free();
		}

		// Token: 0x04000030 RID: 48
		private static GameObject g_loaded;

		// Token: 0x04000031 RID: 49
		public static manager h_manager;
	}
}

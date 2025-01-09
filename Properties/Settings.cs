using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace ub0.Properties
{
	// Token: 0x02000007 RID: 7
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.3.0.0")]
	internal sealed class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600001C RID: 28 RVA: 0x00002564 File Offset: 0x00000764
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x04000009 RID: 9
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}

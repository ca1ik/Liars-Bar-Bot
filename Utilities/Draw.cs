using System;
using UnityEngine;

namespace ub0.utilities
{
	// Token: 0x02000002 RID: 2
	public class draw
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static Vector2 world_to_screen(Vector3 vPos)
		{
			Vector3 vector = Camera.main.WorldToScreenPoint(vPos);
			return new Vector3(vector.x, (float)Screen.height - vector.y);
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002088 File Offset: 0x00000288
		public static void rect(Vector2 vPos, Vector2 vSize, Color rColor)
		{
			GL.PushMatrix();
			GL.Color(rColor);
			GL.Begin(1);
			GL.Vertex3(vPos.x, vPos.y, 0f);
			GL.Vertex3(vPos.x, vPos.y + vSize.y, 0f);
			GL.Vertex3(vPos.x + vSize.x, vPos.y + vSize.y, 0f);
			GL.Vertex3(vPos.x + vSize.x, vPos.y, 0f);
			GL.Vertex3(vPos.x, vPos.y, 0f);
			GL.End();
			GL.PopMatrix();
		}

		// Token: 0x06000003 RID: 3 RVA: 0x0000213A File Offset: 0x0000033A
		public static void rect(Vector2 vPos, Vector2 vSize)
		{
			draw.rect(vPos, vSize, Color.white);
		}
	}
}

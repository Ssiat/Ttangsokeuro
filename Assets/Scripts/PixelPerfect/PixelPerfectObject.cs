using UnityEngine;
using System.Collections;
using System;

namespace Ssiat.PixelPerfect
{
	[ExecuteInEditMode]
	public class PixelPerfectObject : MonoBehaviour
	{
		public int scale = 1;
		public bool positionForScale = true;

		protected void LateUpdate()
		{
			if (transform.hasChanged)
				SetPixelPerfect();
		}

		protected void SetPixelPerfect()
		{
			SetPixelPerfectPosition();
			SetPixelPerfectScale();

			transform.hasChanged = false;
		}

		protected void SetPixelPerfectPosition()
		{
			if (positionForScale)
				transform.position = new Vector2((Mathf.Round(transform.position.x / scale) * scale), (Mathf.Round(transform.position.y / scale) * scale));
			else
				transform.position = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
		}

		protected void SetPixelPerfectScale()
		{
			float pixelsPerUnit = GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
			transform.localScale = new Vector2(scale * pixelsPerUnit, scale * pixelsPerUnit);
		}
	}
}
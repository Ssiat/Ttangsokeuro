using UnityEngine;
using System.Collections;

namespace Ssiat.PixelPerfect
{
	[ExecuteInEditMode]
	public class PixelPerfectSprite : MonoBehaviour
	{
		public int scale = 1;
		public bool positionForScale = true;

		private GameObject _sprite;

		void OnEnable()
		{
			_sprite = new GameObject("Sprite");
			_sprite.transform.parent = transform;
			_sprite.AddComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
			GetComponent<SpriteRenderer>().sprite = null;
		}

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
				_sprite.transform.position = new Vector2((Mathf.Round(transform.position.x / scale) * scale), (Mathf.Round(transform.position.y / scale) * scale));
			else
				_sprite.transform.position = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
		}

		protected void SetPixelPerfectScale()
		{
			float pixelsPerUnit = GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
			transform.localScale = new Vector2(scale * pixelsPerUnit, scale * pixelsPerUnit);
		}
	}
}
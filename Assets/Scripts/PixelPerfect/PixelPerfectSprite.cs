using UnityEngine;
using System.Collections;

namespace Ssiat.PixelPerfect
{
	[ExecuteInEditMode]
	public class PixelPerfectSprite : MonoBehaviour
	{
		public int scale = 1;
		public bool positionForScale = true;

		private GameObject _realSprite;
		private SpriteRenderer _realSpriteRenderer;

		// Awake를 사용해야 할까...?
		/* 
		 * [경고]
		 * SpriteRenderer의 Sprite가 변경되면 반영할 방법이 없다...
		 * 그 외에도 여러가지로 문제가 많을거 같은데...
		 * 아예 C#으로는 설계만 하고 실적인 스크립트는 Lua같은걸로 처리할까?
		 * 실행 도중에 외부에서 스프라이트가 변경되는 일이 생기면 생각해보자!
		*/
		void OnEnable()
		{
			if ( _realSprite == null )
			{
				var childSpriteObject = transform.FindChild("Sprite");

				if ( childSpriteObject == null )
				{
					_realSprite = new GameObject("Sprite");
					_realSprite.transform.parent = transform;
				}
				else
					_realSprite = childSpriteObject.gameObject;

				_realSpriteRenderer = AddORGetSpriteRenderer(_realSprite);

				var spriteRenderer = GetComponent<SpriteRenderer>();

				if ( spriteRenderer != null )
				{
					if ( spriteRenderer.sprite != null )
					{
						_realSpriteRenderer.sprite = spriteRenderer.sprite;

						spriteRenderer.sprite = null;
					}
				}
			}
		}

		protected void LateUpdate()
		{
			if ( transform.hasChanged )
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
			if ( positionForScale )
				_realSprite.transform.position = new Vector2((Mathf.Round(transform.position.x / scale) * scale), (Mathf.Round(transform.position.y / scale) * scale));
			else
				_realSprite.transform.position = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
		}

		protected void SetPixelPerfectScale()
		{
			float pixelsPerUnit = _realSpriteRenderer.sprite.pixelsPerUnit;
			transform.localScale = new Vector2(scale * pixelsPerUnit, scale * pixelsPerUnit);
		}

		protected SpriteRenderer AddORGetSpriteRenderer(GameObject gameObject)
		{
			var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

			if (spriteRenderer == null)
				spriteRenderer = gameObject.AddComponent<SpriteRenderer>();

			return spriteRenderer;
		}
	}
}
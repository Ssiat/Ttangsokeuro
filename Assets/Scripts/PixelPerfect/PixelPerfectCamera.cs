/*
	쿡가대표 일상 브금나온부분 편집해서 티비플에 올려야 겠다. + 바바예투도...?
*/
using UnityEngine;
using System.Collections;

namespace Ssiat.PixelPerfect
{
	[ExecuteInEditMode]
	public class PixelPerfectCamera : MonoBehaviour
	{
		public struct ScreenResolution
		{
			public int width;
			public int height;

			public ScreenResolution(int width, int height)
			{
				this.width	= width;
				this.height	= height;
			}

			public static bool operator ==(ScreenResolution left, ScreenResolution right)
			{
				return (left.width == right.width) && (left.height == right.height);
			}

			public static bool operator !=(ScreenResolution left, ScreenResolution right)
			{
				return (left.width != right.width) && (left.height != right.height);
			}
		}

		private ScreenResolution _lateScreenResolution	= new ScreenResolution(0, 0);
		private bool _xIsEven							= true;
		private bool _yIsEven							= true;
		private Vector2 _truePosition;

		/*
		void Start()
		{
			Debug.Log("Start()");

			SetPixelPerfect();
		}
		*/

		void OnEnable()
		{
			// Debug.Log("OnEnable()");

			_truePosition = new Vector2(transform.position.x, transform.position.y);
			SetPixelPerfect();
		}

		void LateUpdate()
		{
			// Debug.Log("LateUpdate()");

			SetPixelPerfect();
		}

		private void SetPixelPerfect()
		{
			if (transform.hasChanged)
				SetPixelPerfectPosition(transform.position);

			if (IsChangedResolution())
				SetPixelPerfectSize();
		}

		void SetPixelPerfectPosition(Vector2 position)
		{
			// Debug.Log("SetPixelPerfectPosition()");

			_truePosition = new Vector2(position.x, position.y);

			float x;
			float y;

			// Debug.Log(position.x);
			// Debug.Log(position.y);

			// [임시] 리팩토링이 굉장히 필요해 보임.
			if (_xIsEven)
				x = Mathf.Round(position.x);
			else
				// x = (((int)position.x) + 0.5f);
				x = Mathf.Round(position.x) + 0.5f;

			if (_yIsEven)
				y = Mathf.Round(position.y);
			else
				// y = (((int)position.y) + 0.5f);
				y = Mathf.Round(position.y) + 0.5f;

			transform.position = new Vector3(x, y, transform.position.z);
			transform.hasChanged = false;
		}

		void SetPixelPerfectSize()
		{
			// Debug.Log("SetPixelPerfectSize()");

			GetComponent<Camera>().orthographicSize = Screen.height / 2.0f;

			_xIsEven = (Screen.width % 2) == 0;
			_yIsEven = (Screen.height % 2) == 0;

			SetPixelPerfectPosition(_truePosition);
		}

		bool IsChangedResolution()
		{
			ScreenResolution presentScreenResolution = new ScreenResolution(Screen.width, Screen.height);

			if (_lateScreenResolution != presentScreenResolution)
			{
				_lateScreenResolution = presentScreenResolution;
				return true;
			}
			else
				return false;
		}
	}
}
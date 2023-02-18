using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herghys
{
    public class ContentHolder : MonoBehaviour
    {
		public virtual void SetContent() { }

		public virtual void SetContent(string text) { }

		public virtual void SetContent(Sprite sprite) { }
		public virtual void SetContent(float height) { }
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using Herghys;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Herghys
{
	[CreateAssetMenu(fileName = "Materi Content", menuName ="Data/Materi")]
    public class MateriData : ScriptableObject
    {
        public List<MateriContent> contents = new List<MateriContent>();

        [ContextMenu("Add Head")]
        public void AddHead()
        {
            var content = new MateriContent()
            {
				title = "Head",
                contentType = MateriContentType.Head
            };
            contents.Add (content);
		}

		[ContextMenu("Add Subhead")]
		public void AddSubHead()
		{
			var content = new MateriContent()
			{
				title = "Subhead Content",
				contentType = MateriContentType.Subhead
			};
			contents.Add(content);
		}

		[ContextMenu("Add Text")]
		public void AddText()
		{
			var content = new MateriContent()
			{
				title = "Text Content",
				contentType = MateriContentType.Text
			};
			contents.Add(content);
		}

		[ContextMenu("Add Space")]
		public void AddSpace()
		{
			var content = new MateriContent()
			{
				title = "Space",
				contentType = MateriContentType.Space
			};
			contents.Add(content);
			SetDirty();
		}

		[ContextMenu("Add Image")]
		public void Image()
		{
			var content = new MateriContent()
			{
				title = "Image Content",
				contentType = MateriContentType.Image
			};
			AddSpace();
			contents.Add(content);
			AddSpace();
			SetDirty();
		}
		
		new void SetDirty()
		{
#if UNITY_EDITOR
			EditorUtility.SetDirty(this);
#endif
		}
	}

	[Serializable]
	public record MateriContent
	{
		public string title;
		//public GameObject baseUI;
		public Sprite sprite;
		[TextArea(1, 500)]
		public string text;
		public MateriContentType contentType;
	}

}
using UnityEngine;

namespace Herghys
{
	[RequireComponent(typeof(CanvasGroup))]
    public class MateriHolder : MonoBehaviour
    {
		[SerializeField] protected CanvasGroup canvasGroup;

		[SerializeField] protected int index;

		[SerializeField] protected SubjectTypes subject;

        [SerializeField] protected MateriData data;

		[SerializeField] protected RectTransform ContentContainer;

		[SerializeField] protected MateriManager manager;

		[SerializeField] protected ContentHead headContentPrefab;
		[SerializeField] protected ContentImageContainer imageContainerPrefab;
		[SerializeField] protected ContentText textContentPrefab;
        [SerializeField] protected ContentSpace spaceContentPrefab;
        [SerializeField] protected ContentSubhead subheadContentPrefab;

		[SerializeField] protected bool isOpened;

		public int Index { get=> index; set => index = value; }
		public SubjectTypes Subject { get => subject;set => subject = value; }

        [ContextMenu("Create Data")]
		public void CreateData()
        {
			var childCount = ContentContainer.GetComponentsInChildren<ContentHolder>();
			if (childCount.Length > 1)
			{
				foreach (var item in childCount)
				{
					DestroyImmediate(item.gameObject);
				}
			}
			data.contents.ForEach(x =>
            {
				Spawn(x);
            });
        }

        private void Spawn(MateriContent content)
        {
			switch (content.contentType)
			{
				case MateriContentType.Head:
					var head = Instantiate(headContentPrefab, ContentContainer);
					head.SetContent(content.text);
					head.name = "Head";
					break;
				case MateriContentType.Text:
					var text = Instantiate(textContentPrefab, ContentContainer);
					text.name = "Text_Content";
					text.SetContent(content.text);
					break;
				case MateriContentType.Space:
					var space = Instantiate(spaceContentPrefab, ContentContainer);
					space.name = "Space_Content";
					break;
				case MateriContentType.Image:
					var image = Instantiate(imageContainerPrefab, ContentContainer);
					image.name = "Image_Content";
					image.SetContent(content.sprite);
					break;
				case MateriContentType.Subhead:
					var subhead = Instantiate(subheadContentPrefab, ContentContainer);
					subhead.name = "Subhead_Content";
					subhead.SetContent(content.text);
					break;
			}
		}

		public void Open()
		{
			isOpened = true;
			ControlCanvasGroup(isOpened);
		}

		public void Close()
		{
			isOpened = false;
			ControlCanvasGroup(isOpened);
		}

		protected virtual void ControlCanvasGroup(bool status)
		{
			canvasGroup.blocksRaycasts = status;
			canvasGroup.interactable = status;
			canvasGroup.alpha = status ? 1 : 0;
		}

		protected virtual void OnValidate()
		{
			manager = GetComponentInParent<MateriManager>();
			canvasGroup = GetComponentInParent<CanvasGroup>();
		}
	}
}

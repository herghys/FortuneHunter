using System.Collections;
using System.Collections.Generic;
using Herghys.Game.Quiz;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Herghys
{
    public class QuestionController : MonoBehaviour
    {
        [SerializeField] QuestionTypes type;

        [SerializeField] TextMeshProUGUI questionText;
        [SerializeField] Image image;

		[SerializeField] List<AnswerData> answerDatas = new();
		public void SetQuestionData(Question data)
        {
            if (questionText != null)
                questionText.text = data.Info;

            if (image is not null)
                image.sprite = data.Image;

			for (int i = 0; i <= answerDatas.Count - 1; i++)
			{
				answerDatas[i].SetAnswer(data.Answers[i]);
			}
		}

		private void OnValidate()
		{
			GetComponentsInChildren<AnswerData>(true, answerDatas);
		}
	}
}

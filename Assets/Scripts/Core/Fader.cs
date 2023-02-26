using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Herghys
{
    public class Fader : MonoBehaviour
    {
		public CanvasGroup img;
		public AnimationCurve curve;

		private void Start()
		{
			FadeIn();
		}

		#region Methods To Call
		public void FadeTo(string scene)
		{
			StartCoroutine(FadeOut(scene));
		}

		public void FadeToIndex(int sceneIndex)
		{
			StartCoroutine(FadeOutIndex(sceneIndex));
		}

		public void FadeIn()
		{
			StartCoroutine(IE_FadeIn());
		}

		public void FadeOut()
		{
			StartCoroutine(IE_FadeOut());
		}

		#endregion
		IEnumerator IE_FadeIn()
		{
			img.alpha = 1;
			yield return new WaitForSeconds(1);
			float t = 1f;

			while (t > 0f)
			{
				t -= Time.deltaTime;
				float a = curve.Evaluate(t);
				img.alpha = a;
				//img.color = new Color(0f, 0f, 0f, a);
				yield return 0;
			}
			img.blocksRaycasts = false;
		}

		IEnumerator IE_FadeOut()
		{
			img.alpha = 0;
			yield return new WaitForSeconds(1);
			float t = 0f;

			while (t < 1f)
			{
				t += Time.deltaTime;
				float a = curve.Evaluate(t);
				img.alpha = a;
				//img.color = new Color(0f, 0f, 0f, a);
				yield return 0;
			}

			img.blocksRaycasts = false;
		}

		#region Fadeout Normal
		IEnumerator FadeOut(string scene)
		{
			float t = 0f;

			while (t < 1f)
			{
				t += Time.deltaTime;
				float a = curve.Evaluate(t);
				img.alpha = a;
				//img.color = new Color(0f, 0f, 0f, a);
				yield return 0;
			}
			SceneManager.LoadScene(scene);
		}

		IEnumerator FadeOutIndex(int sceneIndex)
		{
			float t = 0f;

			while (t < 1f)
			{
				t += Time.deltaTime;
				float a = curve.Evaluate(t);
				img.alpha = a;
				//img.color = new Color(0f, 0f, 0f, a);
				yield return 0;
			}
			SceneManager.LoadScene(sceneIndex);
		}
		#endregion
	}
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using Herghys.Core;
using Herghys.Global;
using Newtonsoft.Json;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Herghys
{
    public class GameEndManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI scoreText;
		[SerializeField] int correct;
		[SerializeField] int score;

		[SerializeField] SaveDataModel saveData = new();

		bool doneCalulation = false;

		string cDir = @"C:\FortuneHunterData\";
		string fileName = "saveData.json";

		private void Awake()
		{
			CalculateScore();
			
		}

		private void Start()
		{
			StartCoroutine(IE_SaveData());
		}

		public void CalculateScore()
		{
			correct = GlobalVariables.Instance.TotalCorrectAnswers();
			score = correct * 5;
			scoreText.text = score.ToString();
		}


		IEnumerator IE_SaveData()
		{
			saveData.Name = PlayerPrefs.GetString(GameConstants.PLAYER_NAME);
			saveData.JumlahBenar = correct;
			saveData.Score = score;

			yield return null;

			saveData.AnsweredQuestions = GlobalVariables.Instance.answeredQuestions;

			GlobalVariables.Instance.IsFinished = true;
			PlayerPrefs.SetString(GameConstants.IS_FINISHED, bool.TrueString);

			if (!string.IsNullOrEmpty(saveData.Name))
				fileName = $"{saveData.Name}_saveData.json";

			if (!Directory.Exists(@"C:\FortuneHunterData"))
				Directory.CreateDirectory(@"C:\FortuneHunterData");

			var save = JsonConvert.SerializeObject(saveData, Formatting.Indented);

			Debug.Log(save);

			try { File.WriteAllText($"{cDir}{fileName}", save); } catch { }

			try { File.WriteAllText($"{Application.persistentDataPath}/{fileName}", save); } catch { }

			try { File.WriteAllText($"{Application.dataPath}/{fileName}", save); } catch { }

			yield return new WaitForSeconds(1);
			doneCalulation = true;
		}
		public void Finish()
		{
			if (!doneCalulation) return;
			SceneManager.LoadScene("MainMenu");
		}
	}
}

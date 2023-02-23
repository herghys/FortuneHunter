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

		string cDir = @"C:\FortuneHunterData\";
		string fileName = "saveData.json";

		private void Awake()
		{
			CalculateScore();
			SaveData();
		}

		public void Finish()
		{
			SceneManager.LoadScene("MainMenu");
		}

		public void CalculateScore()
		{
			correct = GlobalVariables.Instance.TotalCorrectAnswers();
			score = correct * 5;
			scoreText.text = score.ToString();
		}

		public void SaveData()
		{
			saveData.Name = PlayerPrefs.GetString(GameConstants.PLAYER_NAME);
			saveData.JumlahBenar = correct;
			saveData.Score = score;

			saveData.AnsweredQuestions = GlobalVariables.Instance.answeredQuestions;

			if (!string.IsNullOrEmpty(saveData.Name))
				fileName = $"{saveData.Name}_saveData.json";

				if (!Directory.Exists(@"C:\FortuneHunterData"))
				Directory.CreateDirectory(@"C:\FortuneHunterData");

			var save = JsonConvert.SerializeObject(saveData);

			try { File.WriteAllText($"{cDir}{fileName}", save); } catch { }

			try { File.WriteAllText($"{Application.persistentDataPath}/{fileName}", save); } catch { }

			try { File.WriteAllText($"{Application.dataPath}/{fileName}", save); } catch { }

		}
	}
}

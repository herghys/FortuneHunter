using System.Collections;
using System.Collections.Generic;
using Herghys.Global;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Herghys
{
    public class IntroManager : MonoBehaviour
    {
        [SerializeField] Button saveNameButton;
        [SerializeField] TMP_InputField nameInputField;
        [SerializeField] bool IsFinished { get; set; }

        public string Username { get; set; }

		private void OnEnable()
		{
            saveNameButton.onClick.AddListener(SaveName);
            nameInputField.onValueChanged.AddListener(SetUsername);
			nameInputField.onEndEdit.AddListener(SetUsername);
		}

		private void OnDisable()
		{
			saveNameButton.onClick.RemoveListener(SaveName);
			nameInputField.onValueChanged.RemoveListener(SetUsername);
			nameInputField.onEndEdit.RemoveListener(SetUsername);
		}
        
        public void SetUsername(string username) 
            => Username = username;

        public void GoToMenu()
            => SceneManager.LoadScene("MainMenu");

        public void GetSaveState()
        {
            IsFinished = bool.Parse( PlayerPrefs.GetString(GameConstants.IS_FINISHED));
            GlobalVariables.Instance.IsFinished = IsFinished;
        }

        public void SaveName()
        {
            PlayerPrefs.SetString(GameConstants.PLAYER_NAME, Username);
            GlobalVariables.Instance.Username = Username;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Herghys
{
    public class IntroManager : MonoBehaviour
    {
        [SerializeField] Button saveNameButton;
        [SerializeField] TMP_InputField nameInputField;

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

        public void SaveName()
        {
            PlayerPrefs.SetString(GameConstants.PLAYER_NAME, Username);
        }
    }
}

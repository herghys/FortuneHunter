/*using System.Collections;
using System.Collections.Generic;
using Herghys.Game.Quiz;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Herghys
{
	[CustomEditor(typeof(QuizDataScriptable))]
	public class QuizDataCreator : Editor
	{
		public VisualTreeAsset inspectorUI;
		public override VisualElement CreateInspectorGUI()
		{
			VisualElement myInspector = new VisualElement();

			inspectorUI.CloneTree(myInspector);

			VisualElement questionFoldout = myInspector.Q("Question_Foldout");
			VisualElement answerFoldout = myInspector.Q("Answer_Foldout");

			InspectorElement.FillDefaultInspector(questionFoldout, serializedObject, this);
			InspectorElement.FillDefaultInspector(answerFoldout, serializedObject, this);

			return myInspector;
		}
	}

	[CustomPropertyDrawer(typeof(Question))]
	public class Question_PropertyDrawe : PropertyDrawer
	{
		public override VisualElement CreatePropertyGUI(SerializedProperty property)
		{
			var container = new VisualElement();
			var popup = new UnityEngine.UIElements.PopupWindow();
			popup.text = "Question Detauls";
			popup.Add(new PropertyField(property.FindPropertyRelative("questionInfo"), "Question"));
			popup.Add(new PropertyField(property.FindPropertyRelative("timer"), "Timer"));

			container.Add(popup);
			return container;
		}
	}

	[CustomPropertyDrawer(typeof(Answer))]
	public class Answer_PropertyDrawer : PropertyDrawer
	{
		public override VisualElement CreatePropertyGUI(SerializedProperty property)
		{
			var container = new VisualElement();
			var popup = new UnityEngine.UIElements.PopupWindow();
			popup.text = "Question Detauls";
			popup.Add(new PropertyField(property.FindPropertyRelative("questionInfo"), "Question"));
			popup.Add(new PropertyField(property.FindPropertyRelative("timer"), "Timer"));



			container.Add(popup);
			return container;
		}
	}
}
*/
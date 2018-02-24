using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSelect : MonoBehaviour {
	[SerializeField]
	protected Text[] texts;

	private Language current_language;

	private enum Language {
		FRANCAIS,
		ENGLISH
	}

	private static Dictionary<Language, string> lang_labels = new Dictionary<Language, string>();
	private static Dictionary<Language, string> press_labels = new Dictionary<Language, string>();

	// Use this for initialization
	void Start () {
		current_language = Language.ENGLISH;
		lang_labels[Language.FRANCAIS] = "- Français -";
		lang_labels[Language.ENGLISH] = "- English -";

		press_labels[Language.FRANCAIS] = "[Appuyez sur espace pour commencer]";
		press_labels[Language.ENGLISH] = "[Press space to start]";
	}
	
	public void SwitchLanguage() {
		if (current_language == Language.ENGLISH) current_language = Language.FRANCAIS;
		else current_language = Language.ENGLISH;

		texts[0].text = lang_labels[current_language];
		texts[1].text = press_labels[current_language];
	}
}

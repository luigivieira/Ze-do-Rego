using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Texts {
	private static Dictionary<string, string> textList = new Dictionary<string, string>(){
		{ "ObserveNoAction", "Como assim?"  },
		{ "UseNoAction", "Nah!"},
		{ "PickNoAction", "Não posso pegar isso"},
		{ "TalkToNoAction", "Não acho que vão me responder"},
		{ "ObserveFireExtinguisher", "É um extintor, adoro vermelho!"  },
	};

	public static string GetText(string key) {
		string text = "";
		textList.TryGetValue(key, out text);
		return text;
	}
}

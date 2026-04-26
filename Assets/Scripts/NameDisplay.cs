using UnityEngine;
using UnityEngine.UI;
using TMPro;
//他のシーンでinputした名前を表示する
public class NameDisplay : MonoBehaviour
{
    public TMP_Text nameInput;

    void Start()
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "名無し");

        nameInput.text = playerName;
    }

}

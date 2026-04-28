using UnityEngine;
using TMPro;

// 他のシーンでinputした名前を表示する
public class NameDisplay : MonoBehaviour
{
    private const string KEY_PLAYER_NAME = "PlayerName";

    [SerializeField] private TMP_Text nameText;

    [Header("表示テンプレート（{name}が使える）")]
    [SerializeField] private string message = "{name}さん、調査ありがとう！！";

    void Start()
    {
        string playerName = PlayerPrefs.GetString(KEY_PLAYER_NAME, "名無し");

        // {name} を置換
        string displayText = message.Replace("{name}", playerName);

        nameText.text = displayText;
    }
}
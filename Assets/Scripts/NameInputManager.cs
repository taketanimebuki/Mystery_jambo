using UnityEngine;
using UnityEngine.UI;
using TMPro;

//  ボタン押す
// 入力チェック
// 空ならエラー表示
// OKなら保存して遷移

public class NameInputManager : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_Text errorText; //エラーメッセージ表示
    public SceneLoader sceneLoader;

    public void OnClickNext()
    {
        string playerName = nameInput.text.Trim();

        //空orスペースだけチェック
        if (string.IsNullOrEmpty(playerName))
        {
            Debug.Log("名前が未入力です");
            if (errorText != null)
                errorText.gameObject.SetActive(true);

            return;
        }
        if (errorText != null)
            errorText.gameObject.SetActive(false);


        //保存処理
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();
        Debug.Log("保存した名前: " + playerName);

        //Openingシーンに画面遷移
        GoNext();

    }
    void GoNext()
    {
        sceneLoader.SceneChangeOpening();
    }


}
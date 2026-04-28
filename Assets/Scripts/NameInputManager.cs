using UnityEngine;
using TMPro;

public class NameInputManager : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_Text errorText;
    public SceneLoader sceneLoader;

    void Awake()
    {
        Debug.Log("[NameInputManager] Awake開始");

        if (errorText == null)
        {
            Debug.LogWarning("[NameInputManager] errorText が設定されていません");
        }
        else
        {
            Debug.Log("[NameInputManager] errorText発見: " + errorText.gameObject.name);
            errorText.gameObject.SetActive(false);
            Debug.Log("[NameInputManager] errorTextを非表示にしました");
        }

        if (nameInput == null)
        {
            Debug.LogWarning("[NameInputManager] nameInput が設定されていません");
        }
        else
        {
            Debug.Log("[NameInputManager] nameInput発見: " + nameInput.gameObject.name);
        }

        if (sceneLoader == null)
        {
            Debug.LogWarning("[NameInputManager] sceneLoader が設定されていません");
        }
    }

    public void OnClickNext()
    {
        Debug.Log("[NameInputManager] 決定ボタンが押されました");

        if (nameInput == null)
        {
            Debug.LogWarning("[NameInputManager] nameInput が null なので処理中止");
            return;
        }

        string rawName = nameInput.text;
        string playerName = rawName.Trim();

        Debug.Log("[NameInputManager] 入力値: [" + rawName + "]");
        Debug.Log("[NameInputManager] Trim後: [" + playerName + "]");

        bool isEmpty = string.IsNullOrEmpty(playerName);
        Debug.Log("[NameInputManager] 空チェック結果: " + isEmpty);

        if (errorText != null)
        {
            errorText.gameObject.SetActive(isEmpty);
            Debug.Log("[NameInputManager] errorText表示状態: " + errorText.gameObject.activeSelf);
        }
        else
        {
            Debug.LogWarning("[NameInputManager] errorText が null のため表示切替できません");
        }

        if (isEmpty)
        {
            Debug.Log("[NameInputManager] 名前未入力のため、シーン遷移しません");
            return;
        }

        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();

        Debug.Log("[NameInputManager] 保存した名前: " + playerName);

        GoNext();
    }

    void GoNext()
    {
        Debug.Log("[NameInputManager] GoNext開始");

        if (sceneLoader == null)
        {
            Debug.LogWarning("[NameInputManager] sceneLoader が null のため遷移できません");
            return;
        }

        sceneLoader.SceneChangeOpening();
    }
}
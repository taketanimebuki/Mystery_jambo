using UnityEngine;
using TMPro;

public class NameInputManager : MonoBehaviour
{
    private const string KEY_PLAYER_NAME = "PlayerName";

    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TMP_Text errorText;
    [SerializeField] private SceneLoader sceneLoader;

    void Awake()
    {
        if (errorText != null)
        {
            errorText.gameObject.SetActive(false);
        }
    }

    public void OnClickNext()
    {
        if (nameInput == null) return;

        string playerName = nameInput.text.Trim();
        bool isEmpty = string.IsNullOrEmpty(playerName);

        if (errorText != null)
            errorText.gameObject.SetActive(isEmpty);

        if (isEmpty) return;

        PlayerPrefs.SetString(KEY_PLAYER_NAME, playerName);
        PlayerPrefs.Save();

        GoNext();
    }

    void GoNext()
    {
        if (sceneLoader != null)
        {
            sceneLoader.SceneChangeOpening();
        }
    }
}
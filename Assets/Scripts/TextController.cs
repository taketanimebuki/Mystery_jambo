using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
//タイプライターのような表示
//背景を変えずにセリフをボタンで変えていく
public class TextController : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private string[] messages;
    [SerializeField] private float typeSpeed = 0.05f;

    public enum EndAction
    {
        ShowPanel,
        LoadScene
    }

    [Header("最後まで行った後に表示するパネル")]
    [SerializeField] private EndAction endAction = EndAction.ShowPanel;

    [Header("パネル切り替え用")]
    [SerializeField] private GameObject currentPanel;
    [SerializeField] private GameObject nextPanel;

    [Header("シーン遷移用")]
    [SerializeField] private string nextSceneName;


    private int currentIndex = 0;
    private bool isTyping = false;
    private Coroutine typingCoroutine;

    void Start()
    {
        Debug.Log(this.gameObject.name);

        if (dialogueText == null)
        {
            Debug.LogWarning("dialogueText が設定されていません");
            return;
        }

        if (messages == null || messages.Length == 0)
        {
            Debug.LogWarning("messages が設定されていません");
            return;
        }

        ShowMessage();
    }

    public void OnTap()
    {
        //文字表示中にタップしたら全文表示
        if (isTyping)
        {
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }

            string playerName = PlayerPrefs.GetString("PlayerName", "名無し");
            string message = messages[currentIndex].Replace("{name}", playerName);

            dialogueText.text = message;

            isTyping = false;
            return;
        }
        //次の文章へ
        currentIndex++;
        //最後まで行ったら次のパネルへ
        if (currentIndex >= messages.Length)
        {
            DoEndAction();
            return;
        }
        ShowMessage();

    }
    void ShowMessage()
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "名無し");

        string message = messages[currentIndex].Replace("{name}", playerName);

        typingCoroutine = StartCoroutine(TypeText(message));
    }

    //タイプライター風に１文字ずつ表示する処理
    private IEnumerator TypeText(string message)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char c in message)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }

        isTyping = false;
        typingCoroutine = null;
    }

    void DoEndAction()
    {
        switch (endAction)
        {
            case EndAction.ShowPanel:
                GoNextPanel();
                break;

            case EndAction.LoadScene:
                GoNextScene();
                break;
        }
    }
    private void GoNextPanel()
    {
        if (currentPanel != null)
        {
            currentPanel.SetActive(false);//今のパネルを非表示
        }

        if (nextPanel != null)
        {
            nextPanel.SetActive(true);//次のパネルを表示
        }
    }
    private void GoNextScene()
    {
        if (string.IsNullOrEmpty(nextSceneName))
        {
            Debug.LogWarning("次のシーンが設定されてません");
            return;
        }
        SceneManager.LoadScene(nextSceneName);
    }


}



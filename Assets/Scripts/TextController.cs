using UnityEngine;
using TMPro;
using System.Collections;
//タイプライターのような表示
//背景を変えずにセリフをボタンで変えていく
public class TextController : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private string[] messages;
    [SerializeField] private float typeSpeed = 0.05f;

    [Header("最後まで行った後に表示するパネル")]
    [SerializeField] private GameObject currentPanel;
    [SerializeField] private GameObject nextPanel;

    private int currentIndex = 0;
    private bool isTyping = false;
    private Coroutine typingCoroutine;

    void Start()
    {
        ShowMessage();
    }

    public void OnTap()
    {
        //文字表示中にタップしたら全文表示
        if (isTyping)
        {
            StopCoroutine(typingCoroutine);
            dialogueText.text = messages[currentIndex];
            isTyping = false;
            return;
        }
        //次の文章へ
        currentIndex++;
        //最後まで行ったら次のパネルへ
        if (currentIndex >= messages.Length)
        {
            GoNextPanel();
            return;
        }
        ShowMessage();

    }
    void ShowMessage()
    {
        //Coroutineでタイプライター表示を開始
        typingCoroutine = StartCoroutine(TypeText(messages[currentIndex]));
    }

    //タイプライター風に１文字ずつ表示する処理
    IEnumerator TypeText(string messages)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char c in messages)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }

        isTyping = false;//
    }
    void GoNextPanel()
    {
        currentPanel.SetActive(false);//今のパネルを非表示
        nextPanel.SetActive(true);//次のパネルを表示
    }


}



using UnityEngine;
using TMPro;

public class CharacterConversationManager : MonoBehaviour
{
    [Header("返答を表示するText")]
    public TMP_Text characterCommentText;

    [Header("最初に表示するコメント")]
    [TextArea(2,5)]
    public string firstComment;

    [Header("質問ごとの返答")]
    [TextArea(2,5)]
    public string answer1;

    [TextArea(2,5)]
    public string answer2;

    [TextArea(2,5)]
    public string answer3;

    [TextArea(2,5)]
    public string answer4;

    void OnEnable()
    {
        ShowFirstComment();
    }

    public void ShowFirstComment()
    {
        if(characterCommentText != null)
        {
            characterCommentText.text = firstComment;
        }
        else
        {
            Debug.LogWarning("Character Comment Texrが設定されていません");
        }
    }

    public void ShowAnswer1()
    {
        ShowAnswer(answer1);
    }

    public void ShowAnswer2()
    {
        ShowAnswer(answer2);
    }

    public void ShowAnswer3()
    {
        ShowAnswer(answer3);
    }

    public void ShowAnswer4()
    {
        ShowAnswer(answer4);
    }

    private void ShowAnswer(string answer)
    {
        if(characterCommentText == null)
        {
            Debug.LogWarning("Character Comment Text が設定されていません");
            return;
        }
        characterCommentText.text = answer;
    }
}

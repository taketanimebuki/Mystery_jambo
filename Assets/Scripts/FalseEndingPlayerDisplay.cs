using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FalseEndingCharacterDisplay : MonoBehaviour
{
    [System.Serializable]
    public class FalseEndingCharacterData
    {
        public CulpritSelectManager.CharacterType characterType;
        public Texture texture;

        [TextArea]
        public string message;
    }

    [Header("表示用RawImage")]
    [SerializeField] private RawImage characterImage;

    [Header("セリフ表示用Text")]
    [SerializeField] private TMP_Text dialogueText;

    [Header("キャラごとの画像・セリフ一覧")]
    [SerializeField] private FalseEndingCharacterData[] characterImages;

    private const string KEY_SELECTED_CULPRIT = "SelectedCulprit";

    void Start()
    {
        int savedIndex = PlayerPrefs.GetInt(KEY_SELECTED_CULPRIT, -1);

        if (savedIndex == -1)
        {
            Debug.LogWarning("選ばれたキャラが保存されていません");
            return;
        }

        CulpritSelectManager.CharacterType selectType =
            (CulpritSelectManager.CharacterType)savedIndex;

        // 正解キャラはFalseEndingでは表示しない
        if (selectType == CulpritSelectManager.CharacterType.EngineerA)
        {
            Debug.LogWarning("正解キャラはFalseEndingで表示しません");
            return;
        }

        if (characterImages == null || characterImages.Length == 0)
        {
            Debug.LogWarning("characterImages が設定されていません");
            return;
        }

        foreach (FalseEndingCharacterData ci in characterImages)
        {
            if (ci.characterType == selectType)
            {
                if (characterImage != null)
                    characterImage.texture = ci.texture;

                if (dialogueText != null)
                    dialogueText.text = ci.message;

                Debug.Log("False Endingに表示するキャラ: " + selectType);
                return;
            }
        }

        Debug.LogWarning("対応する画像が見つかりません: " + selectType);
    }
}
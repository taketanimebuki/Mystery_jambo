using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FalseEndingCulpritDisplay : MonoBehaviour
{
    [System.Serializable]
    public class CulpritImage
    {
        public CulpritSelectManager.CharacterType characterType;
        public Texture characterTexture;
        [TextArea] public string message;

    }

    // RawImageに変更
    [SerializeField] private RawImage culpritImage;
    [SerializeField] private TMP_Text dialogueText;

    // キャラごとの画像一覧
    [SerializeField] private CulpritImage[] culpritImages;

    void Start()
    {
        int savedCulprit = PlayerPrefs.GetInt("SelectedCulprit", -1);

        if (savedCulprit == -1)
        {
            Debug.LogWarning("選択された犯人情報が保存されていません");
            return;
        }

        //正解キャラなら何もしない
        CulpritSelectManager.CharacterType selectedType =
            (CulpritSelectManager.CharacterType)savedCulprit;

        if (selectedType == CulpritSelectManager.CharacterType.EngineerA)
        {
            Debug.LogWarning("正解キャラはFalseEndingで表示しません");
            return;
        }

        foreach (CulpritImage ci in culpritImages)
        {
            if (ci.characterType == selectedType)
            {
                culpritImage.texture = ci.characterTexture;

                if (dialogueText != null)
                {
                    dialogueText.text = ci.message;
                }
                Debug.Log("False Endingに表示する犯人: " + selectedType);
                return;
            }
        }

        Debug.LogWarning("対応する犯人画像が見つかりません: " + selectedType);
    }
}

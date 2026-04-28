using UnityEngine;
using UnityEngine.UI;

public class FalseEndingCharacterDisplay : MonoBehaviour
{
    [System.Serializable]
    public class CharacterImage
    {
        public CharacterPanelChanger.CharacterType characterType;
        public Sprite sprite;
    }

    //表示等Image
    [SerializeField] private Image CharacterImage;
    //キャラごとの画像一覧
    [SerializeField] private CharacterImage[] characterImages;
    //キーを定数化
    private const string KEY_SELECTED_CHARACTER = "SelectedCharacter"

    void Start()
    {
        int savedIndex = PlayerPrefs.GetInt(KEY_SELECTED_CHARACTER, -1);
        if (savedIndex == -1)
        {
            Debug.LogWarning("選ばれたキャラが保存されていません");
            return;
        }
        CharacterPanelChanger.CharacterType selectType =
        (CharacterPanelChanger.CharacterType)savedIndex;

        //nullチェック（安全対策）
        if (characterImages == null)
        {
            Debug.LogWarning("imageが設定されていません");
            return;
        }
        foreach (CharacterImege ci in characterImages)
        {
            if (ci.characterType == selectType)
            {
                characterImage.sprite = ci.sprite;
                return;
            }
        }
        Debug.LogWarning("対応する画像が見つかりません:" + selectedType);
    }
}


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
    [SerializeField] private Image CharacterImage;
    [SerializeField] private CharacterImage[] characterImages;

    void Start()
    {
        int savedIndex = PlayerPrefs.GetInt("SelectedCharacter", -1);
        if (savedIndex == -1)
        {
            Debug.LogWarning("選ばれたキャラが保存されていません");
            return;
        }
        CharacterPanelChanger.CharacterType selectType =
        (CharacterPanelChanger.CharacterType)savedIndex;

        foreach (Character ci in characterImages)
        {
            if (ci.characterType == selectType)
            {
                characterImages.sprite = ci.sprite;
                return;
            }
        }
        Debug.LogWarning("対応する画像が見つかりません:" + selectedType);
    }
}


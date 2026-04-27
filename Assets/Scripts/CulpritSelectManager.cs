using UnityEngine;
using UnityEngine.UI;

public class CulpritSelectManager : MonoBehaviour
{
    //キャラクターの種類を固定で定義
    public enum CharacterType
    {
        EngineerA,
        EngineerB,
        EngineerC,
        EngineerD,
        EngineerE,
        EngineerF,
        MarketerG,
        MarketerH,
        HRI,
        CEO
    }

    //キャラ1人分の情報
    [System.Serializable]
    public class CulpritButton
    {
        public CharacterType characterType;
        public Button button;
        public Image frameImage;
    }

    //全キャラ分の情報
    public CulpritButton[] culpritButtons;

    //通常時の枠画像
    public Sprite normalFrameSprite;

    //選択時の枠画像
    public Sprite selectedFrameSprite;

    //シーン移動
    public SceneLoader sceneLoader;

    //選択済みかどうか
    private bool isSelected = false;

    //現在選ばれているキャラ
    private CharacterType selectedCulprit;

    void Start()
    {
        ResetAllFrame();
        SetButtonEvents();
    }

    public void SelectCulprit(CharacterType characterType)
    {
        isSelected = true;
        selectedCulprit = characterType;

        foreach(CulpritButton cb in culpritButtons)
        {
            if (cb.frameImage == null) continue;

            if(cb.characterType == characterType)
            {
                cb.frameImage.sprite = selectedFrameSprite;
            }

            else
            {
                cb.frameImage.sprite = normalFrameSprite;
            }
        }
        Debug.Log("選択した犯人:" + selectedCulprit);
    }

    public void OnClickDecide()
    {
        if(!isSelected)
        {
            Debug.LogWarning("犯人が選択されていません");
            return;
        }

        PlayerPrefs.SetInt("SelectedCulprit", (int)selectedCulprit);
        PlayerPrefs.Save();

        Debug.Log("決定した犯人:" + selectedCulprit);

        //ここでシーンを分岐する
        if(selectedCulprit == CharacterType.EngineerA)
        {
            sceneLoader.SceneChangeTrueEnding();
        }
        else
        {
            sceneLoader.SceneChangeFalseEnding();
        }
    }

    private void ResetAllFrame()
    {
        foreach(CulpritButton cb in culpritButtons)
        {
            if(cb.frameImage != null)
            {
                cb.frameImage.sprite = normalFrameSprite;
            }
        }
    }

    private void SetButtonEvents()
    {
        foreach(CulpritButton cb in culpritButtons)
        {
            if (cb.button == null) continue;

            CharacterType type = cb.characterType;

            cb.button.onClick.RemoveAllListeners();
            cb.button.onClick.AddListener(() =>
            {
                SelectCulprit(type);
            });
        }
    }


}

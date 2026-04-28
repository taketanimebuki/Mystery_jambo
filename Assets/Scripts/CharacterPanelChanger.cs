using UnityEngine;

public class CharacterPanelChanger : MonoBehaviour
{
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
    
    [System.Serializable]
    public class CharacterPanel
    {
        public CharacterType characterType;
        public GameObject panel;
    }

    public CharacterPanel[] characterPanels;

    void Awake()
    {
        HideAllPanels();
    }

    public void ShowPanel(CharacterType type)
    {
        HideAllPanels();

        foreach(CharacterPanel cp in characterPanels)
        {
            if(cp.panel == null)
            {
                continue;
            }
            
            if(cp.characterType == type)
            {
                cp.panel.SetActive(true);
                
                CharacterConversationManager conversation =
                cp.panel.GetComponent<CharacterConversationManager>();

                if(conversation != null)
                {
                    conversation.ShowFirstComment();
                }
                return;
            }
        }
        Debug.LogWarning("該当するパネルがありません: " + type);
    }

    public void ShowPanelByIndex(int index)
    {
        if(index < 0 || index >= System.Enum.GetValues(typeof(CharacterType)).Length)
        {
            Debug.LogWarning("無効なインデックス:" + index);
            return;
        }

        ShowPanel((CharacterType)index);
    }


    public void HideAllPanels()
    {
        foreach(CharacterPanel cp in characterPanels)
        {
            if(cp.panel != null)
            {
                cp.panel.SetActive(false);
            }
        }
    }
}

using UnityEngine;

public class CharacterPanelChanger : MonoBehaviour
{
    [System.Serializable]
    public class CharacterPanel
    {
        public string characterName;
        public GameObject panel;
    }

    public CharacterPanel[] characterPanels;

    void Start()
    {
        HideAllPanels();
    }

    public void ShowPanel(string characterName)
    {
        HideAllPanels();

        foreach(CharacterPanel cp in characterPanels)
        {
            if(cp.characterName == characterName)
            {
                cp.panel.SetActive(true);
                return;
            }
        }
        Debug.LogWarning("該当するパネルがありません: " + characterName);
    }

    public void HideAllPanels()
    {
        foreach(CharacterPanel cp in characterPanels)
        cp.panel.SetActive(false);
    }
    
}

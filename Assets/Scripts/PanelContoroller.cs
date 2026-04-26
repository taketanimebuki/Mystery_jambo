using UnityEngine;

public class PanelContoroller : MonoBehaviour
{


    public GameObject[] panels; // すべてのパネル

    public void ShowPanel(int index)
    {
        // 全部非表示
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }

        // 指定されたパネルだけ表示
        panels[index].SetActive(true);
    }
}

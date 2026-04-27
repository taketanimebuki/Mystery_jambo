using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] panels; //パネル一覧
    private int currentIndex = 0;
    void Start()
    {
        ShowPanel(currentIndex);
    }

    public void ShowNextPanel()//次のパネルにすすむ
    {
        //最後のパネルかのチェック処理
        if (currentIndex >= panels.Length - 1)
        {
            Debug.Log("これ以上パネルはありません");
            return;
        }

        //次のパネルに進んで表示する
        currentIndex++;
        ShowPanel(currentIndex);
    }

    public void ShowPanel(int index) //パネルを表示する本体
    {

        //存在しない番号を防ぐ。
        if (index < 0 || index >= panels.Length)
        {
            Debug.LogWarning("指定したパネル番号が範囲外です");
            return;
        }
        for (int i = 0; i < panels.Length; i++) //全部切り替え。全パネルに対して選ばれたindex→true(表示)
        {
            if (panels[i] != null)
            {
                panels[i].SetActive(i == index);
            }
        }

        currentIndex = index;

    }

}

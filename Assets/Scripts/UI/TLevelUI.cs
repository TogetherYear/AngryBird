using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TLevelUI : MonoBehaviour
{
    public int lockStarCount = 10;

    public Button button;

    public Image background;

    public GameObject lockUI;

    public Text text;

    public int currentLevel;

    public void Show(int starCount)
    {
        if (starCount < lockStarCount)
        {
            button.enabled = false;
            lockUI.SetActive(true);
            text.text = $"{lockStarCount}";
            background.color = new Color(0.56f, 0.56f, 0.56f, 1.0f);
        }
        else
        {
            button.enabled = true;
            lockUI.SetActive(false);
            background.color = Color.white;
        }
    }

    public void OnClick()
    {
        TSelectUI.Instance.ShowCheckPoint(currentLevel);
    }
}

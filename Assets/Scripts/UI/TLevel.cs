using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TLevel : MonoBehaviour
{
    public int lockStartCount = 10;

    public Image background;

    public GameObject lockUI;

    public Text text;

    private void Start()
    {
        Show(10);
    }

    public void Show(int startCount)
    {
        if (startCount < lockStartCount)
        {
            lockUI.SetActive(true);
            text.text = $"{lockStartCount}";
            background.color = new Color(0.56f, 0.56f, 0.56f, 1.0f);
        }
        else
        {
            lockUI.SetActive(false);
            background.color = Color.white;
        }
    }
}

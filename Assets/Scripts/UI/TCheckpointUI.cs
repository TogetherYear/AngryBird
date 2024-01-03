using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TCheckpointUI : MonoBehaviour
{
    public List<Sprite> starts;

    public int current;

    public GameObject lockUI;

    public GameObject unLockUI;

    public Image startUI;

    public Text text;

    public Button button;

    public void Show(int pass, int startCount)
    {
        if (current > pass)
        {
            lockUI.SetActive(true);
            unLockUI.SetActive(false);
            button.enabled = false;
        }
        else
        {
            lockUI.SetActive(false);
            unLockUI.SetActive(true);
            text.text = $"{current + 1}";
            startUI.sprite = starts[Mathf.Clamp(startCount, 0, 3)];
        }
    }

    public void SetDefaultValues(int index)
    {
        current = index;
    }

    public void OnClick()
    {

    }
}

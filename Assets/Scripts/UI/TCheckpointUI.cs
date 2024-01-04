using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TCheckpointUI : MonoBehaviour
{
    public List<Sprite> stars;

    public int current;

    public GameObject lockUI;

    public GameObject unLockUI;

    public Image starUI;

    public Text text;

    public Button button;

    public void Show(int pass, int starCount)
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
            starUI.sprite = stars[Mathf.Clamp(starCount, 0, 3)];
        }
    }

    public void SetDefaultValues(int index)
    {
        current = index;
    }

    public void OnClick()
    {
        TGameManager.Instance.SetLastCheckpoint(current);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TStartScene : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1.0f);
        TSceneManager.Instance.LoadScene(TSceneKey.LevelSelect);
    }
}

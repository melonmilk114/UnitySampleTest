using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    public Button CardMoveSceneButton;
    public Button ChipMoveSceneButton;
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_IOS || UNITY_ANDROID
        Application.targetFrameRate = 60;
#else
        QualitySettings.vSyncCount = 1;
#endif

        CardMoveSceneButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("CardMoveScene");
        });

        ChipMoveSceneButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("ChipMoveScene");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

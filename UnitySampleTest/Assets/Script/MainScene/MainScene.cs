using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    public Button CardMoveSceneButton;
    // Start is called before the first frame update
    void Start()
    {
        CardMoveSceneButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("CardMoveScene");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

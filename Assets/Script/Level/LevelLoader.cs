using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]

public class LevelLoader : MonoBehaviour
{
    private Button button;

    public string LevelName;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onCLick);
    }

    private void onCLick()
    {
        SceneManager.LoadScene(LevelName);
    }
}

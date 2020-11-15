using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    private AsyncOperation asyncOperation = new AsyncOperation();
    private bool isLoadAllowed;
    [SerializeField] private Button startButton; 
    private void Start()
    {
        startButton.onClick.AddListener(AllowLoading);
        LoadSceneInBackGround();
    }
    private void AllowLoading()
    {
        asyncOperation.allowSceneActivation = true;
    }
    private void LoadSceneInBackGround()
    {
        asyncOperation = SceneManager.LoadSceneAsync(1);
        asyncOperation.allowSceneActivation = false;      
    }
}

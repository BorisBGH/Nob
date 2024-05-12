using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseWindow : MonoBehaviour
{
    [SerializeField] private Button _continueBtn;

    private void Awake()
    {
        _continueBtn.onClick.AddListener(Continue);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    private void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

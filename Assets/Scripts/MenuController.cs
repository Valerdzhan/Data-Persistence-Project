using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        // TODO: load data   
        SingleManager.Instance.LoadGame();
        nameInputField.text = SingleManager.Instance.playerName;
        nameInputField.textComponent.SetText(SingleManager.Instance.playerName);
        playerNameText.text = SingleManager.Instance.playerName;
        nameInputField.onValueChanged.AddListener(OnChangeValue);
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void OnChangeValue(string value)
    {
        playerNameText.text = value;
        SingleManager.Instance.OnChangePlayerName(value);
    }

    void Update()
    {
        bestScoreText.text = $"Best Score: {SingleManager.Instance.bestScore}";
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public PlayerController player;

    public TextMeshProUGUI currentGoldText, earnedGoldText, totalGoldText, sliderLevelText;

    [HideInInspector] public int sliderLevel = 1, gold;

    [SerializeField] private GameObject startGameUI, mainGameUI, loseGameUI, winGameUI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    private void Start()
    {
        SetGoldZeroOnStart();
        SetPlayerPrefs();
    }

    void Update()
    {
        switch (GameManager.Instance.CurrentGameState)
        {
            case GameState.PrepareGame:
                StartGameUI();
                UpdateGoldInfo();
                break;
            case GameState.MainGame:
                EqualCurrentGold();
                break;
            case GameState.LoseGame:
                break;
            case GameState.WinGame:
                break;
        }
    }

    public void StartGameUI()
    {
        startGameUI.SetActive(true);
        mainGameUI.SetActive(false);
        loseGameUI.SetActive(false);
        winGameUI.SetActive(false);
    }

    public void MainGameUI()
    {
        startGameUI.SetActive(false);
        mainGameUI.SetActive(true);
        loseGameUI.SetActive(false);
        winGameUI.SetActive(false);
    }

    public void LoseGameUI()
    {
        startGameUI.SetActive(false);
        mainGameUI.SetActive(false);
        loseGameUI.SetActive(true);
        winGameUI.SetActive(false);
    }

    public void WinGameUI()
    {
        startGameUI.SetActive(false);
        mainGameUI.SetActive(false);
        loseGameUI.SetActive(false);
        winGameUI.SetActive(true);
    }

    private void SetGoldZeroOnStart()
    {
        gold = 0;
    }

    private void EqualCurrentGold()
    {
        currentGoldText.text = gold.ToString();
    }

    public void UpdateGoldInfo()
    {
        earnedGoldText.text = currentGoldText.text;
        totalGoldText.text = PlayerPrefs.GetInt("TotalGold").ToString();
    }

    private void SetPlayerPrefs()
    {
        if (!PlayerPrefs.HasKey("TotalGold"))
        {
            PlayerPrefs.SetInt("TotalGold", gold);
        }

        if (!PlayerPrefs.HasKey("SliderLevel"))
        {
            PlayerPrefs.SetInt("SliderLevel", sliderLevel);
        }

        sliderLevelText.text = PlayerPrefs.GetInt("SliderLevel").ToString();
    }

    public IEnumerator DurationWinGameUI()
    {
        yield return new WaitForSeconds(2f);
        WinGameUI();
    }

    public IEnumerator DurationLoseGameUI()
    {
        yield return new WaitForSeconds(2f);
        LoseGameUI();
    }

    public void RetryButton()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void NextLevelButton()
    {
        PlayerPrefs.SetInt("SliderLevel", PlayerPrefs.GetInt("SliderLevel") + 1);
        sliderLevelText.text = PlayerPrefs.GetInt("SliderLevel").ToString();
        //LevelManager.Instance.NextLevel();
    }
}
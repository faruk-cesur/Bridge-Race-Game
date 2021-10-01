using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public PlayerController player;

    public TextMeshProUGUI currentGoldText,
        earnedGoldText,
        earnedGoldBonusText,
        getExtraGoldText,
        getGoldText,
        prepareTotalGoldText,
        winTotalGoldText,
        sliderLevelText;

    [HideInInspector] public int sliderLevel = 1, gold;

    [SerializeField] private GameObject _startGameUI,
        _mainGameUI,
        _loseGameUI,
        _winGameUI,
        _bonusPointArrow,
        _getGoldButton,
        _getBonusGoldButton,
        _bonusXArrow,
        _goldCoinPanel;

    [SerializeField] private List<GameObject> _goldenCoins;

    private bool _isBonusPointSelected;

    private float _anglerBonusArrowZ, _time = 1f;

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

    private void Update()
    {
        switch (GameManager.Instance.CurrentGameState)
        {
            case GameState.StartGame:
                StartGameUI();
                UpdateGoldInfo();
                break;
            case GameState.MainGame:
                UpdateGoldInfo();
                break;
            case GameState.LoseGame:
                break;
            case GameState.WinGame:
                UpdateGoldInfo();
                break;
        }
    }

    public void StartGameUI()
    {
        _startGameUI.SetActive(true);
        _mainGameUI.SetActive(false);
        _loseGameUI.SetActive(false);
        _winGameUI.SetActive(false);
    }

    public void MainGameUI()
    {
        _startGameUI.SetActive(false);
        _mainGameUI.SetActive(true);
        _loseGameUI.SetActive(false);
        _winGameUI.SetActive(false);
    }

    public void LoseGameUI()
    {
        _startGameUI.SetActive(false);
        _mainGameUI.SetActive(false);
        _loseGameUI.SetActive(true);
        _winGameUI.SetActive(false);
    }

    public void WinGameUI()
    {
        _startGameUI.SetActive(false);
        _mainGameUI.SetActive(false);
        _loseGameUI.SetActive(false);
        _winGameUI.SetActive(true);
    }


    public void UpdateGoldInfo()
    {
        CalculateBonusArrowRotation();
        currentGoldText.text = gold.ToString();
        earnedGoldText.text = currentGoldText.text;
        prepareTotalGoldText.text = PlayerPrefs.GetInt("TotalGold").ToString();
        winTotalGoldText.text = PlayerPrefs.GetInt("TotalGold").ToString();
    }


    public IEnumerator DurationWinGameUI()
    {
        yield return new WaitForSeconds(2f);
        WinGameUI();
    }

    public IEnumerator DurationLoseGameUI()
    {
        yield return new WaitForSeconds(2f);
        SoundManager.Instance.PlaySound(SoundManager.Instance.loseGameSound, 1f);
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
        StartCoroutine(LevelManager.Instance.NextLevel());
    }


    public void GetBonusGoldXButton()
    {
        foreach (var goldenCoin in _goldenCoins)
        {
            goldenCoin.SetActive(true);
            goldenCoin.transform.DOLocalMove(new Vector3(38.7f, -50f, 0), _time);
            _time += 0.05f;
        }

        if (_anglerBonusArrowZ <= 360 && _anglerBonusArrowZ >= 306f)
        {
            PlayerPrefs.SetInt("TotalGold", gold * 2 + PlayerPrefs.GetInt("TotalGold"));
        }

        if (_anglerBonusArrowZ < 306f && _anglerBonusArrowZ >= 250f)
        {
            PlayerPrefs.SetInt("TotalGold", gold * 3 + PlayerPrefs.GetInt("TotalGold"));
        }

        if (_anglerBonusArrowZ < 250f && _anglerBonusArrowZ >= 202f)
        {
            PlayerPrefs.SetInt("TotalGold", gold * 4 + PlayerPrefs.GetInt("TotalGold"));
        }

        if (_anglerBonusArrowZ < 202f && _anglerBonusArrowZ >= 180f)
        {
            PlayerPrefs.SetInt("TotalGold", gold * 5 + PlayerPrefs.GetInt("TotalGold"));
        }

        _getGoldButton.SetActive(false);
        _getBonusGoldButton.SetActive(false);
        _bonusXArrow.SetActive(false);
        NextLevelButton();
    }

    public void GetGoldButton()
    {
        foreach (var goldenCoin in _goldenCoins)
        {
            goldenCoin.SetActive(true);
            goldenCoin.transform.DOLocalMove(new Vector3(38.7f, -50f, 0), _time);
            _time += 0.05f;
        }

        PlayerPrefs.SetInt("TotalGold", gold + PlayerPrefs.GetInt("TotalGold"));
        _getGoldButton.SetActive(false);
        _getBonusGoldButton.SetActive(false);
        _bonusXArrow.SetActive(false);
        NextLevelButton();
    }

    private void CalculateBonusArrowRotation()
    {
        var anglerZ = _bonusPointArrow.transform.localEulerAngles.z;
        _anglerBonusArrowZ = anglerZ;
        if (anglerZ <= 360 && anglerZ >= 306f)
        {
            earnedGoldBonusText.text = (gold * 2).ToString();
            getExtraGoldText.text = "GET EXTRA X2";
        }

        if (anglerZ < 306f && anglerZ >= 250f)
        {
            earnedGoldBonusText.text = (gold * 3).ToString();
            getExtraGoldText.text = "GET EXTRA X3";
        }

        if (anglerZ < 250f && anglerZ >= 202f)
        {
            earnedGoldBonusText.text = (gold * 4).ToString();
            getExtraGoldText.text = "GET EXTRA X4";
        }

        if (anglerZ < 202f && anglerZ >= 180f)
        {
            earnedGoldBonusText.text = (gold * 5).ToString();
            getExtraGoldText.text = "GET EXTRA X5";
        }
    }

    private void SetGoldZeroOnStart()
    {
        gold = 0;
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
}
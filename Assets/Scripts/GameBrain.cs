using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class GameBrain : MonoBehaviour
{
    [Header("Custom Settings")]
    [SerializeField] private float _easySecondsTime;
    [SerializeField] private float _mediumSecondsTime;
    [SerializeField] private float _hardSecondsTime;

    [Header("Main Tools")]
    [SerializeField] private RecordWriter _recordWriter;
    [SerializeField] private GamemodeChanger _gamemode;
    [SerializeField] private ManagerUI _ui;
    [SerializeField] private LoseScreen _loseScreen;
    [SerializeField] private Timer _timer;
    [SerializeField] private GiftSpawner _giftSpawner;
    [SerializeField] private PlayerSpawn _playerSpawn;

    [Header("Other Tools")]
    [SerializeField] private GameObject _personCam;
    [SerializeField] private GameObject _haggyVaggy;

    [Header("Buttons")]
    [SerializeField] private Button _startGameButton;


    private void OnEnable()
    {
        _startGameButton.onClick.AddListener(StartGame);
        _timer.TimeOutEvent += EndGame;
        YandexGame.GetDataEvent += GetLoad;
    }

    private void OnDisable()
    {
        _startGameButton.onClick.RemoveListener(StartGame);
        _timer.TimeOutEvent -= EndGame;
        YandexGame.GetDataEvent -= GetLoad;
    }

    private void Start()
    {
        if (YandexGame.SDKEnabled)
            GetLoad();
    }

    private void StartGame()
    {
        _playerSpawn.Spawn();
        _ui.OpenGameScreen();
        SoundManager.Translate();

        _personCam.SetActive(true);
        _haggyVaggy.SetActive(false);

        switch (_gamemode.CurrentGamemode)
        {
            case Gamemode.Easy:
                _timer.StartTimer(_easySecondsTime, _gamemode.CurrentGamemode);
                break;
            case Gamemode.Medium:
                _timer.StartTimer(_mediumSecondsTime, _gamemode.CurrentGamemode);
                break;
            case Gamemode.Hard:
                _timer.StartTimer(_hardSecondsTime, _gamemode.CurrentGamemode);
                break;
            default:
                break;
        }
    }

    public void OpenURL(string URL)
    {
        Application.OpenURL(URL);
    }

    public void EndGame()
    {
        SoundManager.End();
        _ui.OpenLoseScreen();

        int currentRecord = 0;
        int currentScore = _giftSpawner.Score;

        int easy = _recordWriter.CurrentEasyModeRecord;
        int medium = _recordWriter.CurrentMediumModeRecord;
        int hard = _recordWriter.CurrentHardModeRecord;

        switch (_gamemode.CurrentGamemode)
        {
            case Gamemode.Easy:
                currentRecord = easy;

                if(currentScore > currentRecord)
                    _recordWriter.LoadData(currentScore, medium, hard);

                break;
            case Gamemode.Medium:
                currentRecord = medium;

                if (currentScore > currentRecord)
                    _recordWriter.LoadData(easy, currentScore, hard);

                break;
            case Gamemode.Hard:

                if (currentScore > currentRecord)
                    _recordWriter.LoadData(easy, medium, currentScore);

                currentRecord = hard;
                break;
            default:
                break;
        }

        _loseScreen.LoadLoseScreen(currentScore, currentRecord);

        Save();
    }

    public void Save()
    {
        YandexGame.savesData.EasyModeRecord = _recordWriter.CurrentEasyModeRecord;
        YandexGame.savesData.MediumModeRecord = _recordWriter.CurrentMediumModeRecord;
        YandexGame.savesData.HardModeRecord = _recordWriter.CurrentHardModeRecord;

        YandexGame.SaveProgress();
    }

    public void Load() => YandexGame.LoadProgress();

    public void GetLoad()
    {
        _recordWriter.LoadData(
            YandexGame.savesData.EasyModeRecord,
            YandexGame.savesData.MediumModeRecord,
            YandexGame.savesData.HardModeRecord
            );
    }

    public void ReloadGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int currentSceneBuildIndex = currentScene.buildIndex;

        SceneManager.LoadScene(currentSceneBuildIndex);
    }
}
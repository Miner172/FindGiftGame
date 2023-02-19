using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class GamemodeChanger : MonoBehaviour
{
    [SerializeField] private Text _buttonText;

    [SerializeField] private Color _easyColor;
    [SerializeField] private Color _mediumColor;
    [SerializeField] private Color _hardColor;

    private Gamemode _currentGamemode;
    private Button _changeButton;
    private int _currentGameodeId;

    public Gamemode CurrentGamemode => _currentGamemode;

    private void OnEnable()
    {
        _changeButton.onClick.AddListener(ChangeGameMode);
    }

    private void OnDisable()
    {
        _changeButton.onClick.RemoveListener(ChangeGameMode);
    }

    private void Awake()
    {
        _changeButton = GetComponent<Button>();

        _currentGameodeId = -1;

        ChangeGameMode();
    }

    public void ChangeGameMode()
    {
        _currentGameodeId++;

        if (_currentGameodeId > 2)
            _currentGameodeId = 0;

        switch (_currentGameodeId)
        {
            case 0:
                _buttonText.color = _easyColor;
                _currentGamemode = Gamemode.Easy;
                break;
            case 1:
                _buttonText.color = _mediumColor;
                _currentGamemode = Gamemode.Medium;
                break;
            case 2:
                _buttonText.color = _hardColor;
                _currentGamemode = Gamemode.Hard;
                break;
            default:
                break;
        }

        _buttonText.text = $"Режим: {_currentGamemode}";
    }

    public Color GetColorToGameMode()
    {
        Color gamomodeColor;

        switch (_currentGameodeId)
        {
            case 0:
                gamomodeColor = _easyColor;
                break;
            case 1:
                gamomodeColor = _mediumColor;
                break;
            case 2:
                gamomodeColor = _hardColor;
                break;
            default:
                gamomodeColor = Color.white;
                break;
        }

        return gamomodeColor;
    }
}
public enum Gamemode
{
    Easy = 1,
    Medium = 2,
    Hard = 3
}

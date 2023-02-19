using UnityEngine;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] Text _gamemodeText;
    [SerializeField] Text _currentScoreText;
    [SerializeField] Text _recordScoreText;

    [Header("Other Tools")]
    [SerializeField] private GamemodeChanger _gamemode;

    public void LoadLoseScreen(int currentScore, int recordScore)
    {
        _currentScoreText.text = $"��� ����: {currentScore}";
        _recordScoreText.text = $"��� ������ � ���� ������: {recordScore}";

        _gamemodeText.color = _gamemode.GetColorToGameMode();
        _gamemodeText.text = $"�����: {_gamemode.CurrentGamemode}";
    }
}

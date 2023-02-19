using UnityEngine;
using UnityEngine.UI;

public class RecordWriter : MonoBehaviour
{
    [SerializeField] private Text _easyModeText;
    [SerializeField] private Text _mediumModeText;
    [SerializeField] private Text _hardModeText;

    private int _currentEasyModeRecord;
    private int _currentMediumModeRecord;
    private int _currentHardModeRecord;

    public int CurrentEasyModeRecord => _currentEasyModeRecord;
    public int CurrentMediumModeRecord => _currentMediumModeRecord;
    public int CurrentHardModeRecord => _currentHardModeRecord;

    public void LoadData(int easyMode, int mediumMode, int hardMode)
    {
        _currentEasyModeRecord = easyMode;
        _currentMediumModeRecord = mediumMode;
        _currentHardModeRecord = hardMode;

        _easyModeText.text = $"Легкий: {_currentEasyModeRecord}";
        _mediumModeText.text = $"Средний: {_currentMediumModeRecord}";
        _hardModeText.text = $"Сложный: {_currentHardModeRecord}";
    }
}

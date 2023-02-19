using StarterAssets;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    [Header("Screens")]
    [SerializeField] private CanvasAnim _menu;
    [SerializeField] private CanvasAnim _game;
    [SerializeField] private CanvasAnim _pause;
    [SerializeField] private CanvasAnim _lose;
    [SerializeField] private CanvasAnim _rules;

    [Header("Input")]
    [SerializeField] private StarterAssetsInputs _input;

    private bool _isPause;
    private bool _canOpenPauseScreen;

    private void Start()
    {
        OpenMenuScreen();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Tab) && _canOpenPauseScreen)
            OpenPauseScreen();
    }

    private void Pause(bool flag)
    {
        _isPause = flag;

        if (_isPause)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    private void HideCursor(bool flag)
    {
        _input.SetCursorState(flag);
        _input.SetCuresorInputState(flag);
    }

    public void OpenRulesScreen()
    {
        _rules.Open();
    }

    public void CloseRulesScreen()
    {
        _rules.Close();
    }

    public void OpenMenuScreen()
    {
        _menu.Open();

        _canOpenPauseScreen = false;
        HideCursor(false);
        Pause(false);
    }

    public void OpenGameScreen()
    {
        _menu.Close();
        _game.Open();

        _canOpenPauseScreen = true;
        HideCursor(true);
        Pause(false);
    }

    public void OpenPauseScreen()
    {
        _pause.Open();

        HideCursor(false);
        Pause(true);
    }

    public void ClosePauseScreen()
    {
        _pause.Close();

        HideCursor(true);
        Pause(false);
    }

    public void OpenLoseScreen()
    {
        _lose.Open();

        HideCursor(false);
        Pause(true);
    }
}

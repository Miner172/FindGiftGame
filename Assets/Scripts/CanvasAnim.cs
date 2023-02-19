using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Canvas))]
public class CanvasAnim : MonoBehaviour
{
    private Animator _anim;
    private Canvas _canvas;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _canvas = GetComponent<Canvas>();

        _canvas.enabled = false;
    }

    public void Open()
    {
        _canvas.enabled = true;
        _anim.SetTrigger("Open");

        StopAllCoroutines();
    }

    public void Close()
    {
        _anim.SetTrigger("Close");
        StartCoroutine(WaitAnim());
    }

    private IEnumerator WaitAnim()
    {
        yield return new WaitForSecondsRealtime(1);
        _canvas.enabled = false;
    }
}

using System.Collections;
using UnityEngine;

public class GiftSpawpoint : MonoBehaviour
{
    private bool _isFree = true;

    public bool IsFree => _isFree;

    public Vector3 GetPosition()
    {
        _isFree = false;

        return transform.position;
    }

    public void ReLoad()
    {
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        _isFree = true;
    }
}

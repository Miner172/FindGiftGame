using UnityEngine;

public class Look : MonoBehaviour
{
    [SerializeField] private float _rayDistance;
    [SerializeField] private float _touchDelay;
    [SerializeField] private Animator _anim;

    private float _currentTouchTime = 0;

    private void FixedUpdate()
    {
        Ray lookAtRay = new Ray(transform.position, transform.forward);
        _currentTouchTime += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (_currentTouchTime >= _touchDelay)
            {
                _currentTouchTime = 0;
                _anim.SetTrigger("Grab");

                if (Physics.Raycast(lookAtRay, out RaycastHit hit1, _rayDistance))
                    Touch(hit1);
            }
        }
    }

    private void Touch(RaycastHit hit)
    {
        GameObject obj = hit.transform.gameObject;

        if (obj.TryGetComponent(out Gift item))
            item.Found();
    }
}

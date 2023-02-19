using UnityEngine;

public class Gift : MonoBehaviour
{
    private GiftSpawner _spawner;
    private GiftSpawpoint _spawnpoint;

    public void Spawn(GiftSpawpoint spawnpoint, GiftSpawner spawner)
    {
        gameObject.SetActive(true);

        _spawner = spawner;
        _spawnpoint = spawnpoint;
        transform.position = _spawnpoint.GetPosition();
    }

    public void Found()
    {
        gameObject.SetActive(false);

        _spawnpoint.ReLoad();
        _spawner.OneGiftFound(this);
    }
}

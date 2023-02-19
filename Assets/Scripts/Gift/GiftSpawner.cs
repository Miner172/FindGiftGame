using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftSpawner : MonoBehaviour
{
    [SerializeField] private List<GiftSpawpoint> _spawnpoints;
    [SerializeField] private List<Gift> _gifts;
    [SerializeField] private Text _scoreText;
    [SerializeField] private ParticleSystem _giftFoundParticle;
    private int _score;

    public int Score => _score;

    private void Start()
    {
        ActiveSpawner();
        _scoreText.text = $"{_score}";
    }

    public void ActiveSpawner()
    {
        for (int i = 0; i < _gifts.Count; i++)
        {
            for (int j = 0; j < _spawnpoints.Count; j++)
            {
                if (_spawnpoints[j].IsFree)
                {
                    _gifts[i].Spawn(_spawnpoints[j], this);
                    break;
                }
            }
        }
    }

    public void OneGiftFound(Gift gift)
    {
        _score++;
        _scoreText.text = $"{_score}";
        _giftFoundParticle.Play();
        SoundManager.GiftFound();

        for (int i = 0; i < _spawnpoints.Count; i++)
        {
            if (_spawnpoints[i].IsFree)
            {
                gift.Spawn(_spawnpoints[i], this);
                break;
            }
        }
    }
}

using UnityEngine;

public class CoinChase : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField, Tooltip("Min dist from coin to pick it up")] private float _pickupDist = 0.5f;
    [SerializeField, Tooltip("Timer (seconds) for game")] private float _timelimit = 30f;
    [SerializeField, Tooltip("-range to +range for random coin spawn")] private float _range = 4f;
    private int _score;
    private float _timeLeft;
    private bool _gameOver;

    void Start()
    {
        _timeLeft = _timelimit;
        MoveToRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if(_gameOver)
        {
            return;
        }

        _timeLeft -= Time.deltaTime; // delta.time = number of second between the start of the previous frame and the start of the current one
        if(_timeLeft <= 0f)
        {
            _gameOver = true;
            Debug.Log("Time's up. Final score: " + _score);
        }
        if (Vector2.Distance(transform.position, _player.position) <= _pickupDist)
        {
            _score++;
            Debug.Log("Score: " + _score);
            MoveToRandomPosition();
        }
    }

    private void MoveToRandomPosition()
    {
        float x = Random.Range(-_range, _range);
        float y = Random.Range(-_range, _range);
        transform.position = new Vector3(x, y, transform.position.z); // Keeps the original Z

    }
}

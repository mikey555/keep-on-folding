using System;
using UnityEngine;

public class PuzzleSpawner : MonoBehaviour
{
    [SerializeField] Puzzle _puzzlePrefab;
    [SerializeField] Transform _puzzleSpawnTransform;
    [SerializeField] Transform _puzzleParent;
    bool _isSpawning;

    Puzzle _currentPuzzle;
    public Puzzle CurrentPuzzle
    {
        get { return _currentPuzzle; }
        set { _currentPuzzle = value; }
    }

    public static event Action<Puzzle> OnNewPuzzleSpawned;

    private void Awake()
    {
        _puzzleParent = GetComponentInParent<Canvas>().transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        _isSpawning = false;
    }

    private void OnEnable()
    {

        GameManager.OnTransitionToGameplay += EnableSpawning;
        GameManager.OnStartGameplay += SpawnNewPuzzle;
        PuzzleAnimation.OnExitAnimationComplete += SpawnNewPuzzle;
        GameManager.OnGameOver += DisableSpawning;
        GameManager.OnGameOver += DestroyCurrentPuzzle;
    }

    private void OnDisable()
    {
        GameManager.OnTransitionToGameplay -= EnableSpawning;
        GameManager.OnStartGameplay -= SpawnNewPuzzle;
        PuzzleAnimation.OnExitAnimationComplete -= SpawnNewPuzzle;
        GameManager.OnGameOver -= DisableSpawning;
        GameManager.OnGameOver -= DestroyCurrentPuzzle;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnNewPuzzle()
    {

        if (!_isSpawning) return;
        if (CurrentPuzzle != null)
            UnityEngine.Object.Destroy(CurrentPuzzle.gameObject);
        var next = Instantiate<Puzzle>(_puzzlePrefab, _puzzleSpawnTransform.position, Quaternion.identity, _puzzleParent);
        next.gameObject.SetActive(true);
        CurrentPuzzle = next;
        OnNewPuzzleSpawned?.Invoke(CurrentPuzzle);
    }

    public void DestroyCurrentPuzzle()
    {
        GameObject.Destroy(_currentPuzzle.gameObject);
        _currentPuzzle = null;
    }

    public void EnableSpawning()
    {
        _isSpawning = true;
    }

    public void DisableSpawning()
    {
        _isSpawning = false;
    }
}

public interface IGetNewPuzzle
{
    public void GetNewPuzzle(Puzzle puzzle);
}

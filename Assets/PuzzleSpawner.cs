using System;
using UnityEngine;

public class PuzzleSpawner : MonoBehaviour
{
    [SerializeField] Puzzle _puzzlePrefab;
    [SerializeField] Transform _puzzleSpawnTransform;
    [SerializeField] Transform _puzzleParent;

    Puzzle _currentPuzzle;
    public Puzzle CurrentPuzzle
    {
        get { return _currentPuzzle; }
        set { _currentPuzzle = value; }
    }

    public static event Action<Puzzle> OnNewPuzzleSpawned;

    private void Awake()
    {
        _puzzleParent = transform;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        GameManager.OnStartGameplay += SpawnNewPuzzle;
        UnfoldedDieAnimation.OnExitAnimationComplete += SpawnNewPuzzle;
        GameManager.OnGameOver += DestroyCurrentPuzzle;
    }

    private void OnDisable()
    {
        UnfoldedDieAnimation.OnExitAnimationComplete -= SpawnNewPuzzle;
        GameManager.OnGameOver -= DestroyCurrentPuzzle;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnNewPuzzle()
    {

        if (GameManager.Instance.FoldingGameState == GameManager.GameState.GameOverScreen) return;
        if (CurrentPuzzle != null)
            UnityEngine.Object.Destroy(CurrentPuzzle.gameObject);
        // TODO: RectTransform here is missing on replay (reloading scene)
        // TODO: typing still possible during game over. extract answer text field from UIManager.
        var next = Instantiate<Puzzle>(_puzzlePrefab, _puzzleSpawnTransform.position, Quaternion.identity, _puzzleParent);
        next.gameObject.SetActive(true);
        CurrentPuzzle = next;
        OnNewPuzzleSpawned?.Invoke(CurrentPuzzle);
    }

    public void DestroyCurrentPuzzle()
    {
        GameObject.Destroy(_currentPuzzle.gameObject);
    }
}

public interface IGetNewPuzzle
{
    public void GetNewPuzzle(Puzzle puzzle);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using static ExtensionMethods.TransformExtensions;

/// <summary>
/// Responsible for animating time-dependent components such as chained animations. 
/// Components should subscribe to events as much as possible.
/// </summary>
public class TransitionDirector : MonoBehaviour
{
    [SerializeField] ModalScreenAnimation _startScreenModalAnim;
    [SerializeField] ModalScreenAnimation _gameOverModalAnim;
    [SerializeField] Image _backgroundLayer; // e.g., grey semi-transparent panel
    [SerializeField] Timer _countdownTimer;

    [SerializeField] BottomPanelAnimation _bottomPanelAnim;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        GameManager.OnGoToStartScreen += TransitionToStartScreen;
        GameManager.OnGameOver += TransitionToGameOverScreen;
    }

    private void OnDisable()
    {
        GameManager.OnGoToStartScreen -= TransitionToStartScreen;
        // TODO: link up start buttons
        // GameManager.OnStartGameplay -= StartGameplay;

        GameManager.OnGameOver -= TransitionToGameOverScreen;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TransitionToStartScreen()
    {
        _startScreenModalAnim.EaseInFromRight();
    }

    void TransitionToGameplay(ModalScreenAnimation modalAnim)
    {
        var duration = 0.5f;
        var seq = modalAnim.EaseOutToLeft();
        seq.Join(_backgroundLayer.DOColor(Color.clear, duration))
            .AppendCallback(() =>
            {
                _bottomPanelAnim.Show();
                modalAnim.gameObject.SetActive(false);
                _backgroundLayer.gameObject.SetActive(false);
                _countdownTimer.InitAndStart();
            })
            .InsertCallback(4f, () =>
            {
                GameManager.Instance.StartGameplay();
            });
    }

    public void TransitionFromStartScreenToGameplay()
    {
        TransitionToGameplay(_startScreenModalAnim);
    }

    public void TransitionFromGameOverToGameplay()
    {
        TransitionToGameplay(_gameOverModalAnim);
    }

    public void TransitionToGameOverScreen()
    {
        _gameOverModalAnim.EaseInFromRight();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TimeChangeNotifier : MonoBehaviour
{
    [SerializeField] Transform _spawnTransform;
    [SerializeField] Text numberChange;
    Vector3 _spawnPoint;
    // Start is called before the first frame update

    void Awake()
    {

    }

    void Start()
    {
        _spawnPoint = _spawnTransform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        PlayerActions.OnSubmit += ShowBonusTimeModification;
        PlayerActions.OnSkip += ShowPenaltyTimeModification;
    }

    private void OnDisable()
    {
        PlayerActions.OnSubmit -= ShowBonusTimeModification;
        PlayerActions.OnSkip -= ShowPenaltyTimeModification;
    }

    public void ShowTimeModification(float val, bool isPenalty = false)
    {
        var numText = GameObject.Instantiate<Text>(numberChange, _spawnTransform);
        var signString = "";
        Color startColor;
        if (!isPenalty)
        {
            signString = "+";
            startColor = Color.green;
        }
        else
        {
            signString = "-";
            startColor = Color.red;
        }
        var endColor = new Color(startColor.r, startColor.b, startColor.g, 0);
        numText.color = startColor;
        numText.text = signString + val.ToString();
        numText.gameObject.SetActive(true);
        Sequence fadeOut = DOTween.Sequence();
        fadeOut
            .Append(numText.transform.DOMoveY(numText.transform.position.y + 20, 1f))
            .Join(numText.DOColor(endColor, 2f))
            .OnComplete(() =>
            {
                GameObject.Destroy(numText);
            });
    }

    public void ShowBonusTimeModification()
    {
        ShowTimeModification(Constants.CORRECT_ANSWER_TIME_BONUS, false);
    }

    public void ShowPenaltyTimeModification()
    {
        ShowTimeModification(Constants.SKIP_TIME_PENALTY, true);
    }
}

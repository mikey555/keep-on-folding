using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using UnityEngine.UI;

public class DirectorController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TimelineAsset _onStartGameClickedTimeline;
    PlayableDirector _playableDirector;

    // panels to be animated are children of the canvas
    [SerializeField] Canvas _modalCanvas;
    [SerializeField] GameObject _startScreenModal;
    [SerializeField] GameObject _gameOverModal;
    GameObject _modalBackground;



    void Awake()
    {
        _playableDirector = GetComponent<PlayableDirector>();
    }
    void Start()
    {

    }

    private void OnEnable()
    {
        // GameManager.OnGameOver += SetToGameOverPlayable;
        // GameManager.OnGoToStartScreen += PlayStartGamePlayableAsset;
    }

    private void OnDisable()
    {
        // GameManager.OnGameOver -= SetToGameOverPlayable;
        // GameManager.OnGoToStartScreen -= PlayStartGamePlayableAsset;
    }

    // public void SetToGameOverPlayable()
    // {
    //     // var panelBinding = _playableDirector.GetGenericBinding(_bottomPanel)
    //     // _playableDirector.playableAsset = _onPlayAgainClickedPlayable;
    //     // _playableDirector.SetGenericBinding(_bottomPanel, );
    //     // _playableDirector.playableAsset.outputs
    // }
    public void PlayGameOverPlayableAsset()
    {
        BindGameObjectToTrack(_onStartGameClickedTimeline, "UIModalAnim", _gameOverModal);
        BindGameObjectToTrack(_onStartGameClickedTimeline, "UIModalActive", _gameOverModal);
        _playableDirector.Play(_onStartGameClickedTimeline);
    }

    public void PlayStartGamePlayableAsset()
    {
        BindGameObjectToTrack(_onStartGameClickedTimeline, "UIModalAnim", _startScreenModal);
        BindGameObjectToTrack(_onStartGameClickedTimeline, "UIModalActive", _startScreenModal);
        _playableDirector.Play(_onStartGameClickedTimeline);
    }

    void BindGameObjectToTrack(TimelineAsset timelineAsset, string trackName, GameObject outputObj)
    {
        // Get the list of output tracks from the timeline asset.
        var trackList = timelineAsset.GetOutputTracks();

        // Loop through the output tracks and set the binding for each one.
        foreach (var track in trackList)
        {
            // Check to see if the track is the one we want to bind.
            if (track.name == trackName)
            {
                // Set the binding to our GameObject.
                _playableDirector.SetGenericBinding(track, outputObj);
            }
        }
    }


}

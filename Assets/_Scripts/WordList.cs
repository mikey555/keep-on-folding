using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;

public class WordList : MonoBehaviour
{
    [SerializeField] TextAsset wordListJson;
    List<string[]> _words;
    public List<string[]> Words
    {
        get
        {
            return _words;
        }
    }

    void Awake()
    {

        this.Init();
    }

    void Start()
    {

    }

    public void Init()
    {

        // WordListAsset wordList = WordListAsset.CreateFromJSON(wordListJson.text);
        var wordList = JsonConvert.DeserializeObject<WordListAsset>(wordListJson.text);
        this._words = wordList.wordArrays.ToList<string[]>();
    }

    public string[] GetWordPossibilities()
    {
        if (_words.Count == 0)
        {
            // TODO: you win, no more words

        }
        var index = UnityEngine.Random.Range(0, _words.Count);
        var wordArray = _words[index];
        _words.Remove(wordArray);
        Debug.Log(wordArray[0]);
        return wordArray;
    }
}

[System.Serializable]
public class WordListAsset
{
    [SerializeField]
    public string[][] wordArrays;

    public static WordListAsset CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<WordListAsset>(jsonString);
    }
}

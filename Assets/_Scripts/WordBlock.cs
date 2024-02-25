using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace _Scripts
{
    public class WordBlock : MonoBehaviour
    {
        public string word;
        private List<Vector2> _letterBlockPositions;

        [SerializeField] GameObject letterBlockPrefab;

        private void Start()
        {
            Init(word);   
        }

        private void Update()
        {
        
        }

        public void RegenerateLetterBlocks()
        {
            foreach (var child in GetComponentsInChildren<LetterBlock>())
            {
                Destroy(child.gameObject);
            }
            Init(word);
        }


        public void Init(string inputWord)
        {
            word = inputWord;
            _letterBlockPositions = GenerateWordBlockCellPositions(inputWord.Length);
            for (var i = 0; i < _letterBlockPositions.Count; i++)
            {
                var l = word[i].ToString();
                var lb = Instantiate(letterBlockPrefab, transform).GetComponent<LetterBlock>();
                if (Camera.main != null)
                {
                    lb.GetComponent<RectTransform>().position = _letterBlockPositions[i] * 100;
                }
                lb.Init(l);
            }
        }

        private List<Vector2> GenerateWordBlockCellPositions(int count)
        {
            var positions = new List<Vector2>();
            var directions = new List<Vector2> { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
            for (var i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    positions.Add(Vector2.zero);
                    continue;
                }
                // pick a random cell to spawn a cell next to
                var cellFound = false;
                var retriesAttempted = 0;
                while (!cellFound)
                {
                    var randomCell = positions[Random.Range(0, positions.Count)];
                    var randomDir = directions[Random.Range(0, directions.Count)];
                    var newCell = randomCell + randomDir;
                    if (!positions.Contains(newCell))
                    {
                        positions.Add(newCell);
                        cellFound = true;
                        continue;
                    }
                    retriesAttempted += 1;
                    if (retriesAttempted >= 100) throw new Exception("Too many attempts"); 
                }
            }
            foreach (var pos in positions)
            {   
                print(pos);
            }
            return positions;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;
    public List<GameObject> levels;
    public List<LevelPieceBaseSetup> levelPieceBaseSetups;

    public float timeBetweenPieces = .3f;

    [SerializeField] private int _index;
    private GameObject _currentLevel;

    [SerializeField] private List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();
    private LevelPieceBaseSetup _currentSetup;

    private void Start()
    {
        CreateLevelPieces();
    }

    private void SpawNextLevel()
    {
        if (_currentLevel != null)
        {
            Destroy(_currentLevel);
            _index++;

            if (_index >= levels.Count)
            {
                ResetLevelIndex();
            }
        }
        _currentLevel = Instantiate(levels[_index], container);
        _currentLevel.transform.localPosition = Vector3.zero;
    }

    private void ResetLevelIndex()
    {
        _index = 0;
    }

    void CreateLevelPieces()
    {
        CleanSpawnedPieces();

        if (_index >= levelPieceBaseSetups.Count)
        {
            ResetLevelIndex();
        }
        _currentSetup = levelPieceBaseSetups[_index];

        for (int i = 0; i < _currentSetup.pieceStartNumber; i++)
        {
            CreateLevelPiece(_currentSetup.levelsPiecesStart);
        }

        for (int i = 0; i < _currentSetup.pieceNumber; i++)
        {
            CreateLevelPiece(_currentSetup.levelsPieces);
        }

        for (int i = 0; i < _currentSetup.pieceEndNumber; i++)
        {
            CreateLevelPiece(_currentSetup.levelsPiecesEnd);
        }

        ColorManager.Instance.ChangeColorByType(_currentSetup.artType);
    }

    void CreateLevelPiece(List<LevelPieceBase> list)
    {
        if (list == null || list.Count == 0)
        {
            Debug.LogWarning("List is null or empty in CreateLevelPiece");
            return;
        }

        var piece = list[Random.Range(0, list.Count)];
        var spawnedPiece = Instantiate(piece, container);

        if (_spawnedPieces.Count > 0)
        {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];
            spawnedPiece.transform.position = lastPiece.endPiece.position;
        }
        else
        {
            spawnedPiece.transform.localPosition = Vector3.zero;
        }

        foreach (var p in spawnedPiece.GetComponentsInChildren<ArtPiece>())
        {
            var artSetup = ArtManager.Instance.GetSetupByType(_currentSetup.artType);
            if (artSetup != null)
            {
                p.ChangePiece(artSetup.gameObject);
            }
            else
            {
                Debug.LogWarning("ArtSetup is null in CreateLevelPiece");
            }
        }

        _spawnedPieces.Add(spawnedPiece);
    }

    void CleanSpawnedPieces()
    {
        for (int i = _spawnedPieces.Count - 1; i >= 0; i--)
        {
            Destroy(_spawnedPieces[i].gameObject);
        }

        _spawnedPieces.Clear();
    }

    IEnumerator CreatelevelCoroutine()
    {
        _spawnedPieces = new List<LevelPieceBase>();

        for (int i = 0; i < _currentSetup.pieceNumber; i++)
        {
            CreateLevelPiece(_currentSetup.levelsPieces);
            yield return new WaitForSeconds(timeBetweenPieces);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            SpawNextLevel();
        }
    }
}
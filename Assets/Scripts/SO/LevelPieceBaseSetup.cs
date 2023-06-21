using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelPieceBaseSetup : ScriptableObject
{
    public ArtManager.ArtType artType;

    [Header("Pieces")]
    public List<LevelPieceBase> levelsPiecesStart;
    public List<LevelPieceBase> levelsPieces;
    public List<LevelPieceBase> levelsPiecesEnd;

    public int pieceStartNumber = 3;
    public int pieceNumber = 5;
    public int pieceEndNumber = 1;
}

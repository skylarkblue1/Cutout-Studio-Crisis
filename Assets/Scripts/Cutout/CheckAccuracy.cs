using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckAccuracy : MonoBehaviour {
    [SerializeField] private LineRenderer guideline;
    [SerializeField] private LineRenderer drawing;

    private int _score;
    
    public int CalculateScore() {
        _score = 0;
        Vector3[] guidelinePositions = new Vector3[guideline.positionCount];
        guideline.GetPositions(guidelinePositions);
        
        Vector3[] drawingPositions = new Vector3[drawing.positionCount];
        drawing.GetPositions(drawingPositions);
        List<Vector3> drawingPositionsList = drawingPositions.ToList();
        
        int maxScore = guidelinePositions.Length;

        foreach (var point in guidelinePositions) {
            if (drawingPositionsList.Any(p => Vector2.Distance(p, point) <= 0.2f)) _score++;
        }
        
        print(@$"{_score}: {maxScore}");
        _score = (_score / maxScore) * 50;
        return _score;
    }
}
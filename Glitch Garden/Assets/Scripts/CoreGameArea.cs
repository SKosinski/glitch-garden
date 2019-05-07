using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreGameArea : MonoBehaviour
{

    Defender defender;

    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector3 gridPos)
    {
        
        Defender[] defenders = FindObjectsOfType<Defender>();

        foreach(Defender defenderAll in defenders)
        {
            if (defenderAll.transform.position == gridPos)
            {
                return;
            }
        }
        
        var StarDisplay = FindObjectOfType<StarDisplay>();
        if(defender)
        {
            int defenderCost = defender.GetStarCost();
            if (StarDisplay.HaveEnoughStars(defenderCost))
            {
                SpawnDefender(gridPos);
                StarDisplay.SpendStars(defenderCost);
            }
        }

    }

    private Vector3 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector3 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector3 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        float newZ = -5f;
        return new Vector3(newX, newY, newZ);
    }

    private void SpawnDefender(Vector3 worldPos)
    {
        Defender newDefender = Instantiate(defender, worldPos, Quaternion.identity) as Defender;
    }
}

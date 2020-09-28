using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Dictionary<Vector3, Space> Spaces;

    public bool CanMove(Vector3 _locationToCheck)
    {
        if (Spaces[_locationToCheck].currentSPACE_STATE == SPACE_STATE.OPEN)
        {
            Debug.Log(Spaces[_locationToCheck].SPACE_NAME);
            return true;
        }
        return false;
    }

    public void UpdateSpace(Space _space)
    {
        if (Spaces == null)
        {
            Spaces = new Dictionary<Vector3, Space>();
        }
        Spaces.Add(_space.SpaceLocation, _space);
    }

}

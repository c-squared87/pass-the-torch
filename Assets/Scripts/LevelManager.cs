using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Dictionary<Vector3, Space> Spaces;

    public Vector3 LevelStartLocation { get; private set; }

    public bool CanMove(Vector3 _locationToCheck)
    {
        if (Spaces[_locationToCheck].currentSPACE_STATE != SPACE_STATE.BLOCKED)
        {
            return true;
        }
        return false;
    }

    public void UpdateSpace(Space _space)
    {
        if (_space.currentSPACE_STATE == SPACE_STATE.START_SPACE)
        {
            LevelStartLocation = _space.SpaceLocation;
            return;
        }
        if (Spaces == null)
        {
            Spaces = new Dictionary<Vector3, Space>();
        }
        Spaces.Add(_space.SpaceLocation, _space);
    }

}

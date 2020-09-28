using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Dictionary<Vector3, Space> Spaces;

    public bool CanMove(Vector3 _locationToCheck)
    {
        return false;
    }

    public void UpdateSpace(Space _space)
    {
        if (Spaces == null)
        {
            Spaces = new Dictionary<Vector3, Space>();
        }
        Spaces[_space.SpaceLocation] = _space;
    }

}

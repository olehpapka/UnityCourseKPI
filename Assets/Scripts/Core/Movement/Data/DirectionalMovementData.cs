using System;
using UnityEngine;

[Serializable]
public class DirectionalMovementData 
{
    
    [field: SerializeField] public float HorizontalSpeed { get; private set; }
    [field: SerializeField] public bool FaceRight {get; private set;}

    public void Flip()
    {
        FaceRight = !FaceRight;
    }

    
}

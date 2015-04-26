using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Rotate : MonoBehaviour
{
    [Range(-0.1f,0.1f)]
    public float rotation1, rotation2, rotation3;

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(rotation1/10f, rotation2/10f, rotation3/10f));
    }
}

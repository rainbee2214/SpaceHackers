using UnityEngine;
using System.Collections;

public class PlanetRotation : MonoBehaviour 
{
    public float radius;
    public float Radius
    {
        get { return radius; }
        set { radius += value; }
    }

    public float theta;
    public float Theta
    {
        get { return theta; }
        set { theta += value; }
    }

    public float speed = 0.01f;
    public float Speed
    {
        get { return speed; }
        set { speed += value; }
    }

    public void Rotate(Vector3 position)
    {
        theta += speed;
        transform.position = new Vector3(position.x + radius*Mathf.Sin(theta), position.y + radius*Mathf.Cos(theta), -1f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody rb;
    private float myG = 6.67f;
    public static List<Attraction> planetAttraction;
    void FixedUpdate()

    {
        foreach (var pAttraction in planetAttraction)
        {
            if (pAttraction != this)
            {
                Attract(pAttraction); 
            }
        }
    }
    void Attract(Attraction Other)
    {
        Rigidbody rbOther = Other.rb;
        Vector3 direction = rb.position - rbOther.position;
        float distance = direction.magnitude;
        float forceMagnitude = myG * (rb.mass * rbOther.mass) / Mathf.Pow(distance, 2);

        Vector3 force = direction.normalized * forceMagnitude;
        rbOther.AddForce(force);

    }

    private void OnEnable()
    {
        if (planetAttraction == null)
        {
            planetAttraction = new List<Attraction>();

        }
        planetAttraction.Add(this);
    }
}
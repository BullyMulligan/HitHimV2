using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] private GameObject _sphere;
    public Color[] colors = { Color.blue, Color.red, Color.green };
    // Start is called before the first frame update
    void OnDestroy()
    {
        
    }

    public void NewSphere()
    {
        var sphere = Instantiate(_sphere);
        sphere.transform.position = new Vector3(Random.Range(-40, 10), 2, Random.Range(-40, 40));
        sphere.GetComponent<Renderer>().material.color = colors[Random.Range(0, 3)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

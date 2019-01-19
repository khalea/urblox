using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testRotate : MonoBehaviour
{
    public GameObject table;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

      Debug.Log("Turning tables.");

      // Rotate table by 120 deg and then stop
      // table.transform.Rotate(new Vector3(0, 150, 0), Space.Self);
      // table.transform.rotation = Quaternion.Euler(0, 150 * Time.deltaTime, 0);
    }
}

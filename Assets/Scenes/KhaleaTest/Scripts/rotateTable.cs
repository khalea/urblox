using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotateTable : MonoBehaviour
{
  public GameObject btn;
  public GameObject table;
  public float speed;

  Collider btnObjCollider;


    // Start is called before the first frame update
    void Start()
    {
      //Fetch the GameObject's Collider (make sure they have a Collider component)
        btnObjCollider = GetComponent<Collider>();
        //Here the GameObject's Collider is not a trigger
        btnObjCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {



    }

    private void OnTriggerEnter(Collider other) {

      // Button Y goes down
      btn.transform.Translate(0, -1, 0);

      // Rotate table by 120 deg and then stop
      table.transform.Rotate(Vector3.up * speed, Space.Self);

    }

}

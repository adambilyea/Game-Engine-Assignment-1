using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class PlugIn : MonoBehaviour
{
     const string DLL_NAME = "SIMPLEPLUGIN";
    [DllImport(DLL_NAME)]
    private static extern int SimpleFunction();
    private static extern int SaveFunction();
    private static extern int LoadFunction();

    public GameObject Player;
    private Rigidbody rb;

    float PosX, PosY, PosZ;
    
    void Start()
    {
        rb = Player.GetComponent<Rigidbody>();
    }

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.K))
       {
            PosX = rb.GetComponent<Rigidbody>().position.x;
            PosY = rb.GetComponent<Rigidbody>().position.y;
            PosZ = rb.GetComponent<Rigidbody>().position.z;

            Debug.Log(PosX + " : " + PosY + " : " + PosZ + " : ");

           //Debug.Log(SaveFunction());
       }


        if (Input.GetKeyDown(KeyCode.L))
       {
            rb.GetComponent<Rigidbody>().position = new Vector3(PosX, PosY, PosZ);

          //Debug.Log(LoadFunction());
       }
    }
}
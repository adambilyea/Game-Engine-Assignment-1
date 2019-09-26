using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class PlugIn : MonoBehaviour
{
     const string DLL_NAME = "SIMPLEPLUGIN";
    [DllImport(DLL_NAME)]
    private static extern int SimpleFunction();
    [DllImport(DLL_NAME)]
    private static extern int SaveFunction(float x, float y, float z);
    [DllImport(DLL_NAME)]
    private static extern Vector3 LoadFunction();

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

            Debug.Log("Save to file test");
            SaveFunction(PosX, PosY, PosZ);

            Debug.Log(PosX + " : " + PosY + " : " + PosZ + " : ");
       }

        if (Input.GetKeyDown(KeyCode.L))
       {
            Vector3 loc = LoadFunction();

            Debug.Log(loc.x);
            Debug.Log(loc.y);
            Debug.Log(loc.z);

            Player.GetComponent<Rigidbody>().position = new Vector3(loc.x, loc.y, loc.z);

            //rb.GetComponent<Rigidbody>().position = new Vector3(PosX, PosY, PosZ);

            //Debug.Log(LoadFunction());
       }
    }
}
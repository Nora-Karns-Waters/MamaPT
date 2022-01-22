using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Player : MonoBehaviour
{
    public int initialHealth = 3;
    public int initialCharges = 3;

    int previousHealth;
    int previousCharges;

    public int currentHealth;
    public int currentCharges;

    public GameObject UI_health;
    public GameObject UI_charge;

    Vector3 v3_health = new Vector3(-8.4f, 1.1f, 0);
    Vector3 v3_charge = new Vector3(-8.4f, 0.7f, 0);

    List<GameObject> ls_health = new List<GameObject>();
    List<GameObject> ls_charge = new List<GameObject>();


    void Start()
    {

        generateUIObjects(initialHealth, UI_health, ls_health, v3_health);
        generateUIObjects(initialCharges, UI_charge, ls_charge, v3_charge);
        
        currentCharges = initialCharges;
        currentHealth = initialHealth;
        previousCharges = initialCharges;
        previousHealth = initialHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth != previousHealth)
        {
            previousHealth = currentHealth;
            generateUIObjects(currentHealth, UI_health, ls_health, v3_health);          
        }

        if(currentCharges != previousCharges)
        {
            previousCharges = currentCharges;
            generateUIObjects(currentCharges, UI_charge, ls_charge, v3_charge);
        }
    }

    void generateUIObjects(int qty, GameObject obj, List<GameObject> objList, Vector3 initPos)
    {
        foreach(GameObject go in objList)
        {
            Object.Destroy(go);
        }

        objList.Clear();

        for (int i = 0; i < qty; i++)
        {
            objList.Add(Object.Instantiate(obj, initPos, new Quaternion(0, 0, 0, 0), transform));
            objList[i].transform.Translate(new Vector3(i * 0.4f, 0, 0));
        }
    }
}

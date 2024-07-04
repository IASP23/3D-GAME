using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;
using TMPro;
public class ObjectInteractive : MonoBehaviour
{
    //public Inventario inventario;

    public int numObjectives;
    public TextMeshProUGUI missionText;
    public GameObject missionButton;

    void Start()
    {
        //inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
        numObjectives = GameObject.FindGameObjectsWithTag("Objective").Length;
        missionText.text = "Recolecta " + numObjectives + " objetivos";
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Objective")
        {
            Destroy(other.gameObject);
            numObjectives--;
            missionText.text = "Recolecta " + numObjectives + " objetivos";

            if (numObjectives <= 0)
            {
                missionText.text = "Mission Completed";
                missionButton.SetActive(true);
            }
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteGauche : MonoBehaviour
{
    //simplification code
    private Transform paletteTransfo;
    //limite de deplacement de la barre
    public float limiteDeplacement = 3.5f;
    //vitesse de deplacement
    public float vitesseDeplacement = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        //initialisation de la barre
        paletteTransfo = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector qui contient coordonnnees de la palette
        Vector3 posObject = paletteTransfo.position; //postion de la balle 
        
        //Mouvement de la barre affecter par le input, la vitesse et time.deltaTime
        posObject.y += vitesseDeplacement * Time.deltaTime * Input.GetAxis("VerticalPlayer2");
        
        //limitation qui vont etre ajuster a la barre
        posObject.y = Mathf.Min(posObject.y, limiteDeplacement);
        
        posObject.y = Mathf.Max(posObject.y, -limiteDeplacement);
        
        //transmission de tous les données au gameobject
        paletteTransfo.position = posObject;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteAI : MonoBehaviour
{
    //simplification du code
    public GameObject balle;
    private Transform paletteAITransform, balleTransform;
    //limite que la barre AI peut se deplacer
    public float limiteDeplacement = 3.5f;
    //vitesse de deplacement
    public float vitesseDeplacement = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        //initialisation des transform de la balle et barre
        paletteAITransform = gameObject.transform;
        balleTransform = balle.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //vector qui a les coordonnees de la balle
        Vector3 positionBalle = balleTransform.position;
        //vector qui a les coordonnees de la palette
        Vector3 positionBarre = paletteAITransform.position;

        

        //Mouvement de la barre affecter par la vitesse et le time.deltaTime
        positionBalle.y += vitesseDeplacement * Time.deltaTime;
        //limite qui vont etre ajuster a la barre
        positionBalle.y = Mathf.Min(positionBalle.y, limiteDeplacement);
        positionBalle.y = Mathf.Max(positionBalle.y, -limiteDeplacement);
        
        //donne la position en y de la balle à la barre
        positionBarre.y = positionBalle.y;
        
        paletteAITransform.position = positionBarre;

    }
}

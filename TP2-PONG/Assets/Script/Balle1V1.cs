using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Balle1V1 : MonoBehaviour
{
    //simplification du code    
    private Transform transfoBalle;
    private Rigidbody2D rbBalle;
    private AudioSource monAS;

    public AudioClip autreSon, sonPerte;

    //position perte de point
    private float posPerduDroite = 10f, posPerduGauche = -9.21f;

    //impulsion initiale
    public float vitesse = 10.0f;
    
    //augmentation de balle
    private float augmentation = 1.10f;

    //Pointage
    public TextMeshPro pointageDroite, pointageGauche;
    public int pointageMaximal = 5;
    private int pointsDroite, pointsGauche;

    //ecrans
    public GameObject ecranAcueill, jeu;


    // Start is called before the first frame update
    void Awake()
    {
        //initialisation de tous les composantes utiliser
        transfoBalle = gameObject.transform;
        rbBalle = gameObject.GetComponent<Rigidbody2D>();
        monAS = gameObject.GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        //mise au jeu au centre, a l'arret avant l'impulsion
        transfoBalle.position = Vector2.zero;
        rbBalle.velocity = Vector2.zero;
        rbBalle.AddForce(Vector2.one* vitesse, ForceMode2D.Impulse);

        //init points
        pointsDroite = 0;
        pointsGauche = 0;
        pointageDroite.text = pointsDroite.ToString();
        pointageGauche.text = pointsGauche.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //perte de points
        if (transfoBalle.position.x > posPerduDroite)
        {
            transfoBalle.position = Vector2.right;
            rbBalle.velocity = Vector2.right;
            rbBalle.AddForce(Vector2.one * vitesse, ForceMode2D.Impulse);
            //ajustements de points
            pointsGauche++;
            pointageGauche.text = pointsGauche.ToString();
            monAS.PlayOneShot(sonPerte);
            vitesse = vitesse * augmentation;// augmentation de la vitesse de la balle
        }

        if (transfoBalle.position.x < posPerduGauche)
        {
            transfoBalle.position = Vector2.left;
            rbBalle.velocity = Vector2.left;
            rbBalle.AddForce(new Vector2(-1,-1) * vitesse, ForceMode2D.Impulse);
            //ajustements de points
            pointsDroite++;
            pointageDroite.text = pointsDroite.ToString();
            monAS.PlayOneShot(sonPerte);
            vitesse = vitesse * augmentation;// augmentation de la vitesse de la balle
            
        }
            //gestion d'ecran
            //fin de jeu 
        if (pointsDroite >= pointageMaximal || pointsGauche >= pointageMaximal)
        {
            ecranAcueill.SetActive(true);
            jeu.SetActive(false);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //son pour collision avec palette
        if (collision.transform.name == "PaletteDroite" || collision.transform.name == "PaletteGauche")
        {
            monAS.PlayOneShot(autreSon);
        }
        else
        {
            //son collision avec autre
            monAS.Play();
        }
    }
}
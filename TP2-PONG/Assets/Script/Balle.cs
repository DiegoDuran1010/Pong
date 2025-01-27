using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Balle : MonoBehaviour
{
    //simplification du code    
    private Transform transfoBalle;
    private Rigidbody2D rbBalle;
    private AudioSource monAS;
    public AudioClip autreSon, sonPerte;
    //position perte de point
    private float posPerduBalle = 10f;
    
    //impulsion initiale
    public float vitesse = 10.0f;
    //augmentation de vitesse
    private float augmentation = 1.10f;
    //Pointage
    public TextMeshPro monPointage;
    public int pointageInitial = 10;
    private int points;

    //ecrans
    public GameObject ecranAcueill, jeu;


    // Start is called before the first frame update
    void Awake()
    {
        //initialisation des composants utiliser
        transfoBalle = gameObject.transform;
        rbBalle = gameObject.GetComponent<Rigidbody2D>();
        monAS = gameObject.GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        //mise au jeu au centre, a l'arret avant l'impulsion
        transfoBalle.position = Vector2.zero;
        rbBalle.velocity = Vector2.zero;
        rbBalle.AddForce(Vector2.one * vitesse, ForceMode2D.Impulse);
        //init points
        points = pointageInitial;
        monPointage.text = points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //perte de points
        if (transfoBalle.position.x > posPerduBalle)
        {
            transfoBalle.position = Vector2.zero;
            rbBalle.velocity = Vector2.zero;
            rbBalle.AddForce(Vector2.one * vitesse, ForceMode2D.Impulse);
            //ajustements de points
            points--;
            monPointage.text = points.ToString();
            monAS.PlayOneShot(sonPerte);
            vitesse = vitesse * augmentation;// augmentation de la vitesse de la balle
            //gestion d'ecran
            //fin de jeu 
            if (points == 0)
            {
                ecranAcueill.SetActive(true);
                jeu.SetActive(false);
            }
        }
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //son pour collision avec palette
        if (collision.transform.name == "Palette")
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
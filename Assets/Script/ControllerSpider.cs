using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSpider : MonoBehaviour
{
    public float distanciaAtaque = 900f; // Distancia mínima requerida para atacar
    private GameObject player; // Referencia al objeto del personaje
    Animator animator;
    private int currentAnimation = 1;
    void Start()
    {
        animator = GetComponent<Animator>();
        // Buscar el objeto del personaje por su etiqueta
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        currentAnimation = 1;
        Vector3 playerPosition = player.transform.position;
        // Calcular la distancia entre la araña y el personaje
        float distanceToPlayer = Vector3.Distance(transform.position, playerPosition);

        if (distanceToPlayer < distanciaAtaque)
        {
            // Ejecutar la animación de ataque
            Debug.Log("¡Atacar al personaje!");
            currentAnimation = 3;

        }
        animator.SetInteger("Estado", currentAnimation);

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "flechaPersonaje")
        {
            Debug.Log("choco a spider");
           
        }
    }
}

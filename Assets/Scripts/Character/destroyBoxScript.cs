using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBoxScript : MonoBehaviour {
    [SerializeField]
    ParticleSystem particles;
    [SerializeField]
    MeshRenderer mesh;
    [SerializeField]
    Collider col;
    float timer;

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Destrói a caixa
        if (timer >= 1)
        timer += Time.deltaTime;
        if (timer >= 1.5f)
            Destroy(gameObject);
    }

    //Faz o player destruir as caixas mas não completamente para as particulas aparecerem
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerDamage")
        {
            mesh.enabled = false;
            particles.Play();
            Destroy(col);
            timer = 1;
           
        }
    }
  

}

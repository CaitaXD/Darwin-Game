using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour {

    Character _character;
    [SerializeField]
    EnemyScript _enemyScript; 
    PlayerScript _playerScript;
    public float damage;
    public float damageTaken;
    float OldDistance = Mathf.Infinity;
    float MinDistance;
    GameObject []Enemyes;
    public AudioSource HitDamage;
    public AudioSource EnemyHitDamage;
    private void FixedUpdate()
    {
       
        _character = GetComponentInParent<Character>();
        _playerScript = GetComponentInParent<PlayerScript>();
        
    }
    //Método que faz o dano acontecer no player
  public  void TakeDamage()
    {
        if (!_playerScript.Immune)
        {
            HitDamage.Play();
           damageTaken = _playerScript._enemyScript.damage;
            _character.hitPoints -= damageTaken;
            _playerScript.Immune = true;
            if (_playerScript._enemyScript.transform.eulerAngles.y > 87 && _playerScript._enemyScript.transform.eulerAngles.y < 91 )
                _character.rBody.velocity = new Vector3(12, 6, 0);
            if (_playerScript._enemyScript.transform.eulerAngles.y < 273 && _playerScript._enemyScript.transform.eulerAngles.y > 269)
            { _character.rBody.velocity = new Vector3(-12, 6, 0); }
            _playerScript.idleTimer = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
            //Método que da dano no inimigo
            if (other.tag == "Enemy")
            {
            _enemyScript = other.gameObject.GetComponent<EnemyScript>();
            if (!_enemyScript.Immune)
            {
                EnemyHitDamage.Play();
                _enemyScript.hitPoints -= damage;
                if (_playerScript.transform.eulerAngles.y > 89 && _playerScript.transform.eulerAngles.y < 91)
                    _enemyScript.rBody.velocity = new Vector3(12, 6, 0);
                else if (_playerScript.transform.eulerAngles.y > 269 && transform.eulerAngles.y > 271)
                    _enemyScript.rBody.velocity = new Vector3(-12, 6, 0);
                _enemyScript.Immune = true;
            }
        }
    }
}

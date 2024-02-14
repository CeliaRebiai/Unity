using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxLifePoints = 3;
    public int currentLifePoints;

    public bool isInvulnerable = false ;
    public float invulnerableDelta = 0.15f;

    public int invulnerableDuration = 3;

    public SpriteRenderer sr;

    private void Start(){
        currentLifePoints = maxLifePoints;
    }
    
    public void Hurt(int damage) {
        currentLifePoints = currentLifePoints - damage;
    StartCoroutine(Invulnerable());
    }

  public IEnumerator Invulnerable(){

        isInvulnerable = true;

        WaitForSeconds invulnerableDeltaWait = new WaitForSeconds(invulnerableDelta);
 
        for (float i = 0; i <= invulnerableDuration; i += invulnerableDelta)
        {
            if (sr.color.a == 1)
            {
                sr.color = new Color(1f, 1f, 1f, 0f); // Color.clear
            }
            else
            {
                sr.color = Color.white;
            }
 
            yield return new WaitForSeconds(invulnerableDelta);
        }
 
        sr.color = Color.white;
        isInvulnerable = false;
    }
}
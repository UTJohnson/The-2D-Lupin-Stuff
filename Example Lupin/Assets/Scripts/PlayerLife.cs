using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    bool dead = false;
    private void Update() {
        if(transform.position.y < -1f && !dead) 
        {
            Die();
        }
    }
    // Start is called before the first frame update
   private void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.CompareTag("Enemy Body")) {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovment>().enabled = false;
        Die();
    }
   }

   void Die(){
      Invoke(nameof(ReloadLevel), 1.3f);
      dead = true;
      Debug.Log("ded!");

   }

   void ReloadLevel() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }
}

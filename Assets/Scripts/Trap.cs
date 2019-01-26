using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public bool isDeployed = false;
    public int playerNumber = 0;
    public int damage;
    public int slowedSpeed = 5;
    public int delayTime = 3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            Player player = other.GetComponent<Player>();
            if (!isDeployed)
            {
                player.hasTrap = true;
                Destroy(this.gameObject);
            } else if(player.playerNumber != this.playerNumber){
                //make damage
                player.hp-=damage;
                //
                player.isSlowed = true;
                player.SlowDown(slowedSpeed, delayTime);
                //start coroutine dove rallenta questo player e gli fa droppare l' obiettivo se ce l'ha
                Destroy(this.gameObject);
            }
        }
    }
    
    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace hit
{
    public class Merge : MonoBehaviour
    {


        public void HitCubeMethod(Transform player, List<Transform> playerCubes,Transform hitObject)
        {

           

            player.position = new Vector3(player.position.x, player.position.y + 1, player.position.z);
            player.GetChild(0).position = new Vector3(player.GetChild(0).position.x, player.GetChild(0).position.y - 1, player.GetChild(0).position.z);
        
            if (playerCubes.Count > 0)
            {
                player.GetChild(1).position = new Vector3(player.GetChild(1).position.x, player.GetChild(1).position.y - 1, player.GetChild(1).position.z);
               
                for (int i = 0; i < playerCubes.Count; i++)
                {
                    playerCubes[i].position = new Vector3(playerCubes[i].position.x, playerCubes[i].position.y + 1, playerCubes[i].position.z);
                   
                }

            }

            playerCubes.Add(hitObject);
            hitObject.position = new Vector3(player.position.x, hitObject.position.y, player.position.z);
            
        }
       

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace hit
{
    public class HitStair : MonoBehaviour
    {
        public void HitStairMethod(Transform player, List<Transform> playerCubes, bool CheckHitFinish)
        {

                if (playerCubes.Count < 1)
                {
                GameManager.Instance.IsGameOver = true;
                GameManager.Instance.GameOverStair();
                }
                else
                {
                    playerCubes[playerCubes.Count - 1].tag = "PassCube";
                    playerCubes.RemoveAt(playerCubes.Count - 1);

                    player.GetChild(0).position = new Vector3(player.GetChild(0).position.x, player.GetChild(0).position.y + 1, player.GetChild(0).position.z);
                    player.GetChild(1).position = new Vector3(player.GetChild(1).position.x, player.GetChild(1).position.y + 1, player.GetChild(1).position.z);
                }
                if (CheckHitFinish)
                {
                    if (GameManager.Instance.StairScore == 10)
                    {
                    GameManager.Instance.IsGameOver = true;
                    GameManager.Instance.GameOverStair();
                    }
                }
            

            


        }

            
          



        
    }
}

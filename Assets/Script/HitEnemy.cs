using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace hit
{
    public class HitEnemy : MonoBehaviour
    {
        internal GameObject LastCube;
        public void HitEnemyMethod(Transform player, List<Transform> playerCubes,
            GameObject _destroyedCube, GameObject _destroyedEnemyCube)
        {

           
            player.position = new Vector3(player.position.x, player.position.y - 1, player.position.z);
            player.GetChild(0).position = new Vector3(player.GetChild(0).position.x, player.GetChild(0).position.y + 1, player.GetChild(0).position.z);
            player.GetChild(1).position = new Vector3(player.GetChild(1).position.x, player.GetChild(1).position.y + 1, player.GetChild(1).position.z);
            Debug.Log(player.position);

            for (int i = 0; i < playerCubes.Count; i++)
            {
                playerCubes[i].position = new Vector3(playerCubes[i].position.x,
                    playerCubes[i].position.y - 1, playerCubes[i].position.z);

            }
            DestroyPassCube(_destroyedCube);
            DestroyEnemyCube(_destroyedEnemyCube);


        }

        public void PassCube(List<Transform> playerCubes)
        {
            if (playerCubes.Count > 0)
            {
                playerCubes[playerCubes.Count - 1].tag = "PassCube";
                LastCube = playerCubes[playerCubes.Count - 1].gameObject;
                playerCubes.RemoveAt(playerCubes.Count - 1);
            }
            else
            {
                GameManager.Instance.IsGameOver = true;
                GameManager.Instance.GameOver();
            }
           
        }
        public void DestroyPassCube(GameObject _destroyedCube)
        {
            Destroy(LastCube);
            GameObject _destroyedPassCube = Instantiate(_destroyedCube,
                LastCube.transform.position, Quaternion.identity);
            Destroy(_destroyedPassCube, 2.5f);
           
        }
        public void DestroyEnemyCube(GameObject _destroyedEnemyCube)
        {
            Destroy(MergeController.Instance.HitEnemy.gameObject);
            GameObject _destroyedPassEnemyCube = Instantiate(_destroyedEnemyCube,
                MergeController.Instance.HitEnemy.position, Quaternion.identity);
            Destroy(_destroyedPassEnemyCube, 2.5f);

        }

    }


}

using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMultiPlayerManager : MonoBehaviour
{
    public List<Sprite> possiblePlayerVisuals;
    public List<PlayerInput> existingPlayers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPLayerJoined(PlayerInput newPlayer)
    {
        //Assign visuals to the new player
        SpriteRenderer newPlayerRenderer = newPlayer.GetComponent<SpriteRenderer>();
        newPlayerRenderer.sprite = possiblePlayerVisuals[existingPlayers.Count];
        existingPlayers.Add(newPlayer);

        LocalMultiPlayer playerScript = newPlayer.GetComponent<LocalMultiPlayer>();  
        playerScript.moveSpeed = 5f;
        //playerScript.manager = this;          
        //Equals to playerScript.manager = GetComponent<LocalMultiPlayerManager>(); 
    }
    //Detecting attack from players
    public void TyAttack(PlayerInput attackingPlayer)
    {
        
        for (int i = 0; i < existingPlayers.Count; i++)
        {
            if (attackingPlayer == existingPlayers[i])
            {
                continue;//skip this loop
            }
            Vector3 attackingPlayerPosition = attackingPlayer.transform.position;
            Vector3 existingPlayerPosition = existingPlayers[i].transform.position;
            float distanceToPlayer = Vector3.Distance(attackingPlayerPosition, existingPlayerPosition);
            if (distanceToPlayer < 1.5f)
            {
                Debug.Log("ATTACKING THIS PLAYER: " + existingPlayers[i].playerIndex);
            }
        }
    }
}

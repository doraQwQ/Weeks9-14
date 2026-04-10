using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Wk13CodingGymManagerscript : MonoBehaviour
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

        Wk13CodingGmPlayerInput playerScript = newPlayer.GetComponent<Wk13CodingGmPlayerInput>();
        playerScript.moveSpeed = 5f;
        //playerScript.manager = this;          
        //Equals to Wk13CodingGmPlayerInput.manager = GetComponent<Wk13CodingGymManagerscript>(); 
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
                //Basically getting access to the player script
                //This is calling a refrences that calls the player script to response to the code
                PlayerInput playerInput = GetComponent<PlayerInput>();          
                GameObject existingPlayerObject = existingPlayers[i].gameObject;
                Wk13CodingGmPlayerInput existingPlayerInput = existingPlayerObject.GetComponent<Wk13CodingGmPlayerInput>();
                existingPlayerInput.OnSqueezed();


            }
        }
    }
}

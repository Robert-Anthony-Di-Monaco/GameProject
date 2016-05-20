using UnityEngine;
using System.Collections.Generic;

public class Formation : MonoBehaviour
{ 
    // SuperSoldier, MutatedSoldier -> can lose control rage if too much damage will attack all near

    /*
            1 shield + 2 guns rockets
            4 shields or tank?
            8 guns
            4 rockets
            2 artilery --> back up stuff, little robots to attack others, can drop them
            
            BUTTON to equal up 2 diff platoons
            BUTTON for each type to attack, or to send it out only artillery
     */
    


    // Slots for each type, get 1st available in list, arranged by closest to center, parented slot positions 
    // Alter how not moving and  no tank or seiege so circle formation
    
    List<Unit> ShieldVanguard_Slots,    // 1st line in formation
               AssaultInfantry_Slots,   // 2nd line
               ExplosiveInfantry_Slots, // 3rd line
               ArmoredProtector_Slots,  // Can move between front and back
               MobileArtillery_Slots,   // Can move between front and back
               AssassinSpy_Slots;       // On their own


	void Start ()
    {
	    
	}
	
	void Update ()
    {
	    
	}
}

// kill leader all disperse, stelth is valuable or spy pretend be them or plant bombs on them. detonate wtich to it the stealth climber
// Moving in line, Stop do arc
// when not moving and no tank then form circle aim all over 
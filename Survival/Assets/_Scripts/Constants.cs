using UnityEngine;

public static class Constants
{
    // General Animations
    public static int IsMoving = Animator.StringToHash("IsMoving");
    public static int TakeHit = Animator.StringToHash("TakeHit");
    
    // Enemy Specific Animations
    public static int Attack = Animator.StringToHash("Attack");
    
    // Player Specific Animations
    public static int CastedLightSpell = Animator.StringToHash("CastedLightSpell");
    public static int CastedStrongSpell = Animator.StringToHash("CastedStrongSpell");
}

#if PC2D_PLAYMAKER_SUPPORT

using Com.LuisPedroFonseca.ProCamera2D;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;
using UnityEngine;

[ActionCategory(ActionCategory.Camera)]
[Tooltip("Enable or disable the a cinematic focus target.")]
public class ProCamera2DToggleCinematicFocusTargetAction : FsmStateAction 
{
    [RequiredField]
    [Tooltip("The GameObject with the CinematicFocusTarget component")]
    public FsmGameObject CinematicFocusTarget;

    [Tooltip("The state the CinematicFocusTarget should enter")]
    public FsmBool Enable = true;

    public override void OnEnter() 
    {
        var cinematicFocusTarget = CinematicFocusTarget.Value.GetComponent<ProCamera2DCinematicFocusTarget>();

        if (cinematicFocusTarget == null)
            Debug.LogError("The CinematicFocusTarget GameObjects needs to have the ProCamera2DCinematicFocusTarget component added.");
        
        if (ProCamera2D.Instance != null && cinematicFocusTarget != null)
        {
            if (Enable.Value)
                cinematicFocusTarget.Enable();
            else
                cinematicFocusTarget.Disable();
        }

        Finish();
    }
}

#endif
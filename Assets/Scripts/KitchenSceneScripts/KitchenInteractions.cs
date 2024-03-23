using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KitchenInteractions : MonoBehaviour
{
    public GameObject InteractableObjects;
    [SerializeField] 
    private GameObject TooltipForKnob;
    [SerializeField] 
    private TextMeshProUGUI toolTipText;
    
    private static float STOVE_ON_ANGLE = 90f;
    private static float STOVE_OFF_ANGLE = 0f;
    private static float SPEED = 5.0f;

    /**
        STATES OF THE KNOBS
    */
    private static float StoveKnobLeft1_state;
    private static float StoveKnobLeft2_state;
    private static float StoveKnobRight1_state;
    private static float StoveKnobRight2_state;

    private bool canRotateLeft1;
    private bool canRotateLeft2;
    private bool canRotateRight1;
    private bool canRotateRight2;

    // Start is called before the first frame update
    void Start()
    {
        canRotateLeft1 = false;
        canRotateLeft2 = false;
        canRotateRight1 = false;
        canRotateRight2 = false;

        StoveKnobLeft1_state = STOVE_OFF_ANGLE;
        StoveKnobLeft2_state = STOVE_ON_ANGLE;
        StoveKnobRight1_state = STOVE_OFF_ANGLE;
        StoveKnobRight2_state = STOVE_OFF_ANGLE;
    }

    // Update is called once per frame
    void Update()
    {
        if (canRotateLeft1)
        {
            rotateStoveKnobLeft1();
        }

        if (canRotateLeft2)
        {
            rotateStoveKnobLeft2();
        }

        if (canRotateRight1)
        {
            rotateStoveKnobRight1();
        }

        if (canRotateRight2)
        {
            rotateStoveKnobRight2();
        }
    }


    /**
        PUBLIC FUNCTIONS FOR ROTATING STOVE KNOBS
        
        Left1 - third from the left
        Left2 - last from the left

        Right1 - second from the left
        Right2 - first from the left

        (dont ask me why theyre named this way...its from the asset)
    */
    public void RotateStoveKnobLeft1() 
    {
        if (StoveKnobLeft1_state == STOVE_ON_ANGLE)
        {
            StoveKnobLeft1_state = STOVE_OFF_ANGLE;
        } 
        else
        {
            StoveKnobLeft1_state = STOVE_ON_ANGLE;
        }
        canRotateLeft1 = true;
        
    }

    public void RotateStoveKnobLeft2() 
    {
        if (StoveKnobLeft2_state == STOVE_ON_ANGLE)
        {
            StoveKnobLeft2_state = STOVE_OFF_ANGLE;
        } 
        else
        {
            StoveKnobLeft2_state = STOVE_ON_ANGLE;
        }
        canRotateLeft2 = true;
    }

    public void RotateStoveKnobRight1()
    {
        if (StoveKnobRight1_state == STOVE_ON_ANGLE)
        {
            StoveKnobRight1_state = STOVE_OFF_ANGLE;
        } 
        else
        {
            StoveKnobRight1_state = STOVE_ON_ANGLE;
        }
        canRotateRight1 = true;
    }

    public void RotateStoveKnobRight2()
    {
        if (StoveKnobRight2_state == STOVE_ON_ANGLE)
        {
            StoveKnobRight2_state = STOVE_OFF_ANGLE;
        } 
        else
        {
            StoveKnobRight2_state = STOVE_ON_ANGLE;
        }
        canRotateRight2 = true;
    }


    /**
        PRIVATE COROUTINES TO MAKE THE ROTATION SMOOTH
    */
    private void rotateStoveKnobLeft1()
    {
        GameObject Stove = InteractableObjects.transform.Find("Stove").gameObject;

        if (Stove != null)
        {
            Transform StoveKnobLeft1 = Stove.transform.Find("Stove-KnobLeft1");
            if (StoveKnobLeft1 != null)
            {
                Quaternion currentRot = StoveKnobLeft1.rotation;
                Quaternion targetRot = Quaternion.Euler(new Vector3(0, 0, StoveKnobLeft1_state));

                StoveKnobLeft1.rotation = Quaternion.Slerp(currentRot, targetRot, Time.deltaTime * SPEED);

                if (currentRot.eulerAngles.z == targetRot.eulerAngles.z)
                {
                    canRotateLeft1 = false;
                }

                StoveKnobLeft1.rotation = Quaternion.Slerp(currentRot, targetRot, Time.deltaTime * SPEED);
            }
            else Debug.Log("no child with stove knob left 1 found");
        }
        else Debug.Log("no child with stove found");
    }

    private void rotateStoveKnobLeft2()
    {
        
        GameObject Stove = InteractableObjects.transform.Find("Stove").gameObject;

        if (Stove != null)
        {
            Transform StoveKnobLeft2 = Stove.transform.Find("Stove-KnobLeft2");
            if (StoveKnobLeft2 != null)
            {
                Quaternion currentRot = StoveKnobLeft2.rotation;
                Quaternion targetRot = Quaternion.Euler(new Vector3(0, 0, StoveKnobLeft2_state));

                StoveKnobLeft2.rotation = Quaternion.Slerp(currentRot, targetRot, Time.deltaTime * SPEED);

                if (currentRot.eulerAngles.z == targetRot.eulerAngles.z)
                {
                    canRotateLeft2 = false;
                }

                KitchenSceneState.SetGasStoveTurnedOff(true);
            }
            else Debug.Log("no child with stove knob left 2 found");
        }
        else Debug.Log("no child with stove found");
    }

    private void rotateStoveKnobRight1()
    {
        GameObject Stove = InteractableObjects.transform.Find("Stove").gameObject;

        if (Stove != null)
        {
            Transform StoveKnobRight1 = Stove.transform.Find("Stove-KnobRight1");
            if (StoveKnobRight1 != null)
            {
                Quaternion currentRot = StoveKnobRight1.rotation;
                Quaternion targetRot = Quaternion.Euler(new Vector3(0, 0, StoveKnobRight1_state));

                StoveKnobRight1.rotation = Quaternion.Slerp(currentRot, targetRot, Time.deltaTime * SPEED);

                if (currentRot.eulerAngles.z == targetRot.eulerAngles.z)
                {
                    canRotateRight1 = false;
                }
            }
            else Debug.Log("no child with stove knob right 1 found");
        }
        else Debug.Log("no child with stove found");
    }

    private void rotateStoveKnobRight2()
    {
        Debug.Log("Reaches function");
        GameObject Stove = InteractableObjects.transform.Find("Stove").gameObject;

        if (Stove != null)
        {
            Transform StoveKnobRight2 = Stove.transform.Find("Stove-KnobRight2");
            if (StoveKnobRight2 != null)
            {
                Quaternion currentRot = StoveKnobRight2.rotation;
                Quaternion targetRot = Quaternion.Euler(new Vector3(0, 0, StoveKnobRight2_state));

                StoveKnobRight2.rotation = Quaternion.Slerp(currentRot, targetRot, Time.deltaTime * SPEED);

                if (currentRot.eulerAngles.z == targetRot.eulerAngles.z)
                {
                    canRotateRight2 = false;
                }
            }
            else Debug.Log("no child with stove knob right 2 found");
        }
        else Debug.Log("no child with stove found");
    }

    public void hoverOnKnobForToolTip()
    {
        toolTipText.text = "TURN KNOB";
        TooltipForKnob.SetActive(true);
    }

    public void hoverOffKnobForToolTip()
    {
        toolTipText.text = "";
        TooltipForKnob.SetActive(false);
    }

}

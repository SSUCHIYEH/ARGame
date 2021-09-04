using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiJian_Dance : MonoBehaviour
{
    [SerializeField]
    public float jumpForce = 10f;
    Rigidbody2D rigid;


    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
        ManomotionManager.OnManoMotionFrameProcessed += HandleManoMotionFrameUpdated;
    }
	public void jump()
	{
		rigid.velocity = Vector2.up * jumpForce;

	}

	void HandleManoMotionFrameUpdated()
	{
		GestureInfo gesture = ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info;
		//TrackingInfo tracking = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info;
		Warning warning = ManomotionManager.Instance.Hand_infos[0].hand_info.warning;

		//AssignSpookeyFace(gesture, warning);
		GestureTigger(gesture, warning);
		//MoveAndScaleSpookey(tracking, warning);
		//HighlightSpookeyImage(warning);
	}

	void GestureTigger(GestureInfo gesture, Warning warning)
	{
		if (warning != Warning.WARNING_HAND_NOT_FOUND)
		{
			if (gesture.mano_gesture_trigger == ManoGestureTrigger.GRAB_GESTURE)
			{
				jump();
			}
		}
	}
}

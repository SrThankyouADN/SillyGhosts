using UnityEngine;
using System.Collections;

//This script allows to drag rigidbody2D elements on the scene with orthographic camera
//Attach this script to your camera

public class DragRigidbody2D : MonoBehaviour
{
		public float Damper = 5f;
		public float Frequency = 3;
		public float Drag = 10f;
		public float AngularDrag = 5f;
		public float MaxDistance = 1;

		private SpringJoint2D _SpringJoint;
		private Camera _camera;  
		private RaycastHit2D _rayHit;
		
		void Start ()
		{
				_camera = gameObject.GetComponent<Camera> ();
		}

		void Update ()
		{				
				if (!Input.GetMouseButtonDown (0))
						return;

				//Looking for any collider2D under mouse position
				_rayHit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
		
				if (_rayHit.collider == null)
						return;
		
				if (!_rayHit.collider.rigidbody2D || _rayHit.collider.rigidbody2D.isKinematic)
						return;
				
				if (!_SpringJoint) {
						//Create Spring joint
						GameObject go = new GameObject ("[Rigidbody2D_dragger]");
						Rigidbody2D body = go.AddComponent<Rigidbody2D> ();
						_SpringJoint = go.AddComponent<SpringJoint2D> ();
						body.isKinematic = true;
				}		
				_SpringJoint.transform.position = _rayHit.point;		
				_SpringJoint.anchor = Vector2.zero;
		
				//Apply parameters to Spring joint
				_SpringJoint.frequency = Frequency;
				_SpringJoint.dampingRatio = Damper;
				_SpringJoint.distance = 0.005f;
				_SpringJoint.connectedBody = _rayHit.collider.rigidbody2D;
				
				//startDrag
				StartCoroutine ("DragObject");
		}

		IEnumerator DragObject ()
		{
				//store old values
				var oldDrag = _SpringJoint.connectedBody.drag;
				var oldAngDrag = _SpringJoint.connectedBody.angularDrag;
		
				_SpringJoint.connectedBody.drag = Drag;
				_SpringJoint.connectedBody.angularDrag = AngularDrag;
		
				while (Input.GetMouseButton(0)) {
						Vector2 newPos = _camera.ScreenToWorldPoint (Input.mousePosition);
						_SpringJoint.transform.position = new Vector2 (newPos.x, newPos.y);

						yield return new WaitForSeconds (0.01f);

						float Distance = Vector2.Distance (_SpringJoint.connectedBody.transform.position, Camera.main.ScreenToWorldPoint (Input.mousePosition));
						//print ("Distance=" + Distance);

						if (Distance > MaxDistance) {
								StopCoroutine ("DragObject");
								_SpringJoint.connectedBody.drag = oldDrag;
								_SpringJoint.connectedBody.angularDrag = oldAngDrag;
								_SpringJoint.connectedBody = null;
						}
				}
			
				//Set old Object Position
				if (_SpringJoint.connectedBody) {
						_SpringJoint.connectedBody.drag = oldDrag;
						_SpringJoint.connectedBody.angularDrag = oldAngDrag;
						_SpringJoint.connectedBody = null;
				}
		}
}
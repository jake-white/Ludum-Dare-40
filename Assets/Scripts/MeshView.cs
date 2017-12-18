using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshView : MonoBehaviour {

	private int accuracy = 30;
	private float fieldOfView = Mathf.PI * 0.5f;
	public int range;
	private Vector2[] polygonCollision;

	void Start () {

	}

	void Update() {
		RaycastHit hitdata;
		float smallAngles = fieldOfView/accuracy;
		Vector3[] meshVertices = new Vector3[accuracy + 1];
		polygonCollision = new Vector2[accuracy+1];
		int[] meshTriangles = new int[accuracy*3];
		float angleStart = (transform.eulerAngles.z * Mathf.Deg2Rad) - fieldOfView/2;

		for(int i = 0; i < accuracy; ++i)
		{
			float x = Mathf.Cos(angleStart + smallAngles*i);
			float y = Mathf.Sin(angleStart + smallAngles*i);


			Vector3 angle = new Vector3(x, y, 0);
			bool hit = Physics.Raycast(transform.position, angle, out hitdata, range);
			meshVertices[0] = transform.InverseTransformPoint(transform.position);
			polygonCollision[0] = transform.InverseTransformPoint(transform.position);

			meshTriangles[i*3] = 0;
			meshTriangles[i*3 + 1] = i;
			meshTriangles[i*3 + 2] = i+1;
			if (hit)
			{
				meshVertices[i+1] = transform.InverseTransformPoint(hitdata.point);
				polygonCollision[i+1] = transform.InverseTransformPoint(new Vector2(hitdata.point.x, hitdata.point.y));
			}
			else 
			{ 
				Ray distanceRay = new Ray(transform.position, angle);
				Vector3 hitDistance = distanceRay.GetPoint(range);
				meshVertices[i+1] = transform.InverseTransformPoint(hitDistance);
				polygonCollision[i+1] = transform.InverseTransformPoint(hitDistance);

			}
			Mesh mesh = new Mesh();
			mesh.vertices = meshVertices;
			mesh.triangles = meshTriangles;
			gameObject.GetComponent<MeshFilter>().mesh = mesh;
			gameObject.GetComponent<MeshCollider>().inflateMesh = mesh;
			

		}
	}

	public Vector2[] getPolygon()
	{
		return polygonCollision;
	}
}

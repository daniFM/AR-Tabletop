﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HexMap;

public class PathTester : MonoBehaviour {
	GameObject[] markers;
	AStarHex pathfinding;
	public GameObject player;
	// Use this for initialization
	void Start () {
		if (HexGrid.instance == null){
			Debug.LogError("REEEE");
		}
		pathfinding = new AStarHex();
		markers = new GameObject[10];
	}
	Vector3[] waypoints;
	int pathcount;
	LTDescr tween;
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)){
				//Vector3 mpos = Input.mousePosition;	
				Debug.Log("hit "+hit.point);
			}

			//Debug.Log(Input.mousePosition);
			HexCell target = HexGrid.instance.GetCell(hit.point);
			//HexCell start = HexGrid.instance.GetCell(player.transform.position);
			Debug.Log("Clicked "+ target.q+":"+target.r);
			waypoints = pathfinding.FindPath(player.transform.position, hit.point);
			foreach (var item in markers) {
				Destroy(item);
			}
			markers = new GameObject[waypoints.Length];
			for (int i = 0; i < waypoints.Length; i++) {
				
				markers[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				markers[i].transform.localScale = Vector3.one*0.3f;
				markers[i].transform.position = waypoints[i];
				markers[i].name = "Hex mark";

			}

			pathcount = 0;
			tween = LeanTween.move(player, waypoints[pathcount], 0.2f).setOnComplete(() => TweenNext());
			// LeanTween.rotate(player, Vector3.zero, 1f);
			Vector3 myRotation =  Quaternion.LookRotation(waypoints[pathcount]-player.transform.position).eulerAngles;
			LeanTween.rotateLocal(player,myRotation, 0.2f).setEase(LeanTweenType.easeSpring);


		}

//		if (LeanTween.isTweening(player)){
//			float ratio = tween.passed / tween.time;
//			player.transform.rotation = Quaternion.Lerp();
//		}
	}

	void TweenNext(){
		pathcount++;
		if (pathcount < waypoints.Length){
			LeanTween.move(player, waypoints[pathcount], 0.3f).setOnComplete(() => TweenNext());

				//player.transform.LookAt(waypoints[pathcount+1]);
			Vector3 myRotation =  Quaternion.LookRotation(waypoints[pathcount]-waypoints[pathcount-1]).eulerAngles;
			LeanTween.rotateLocal(player,myRotation, 0.2f).setEase(LeanTweenType.easeSpring);
			//}
			//LeanTween.rotate(player, waypoints[pathcount+1], 0.1f);
		}
	}
}

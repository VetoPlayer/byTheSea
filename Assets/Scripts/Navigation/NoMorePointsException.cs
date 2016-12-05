using UnityEngine;
using System.Collections;
using System;

public class NoMorePointsException : Exception {

	public NoMorePointsException(string message) : base(message){
	}
}

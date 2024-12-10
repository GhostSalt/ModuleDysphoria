using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MDComponent : MonoBehaviour {

	protected int[] Registers;

	public abstract int[] GetRegisters();
	public abstract void DeactivateAppearance();
	public abstract void DeactivateLayout();

    public void SetRegisters(int[] registers)
	{
		Registers = registers;

		Debug.Log(Registers.Join(", "));
	}
}

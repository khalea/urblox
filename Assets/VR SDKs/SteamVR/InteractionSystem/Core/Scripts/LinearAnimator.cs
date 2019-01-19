//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Animator whose speed is set based on a linear mapping
//
//=============================================================================

using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	public class LinearAnimator : MonoBehaviour
	{
		public LinearMapping linearMapping;
		public Animator animator;
        public GameObject table;

        private float currentLinearMapping = float.NaN;
		private int framesUnchanged = 0;

	
		//-------------------------------------------------
		void Awake()
		{
			if ( animator == null )
			{
				animator = GetComponent<Animator>();
			}

			animator.speed = 0.0f;

			if ( linearMapping == null )
			{
				linearMapping = GetComponent<LinearMapping>();
			}
		}


		//-------------------------------------------------
		void Update()
		{
            //table.transform.Rotate(new Vector3(0, currentLinearMapping, 0), Space.Self);
            if ( currentLinearMapping != linearMapping.value )
			{
				currentLinearMapping = linearMapping.value;
                table.transform.Rotate(new Vector3(0, currentLinearMapping, 0), Space.Self);
    //            animator.enabled = true;
				//animator.Play( 0, 0, currentLinearMapping );
				framesUnchanged = 0;
			}
			else
			{
				framesUnchanged++;
				if ( framesUnchanged > 2 )
				{
					animator.enabled = false;
				}
			}
		}
	}
}

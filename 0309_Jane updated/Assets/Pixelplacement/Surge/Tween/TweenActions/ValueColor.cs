﻿/// <summary>
/// SURGE FRAMEWORK
/// Author: Bob Berkebile
/// Email: bobb@pixelplacement.com 
/// </summary>

using UnityEngine;
using System;
using Pixelplacement;

namespace Pixelplacement.TweenSystem
{
	class ValueColor : TweenBase
	{
		#region Public Properties
		public Color EndValue {get; private set;}
		#endregion

		#region Private Variables
		Action<Color> _valueUpdatedCallback;
		Color _start;
		#endregion

		#region Constructor
		public ValueColor (Color startValue, Color endValue, Action<Color> valueUpdatedCallback, float duration, float delay, bool obeyTimescale, AnimationCurve curve, Tween.LoopType loop, Action startCallback, Action completeCallback)
		{
			//set essential properties:
			SetEssentials (Tween.TweenType.Value, -1, duration, delay, obeyTimescale, curve, loop, startCallback, completeCallback);

			//catalog custom properties:
			_valueUpdatedCallback = valueUpdatedCallback;
			_start = startValue;
			EndValue = endValue;
		}
		#endregion

		#region Processes
		protected override bool SetStartValue ()
		{
			return true;
		}

		protected override void Operation (float percentage)
		{
			Color calculatedValue = TweenUtilities.LinearInterpolate (_start, EndValue, percentage);
			_valueUpdatedCallback (calculatedValue);
		}
		#endregion

		#region Loops
		public override void Loop ()
		{
			ResetStartTime ();
		}

		public override void PingPong ()
		{
			ResetStartTime ();
			Color temp = _start;
			_start = EndValue;
			EndValue = temp;
		}
		#endregion
	}
}
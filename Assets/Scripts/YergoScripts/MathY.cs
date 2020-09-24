using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YergoScripts
{
    /// <summary>
    /// Collection of hassle-driven problems resulted to the research of additional Math Functions.
    /// </summary>
    public struct MathY
    {
        /// <summary>
        /// Converts Radians to Vector2. Source: https://answers.unity.com/questions/823090/equivalent-of-degree-to-vector2-in-unity.html
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static Vector2 RadianToVector2(float radian)
        {
            return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
        }

        /// <summary>
        /// Converts Degrees to Vector2. Source: https://answers.unity.com/questions/823090/equivalent-of-degree-to-vector2-in-unity.html 
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        public static Vector2 DegreeToVector2(float degree)
        {
            return RadianToVector2(degree * Mathf.Deg2Rad);
        }

        /// <summary>
        /// Finds the minimum value among the entered values.
        /// </summary>
        /// <param name="minValues"></param>
        /// <returns></returns>
        public static int Min(params int[] minValues)
        {
            int minVal = int.MaxValue;

            foreach(int val in minValues)
            {
                if(minVal > val)
                    minVal = val;
            }

            return minVal;
        }
        
        /// <summary>
        /// Finds the minimum value among the entered values.
        /// </summary>
        /// <param name="minValues"></param>
        /// <returns></returns>
        public static float Min(params float[] minValues)
        {
            float minVal = int.MaxValue;

            foreach(float val in minValues)
            {
                if(minVal > val)
                    minVal = val;
            }

            return minVal;
        }

        /// <summary>
        /// Finds the maximum value among the entered values.
        /// </summary>
        /// <param name="minValues"></param>
        /// <returns></returns>
        public static int Max(params int[] maxValues)
        {
            int maxVal = int.MaxValue;

            foreach(int val in maxValues)
            {
                if(maxVal < val)
                    maxVal = val;
            }

            return maxVal;
        }

        
        /// <summary>
        /// Finds the maximum value among the entered values.
        /// </summary>
        /// <param name="minValues"></param>
        /// <returns></returns>
        public static float Max(params float[] maxValues)
        {
            float maxVal = float.MaxValue;

            foreach(float val in maxValues)
            {
                if(maxVal < val)
                    maxVal = val;
            }

            return maxVal;
        }
    }
}
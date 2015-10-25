using Assets.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Enemies
{
    class HoppingBehavior : MonoBehaviour
    {
        public float jumpInterval = 2;
        public float turnInterval = 8;
        public Vector2 jumpForce = new Vector2(50.0f, 100.0f);

        Rigidbody2D body;
        Direction direction = Direction.RIGHT;
        RepeatedAction jumpAction;
        RepeatedAction turnAction;


        // Use this for initialization
        void Start()
        {
            body = GetComponent<Rigidbody2D>();


            jumpAction = new RepeatedAction(Jump, jumpInterval, this);
            turnAction = new RepeatedAction(TurnAround, turnInterval, this);

            jumpAction.Start();
            turnAction.Start();
        }

        void Jump()
        {
            float x = direction == Direction.RIGHT ? jumpForce.x : -jumpForce.x;
            body.AddForce(new Vector2(x, jumpForce.y));
        }

        void TurnAround()
        {
            if (direction == Direction.LEFT)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                direction = Direction.RIGHT;
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                direction = Direction.LEFT;
            }
        }

        private enum Direction
        {
            LEFT,
            RIGHT
        }
    }
}

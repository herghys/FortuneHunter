using System;
using UnityEngine;
using UnityEngine.AI;

namespace Herghys
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] GameObject target;
		[SerializeField] Vector3 targetPos;
		[SerializeField] NavMeshAgent agent;
		[SerializeField] Animator animator;

		[SerializeField] GameManager gameManager;

		private void Awake()
		{
			if (gameManager == null) gameManager = FindObjectOfType<GameManager>();
		}

		private void OnEnable()
		{
			gameManager.MovePlayer += OnMovePlayer;
		}

		private void OnDisable()
		{
			gameManager.MovePlayer -= OnMovePlayer;

		}

		private void OnMovePlayer(GameObject arg0)
		{
			SetTarget (arg0);
		}


		public void SetTarget(GameObject target)
        {
            this.target = target;
			targetPos = target.transform.position;
            MoveToDestination();
        }

		public void SetTarget(Vector3 targetPos)
		{
			this.targetPos = targetPos;
			MoveToDestination();
		}

		[ContextMenu("Move To Tatget")]
		public void MoveToDestination()
        {
            if (target == null) return;

			Debug.Log("Move To Target");
			animator.SetBool("IsMoving", true);
            agent.SetDestination(target.transform.position);
        }

		public void MoveToDestination(Vector3 targetPos)
		{
			animator.SetBool("IsMoving", true);
			agent.SetDestination(targetPos);
		}

		public void StopMoving()
		{
			animator.SetBool("IsMoving", false);
			agent.isStopped= true;
			gameManager.PlayerStopped?.Invoke();
		}

		private void OnValidate()
		{
			if (agent == null) agent = GetComponent<NavMeshAgent>();
			if (animator == null) animator = GetComponent<Animator>();
			if (gameManager == null) gameManager = FindObjectOfType<GameManager>();
		}
	}
}

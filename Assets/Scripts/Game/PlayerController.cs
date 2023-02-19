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

		[SerializeField] Target currentTarget;

		private void Awake()
		{
			if (gameManager == null) gameManager = FindObjectOfType<GameManager>();
		}

		private void OnEnable()
		{
			gameManager.MovePlayer += OnMovePlayer;
			gameManager.UpdateTargetReference += OnUpdateTargetReference;
		}

		private void OnDisable()
		{
			gameManager.MovePlayer -= OnMovePlayer;
			gameManager.UpdateTargetReference -= OnUpdateTargetReference;
		}

		private void OnMovePlayer(GameObject arg0)
		{
			SetTarget (arg0);
		}

		private void OnUpdateTargetReference(Target arg0)
		{
			currentTarget = arg0;
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
			agent.SetDestination(target.transform.position);
			Debug.Log("Set Destination");

			if (agent.isStopped) 
				agent.isStopped= false;

			if (!agent.isStopped)
			animator.SetBool("IsMoving", true);
        }

		public void StopMoving()
		{
			agent.isStopped = true;
			animator.SetBool("IsMoving", false);
			//agent.isStopped= true;
			gameManager.PlayerStopped?.Invoke(currentTarget);
		}

		private void OnValidate()
		{
			if (agent == null) agent = GetComponent<NavMeshAgent>();
			if (animator == null) animator = GetComponent<Animator>();
			if (gameManager == null) gameManager = FindObjectOfType<GameManager>();
		}
	}
}

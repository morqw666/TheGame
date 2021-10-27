using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodiumMover : MonoBehaviour
{
    [SerializeField] private Transform podiumsPosUp;
    [SerializeField] private Transform podiumsPosDown;
    private float _targetHeight;
    private float _speed = 0.8f;
    private List<Podium> _podiums;
    private void Update()
    {
        MovePodiums();
    }
    private void MovePodiums()
    {
        for (int i = 0; i < _podiums.Count; i++)
        {
            var podium = _podiums[i];
            var pos = podium.transform.position;
            var position = new Vector3(pos.x, _targetHeight, pos.z);
            podium.transform.position = Vector3.MoveTowards(pos, position, _speed * Time.deltaTime);
        }
    }
    public void MoveUp(List<Podium> podiums)
    {
        _podiums = podiums;
        _targetHeight = podiumsPosUp.position.y;
        CollidersEnabled(true);
    }
    public void MoveDown(List<Podium> podiums)
    {
        _podiums = podiums;
        _targetHeight = podiumsPosDown.position.y;
        CollidersEnabled(false);
    }
    private void CollidersEnabled(bool option)
    {
        for (int i = 0; i < _podiums.Count; i++)
        {
            var podium = _podiums[i];
            var colider = podium.GetComponent<Collider>();
            colider.enabled = option;
        }
    }
}

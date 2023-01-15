using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tower))]
public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private Block _block;                
    [SerializeField] private Transform _buildPoint;       
    [SerializeField] private float _towerSize;            
    
    private List<Block> _blocks;                         

    public List<Block> Build()
    {
        _blocks = new List<Block>();
        Transform currentPoint = _buildPoint;               

        for (int i = 0; i < _towerSize; i++)
        {
            Block newblock = BuildBlock(currentPoint);
            _blocks.Add(newblock);
            currentPoint = newblock.transform;              
        }
        return _blocks;
    }

    private Block BuildBlock(Transform currentBuildPoint)          
    {
        return Instantiate(_block, GetBuildPosition(currentBuildPoint), Quaternion.identity);          
    }

    private Vector3 GetBuildPosition(Transform currentSegment)    
    {
        return new Vector3(_buildPoint.position.x, currentSegment.position.y + currentSegment.localScale.y / 2, _buildPoint.position.z);  // прибавляем размер деленный на 2, чтобы блоки строились один над другим
    }
}

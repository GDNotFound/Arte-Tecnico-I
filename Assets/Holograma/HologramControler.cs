using System.Collections;
using UnityEngine;

public class HologramControler : MonoBehaviour
{
    [SerializeField] private Vector3 _timeValues;
    private Material _hologram;
    private void Awake()
    {
        _hologram = GetComponent<Renderer>().material;
    }
    void Start()
    {
        StartCoroutine(Glitch());
    }
    private IEnumerator Glitch()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(Random.Range(_timeValues.x, _timeValues.y));
            _hologram.SetFloat("_Glitch_Enabled", 1);
            _hologram.SetFloat("_Enable_Vertical_Glitch", Random.Range(0,2));
            yield return new WaitForSecondsRealtime(Random.Range(_timeValues.x, _timeValues.z));
            _hologram.SetFloat("_Glitch_Enabled", 0);
        }
    }
}

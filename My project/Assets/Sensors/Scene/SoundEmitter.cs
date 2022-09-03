using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEmitter : MonoBehaviour
{
    public float soundIntensity;
    public float soundAttenuation;

    private Dictionary<int, SoundReceiver> receivers;
        
    // Start is called before the first frame update
    void Start()
    {
        receivers = new Dictionary<int, SoundReceiver>();
    }

    // Update is called once per frame
    void Update()
    {
        Emit();
    }

    private void Emit()
    {
        Vector3 srPosition;
        float intensity;
        float distance;
        Vector3 emitterPos = transform.position;

        foreach(SoundReceiver receiver in receivers.Values)
        {
            srPosition = receiver.transform.position;
            distance = Vector3.Distance(srPosition, emitterPos);
            intensity = soundIntensity;
            intensity -= soundAttenuation * distance;
            if(intensity < receiver.soundThresholdToDetectPlayer)
            {
                //No pasa nada
                //Pre aviso
                continue;
            }

            receiver.Receive(intensity, transform);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        SoundReceiver receiver = other.GetComponent<SoundReceiver>();

        if(receiver != null)
        {
            int objId = other.gameObject.GetInstanceID();
            receivers.Add(objId, receiver);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        SoundReceiver receiver = other.GetComponent<SoundReceiver>();

        if (receiver != null)
        {
            int objId = other.gameObject.GetInstanceID();
            receivers.Remove(objId);
        }
    }
}

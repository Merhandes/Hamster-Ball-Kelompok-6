using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PortalEffectController : MonoBehaviour
{
    public VisualEffect portalEffect;  // Visual Effect yang akan diatur
    public float burstCount = 500;     // Jumlah partikel yang muncul dalam burst
    public float spawnRateMultiplier = 2f;  // Percepatan spawn rate (kelipatan)
    public float lifetimeMultiplier = 0.5f; // Kurangi lifetime agar lebih cepat hilang

    private float defaultSpawnRate;
    private float defaultLifetime;

    void Start()
    {
        // Ambil nilai awal spawn rate dan lifetime
        defaultSpawnRate = portalEffect.GetFloat("Spawn Rate");
        defaultLifetime = portalEffect.GetFloat("Lifetime");
    }

    public void ActivatePortal()
    {
        // Tambahkan burst instan
        portalEffect.SendEvent("OnPlay");
        portalEffect.SetFloat("Spawn Rate", defaultSpawnRate * spawnRateMultiplier);
        portalEffect.SetFloat("Lifetime", defaultLifetime * lifetimeMultiplier);

        // Burst sekali untuk efek langsung terlihat
        portalEffect.SendEvent("TriggerBurst");
        portalEffect.SetFloat("Spawn Rate", defaultSpawnRate);  // Kembalikan ke normal setelah burst
    }
}
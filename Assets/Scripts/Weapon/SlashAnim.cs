using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAnim : MonoBehaviour
{
    private ParticleSystem ps; // ParticleSystem•≥•Û•›©`•Õ•Û•»§Ú±£≥÷§π§ÅE‰ ˝

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>(); // §≥§ŒGameObject§À•¢•ø•√•¡§µ§ÅEøParticleSystem•≥•Û•›©`•Õ•Û•»§Ú»°µ√
    }

    private void Update()
    {
        // ParticleSystem§¨¥Ê‘⁄§∑°¢§´§ƒ…˙¥Ê§∑§∆§§§ §§àˆ∫œ
        if (ps && !ps.IsAlive())
        {
            DestroySelf(); // §≥§ŒGameObject§Ú∆∆â≤§π§ÅE·•Ω•√•…§Ú∫Ù§”≥ˆ§π
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject); // §≥§ŒGameObject§Ú∆∆â≤
    }

    // •π•È•√•∑•Â•®•’•ß•Ø•»§Ú‘Ÿ…˙§π§ÅE·•Ω•√•…
    public void PlaySlashEffect()
    {
        if (ps != null)
        {
            Debug.Log("•π•È•√•∑•Â•—©`•∆•£•Ø•ÅE®•’•ß•Ø•»§Ú‘Ÿ…ÅE");
            ps.Play(); // •—©`•∆•£•Ø•ÅE∑•π•∆•‡§Ú‘Ÿ…ÅE
        }
    }
}

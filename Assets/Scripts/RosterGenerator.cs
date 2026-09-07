using UnityEngine;

public class RosterGenerator : MonoBehaviour
{
    public GameObject playerPrefab;
    public int rosterSize = 11;
    public Vector3 spawnCenter = Vector3.zero;
    public float spread = 4f;

    public void GenerateRoster()
    {
        if (playerPrefab == null) return;
        for (int i = 0; i < rosterSize; i++)
        {
            Vector3 pos = spawnCenter + new Vector3((i % 4) * 1.5f, 0, (i / 4) * 1.5f);
            GameObject p = Instantiate(playerPrefab, pos, Quaternion.identity, transform);

            // Simple random visual variation (scale / color tweak)
            float rnd = Random.Range(-0.5f, 0.5f);
            p.transform.localScale = Vector3.one * (1.0f + rnd * 0.08f);

            var rend = p.GetComponentInChildren<Renderer>();
            if (rend != null)
            {
                Color c = rend.material.color;
                c *= Random.Range(0.85f, 1.15f);
                rend.material.color = c;
            }

            // Optionally set animator params or randomize avatar features here
        }
    }
}

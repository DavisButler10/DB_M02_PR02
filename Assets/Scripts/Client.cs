using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public Drone m_Drone;
    public Sniper m_Sniper;
    public Boss m_Boss;
    public EnemySpawner m_Spawner;
    private Enemy m_Spawn;
    private int m_IncrementorDrone = 0;
    private int m_IncrementorSniper = 0;
    private int m_IncrementorBoss = 0;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            m_Spawn = m_Spawner.SpawnEnemy(m_Drone);
            m_Spawn.name = "Drone_Clone_" + ++m_IncrementorDrone;
            m_Spawn.transform.Translate(Vector3.forward * m_IncrementorDrone * 1.5f);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            m_Spawn = m_Spawner.SpawnEnemy(m_Sniper);
            m_Spawn.name = "Sniper_Clone_" + ++m_IncrementorSniper;
            m_Spawn.transform.Translate(Vector3.forward * m_IncrementorSniper * 1.5f);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            for (int i = 0; i < 1000; i++)
            {
                m_Spawn = m_Spawner.SpawnEnemy(m_Boss);
                m_Spawn.name = "Boss_Clone_" + ++m_IncrementorBoss;
                m_Spawn.transform.Translate(Vector3.forward * m_IncrementorBoss * 1.5f);
            }
        }
    }
}
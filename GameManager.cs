using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Patterns.Singleton
{
    public class GameManager : Singleton<GameManager>
    {
        private DateTime _sessionStartTime;
        private DateTime _sessionEndTime;

        void Start()
        {
            // TODO:
            // - �÷��̾� ���̺� �ε�
            // - ���̺갡 ������ �÷��̾ ��� ������ �����̷����Ѵ�.
            // - �鿣�带 ȣ���ϰ� ���� ç������ ������ ��´�.

            _sessionStartTime = DateTime.Now;
            Debug.Log("Game session start @ : " + DateTime.Now);
        }

        void OnApplicationQuit()
        {
            _sessionEndTime = DateTime.Now;

            TimeSpan timeDifference = _sessionEndTime.Subtract(_sessionStartTime);

            Debug.Log("Game session end @ : " + DateTime.Now);
            Debug.Log("Game session duration : " + timeDifference);
        }

        void OnGUI()
        {
            if (GUILayout.Button("Next Scene"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using System.IO;
/*
 저장하는 방법
 1. 저장할 데이터가 존재 
 2. 데이터를 제이슨으로 변환 
 3. 제이슨을 외부에 저장 
 
 불러오는 방법 
 1. 외부에 저장한 제이슨을 가져옴
 2. 제이슨을 데이터 형태로 변환 
 3. 불러온 데이터를 사용
 */
public class PlayerData
{
	public string Name;
}

	public class DataManager : MonoBehaviour
	{
		//싱글톤
		public static DataManager Instance;
		//플레이어 데이터 생성
		public PlayerData NowPlayer = new PlayerData();
		
		public string path;//경로

		private void Awake()
		{
			#region 싱글톤
			if (Instance == null)
			{
				Instance = this;
			}
			else if( Instance != null)
			{
				Destroy(Instance.gameObject);
			}
			DontDestroyOnLoad(this.gameObject);
			#endregion

			path = Application.persistentDataPath + "/save"; //경로저장
			print(path);
		}
		/// <summary>
		/// 저장 기능
		/// </summary>
		public void SaveData()
		{
			string data = JsonUtility.ToJson(NowPlayer);
			File.WriteAllText(path,data);
			
		}
		/// <summary>
		/// 불러오기 기능
		/// </summary>
		public void LoadData()
		{
			string data	= File.ReadAllText(path);
			NowPlayer = JsonUtility.FromJson<PlayerData>(data);
		}
		/// <summary>
		/// 정보 삭제 기능
		/// </summary>
		public void DeleteData()
		{
			System.IO.File.Delete(path);
		}
	}

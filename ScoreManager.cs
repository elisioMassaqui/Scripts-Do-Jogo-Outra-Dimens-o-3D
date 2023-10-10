using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
    public class ScoreManager : MonoBehaviour
    {
        public static int Mortes;
		 
        Text sText;

        void Awake ()
	{
		sText = GetComponent <Text> ();
		Mortes = 0;
		if (PlayerPrefs.HasKey ("Mortes")) 
		{
			Mortes = PlayerPrefs.GetInt ("Mortes");  
		} 
		else 
			
		Mortes = 0;

			
	}


        void Update ()
        {
            sText.text = "Até que pontuação consegues alcançar?: " + Mortes;
			PlayerPrefs.SetInt ("Mortes", Mortes);
        }
       
    }
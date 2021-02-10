using System;
using UnityEngine;

namespace UIScripts
{
    public class ControlsScreenController : MonoBehaviour
    {
        public GameObject[] pages;
        private int currentPage = 0;

        private void Awake()
        {
            ChangePage(currentPage);
        }

        public void Right()
        {
            if (currentPage < pages.Length - 1)
            {
                currentPage++;
                ChangePage(currentPage);
            }
        }

        public void Left()
        {
            if (currentPage > 0)
            {
                currentPage--;
                ChangePage(currentPage);
            }
        }

        public void ChangePage(int pageIndex)
        {
            for (int i = 0; i < pages.Length; i++)
            {
                if (i == pageIndex)
                {
                    pages[i].SetActive(true);
                }
                else
                {
                    pages[i].SetActive(false);
                }
            }
        }
    }
}
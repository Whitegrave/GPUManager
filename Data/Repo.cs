using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data
{
    public class Repo
    {
        public GPU[] GPU_Data;
        // Constructor to populate basic data on init
        public Repo()
        {
            GPU_Data = new GPU[6];

            for (int i = 0; i < 6; i++)
            {
                GPU_Data[i] = new GPU();
            }

            GPU_Data[0].Repo_ID = 1;
            GPU_Data[0].Brand = "NVIDIA";
            GPU_Data[0].Name = "1080 Ti";
            GPU_Data[0].MemoryGB = 11;
            GPU_Data[0].ClockSpeedHZ = 1582;
            GPU_Data[0].Cores = 3584;

            GPU_Data[1].Repo_ID = 2;
            GPU_Data[1].Brand = "NVIDIA";
            GPU_Data[1].Name = "2080 Ti";
            GPU_Data[1].MemoryGB = 11;
            GPU_Data[1].ClockSpeedHZ = 1635;
            GPU_Data[1].Cores = 4352;

            GPU_Data[2].Repo_ID = 3;
            GPU_Data[2].Brand = "NVIDIA";
            GPU_Data[2].Name = "3080";
            GPU_Data[2].MemoryGB = 10;
            GPU_Data[2].ClockSpeedHZ = 1710;
            GPU_Data[2].Cores = 8704;

            GPU_Data[3].Repo_ID = 4;
            GPU_Data[3].Brand = "AMD";
            GPU_Data[3].Name = "Radeon RX 6900 XT";
            GPU_Data[3].MemoryGB = 16;
            GPU_Data[3].ClockSpeedHZ = 2250;
            GPU_Data[3].Cores = 5120;

        }

        public bool GetIsIndexValid(GPU[] GPU_Repo, int index)
        {
            if(GPU_Repo[index].Repo_ID == 0)
                return false;

            return true;
        }
        private void Create()
        {

        }

        private void ReadAll()
        {

        }

        private void ReadID()
        {

        }

        private void Update()
        {

        }

        private void Delete()
        {

        }
    }
}

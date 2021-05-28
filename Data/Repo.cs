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
        private GPU[] GPU_Data;
        // Constructor to populate basic data on init
        public Repo()
        {
            GPU_Data = new GPU[6];

            for (int i = 0; i < 6; i++)
            {
                GPU_Data[i] = new GPU();
            }

            GPU_Data[0].Repo_ID = 0;
            GPU_Data[0].Brand = "NVIDIA";
            GPU_Data[0].Name = "1080 Ti";
            GPU_Data[0].MemoryGB = 11;
            GPU_Data[0].ClockSpeedHZ = 1582;
            GPU_Data[0].Cores = 3584;

            GPU_Data[1].Repo_ID = 1;
            GPU_Data[1].Brand = "NVIDIA";
            GPU_Data[1].Name = "2080 Ti";
            GPU_Data[1].MemoryGB = 11;
            GPU_Data[1].ClockSpeedHZ = 1635;
            GPU_Data[1].Cores = 4352;

            GPU_Data[2].Repo_ID = 2;
            GPU_Data[2].Brand = "NVIDIA";
            GPU_Data[2].Name = "3080";
            GPU_Data[2].MemoryGB = 10;
            GPU_Data[2].ClockSpeedHZ = 1710;
            GPU_Data[2].Cores = 8704;

            GPU_Data[3].Repo_ID = 3;
            GPU_Data[3].Brand = "AMD";
            GPU_Data[3].Name = "Radeon RX 6900 XT";
            GPU_Data[3].MemoryGB = 16;
            GPU_Data[3].ClockSpeedHZ = 2250;
            GPU_Data[3].Cores = 5120;

        }

        public void Create(int gpuID, string gpuBrand, string gpuName, int gpuMemory, int gpuClock, int gpuCores)
        {
            this.GPU_Data[gpuID].Repo_ID = gpuID;
            this.GPU_Data[gpuID].Brand = gpuBrand;
            this.GPU_Data[gpuID].Name = gpuName;
            this.GPU_Data[gpuID].MemoryGB = gpuMemory;
            this.GPU_Data[gpuID].ClockSpeedHZ = gpuClock;
            this.GPU_Data[gpuID].Cores = gpuCores;
        }

        public GPU ReadID(int GPU_ID)
        {
            if (GPU_ID < 0 || GPU_ID > this.GPU_Data.Length - 1)
                return null;

            if (this.GPU_Data[GPU_ID].Brand == null)
                return null;

            return this.GPU_Data[GPU_ID];
        }

        public void Update(GPU selectedGPU, string gpuBrand, string gpuName, int gpuMemory, int gpuClock, int gpuCores)
        {
            selectedGPU.Brand = gpuBrand;
            selectedGPU.Name = gpuName;
            selectedGPU.MemoryGB = gpuMemory;
            selectedGPU.ClockSpeedHZ = gpuClock;
            selectedGPU.Cores = gpuCores;
        }

        public void Delete(GPU selectedGPU)
        {
            selectedGPU.Brand = null;
            selectedGPU.Name = null;
            selectedGPU.MemoryGB = 0;
            selectedGPU.ClockSpeedHZ = 0;
            selectedGPU.Cores = 0;
        }

        public GPU GetGPUFromUserInput(string userInput)
        {
            int castedString = -1;      // Input to be converted to Int

            // If valid conversion to int, return a GPU if it exists in index
            if (Int32.TryParse(userInput, out castedString))
                return this.ReadID(castedString);

            // Failed to convert
            return null;
        }

        public int GetLength()
        {
            return this.GPU_Data.Length;
        }
    }
}

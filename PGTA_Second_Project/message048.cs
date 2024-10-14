﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
namespace PGTA_Second_Project
{
    public class message048
    {
        private int length;
        private List<byte> message;
        private string SAC;
        private string SIC;
        private string timeOfDay;

        public message048(int length, List<byte> FSPEC, List<byte> fullMessage)
        {
            this.length = length;
            this.message = fullMessage;
            int[] arrayFSPEC1 = dec2bin(FSPEC[0], 8);
            int byteCount = 0;
            if (arrayFSPEC1[0] == 1)
            {
                this.SAC = Convert.ToString(fullMessage[byteCount]);
                this.SIC = Convert.ToString(fullMessage[byteCount+1]);
                byteCount = byteCount + 2;
            }
            if (arrayFSPEC1[1] == 1)
            {
                this.timeOfDay = timeFinder(fullMessage[byteCount], fullMessage[byteCount+1], fullMessage[byteCount+2]);
                byteCount = byteCount + 3;
            }
            if (arrayFSPEC1[2] == 1)
            {

            }
            if (arrayFSPEC1[3] == 1)
            {
                
            }
            if (arrayFSPEC1[4] == 1)
            {

            }
            if (arrayFSPEC1[5] == 1)
            {

            }
            if (arrayFSPEC1[6] == 1)
            {

            }
            if (arrayFSPEC1[7] == 1)
            {
                int[] arrayFSPEC2 = dec2bin(FSPEC[1], 8);
            }
            return;
        }
        public int[] dec2bin(int decimalNum, int bitNumber)
        {
            int[] bitArray = new int[bitNumber];
            int[] auxArray = new int[bitNumber];
            int i = 0;
            while (decimalNum > 0)
            {
                auxArray[i] = decimalNum % 2;
                decimalNum /= 2;
                i++;
            }
            for (int j = 0; j < bitNumber; j++)
            {
                bitArray[(bitNumber - j-1)] = auxArray[j];
            }
            return bitArray;
        }
        public string timeFinder(int octet1, int octet2, int octet3)
        {
            int[] bits1 = dec2bin(octet1, 8);
            int[] bits2 = dec2bin(octet2, 8);
            int[] bits3 = dec2bin(octet3, 8);
            int[] fullbits = new int[24];
            double foundTime = 0;
            for (int i = 0; i < bits1.Length; i++)
            {
                fullbits[i] = bits1[i];
            }
            for (int i = bits1.Length; i < bits1.Length+bits2.Length; i++)
            {
                fullbits[i] = bits2[i-bits1.Length];
            }
            for (int i = bits1.Length + bits2.Length; i < bits1.Length + bits2.Length + bits3.Length; i++)
            {
                fullbits[i] = bits3[i - (bits1.Length + bits2.Length)];
            }
            for (int i = 0; i < 24; i++)
            {
                if (fullbits[i] != 0)
                {
                    foundTime = foundTime + Math.Pow(2, 23-i) * 1 / 128;
                }
            }
            int hours = (int)Math.Floor(foundTime / 3600);
            int minutes = (int)Math.Floor(foundTime/60 - 60*hours);
            double seconds = foundTime-3600*hours-60*minutes;
            string timeHHMMSS = $"{ hours } : {minutes} : {seconds}";
            return timeHHMMSS;
        }
    }
}
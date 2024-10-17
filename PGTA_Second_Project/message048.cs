using System;
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
        //020 variables
        private bool Purity = false;
        private string TYP;
        private string SIM;
        private string RDP;
        private string SPI;
        private string RAB;
        private string TST;
        private string ERR;
        private string XPP;
        private string ME;
        private string MI;
        private string FOE_FRI;
        private string RHO;
        private string THETA;
        private string mode3V;
        private string mode3G;
        private string mode3L;
        private string mode3squawk;

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
                int count = this.targetReport(fullMessage[byteCount], fullMessage[byteCount+1]);
                byteCount = byteCount + count;
            }
            if (arrayFSPEC1[3] == 1)
            {
                this.RHO = getRHO(fullMessage[byteCount], fullMessage[byteCount + 1]);
                byteCount = byteCount + 2;
                this.THETA = getTHETA(fullMessage[byteCount], fullMessage[byteCount + 1]);
                byteCount = byteCount + 2;
            }
            if (arrayFSPEC1[4] == 1)
            {
                this.mode3squawk = mode3AOctal(fullMessage[byteCount], fullMessage[byteCount + 1]);
                byteCount = byteCount + 2;
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
        public double bin2dec(int[] bits) {
            int count = bits.Length;
            double decimalNum = 0;
            for (int i = 0; i < count; i++)
            {
                if (bits[i] != 0)
                {
                    decimalNum = decimalNum + Math.Pow(2,count-1-i);
                }
            }
            return decimalNum;

        }

        public int hex2dec(string hexValue)
        {
            return Convert.ToInt32(hexValue, 16);
        }
        public string timeFinder(int octet1, int octet2, int octet3)
        {
            double foundTime = 0;
            int fullnumber = (octet1 << 16) | (octet2 << 8) | octet3;
            int[] fullbits = dec2bin(fullnumber, 24);
            foundTime = bin2dec(fullbits) / 128;
            int hours = (int)Math.Floor(foundTime / 3600);
            int minutes = (int)Math.Floor(foundTime/60 - 60*hours);
            double seconds = foundTime-3600*hours-60*minutes;
            string timeHHMMSS = $"{ hours } : {minutes} : {seconds}";
            return timeHHMMSS;
        }

        public int targetReport(int octet1, int octet2)
        {
            int count = 1;
            int[] array1 = this.dec2bin((int)octet1,8);
            //Check the first three bits to know the type of detection
            if (array1[0] == 0)
            {
                if (array1[1] == 0)
                {
                    if (array1[2] == 0)
                    {
                        //No detection
                        this.TYP = "NO DETECTION";
                        this.Purity = true;
                    }
                    else
                    {
                        //Single PSR detection
                        this.TYP = "PSR";
                        this.Purity = true;
                    }
                }
                else 
                { 
                    if (array1[2]==0)
                    {
                        //Single SSR detection
                        this.TYP = "SSR";
                        this.Purity = true;
                    }
                    else
                    {
                        //SSR + PSR detection
                        this.TYP = "SSR+PSR";
                        this.Purity = true;
                    }
                }
            }
            else 
            { 
                if (array1[1] == 0)
                {
                    if (array1[2] == 0)
                    {
                        //Single ModeS All-call
                        this.TYP = "SINGLE ModeS ALL-CALL";
                    }
                    else
                    {
                        //Single ModeS Roll-call
                        this.TYP = "SINGLE ModeS ROLL-CALL";
                    }
                }
                else 
                {
                    if (array1[2] == 0)
                    {
                        //ModeS All-Call + PSR
                        this.TYP = "ModeS ALL-CALL + PSR";
                        
                    }
                    else
                    {
                        //Mode S Roll-Call + PSR
                        this.TYP = "ModeS ROLL-CALL + PSR";
                        
                    }
                }
            }
            if (array1[3] == 0)
            {
                //Actual target report
                this.SIM = "ACTUAL TARGET REPORT";
            }
            else
            {
                //Simulated target report
                this.SIM = "SIMULATED TARGET REPORT";
            }
            if (array1[4]==0)
            {
                //Report from RDP chain 1
                this.RDP = "REPORT FROM RDP CHAIN 1";
            }
            else
            {
                //Report from RDP chain 2
                this.RDP = "REPORT FROM RDP CHAIN 2";
            }
            if (array1[5] == 0)
            {
                //No SPI
                this.SPI = "ABSENCE OF SPI";
            }
            else
            {
                //Special Position ID
                this.SPI = "SPI";
            }
            if (array1[6] == 0)
            {
                //Report from a/c transponder
                this.RAB = "REPORT FROM A/C TRANSPONDER";
            }
            else
            {
                //Report from field monitor (fixed transponder)
                this.RAB = "REPORT FROM FIELD MONITOR (FIXED TRANSPONDER)";
            }
            if (array1[7] == 1)
            {
                count++;
                int[] array2 = this.dec2bin((int)octet1, 8);
                if (array2[0] == 0)
                {
                    //Real target report
                    this.TST = "REAL TARGET REPORT";
                }
                else
                {
                    //Test target report
                    this.TST = "TEST TARGET REPORT";
                }
                if (array2[1] == 0)
                {
                    //No extended range
                    this.ERR = "NO EXTENDED RANGE";
                }
                else
                {
                    //Report from RDP chain 2
                    this.RDP = "EXTENDED RANGE PRESENT";
                }
                if (array2[2] == 0)
                {
                    //No X-Pulse present
                    this.XPP = "NO X-PULSE PRESENT";
                }
                else
                {
                    //X-pulse present
                    this.XPP = "X-PULSE PRESENT";
                }
                if (array2[3] == 0)
                {
                    //No military emergency
                    this.ME = "NO MILITARY EMERGENCY";
                }
                else
                {
                    //Military emergency
                    this.ME = "MILITARY EMERGENCY";
                }
                if (array2[4] == 0)
                {
                    //No military ID
                    this.MI = "NO MILITARY ID";
                }
                else
                {
                    //Military ID
                    this.ME = "MILITARY ID";
                }
                if (array2[5] == 0 & array2[6] == 0)
                {
                    //No mode 4 interrogation
                    this.FOE_FRI = "NO MODE 4 INTERROGATION";
                }
                else if(array2[5] == 0 & array2[6] == 1)
                {
                    //Friendly target
                    this.FOE_FRI = "FRIENDLY TARGET";
                }
                else if (array2[5] == 1 & array2[6] == 0)
                {
                    //Unknown target
                    this.FOE_FRI = "UNKNOWN TARGET";
                }
                else if (array2[5] == 1 & array2[6] == 1)
                {
                    //No reply
                    this.FOE_FRI = "NO REPLY";
                }
                return count;

            }
            else
            {
                return count;
            }
                
        }

        public string getRHO(int octet1, int octet2)
        {
            double foundRHO = 0;
            int fullNumber = (octet1 << 8) | octet2;
            int[] fullBits = dec2bin(fullNumber, 16);

            foundRHO = bin2dec(fullBits) / 256;

            string RHO = Convert.ToString(foundRHO);
            return RHO;
        }

        public string getTHETA(int octet1, int octet2)
        {
            double foundTHETA = 0;
            int fullNumber = (octet1 << 8) | octet2;
            int[] fullBits = dec2bin(fullNumber, 16);

            foundTHETA = bin2dec(fullBits)*(360 / Math.Pow(2, 16));

            string THETA = Convert.ToString(foundTHETA);
            return THETA;
        }
       public string mode3AOctal(int octet1, int octet2)
        {
            int fullnumber = (octet1<<8) | octet2;
            int[] fullbits = dec2bin(fullnumber, 16);
            this.mode3V = "Validated";
            this.mode3G = "Default";
            this.mode3L = "Derived from reply";
            if (fullbits[0] == 1) {
                this.mode3V = "Not validated";
            }
            if (fullbits[1] == 1)
            {
                this.mode3G = "Garbled";
            }
            if (fullbits[2] == 1)
            {
                this.mode3L = "Not extracted during last scan";
            }
            string squawk = null;
            for (int i = 4; i < 16; i+=3) {
                int[] squawkBits = new int[3];
                squawkBits[0] = fullbits[i];
                squawkBits[1] = fullbits[i+1];
                squawkBits[2] = fullbits[i+2];
                squawk = squawk + bin2dec(squawkBits);
            }
            return squawk;

        }
       
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Text;
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
        public string SAC = "N/A";
        public string SIC = "N/A";
        public string timeOfDay = "N/A";
        public int timeInSeconds;
        public string acAddress = "N/A";
        public string trackNum = "N/A";
        public string acID = "N/A";
        public bool Purity = false;
        public bool Grounded = false;
        public bool Fixed = false;
        public string TYP = "N/A";
        public string SIM = "N/A";
        public string RDP = "N/A";
        public string SPI = "N/A";
        public string RAB = "N/A";
        public string TST = "N/A";
        public string ERR = "N/A";
        public string XPP = "N/A";
        public string ME = "N/A";
        public string MI = "N/A";
        public string FOE_FRI = "N/A";
        public string RHO = "N/A";
        public string THETA = "N/A";
        public string mode3V = "N/A";
        public string mode3G = "N/A";
        public string mode3L = "N/A";
        public string mode3squawk = "N/A";
        public string flightLevel = "N/A";
        public string V090 = "N/A";
        public string G090 = "N/A";
        public string SRL = "N/A";
        public string SRR = "N/A";
        public string SAM = "N/A";
        public string PRL = "N/A";
        public string PAM = "N/A";
        public string RPD = "N/A";
        public string APD = "N/A";
        public string cartesianX = "N/A";
        public string cartesianY = "N/A";
        public string groundSpeedKT = "N/A";
        public string Heading = "N/A";
        public string CNF = "N/A";
        public string RAD = "N/A";
        public string DOU = "N/A";
        public string MAH = "N/A";
        public string CDM = "N/A";
        public string TRE = "N/A";
        public string GHO = "N/A";
        public string SUP = "N/A";
        public string TCC = "N/A";
        public string BDS = "N/A";
        public string MCP_FCU = "N/A";
        public string FMS = "N/A";
        public string barometricPressureSetting = "N/A";
        public string rollAngle = "N/A";
        public string trueTrackAngle = "N/A";
        public string groundSpeed = "N/A";
        public string trueAirspeed = "N/A";
        public string magneticHeading = "N/A";
        public string IAS = "N/A";
        public string machNumber = "N/A";
        public string barometricAltitudeRate = "N/A";
        public string inertialVerticalVelocity = "N/A";
        public string heightMeasured3DRadar = "N/A";
        public string COM = "N/A";
        public string STAT = "N/A";
        public string SI = "N/A";
        public string MSSC = "N/A";
        public string ARC = "N/A";
        public string AIC = "N/A";
        public string B1A = "N/A";
        public string B1B = "N/A";

        public message048(int length, List<byte> FSPEC, List<byte> fullMessage)
        {
            this.length = length;
            this.message = fullMessage;
            int[] arrayFSPEC1 = dec2bin(FSPEC[0], 8);
            int byteCount = 0;
            if (arrayFSPEC1[0] == 1) //Data Source Identifier
            {
                this.SAC = Convert.ToString(fullMessage[byteCount]);
                this.SIC = Convert.ToString(fullMessage[byteCount+1]);
                byteCount = byteCount + 2;
            }
            if (arrayFSPEC1[1] == 1) //Time of day
            {
                this.timeOfDay = timeFinder(fullMessage[byteCount], fullMessage[byteCount+1], fullMessage[byteCount+2]);
                byteCount = byteCount + 3;
            }
            if (arrayFSPEC1[2] == 1) //Type and Properties of the Target Report and Target Capabilities
            {
                int count = targetReport(fullMessage[byteCount], fullMessage[byteCount+1]);
                byteCount = byteCount + count;
            }
            if (arrayFSPEC1[3] == 1) //Measured Position in Slant Polar Coordinates
            {
                this.RHO = getRHO(fullMessage[byteCount], fullMessage[byteCount + 1]);
                byteCount = byteCount + 2;
                this.THETA = getTHETA(fullMessage[byteCount], fullMessage[byteCount + 1]);
                byteCount = byteCount + 2;
            }
            if (arrayFSPEC1[4] == 1) //Mode-3/A Code in Octal Representation
            {
                this.mode3squawk = mode3AOctal(fullMessage[byteCount], fullMessage[byteCount + 1]);
                byteCount = byteCount + 2;
            }
            if (arrayFSPEC1[5] == 1) //Flight Level in Binary Representation
            {
                this.flightLevel = getFlightLevel(fullMessage[byteCount], fullMessage[byteCount + 1]);
                byteCount = byteCount + 2;
            }
            if (arrayFSPEC1[6] == 1) //Radial Plot Characteristics
            {
                int count = radarPlot(fullMessage[byteCount], fullMessage[byteCount + 1], 
                    fullMessage[byteCount + 2], fullMessage[byteCount + 3], fullMessage[byteCount + 4],
                    fullMessage[byteCount + 5], fullMessage[byteCount + 6], fullMessage[byteCount + 7]);
                byteCount = byteCount + count;
            }
            if (arrayFSPEC1[7] == 1) //Field Extension Indicator
            {
               int[] arrayFSPEC2 = dec2bin(FSPEC[1], 8);   
               if (arrayFSPEC2[0] == 1) //Aircraft Address
               {
                    aircraftAddress(fullMessage[byteCount], fullMessage[byteCount +1], fullMessage[byteCount+2]);
                    byteCount = byteCount + 3;
                }
               if (arrayFSPEC2[1] == 1) //Aircraft ID
               {
                    aircraftID(fullMessage[byteCount], fullMessage[byteCount + 1], fullMessage[byteCount + 2],
                        fullMessage[byteCount + 3], fullMessage[byteCount + 4], fullMessage[byteCount + 5]);
                    byteCount = byteCount + 6;
                }
               if (arrayFSPEC2[2] == 1) //Mode S MB Data
               {
                    int repetitionFactor = fullMessage[byteCount];
                    List <byte> usedOctets = new List <byte>();
                    byteCount++;
                    for (int i = 0; i < repetitionFactor; i++)
                    {
                        /*
                        int octet1 = fullMessage[byteCount];
                        int octet2 = fullMessage[byteCount + 1];
                        int octet3 = fullMessage[byteCount + 2];
                        int octet4 = fullMessage[byteCount + 3];
                        int octet5 = fullMessage[byteCount + 4];
                        int octet6 = fullMessage[byteCount + 5];
                        int octet7 = fullMessage[byteCount + 6];
                        int octet8 = fullMessage[byteCount + 7];
                        */
                        for (int j = 0; j < 8; j++)
                        {
                            usedOctets.Add(fullMessage[byteCount + j]);
                            byteCount++;
                        }
                        // Code to be executed for each iteration
                        //byteCount = byteCount + 8;
                    }
                    modeSMBdecoding(usedOctets); //byteCount is already uptaded in loop
                    
                }
               if (arrayFSPEC2[3] == 1) //Track Number
               {
                    trackNumber(fullMessage[byteCount], fullMessage[byteCount + 1]);
                    byteCount = byteCount + 2;
                }
               if (arrayFSPEC2[4] == 1) //Calculated Position in Cartesian Coordinates
               {
                    calculatedCartesianPosition(fullMessage[byteCount], fullMessage[byteCount + 1],
                        fullMessage[byteCount + 2], fullMessage[byteCount + 3]);
                    byteCount = byteCount + 4;
                }
               if (arrayFSPEC2[5] == 1) //Calculated Track Velocity in Polar Coordinates
               {
                    calculatedVelocityPolar(fullMessage[byteCount], fullMessage[byteCount + 1],
                        fullMessage[byteCount + 2], fullMessage[byteCount + 3]);
                    byteCount = byteCount + 4;
                }
               if (arrayFSPEC2[6] == 1) //Track Status
               {
                    List<byte> usedOctets = new List<byte>();
                    usedOctets.Add(fullMessage[byteCount]);
                    for (int k = byteCount+1; k < fullMessage.Count; k++)
                    {
                        if (fullMessage[k]%2 == 1)
                        {
                            usedOctets.Add(fullMessage[k]);
                        }
                    }
                    int count = trackStatus(usedOctets);
                    //1+ length, function must return the length of the message
                    byteCount = byteCount + count;
                }
               if (arrayFSPEC2[7] == 1) //Field Extension Indicator
               {
                    int[] arrayFSPEC3 = dec2bin(FSPEC[2], 8);
                    if (arrayFSPEC3[0] == 1) //Track Quality
                    {
                        // Data Item not accounted for
                        byteCount = byteCount + 4;
                    }
                    if (arrayFSPEC3[1] == 1) //Warning/Error Conditions/Target Classification
                    {
                        for (int k = byteCount; k < fullMessage.Count(); k++)
                        {
                            byteCount++;
                            if (fullMessage[k] % 2 != 1)
                            {
                                break;
                            }
                        }
                    }
                    if (arrayFSPEC3[2] == 1) //Mode-3/A Code Confidence Indicator
                    {
                        byteCount = byteCount + 2;
                    }
                    if (arrayFSPEC3[3] == 1) //Mode-C Code and Confidence Indicator
                    {
                        byteCount = byteCount + 4;
                    }
                    if (arrayFSPEC3[4] == 1) //Height Measured by 3D Radar
                    {
                        heightMeas3DRadar(fullMessage[byteCount], fullMessage[byteCount + 1]);
                        byteCount = byteCount + 2;
                    }
                    if (arrayFSPEC3[5] == 1) //Radial Doppler Speed
                    {
                        //1+ length, function must return the length of the message
                        //byteCount = byteCount + count;
                    }
                    if (arrayFSPEC3[6] == 1) //Communications/ACAS Capability and Flight Status
                    {
                        commsACASCapabilityandFlightStatus(fullMessage[byteCount], fullMessage[byteCount + 1]);
                        byteCount = byteCount + 2;
                    }
                    if (arrayFSPEC3[7] == 1) //Field Extension Indicator
                    {
                        //DUE TO READING BYTES FROM FRONT TO BACK, ONCE WE REACH THE POINT WHERE FUTURE OCTETS ARE NOT NEEDED, WE DON'T NEED TO COUNT ANYMORE
                        /*
                        int[] arrayFSPEC4 = dec2bin(FSPEC[3], 8);
                        if (arrayFSPEC4[0] == 1) //ACAS Resolution Advisory Report
                        {
                            byteCount = byteCount + 7;
                        }
                        if (arrayFSPEC4[1] == 1) //Mode-1 Code in Octal Representation
                        {
                            byteCount = byteCount + 1;
                        }
                        if (arrayFSPEC4[2] == 1) //Mode-2 Code in Octal Representation
                        {
                            byteCount = byteCount + 2;
                        }
                        if (arrayFSPEC4[3] == 1) //Mode-1 Code Confidence Indicator
                        {
                            byteCount = byteCount + 1;
                        }
                        if (arrayFSPEC4[4] == 1) //Mode-2 Code Confidence Indicator
                        {
                            byteCount = byteCount + 2;
                        }
                        if (arrayFSPEC4[5] == 1) //Special Purpose Field
                        {
                            //1+1+ length, function must return the length of the message
                            //byteCount = byteCount + count;
                        }
                        if (arrayFSPEC4[6] == 1) //Reserved Expansion Field
                        {
                            //1+1+ length, function must return the length of the message
                            //byteCount = byteCount + count;
                        }
                        if (arrayFSPEC4[7] == 1) //Field Extension Indicator
                        {
                            //n.a
                        }
                        */
                    }
               }
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

        public int[] twosComplement(int[] a)
        {
            // Invertir los bits
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = a[i] == 0 ? 1 : 0;
            }
            // Sumar 1 al resultado
            for (int i = a.Length - 1; i >= 0; i--)
            {
                if (a[i] == 0)
                {
                    a[i] = 1;
                    break;
                }
                else
                {
                    a[i] = 0;
                }
            }
            return a;
        }

        public string timeFinder(int octet1, int octet2, int octet3)
        {
            double foundTime = 0;
            int fullnumber = (octet1 << 16) | (octet2 << 8) | octet3;
            int[] fullbits = dec2bin(fullnumber, 24);
            foundTime = bin2dec(fullbits) / 128;
            this.timeInSeconds = (int) foundTime;
            TimeSpan formalTime = TimeSpan.FromSeconds(foundTime);
            string timeHHMMSS = formalTime.ToString(@"hh\:mm\:ss\:fff");
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
                this.mode3G = "Garbled code";
            }
            if (fullbits[2] == 1)
            {
                this.mode3L = "Not extracted during last scan";
            }
            string squawk = string.Empty;
            for (int i = 4; i < 16; i+=3) {
                int[] squawkBits = new int[3];
                squawkBits[0] = fullbits[i];
                squawkBits[1] = fullbits[i+1];
                squawkBits[2] = fullbits[i+2];
                squawk = squawk + bin2dec(squawkBits);
            }
            return squawk;

        }

        public string getFlightLevel(int octet1, int octet2)
        {
            int fullNumber = (octet1 << 8) | octet2;
            int[] fullBits = dec2bin(fullNumber, 16);

            this.V090 = "Validated";
            this.G090 = "Default";

            if (fullBits[0] == 1)
            {
                this.mode3V = "Not validated";
            }
            if (fullBits[1] == 1)
            {
                this.mode3G = "Garbled code";
            }

            int[] foundFlightLevel = fullBits.Skip(2).ToArray();
            double foundFlightLevelDouble = bin2dec(foundFlightLevel)/4;

            string flightLevel = Convert.ToString(foundFlightLevelDouble);
            return flightLevel;
        }

        public int radarPlot(int octet1, int octet2, int octet3,
            int octet4, int octet5, int octet6, int octet7, int octet8)
        {
            int count = 1;
            int[] array1 = dec2bin((int)octet1, 8);
            if (array1[0] == 1) //SRL
            {
                count++;
                string srl = Convert.ToString((double)octet2 * 0.044) + "dg";
                this.SRL = srl;

            }
            if (array1[1] == 1) //SRR
            {
                count++;
                string srr = Convert.ToString((double)octet3);
                this.SRR = srr;

            }
            if (array1[2] == 1) //SAM
            {
                count++;
                if ((byte)octet4 < 128)
                {
                    this.SAM = Convert.ToString(octet4) + "dBm";
                }
                else
                {
                    this.SAM = Convert.ToString(-bin2dec(twosComplement(dec2bin((int)octet4, 8)))) + "dBm";
                }

            }
            if (array1[3] == 1) //PRL
            {
                count++;
                string prl = Convert.ToString((double)octet5 * 0.044) + "dg";
                this.PRL = prl;
            }
            if (array1[4] == 1) //PAM
            {
                count++;
                if ((byte)octet6 < 128)
                {
                    this.PAM = Convert.ToString(octet6) + "dBm";
                }
                else
                {
                    this.PAM = Convert.ToString(-bin2dec(twosComplement(dec2bin((int)octet6, 8)))) + "dBm";
                }

            }
            if (array1[5] == 1) //RPD
            {
                count++;
                if ((byte)octet7 < 128)
                {
                    this.RPD = Convert.ToString(Decimal.Round(Convert.ToDecimal((double)octet7 * 1.0 / 256.0), 3))+"NM";
                }
                else
                {
                    this.RPD = Convert.ToString(Decimal.Round(Convert.ToDecimal((double) -this.bin2dec(this.twosComplement(this.dec2bin((int)octet7, 8)))* 1.0 / 256.0), 3)) + "NM";
                }

            }
            if (array1[6] == 1) //APD
            {
                count++;
                if ((byte)octet7 < 128)
                {
                    this.APD = Convert.ToString(Decimal.Round(Convert.ToDecimal((double)octet8 * 0.02197265625), 3)) + "dg";
                }
                else
                {
                    this.APD = Convert.ToString(Decimal.Round(Convert.ToDecimal((double)-this.bin2dec(this.twosComplement(this.dec2bin((int)octet8, 8))) * 0.02197265625), 3)) + "dg";
                }
            }
            return count;

        }

        public void aircraftAddress(int octet1, int octet2, int octet3)
        {
            StringBuilder addressBuilder = new StringBuilder(6);

            void AppendHex(int octet)
            {
                addressBuilder.Append(octet.ToString("X2"));
            }
            AppendHex(octet1);
            AppendHex(octet2);
            AppendHex(octet3);

            this.acAddress = addressBuilder.ToString();
        }

        public void aircraftID(int octet1, int octet2, int octet3, int octet4, int octet5, int octet6)
        {
            // Combine all octets into a single bit array
            int[] bitArray = new int[48];
            int[] octets = {octet1, octet2, octet3, octet4, octet5, octet6};
            for (int i = 0; i < 6; i++)
            {
                int[] bits = dec2bin(octets[i], 8);
                Array.Copy(bits, 0, bitArray, i * 8, 8);
            }

            // Decode each 6-bit segment into a character
            StringBuilder aircraftIDBuilder = new StringBuilder(8);
            for (int i = 0; i < 8; i++)
            {
                int[] charBits = new int[6];
                Array.Copy(bitArray, i * 6, charBits, 0, 6);
                int charValue = (int)bin2dec(charBits);
                char decodedChar = DecodeChar(charValue);
                aircraftIDBuilder.Append(decodedChar);
            }

            // Set the aircraft ID
            this.acID = aircraftIDBuilder.ToString();
        }

        private char DecodeChar(int value)
        {
            if (value >= 1 && value <= 26)
            {
                // A-Z
                return (char)('A' + value - 1);
            }
            else if (value >= 48 && value <= 57)
            {
                // 0-9
                return (char)('0' + value - 48);
            }
            else if (value == 32)
            {
                // Space
                return ' ';
            }
            else
            {
                // Invalid character
                return '?';
            }
        }

        public int ModeSMB(int octet1, int octet2, int octet3, int octet4, int octet5, int octet6, int octet7, int octet8)
        {
            int count = 1;
            return count;
        }
        
        public void trackNumber(int octet1, int octet2)
        {
            int fullNumber = (octet1 << 8) | octet2;
            this.trackNum = Convert.ToString(fullNumber);
        }

        public void calculatedCartesianPosition(int octet1, int octet2, int octet3, int octet4)
        {
            // Combine the first two octets into a single 16-bit integer for the X coordinate
            int x = (octet1 << 8) | octet2;
            // Combine the next two octets into a single 16-bit integer for the Y coordinate
            int y = (octet3 << 8) | octet4;

            // Convert from two's complement if necessary
            if ((x & 0x8000) != 0) x -= 0x10000;
            if ((y & 0x8000) != 0) y -= 0x10000;

            // Store the coordinates as strings
            this.cartesianX = x.ToString();
            this.cartesianY = y.ToString();
        }

        public void calculatedVelocityPolar(int octet1, int octet2, int octet3, int octet4)
        {
            // Combine the first two octets into a single 16-bit integer for the ground speed
            int groundSpeedRaw = (octet1 << 8) | octet2;
            // Combine the next two octets into a single 16-bit integer for the heading
            int headingRaw = (octet3 << 8) | octet4;

            // Convert the raw ground speed to knots (assuming a conversion factor of 0.22)
            double groundSpeedKnots = Math.Round(groundSpeedRaw * 0.22, 4);
            // Convert the raw heading to degrees (assuming a full circle is 2^16 units)
            double headingDegrees = Math.Round(headingRaw * (360.0 / Math.Pow(2.0, 16.0)), 4);

            // Store the ground speed and heading as strings
            this.groundSpeedKT = groundSpeedKnots.ToString();
            this.Heading = headingDegrees.ToString();
        }

        public int trackStatus(List<byte> validOctets)
        {
            int octet1 = validOctets[0];

            // Convert octet1 to a binary array
            int[] numArray1 = this.dec2bin(octet1, 8);

            // Extract bit 8 for CNF
            this.CNF = numArray1[0] != 1 ? "CONFIRMED TRACK" : "TENTATIVE TRACK";

            // Extract bits 7-6 for RAD
            this.RAD = numArray1[1] != 1 ? (numArray1[2] != 1 ? "COMBINED" : "PSR") : (numArray1[2] != 1 ? "SSR/MODE S" : "INVALID");

            // Extract bit 5 for DOU
            this.DOU = numArray1[3] != 1 ? "NORMAL CONFIDENCE" : "LOW CONFIDENCE";

            // Extract bit 4 for MAH
            this.MAH = numArray1[4] != 1 ? "NO HORIZONTAL MANEUVER SENSED" : "HORIZONTAL MANEUVER SENSED";

            // Extract bits 3-2 for CDM
            this.CDM = numArray1[5] != 1 ? (numArray1[6] != 1 ? "MAINTAINING" : "CLIMBING") : (numArray1[6] != 1 ? "DESCENDING" : "UNKNOWN");

            // Check if the second octet is used
            if (numArray1[7] == 1)
            {
                int octet2 = validOctets[1];
                // Convert octet2 to a binary array
                int[] numArray2 = this.dec2bin(octet2, 8);

                // Extract each bit from the second octet and assign to the corresponding flags
                this.TRE = numArray2[0] != 1 ? "TRACK ALIVE" : "LAST REPORT";
                this.GHO = numArray2[1] != 1 ? "TRUE TARGET" : "GHOST TARGET";
                this.SUP = numArray2[2] != 1 ? "NO" : "YES";
                this.TCC = numArray2[3] != 1 ? "SLANT RANGE CORRECTION" : "TRACKING IN RADAR PLANE";

                return 2; // Both octets are used
            }

            return 1; // Only the first octet is used
        }

        public void heightMeas3DRadar(int octet1, int octet2)
        {
            int combined = (octet1 << 8) | octet2;

            // Extract the lower 14 bits (ignore the top 2 bits)
            int height = combined & 0x3FFF;

            // Check if the value is negative (two's complement)
            if ((height & 0x2000) != 0) // Check if the 14th bit is set
            {
                // Convert to negative value using two's complement
                height = height - 0x4000;
            }

            // Convert the height to feet
            double heightFeet = height * 25;
            this.heightMeasured3DRadar = heightFeet.ToString();
        }

        private void commsACASCapabilityandFlightStatus(int octet1, int octet2)
        {
            int combined = (octet1 << 8) | octet2;
            int[] combinedarray = dec2bin(combined, 16);

            if (combinedarray[0] == 0)
            {
                if (combinedarray[1] == 0)
                {
                    if (combinedarray[2] == 0)
                    {
                        this.COM = "NO COMMS CAPABILITY";
                    }
                    else
                    {
                        this.COM = "COMM. A AND COMM. B CAPABILITY";
                    }
                }
                else
                {
                    if (combinedarray[2] == 0)
                    {
                        this.COM = "COMM. A, COMM. B CAPABILITY AND UPLINK ELM";
                    }
                    else
                    {
                        this.COM = "COMM. A, COMM. B CAPABILITY, UPLINK ELM AND DOWNLINK ELM";
                    }
                }
            }
            else
            {
                if (combinedarray[1] == 0 || combinedarray[2] == 0)
                {
                    this.COM = "LEVEL 5 TRANSPONDER CAPABILITIES";
                }
            }

            if (combinedarray[3] == 0)
            {
                if (combinedarray[4] == 0)
                {
                    if (combinedarray[5] == 0)
                    {
                        this.STAT = "NO ALERT, NO SPI, AC AIRBORNE";
                    }
                    else
                    {
                        this.STAT = "NO ALERT, NO SPI, AC GROUNDED";
                        this.Grounded = true;
                    }
                }
                else
                {
                    if (combinedarray[4] == 0)
                    {
                        this.STAT = "ALERT, NO SPI, AC AIRBORNE";
                    }
                    else
                    {
                        this.STAT = "ALERT, NO SPI, AC GROUNDED";
                        this.Grounded = true;
                    }
                }
            }
            else
            {
                if (combinedarray[4] == 0)
                {
                    if (combinedarray[5] == 0)
                    {
                        this.STAT = "ALERT, SPI, AC AIRBORNE OR GROUNDED";
                    }
                    else
                    {
                        this.STAT = "NO ALERT, SPI, AC AIRBORNE OR GROUNDED";
                    }
                }
                else
                {
                    if (combinedarray[5] == 0)
                    {
                        this.STAT = "NOT ASSIGNED";
                    }
                    else
                    {
                        this.STAT = "UNKNOWN";
                    }
                }
            }

            if (combinedarray[6] == 0)
            {
                this.SI = "SI CODE CAPABILITY";
            }
            else
            {
                this.SI = "II CODE CAPABILITY";
            }

            if (combinedarray[8] == 0)
            {
                this.MSSC = "YES";
            }
            else
            {
                this.MSSC = "NO";
            }

            if (combinedarray[9] == 0)
            {
                this.ARC = "100 FT RES";
            }
            else
            {
                this.ARC = "25 FT RES";
            }

            if (combinedarray[10] == 0)
            {
                this.AIC = "NO";
            }
            else
            {
                this.AIC = "YES";
            }

            if (combinedarray[11] == 0)
            {
                this.B1A = "BDS 1,0 bit16=0";
            }
            else
            {
                this.B1A = "BDS 1,0 bit16=1";
            }

            if (combinedarray[12] == 0)
            {
                if (combinedarray[13] == 0)
                {
                    if (combinedarray[14] == 0)
                    {
                        if (combinedarray[15] == 0)
                            this.B1B = "BDS 1,0 bits 37/40=0000";
                        else
                            this.B1B = "BDS 1,0 bits 37/40=0001";
                    }
                    else
                        this.B1B = combinedarray[15] != 0 ? "BDS 1,0 bits 37/40=0011" : "BDS 1,0 bits 37/40=0010";
                }
                else
                    this.B1B = combinedarray[14] != 0 ? (combinedarray[15] != 0 ? "BDS 1,0 bits 37/40=0111" : "BDS 1,0 bits 37/40=0110") : (combinedarray[15] != 0 ? "BDS 1,0 bits 37/40=0101" : "BDS 1,0 bits 37/40=0100");
            }
            else
                this.B1B = combinedarray[13] != 0 ? (combinedarray[14] != 0 ? (combinedarray[15] != 0 ? "BDS 1,0 bits 37/40=1111" : "BDS 1,0 bits 37/40=1110") : (combinedarray[15] != 0 ? "BDS 1,0 bits 37/40=1101" : "BDS 1,0 bits 37/40=1100")) : (combinedarray[14] != 0 ? (combinedarray[15] != 0 ? "BDS 1,0 bits 37/40=1011" : "BDS 1,0 bits 37/40=1010") : (combinedarray[15] != 0 ? "BDS 1,0 bits 37/40=1001" : "BDS 1,0 bits 37/40=1000"));
        }

        private void modeSMBdecoding(List<byte> data)
        {

        }
    }
}

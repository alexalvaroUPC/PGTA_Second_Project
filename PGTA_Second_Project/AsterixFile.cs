using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace PGTA_Second_Project
{
    public class AsterixFile
    {
        private List<message048> itemList = new List<message048>();

        public List<message048> get048List() { return itemList; }
        public List<message048> byteOperations(string fullFile)
        {
            
            byte[] totalBytes = File.ReadAllBytes(fullFile);
            int i = 0;
            int astLength = totalBytes.Length;
            int k = 0;
            while (i < astLength)
            {
                List<byte> FSPEC = new List<byte>();
                List<byte> messageBytes = new List<byte>();

                int dataLength = (totalBytes[i + 1]<<8) | (totalBytes[i + 2]);

                FSPEC.Add(totalBytes[i + 3]);
                int messageStart = 4;

                if (totalBytes[i+3] % 2 == 1){
                    FSPEC.Add(totalBytes[i + 4]);
                    messageStart++;
                    if (totalBytes[i + 4] % 2 == 1)
                    {
                        FSPEC.Add(totalBytes[i + 5]);
                        messageStart++;
                        if (totalBytes[i + 5] % 2 == 1)
                        {
                            FSPEC.Add(totalBytes[i + 6]);
                            messageStart++;
                        }
                    }
                }

                for(int j = i+messageStart; j<i+dataLength; j++)
                {
                    messageBytes.Add(totalBytes[j]);
                }

                this.itemList.Add(new message048(dataLength, FSPEC, messageBytes));

                i = i + dataLength;

                k = k + 1;
            }
            return this.itemList;
        }
    }
}

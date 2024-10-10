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
        List<message048> itemList;
        public List<message048> byteOperations(string fullFile)
        {
            byte[] totalBytes = File.ReadAllBytes(fullFile);
            int i = 0;
            int astLength = totalBytes.Length;
            int k = 0;
            while (i < astLength)
            {
                /* Propuesta para comprobar que es CAT048
                 * if totalBytes[i] != 48
                    DEVOLVER ERROR
                    break
                   else
                    seguir con el bucle
                */
                int dataLength = totalBytes[i + 1] + totalBytes[i + 2];
                this.itemList.Add(new message048(dataItem1, dataItem2, dataItem3));
                i = i + dataLength;
                k = k + 1;
                return this.itemList
            }
        }
    }
}

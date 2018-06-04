using System;
using System.Collections;
using System.IO;

class BitArrayWriter{
    private BitArray bitArray;
    private string path;

    public BitArrayWriter(BitArray b, String path){
        this.bitArray = b;
        this.path = path;
    }

    public void write(){
        FileStream fos = new FileStream(path, FileMode.Create);
        byte[] byteArr = new byte[(bitArray.Length - 1) / 8 + 1];
        bitArray.CopyTo(byteArr, 0);
        fos.Write(byteArr, 0 , byteArr.Length);
        fos.Flush();
        fos.Close();
    }
}

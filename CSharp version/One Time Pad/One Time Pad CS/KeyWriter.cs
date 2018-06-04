using System;
using System.IO;
using System.Security.Cryptography;

class KeyWriter{

    public KeyWriter() {}

    public void writeKey(VernamKey vernamKey, String outputPath){
        File.WriteAllBytes(outputPath, vernamKey.getByteArray());
    }

    public void writeNewKey(int bytes, String outputPath){
        RandomNumberGenerator secureRandom = RandomNumberGenerator.Create();
        FileStream fos = new FileStream(outputPath, FileMode.Create);
        for(int i = 0; i < bytes; i++){
            byte[] b = new byte[1];
            secureRandom.GetBytes(b);
            fos.Write(b, 0, b.Length);
        }
        fos.Flush();
        fos.Close();
    }
}

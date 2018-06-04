using System;
using System.IO;
using System.Collections;

class VernamEngine{

    public VernamEngine(){}

    public static BitArray doOperation(BitArray a, VernamKey b){
        a.Xor(b.getKeyBitArray());
        return a;
    }

    public static void doStreamOperation(String inputPath, String outputPath, VernamKey vernamKey){
        BitArray b = vernamKey.getKeyBitArray();
        byte[] key = new byte[(b.Length - 1) / 8 + 1];
        b.CopyTo(key, 0);

        string inputFile = Path.GetFullPath(inputPath);

        if (new FileInfo(inputFile).Length == key.Length) {
            FileStream fis = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
            BinaryWriter br = new BinaryWriter(new FileStream(outputPath, FileMode.Create));

            int i = 0, j;
            while ((j = fis.ReadByte()) >= 0){
                br.Write((byte)(j ^ key[i]));
                i++;
            }

            fis.Close();
            br.Flush();
            br.Close();
        }else{
            throw new Exception("Key length mismatch detected");
        }
    }

    public static void doStreamOperationWithKeyFile(String inputPath, String outputPath, String keyPath){
        string keyFile = Path.GetFullPath(keyPath);
        string outputFile = Path.GetFullPath(outputPath);
        string inputFile = Path.GetFullPath(inputPath);

        if (new FileInfo(inputFile).Length == new FileInfo(keyFile).Length) {
            FileStream dis = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
            FileStream kis = new FileStream(keyFile, FileMode.Open, FileAccess.Read);

            BinaryWriter br = new BinaryWriter(new FileStream(outputFile, FileMode.Create, FileAccess.Write));

            int j;
            while ((j = dis.ReadByte()) >= 0) {
                br.Write((byte)(j ^ kis.ReadByte()));
            }

            dis.Close();
            kis.Close();
            br.Flush();
            br.Close();
        }else{
            throw new Exception("Key length mismatch detected");
        }
    }

    public static void doStreamOperationKeyFileNoDuplicate(String inputPath, String keyPath){
        string keyFile = Path.GetFullPath(keyPath);
        string inputFile = Path.GetFullPath(inputPath);

        if (new FileInfo(inputFile).Length == new FileInfo(keyFile).Length){
            FileStream dis = new FileStream(inputFile, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
            BinaryWriter bw = new BinaryWriter(new FileStream(inputFile, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite));
            FileStream kis = new FileStream(keyFile, FileMode.Open, FileAccess.Read);

            int j;
            while ((j = dis.ReadByte()) >= 0){
                bw.Write((byte)(j ^ kis.ReadByte()));
                bw.Flush();
            }

            dis.Close();
            kis.Close();
            bw.Close();
        }else{
            throw new Exception("Key length mismatch detected");
        }
    }

    public static void doStreamOperationNoDuplicate(String inputPath, VernamKey vernamKey){
        BitArray b = vernamKey.getKeyBitArray();
        byte[] key = new byte[(b.Length - 1) / 8 + 1];
        b.CopyTo(key, 0);

        string inputFile = Path.GetFullPath(inputPath);

        if (new FileInfo(inputFile).Length == key.Length){
            FileStream fis = new FileStream(inputFile, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
            BinaryWriter bw = new BinaryWriter(new FileStream(inputFile, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite));

            int i = 0, j;
            while ((j = fis.ReadByte()) >= 0){
                bw.Write((byte)(j ^ key[i]));
                bw.Flush();
                i++;
            }
            fis.Close();
            bw.Close();
        }else{
            throw new Exception("Key length mismatch detected");
        }
    }
}
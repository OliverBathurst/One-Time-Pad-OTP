using System;
using System.Collections;
using static System.IO.File;
using static System.IO.Path;

class KeyReader{

    public KeyReader() {}

    public VernamKey readKey(String filePath){
        return new VernamKey(new BitArray(ReadAllBytes(GetFullPath(filePath))));
    }

    public byte[] readKeyIntoByteArray(String filePath){
        return ReadAllBytes(GetFullPath(filePath));
    }

    public BitArray readKeyIntoBitArray(String filePath){
        return new BitArray(ReadAllBytes(GetFullPath(filePath)));
    }
}

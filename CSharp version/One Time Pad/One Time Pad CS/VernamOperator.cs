using System;
using System.Collections;
using static System.Text.Encoding;

class VernamOperator{

    public VernamOperator() {}

    public void performFileStreamOperation(String inputPath, String outputPath, VernamKey vernamKey){
        VernamEngine.doStreamOperation(inputPath, outputPath, vernamKey);
    }
    public void fileStreamOperationWithKeyFile(String inputPath, String outputPath, String vernamKeyPath){
        VernamEngine.doStreamOperationWithKeyFile(inputPath, outputPath, vernamKeyPath);
    }

    public void fileOperation(String filePath, VernamKey key){
        new BitArrayWriter(VernamEngine.doOperation(new BitArrayReader(filePath).readFileIntoBitSet(), key), filePath).write();
    }

    public void performFileOperation(BitArray fileBitSet, VernamKey key, String outputPath){
        new BitArrayWriter(VernamEngine.doOperation(fileBitSet, key), outputPath).write();
    }

    public BitArray performTextOperation(String text, VernamKey key){
        return VernamEngine.doOperation(new BitArray(ASCII.GetBytes(text)), key);
    }

    public string performTextOperationToString(String text, VernamKey key){
        return VernamEngine.doOperation(new BitArray(ASCII.GetBytes(text)), key).ToString();
    }
}

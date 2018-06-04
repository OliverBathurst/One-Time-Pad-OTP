using System.IO;
using System.Collections;

class BitArrayReader{
    private string filePath;

    public BitArrayReader(){}

    public BitArrayReader(string filepath){
        this.filePath = filepath;
    }

    public void setFilePath(string filePath){
        this.filePath = filePath;
    }

    public string getFilePath(){
        return filePath;
    }

    public BitArray readFileIntoBitSet(){
        return new BitArray(File.ReadAllBytes(Path.GetFullPath(filePath)));
    }
}
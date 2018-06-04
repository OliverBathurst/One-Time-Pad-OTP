using System.Collections;

class VernamKey{
    private BitArray b;

    public VernamKey(BitArray bitArray){
        b = bitArray;
    }

    public BitArray getKeyBitArray(){
        return b;
    }

    public byte[] getByteArray(){
        byte[] arr = new byte[(b.Length - 1) / 8 + 1];
        b.CopyTo(arr, 0);
        return arr;
    }
}

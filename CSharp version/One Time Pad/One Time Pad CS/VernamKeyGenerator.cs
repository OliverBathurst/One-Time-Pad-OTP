using System.Security.Cryptography;
using System.Collections;

class VernamKeyGenerator{
    private RandomNumberGenerator secureRandom = RandomNumberGenerator.Create();

    public VernamKeyGenerator() {}

    public VernamKey generateKey(int length){
        byte[] keyBytes = new byte[length];
        secureRandom.GetBytes(keyBytes);
        return new VernamKey(new BitArray(keyBytes));
    }
}
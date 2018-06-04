import java.security.SecureRandom;
import java.util.BitSet;

/**
 * Created by Oliver on 17/05/2018.
 * Written by Oliver Bathurst <oliverbathurst12345@gmail.com>
 */

class VernamKeyGenerator {
    private final SecureRandom secureRandom = new SecureRandom();

    VernamKeyGenerator(){}

    VernamKey generateKey(int length){
        byte[] keyBytes = new byte[length];
        secureRandom.nextBytes(keyBytes);
        return new VernamKey(BitSet.valueOf(keyBytes));
    }
}
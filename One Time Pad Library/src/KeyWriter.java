import java.io.FileOutputStream;
import java.io.IOException;
import java.security.SecureRandom;

/**
 * Created by Oliver on 17/05/2018.
 * Written by Oliver Bathurst <oliverbathurst12345@gmail.com>
 */

class KeyWriter {

    KeyWriter(){}

    void writeKey(VernamKey vernamKey, String outputPath) throws IOException {
        FileOutputStream fos = new FileOutputStream(outputPath);
        fos.write(vernamKey.getByteArray());
        fos.flush();
        fos.close();
    }

    void writeNewKey(int bytes, String outputPath) throws IOException {
        final SecureRandom secureRandom = new SecureRandom();
        FileOutputStream fos = new FileOutputStream(outputPath);
        for(int i = 0; i < bytes; i++){
            byte[] b = new byte[1];
            secureRandom.nextBytes(b);
            fos.write(b);
        }
        fos.flush();
        fos.close();
    }
}
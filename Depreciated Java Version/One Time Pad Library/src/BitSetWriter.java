import java.io.FileOutputStream;
import java.io.IOException;
import java.util.BitSet;

/**
 * Created by Oliver on 17/05/2018.
 * Written by Oliver Bathurst <oliverbathurst12345@gmail.com>
 */

class BitSetWriter {
    private final BitSet bitSet;
    private final String path;

    BitSetWriter(BitSet b, String path){
        this.bitSet = b;
        this.path = path;
    }

    void write() throws IOException {
        FileOutputStream fos = new FileOutputStream(path);
        fos.write(bitSet.toByteArray());
        fos.close();
    }
}
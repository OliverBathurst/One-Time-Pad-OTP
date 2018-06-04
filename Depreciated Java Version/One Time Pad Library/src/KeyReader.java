import java.io.*;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.BitSet;

/**
 * Created by Oliver on 17/05/2018.
 * Written by Oliver Bathurst <oliverbathurst12345@gmail.com>
 */

class KeyReader {

    KeyReader(){}

    VernamKey readKey(String filePath) throws IOException {
        return new VernamKey(BitSet.valueOf(Files.readAllBytes(Paths.get(filePath))));
    }

    byte[] readKeyIntoByteArray(String filePath) throws IOException {
        return Files.readAllBytes(Paths.get(filePath));
    }

    BitSet readKeyIntoBitSet(String filePath) throws IOException {
        return BitSet.valueOf(Files.readAllBytes(Paths.get(filePath)));
    }
}
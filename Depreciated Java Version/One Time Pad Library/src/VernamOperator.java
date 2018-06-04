import java.io.IOException;
import java.util.BitSet;

/**
  Created by Oliver on 17/05/2018.
  Written by Oliver Bathurst <oliverbathurst12345@gmail.com>
 */

/**
 * Sample operators for Vernam encryption/decryption
 */
class VernamOperator {

    VernamOperator(){}

    void performFileStreamOperation(String inputPath, String outputPath, VernamKey vernamKey) throws Exception {
        VernamEngine.doStreamOperation(inputPath, outputPath, vernamKey);
    }
    void fileStreamOperationWithKeyFile(String inputPath, String outputPath, String vernamKeyPath) throws Exception {
        VernamEngine.doStreamOperationWithKeyFile(inputPath, outputPath, vernamKeyPath);
    }

    void fileOperation(String filePath, VernamKey key) throws IOException {
        new BitSetWriter(VernamEngine.doOperation(new BitSetReader(filePath).readFileIntoBitSet(), key), filePath).write();
    }

    void performFileOperation(BitSet fileBitSet, VernamKey key, String outputPath) throws IOException {
        new BitSetWriter(VernamEngine.doOperation(fileBitSet, key), outputPath).write();
    }

    BitSet performTextOperation(String text, VernamKey key) {
        return VernamEngine.doOperation(BitSet.valueOf(text.getBytes()), key);
    }

    String performTextOperationToString(String text, VernamKey key) {
        return VernamEngine.doOperation(BitSet.valueOf(text.getBytes()), key).toString();
    }
}
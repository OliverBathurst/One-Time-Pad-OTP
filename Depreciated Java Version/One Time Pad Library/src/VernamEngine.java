import java.io.*;
import java.util.BitSet;

/**
 * Created by Oliver on 17/05/2018.
 * Written by Oliver Bathurst <oliverbathurst12345@gmail.com>
 */

class VernamEngine {

    VernamEngine(){}

    static BitSet doOperation(BitSet a, VernamKey b){
        a.xor(b.getKeyBitSet());
        return a;
    }

    static void doStreamOperation(String inputPath, String outputPath, VernamKey vernamKey) throws Exception {
        byte[] key = vernamKey.getKeyBitSet().toByteArray();
        File inputFile = new File(inputPath);

        if(inputFile.length() == key.length) {
            DataInputStream dis = new DataInputStream(new FileInputStream(inputFile));
            FileOutputStream fos = new FileOutputStream(outputPath);

            int i = 0;
            while(dis.available() > 0) {
                fos.write(new byte[]{(byte) (dis.readByte() ^ key[i])});
                i++;
            }
            dis.close();
            fos.flush();
            fos.close();
        }else{
            throw new Exception("Key length mismatch detected");
        }
    }

    static void doStreamOperationWithKeyFile(String inputPath, String outputPath, String keyPath) throws Exception {
        File keyFile = new File(keyPath);
        File inputFile = new File(inputPath);

        if(inputFile.length() == keyFile.length()) {
            DataInputStream dis = new DataInputStream(new FileInputStream(inputFile));
            DataInputStream kis = new DataInputStream(new FileInputStream(keyFile));

            FileOutputStream fos = new FileOutputStream(outputPath);

            while(dis.available() > 0 && kis.available() > 0) {
                fos.write(new byte[]{(byte) (dis.readByte() ^ kis.readByte())});
            }
            dis.close();
            kis.close();
            fos.flush();
            fos.close();
        }else{
            throw new Exception("Key length mismatch detected");
        }
    }
}
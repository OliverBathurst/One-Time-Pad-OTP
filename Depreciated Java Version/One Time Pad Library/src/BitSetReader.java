import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.BitSet;

/**
 * Created by Oliver on 17/05/2018.
 * Written by Oliver Bathurst <oliverbathurst12345@gmail.com>
 */

class BitSetReader {
    private String filePath;

    BitSetReader(){}

    BitSetReader(String filepath){
        this.filePath = filepath;
    }

    void setFilePath(String filePath){
        this.filePath = filePath;
    }

    String getFilePath(){
        return this.filePath;
    }

    BitSet readFileIntoBitSet() throws IOException {
        return BitSet.valueOf(Files.readAllBytes(Paths.get(this.filePath)));
    }
}
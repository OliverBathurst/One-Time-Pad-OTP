import java.io.Serializable;
import java.util.BitSet;

/**
 * Created by Oliver on 17/05/2018.
 * Written by Oliver Bathurst <oliverbathurst12345@gmail.com>
 */

class VernamKey implements Serializable{
	private static final long serialVersionUID = 1L;
	private BitSet b;

    VernamKey(BitSet bitSet){
        this.b = bitSet;
    }

    BitSet getKeyBitSet(){
        return b;
    }

    byte[] getByteArray(){
        return b.toByteArray();
    }

    void setBitSet(byte[] array){
        this.b = BitSet.valueOf(array);
    }
}
# One-Time-Pad-OTP
A small One-Time-Pad (Vernam Cipher) library and sample application.  
In cryptography, the one-time pad (OTP) is an encryption technique that cannot be cracked, but requires the use of a one-time pre-shared key the same size as, or longer than, the message being sent.
It is therefore a symmetric key encryption/decryption technique.
In this technique, a plaintext is paired with a random secret key (also referred to as a one-time pad). Then, each bit or character of the plaintext is encrypted by combining it with the corresponding bit or character from the pad using modular addition (XOR). If the key is truly random, is at least as long as the plaintext, is never reused in whole or in part, and is kept completely secret, then the resulting ciphertext will be impossible to decrypt or break.
## One-Time-Pad Sample Application ##
Within this project is a sample application that uses the included library. This tool will assist a user in using the Vernam cipher (One-Time-Pad variant) to encrypt and decrypt files.
![alt text](https://github.com/OliverBathurst/One-Time-Pad-OTP/blob/master/screens/screen.PNG)
### Features ###
* 'Open File' - user specifies a file for operation
* 'Generate New Key' - generates a one-time-pad key the size of the selected file, key resides in memory
* 'Open Key File' - user specifies a saved key file to be used as the key in an operation, this option loads the key from the keyfile into memory (unsuitable for large keys, use 'Stream Key From File' instead)
* 'Write Key To File' - writes the key in memory to an output file specified by the user
* 'Write New Key To File' - writes a key the size of the selected file to an output file specified by the user, as the key never resides entirely in memory, this is useful for larger files (that have large keys that won't fit in memory)
* 'Encrypt/Decrypt' - takes the selected file and encrypts/decrypts using the key from memory/keyfile, outputs resulting encrypted/decrypted file to the specified output path
* 'Output Path' - sets output path for the encrypted/decrypted file
* 'Use Key From Memory' - the application will perform the encryption/decryption process using the key currently in memory
* 'Stream Key From File' - the application will perform the encryption/decryption process using the keyfile specified by the user, the keyfile is streamed (and the output file created) on a byte-by-byte basis, this should be used when memory is limited and the key is too large to be loaded into memory

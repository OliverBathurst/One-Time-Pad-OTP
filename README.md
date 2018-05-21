# One-Time-Pad-OTP
A small One-Time-Pad (Vernam Cipher) library and sample application.  
In cryptography, the one-time pad (OTP) is an encryption technique that cannot be cracked, but requires the use of a one-time pre-shared key the same size as, or longer than, the message being sent.
It is therefore a symmetric key encryption/decryption technique.
In this technique, a plaintext is paired with a random secret key (also referred to as a one-time pad). Then, each bit or character of the plaintext is encrypted by combining it with the corresponding bit or character from the pad using modular addition (XOR). If the key is truly random, is at least as long as the plaintext, is never reused in whole or in part, and is kept completely secret, then the resulting ciphertext will be impossible to decrypt or break.
# One-Time-Pad Sample Application
Within this project is a sample application that uses the included library. This tool will assist a user in using the Vernam cipher (One-Time-Pad variant) to encrypt and decrypt files.
![alt text](https://github.com/OliverBathurst/One-Time-Pad-OTP/blob/master/screens/screen.PNG)
* 'Open File' - user specifies a file for operation
* 'Generate New Key' - generates a one-time-pad key the size of the selected file, key resides in memory
* 'Open Key File' - user specifies a saved key file to be used as the key in an operation

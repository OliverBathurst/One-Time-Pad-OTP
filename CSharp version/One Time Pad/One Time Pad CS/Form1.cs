using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace One_Time_Pad_CS{
    public partial class otp : Form{
        private string inputPath, streamKeyPath, duplicatePath;
        private static VernamKey currentKey;

        public otp(){
            InitializeComponent();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e){
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK){
                inputPath = file.FileName;
                log.AppendText("Current File: " + inputPath + "\n");
            }
        }

        private void otp_Load(object sender, EventArgs e){
            keyFrom.SelectedIndex = 0;
            fileOptions.SelectedIndex = 0;
        }

        private void generateNewKeyToolStripMenuItem_Click(object sender, EventArgs e){
            if (inputPath != null){
                log.AppendText("Generating key\n");
                Thread t = new Thread(() => KeyGen(new FileInfo(inputPath).Length));
                t.Start();
            }
            else{
                log.AppendText("No current file selected\n");
            }
        }

        private void writeKeyToFileToolStripMenuItem_Click(object sender, EventArgs e){
            if (currentKey != null){
                SaveFileDialog file = new SaveFileDialog();
                file.Filter = "Vernam Cipher Symmetric Key (*.vcsk)|*.vcsk|All Files(*.*)|*.*";
                if (file.ShowDialog() == DialogResult.OK){
                    string path = file.FileName;
                    log.AppendText("Writing key to: " + path + "\n");
                    Thread t = new Thread(() => KeyWriteBackgroundTask(path, currentKey));
                    t.Start();
                }
            }else{
                log.AppendText("No key in memory\n");
            }
        }

        private void writeNewKeyToFileToolStripMenuItem_Click(object sender, EventArgs e){
            SaveFileDialog file = new SaveFileDialog();
            if (inputPath != null){
                file.Filter = "Vernam Cipher Symmetric Key (*.vcsk)|*.vcsk|All Files(*.*)|*.*";
                if (file.ShowDialog() == DialogResult.OK){
                    string path = file.FileName;
                    long fileSize = new FileInfo(inputPath).Length;
                    log.AppendText("Writing key of size: " + fileSize + " to " + path + "\n");
                    Thread t = new Thread(() => KeyWriterBackgroundTask((int) fileSize, path));
                    t.Start();
                }
            }else{
                log.AppendText("No current file selected to generate a key from, please use 'Open File' to select a file\n");
            }
        }

        private void encryptDecryptToolStripMenuItem_Click(object sender, EventArgs e){
            log.AppendText("Encrypting/Decrypting...\n");
            if (inputPath != null){
                if(keyFrom.SelectedIndex == 0){
                    if(currentKey != null){
                        if(fileOptions.SelectedIndex == 0){
                            Thread t = new Thread(() => existingWithKey(inputPath, currentKey));
                            t.Start();
                        }else if(fileOptions.SelectedIndex == 1){
                            if(duplicatePath != null){
                                Thread t = new Thread(() => duplicateKeyInMemory(inputPath, duplicatePath, currentKey));
                                t.Start();
                            }
                            else{
                                log.AppendText("No duplicate file path selected\n");
                            }
                        }
                    }else{
                        log.AppendText("No current key in memory\n");
                    }
                }else if(keyFrom.SelectedIndex == 1){
                    if(streamKeyPath != null){
                        if (fileOptions.SelectedIndex == 0){
                            Thread t = new Thread(() => overwriteExistingWithKeyFile(inputPath, streamKeyPath));
                            t.Start();
                        }else if (fileOptions.SelectedIndex == 1){
                            Thread t = new Thread(() => createDuplicatteWithKeyFile(inputPath, duplicatePath, streamKeyPath));
                            t.Start();
                        }
                    }else{
                        log.AppendText("Invalid key path\n");
                    }
                }
            }else{
                log.AppendText("No current file selected to generate a key from, please use 'Open File' to select a file\n");
            }
        }

        private void selectKeyFile(object sender, EventArgs e){
            if(keyFrom.SelectedIndex == 1){
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = "Vernam Cipher Symmetric Key (*.vcsk)|*.vcsk|All Files(*.*)|*.*";
                if (file.ShowDialog() == DialogResult.OK){
                    streamKeyPath = file.FileName;
                    log.AppendText("Stream key from: " + streamKeyPath + "\n");
                }
            }
        }

        private void openKeyFileToolStripMenuItem_Click(object sender, EventArgs e){
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Vernam Cipher Symmetric Key (*.vcsk)|*.vcsk|All Files(*.*)|*.*";
            if (file.ShowDialog() == DialogResult.OK){
                string keyPath = file.FileName;
                log.AppendText("Reading key from: " + keyPath + "\n");
                Thread t = new Thread(() => KeyReaderBackgroundTask(keyPath));
                t.Start();
            }
        }

        private void selectDuplicate(object sender, EventArgs e){
            if(fileOptions.SelectedIndex == 1){
                SaveFileDialog sfd = new SaveFileDialog();
                if (sfd.ShowDialog() == DialogResult.OK){
                    duplicatePath = sfd.FileName;
                    log.AppendText("Duplicate file path: " + duplicatePath +  "\n");
                }
            }
        }

        static void existingWithKey(string inputPath, VernamKey vernamKey){
            VernamEngine.doStreamOperationNoDuplicate(inputPath, vernamKey);
            MessageBox.Show("Operation complete", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        static void duplicateKeyInMemory(string inputPath, string outputPath, VernamKey vernamKey){
            VernamEngine.doStreamOperation(inputPath, outputPath, vernamKey);
            MessageBox.Show("Operation complete", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        static void overwriteExistingWithKeyFile(string inputPath, string keyPath) {
            VernamEngine.doStreamOperationKeyFileNoDuplicate(inputPath, keyPath);
            MessageBox.Show("Operation complete", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        static void createDuplicatteWithKeyFile(string inputPath, string outputPath, string keyPath){
            VernamEngine.doStreamOperationWithKeyFile(inputPath, outputPath, keyPath);
            MessageBox.Show("Operation complete", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        static void KeyGen(long size){
            currentKey = new VernamKeyGenerator().generateKey((int)size);
            MessageBox.Show("Key generated", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        static void KeyReaderBackgroundTask(string path){
            currentKey = new KeyReader().readKey(path);
            MessageBox.Show("Key read", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        static void KeyWriteBackgroundTask(string path, VernamKey vernam){
            new KeyWriter().writeKey(vernam, path);
            MessageBox.Show("Key written", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        static void KeyWriterBackgroundTask(int size, string filePath){
            new KeyWriter().writeNewKey(size, filePath);
            MessageBox.Show("Key written", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
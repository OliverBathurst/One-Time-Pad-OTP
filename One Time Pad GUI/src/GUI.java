/**
 * Created by Oliver on 19/05/2018.
 * Written by Oliver Bathurst <oliverbathurst12345@gmail.com>
 */
import javax.swing.*;
import javax.swing.filechooser.FileNameExtensionFilter;
import java.io.File;
import java.io.IOException;

class GUI {
    private JPanel panel1;
    private JButton openFile;
    private JTextArea log;
    private JButton encryptDecryptButton;
    private JButton openKeyFileButton;
    private JButton writeKeyToFileButton;
    private JButton generateNewKey;
    private JRadioButton useKeyFromMemoryRadioButton;
    private JButton writeNewKeyToButton;
    private JRadioButton stream;
    private JFormattedTextField formattedTextField1;
    private JButton selectKeyToStream;
    private JButton setOutputPathButton;
    private JLabel outputPathLabel;
    private JFormattedTextField outputPath;
    private static VernamKey currentKey;
    private File currentFile, currentKeyFile, currentOutputFile;

    private GUI(){
        useKeyFromMemoryRadioButton.addActionListener(e -> {
            if(stream.isSelected()){
                stream.setSelected(false);
            }
        });
        stream.addActionListener(e -> {
            if(useKeyFromMemoryRadioButton.isSelected()){
                useKeyFromMemoryRadioButton.setSelected(false);
            }
        });
        encryptDecryptButton.addActionListener(e -> {
            if(useKeyFromMemoryRadioButton.isSelected()) {
                if (currentFile != null) {
                    if (currentKey != null) {
                        if(currentKey.getByteArray().length == currentFile.length()) {
                            if (currentOutputFile != null) {
                                new CipherBackgroundTaskKeyInMem(currentFile, currentOutputFile, currentKey).execute();
                            } else {
                                log.append("No output file selected\n");
                            }
                        }else{
                            log.append("Key length mismatch\n");
                        }
                    }else{
                        log.append("No key in memory\n");
                    }
                }else{
                    log.append("No file selected\n");
                }
            }else if(stream.isSelected()){
                if (currentFile != null) {
                    if (currentKeyFile != null) {
                        if(currentFile.length() == currentKeyFile.length()) {
                            if (currentOutputFile != null) {
                                new CipherBackgroundTaskKeyInFile(currentFile, currentOutputFile, currentKeyFile).execute();
                            } else {
                                log.append("No output file selected\n");
                            }
                        }else{
                            log.append("Key length mismatch\n");
                        }
                    }else{
                        log.append("No key file selected\n");
                    }
                }else{
                    log.append("No file selected\n");
                }
            }
        });
        openFile.addActionListener(e -> {
            JFileChooser jfc = new JFileChooser();
            if (jfc.showOpenDialog(panel1) == JFileChooser.APPROVE_OPTION) {
                File f = jfc.getSelectedFile();
                if (f != null) {
                    currentFile = f;
                }
                log.append("Current File: " + currentFile.getAbsolutePath() + "\n");
            }
        });
        setOutputPathButton.addActionListener(e -> {
            JFileChooser jfc = new JFileChooser();
            if (jfc.showSaveDialog(panel1) == JFileChooser.APPROVE_OPTION) {
                File f = jfc.getSelectedFile();
                if (f != null) {
                    currentOutputFile = f;
                    outputPath.setText(currentOutputFile.getAbsolutePath());
                    log.append("Set output path as: " + currentOutputFile.getAbsolutePath() + "\n");
                }
            }
        });
        selectKeyToStream.addActionListener(e -> {
            JFileChooser jfc = new JFileChooser();
            jfc.setFileFilter(new FileNameExtensionFilter ("Vernam Cipher Symmetric Key .vcsk", "vcsk"));
            jfc.setAcceptAllFileFilterUsed(false);
            if (jfc.showOpenDialog(panel1) == JFileChooser.APPROVE_OPTION) {
                File f = jfc.getSelectedFile();
                if (f != null) {
                    currentKeyFile = f;
                }
                formattedTextField1.setText(currentKeyFile.getAbsolutePath());
                log.append("Current Key File: " + currentKeyFile.getAbsolutePath() + "\n");
            }
        });
        generateNewKey.addActionListener(e -> {
            if(currentFile != null) {
                new KeyGen((int) currentFile.length()).execute();
            }else{
                log.append("No current file selected\n");
            }
        });
        writeKeyToFileButton.addActionListener(e -> {
            if(currentKey != null){
                JFileChooser jfc = new JFileChooser();
                jfc.setFileFilter(new FileNameExtensionFilter("Vernam Cipher Symmetric Key .vcsk", "vcsk"));
                if (jfc.showSaveDialog(panel1) == JFileChooser.APPROVE_OPTION) {
                    File f = jfc.getSelectedFile();
                    if (f != null) {
                        log.append("Writing key to: " + f.getAbsolutePath() + ".vcsk\n");
                        new KeyWriteBackgroundTask(f).execute();
                    }
                }
            }else{
                log.append("No key in memory\n");
            }
        });
        openKeyFileButton.addActionListener(e -> {
            JFileChooser jfc = new JFileChooser();
            jfc.setFileFilter(new FileNameExtensionFilter ("Vernam Cipher Symmetric Key .vcsk", "vcsk"));
            jfc.setFileSelectionMode(JFileChooser.FILES_ONLY);
            jfc.setAcceptAllFileFilterUsed(false);
            if (jfc.showOpenDialog(panel1) == JFileChooser.APPROVE_OPTION) {
                File f = jfc.getSelectedFile();
                if (f != null) {
                    log.append("Reading key from: " + f.getAbsolutePath() + "\n");
                    new KeyReaderBackgroundTask(f).execute();
                }
            }
        });
        writeNewKeyToButton.addActionListener(e -> {
            JFileChooser jfc = new JFileChooser();
            if(currentFile != null) {
                try {
                    jfc.setFileFilter(new FileNameExtensionFilter("Vernam Cipher Symmetric Key .vcsk", "vcsk"));
                    jfc.setAcceptAllFileFilterUsed(false);
                    if (jfc.showSaveDialog(panel1) == JFileChooser.APPROVE_OPTION) {
                        File f = jfc.getSelectedFile();
                        if (f != null) {
                            log.append("Writing key of size: " + (int) currentFile.length() + " to " + f.getAbsolutePath() + ".vcsk\n");
                            new KeyWriterBackgroundTask((int) currentFile.length(), f).execute();
                        } else {
                            log.append("Error saving file\n");
                        }
                    }
                } catch (Exception f) {
                    log.append("Error parsing integer: " + f.getMessage() + "\n");
                }
            }else{
                log.append("No current file selected to generate a key from, please use 'Open File' to select a file\n");
            }
        });
    }

    class CipherBackgroundTaskKeyInFile extends SwingWorker<Void, Object> {
        private final File currentFile, currentOutputFile, currentKeyFile;

        CipherBackgroundTaskKeyInFile(File in, File out, File key){
            this.currentFile = in;
            this.currentOutputFile = out;
            this.currentKeyFile = key;
        }

        @Override
        protected Void doInBackground() throws Exception {
            VernamEngine.doStreamOperationWithKeyFile(currentFile.getAbsolutePath(), currentOutputFile.getAbsolutePath(), currentKeyFile.getAbsolutePath());
            return null;
        }
        protected void done() {
            log.append("Operation complete\n");
        }
    }

    class CipherBackgroundTaskKeyInMem extends SwingWorker<Void, Object> {
        private final File input, output;
        private final VernamKey vernamKey;

        CipherBackgroundTaskKeyInMem(File input, File output, VernamKey vernamKey){
            this.input = input;
            this.output = output;
            this.vernamKey = vernamKey;
        }

        @Override
        protected Void doInBackground() throws Exception {
            VernamEngine.doStreamOperation(input.getAbsolutePath(), output.getAbsolutePath(), vernamKey);
            return null;
        }
        protected void done() {
            log.append("Operation complete\n");
        }
    }

    class KeyWriterBackgroundTask extends SwingWorker<Void, Object> {
        private final File f;
        private final int size;
        KeyWriterBackgroundTask(int size, File file){
            this.size = size;
            this.f = file;
        }
        @Override
        protected Void doInBackground() throws Exception {
            new KeyWriter().writeNewKey(size, f.getAbsolutePath() + ".vcsk");
            return null;
        }
        protected void done() {
            log.append("Key written\n");
        }
    }


    class KeyGen extends SwingWorker<Void, Object> {
        private final int size;
        KeyGen(int size){
            this.size = size;
        }
        @Override
        protected Void doInBackground() throws Exception {
            currentKey = new VernamKeyGenerator().generateKey(this.size);
            return null;
        }
        protected void done() {
            log.append("New key generated\n");
        }
    }

    class KeyReaderBackgroundTask extends SwingWorker<Void, Object> {
        private final File file;
        KeyReaderBackgroundTask(File f){
            this.file = f;
        }
        @Override
        protected Void doInBackground() throws Exception {
            currentKey = new KeyReader().readKey(file.getAbsolutePath());
            return null;
        }
        protected void done() {
            log.append("Reading complete\n");
        }
    }

    class KeyWriteBackgroundTask extends SwingWorker<Void, Object> {
        private final File file;
        KeyWriteBackgroundTask(File f){
            this.file = f;
        }
        @Override
        public Void doInBackground() {
            try {
                new KeyWriter().writeKey(currentKey, file.getAbsolutePath() + ".vcsk");
            } catch (IOException e) {
                log.append("Error writing key\n");
            }
            return null;
        }
        @Override
        protected void done() {
            log.append("Writing complete\n");
        }
    }

    public static void main(String[] args){
        JFrame frame = new JFrame("Vernam File Tool");
        frame.setContentPane(new GUI().panel1);
        frame.setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        frame.setSize(600,400);
        frame.setVisible(true);
    }
}
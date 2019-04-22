using System;
using System.Diagnostics;

namespace MinesweeperProject.Architecture.Factory {
    public class CppGenerator : IGenerator {

        private const string Filename = "..\\Executables\\Mines.exe";
        private string _buffer;
        
        public char[,] GenerateBoard(int size, int mines) {
            _buffer = "";
            
            Process process = new Process();

            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.EnableRaisingEvents = true;
            process.StartInfo.FileName = Filename;

            process.Start();
            process.BeginOutputReadLine();
            process.OutputDataReceived += new DataReceivedEventHandler(ProcessOutput);

            process.WaitForExit();
            process.Close();
            
            char[,] board = new char[size, size];
            int textPos = 0;
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    board[i, j] = _buffer[textPos];
                    textPos++;
                }
            }

            return board;
        }
        
        private void ProcessOutput(object sender, DataReceivedEventArgs e) {

            if(e.Data != null){
                string s = e.Data.ToString();
                _buffer += s;

            }
        }
    }
}
using System.IO;
using System.Net;
using System.Resources;

namespace MinesweeperProject.Architecture.Factory {
    public class WebGenerator : IGenerator {

        private const string Url = "http://127.0.0.1:9876/minesweaper";
        
        public char[,] GenerateBoard(int size, int mines) {
            string endpointUrl = Url + "/generate?size=" + size + "&mines=" + mines;
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(endpointUrl);

            request.Method = "GET";
            request.Accept = "text/plain";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
 
            var content = string.Empty;
            using (var response = (HttpWebResponse)request.GetResponse()) {
                using (var stream = response.GetResponseStream()) {
                    using (var sr = new StreamReader(stream)) {
                        content = sr.ReadToEnd();
                    }
                }
            }

            char[,] board = new char[size, size];
            int textPos = 0;
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    board[i, j] = content[textPos];
                    textPos++;
                }
            }

            return board;
        }
    }
}
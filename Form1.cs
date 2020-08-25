using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Gotocommic
{
    public partial class Form1 : Form
    {
        private readonly string folder = @"C:\Temp_GoTOCommic";
        string nameCBZ;
        int nVolumes = 0;
        public Form1()
        { InitializeComponent(); }

        #region Action Button

        private void BtnChapter_Click(object sender, EventArgs e)
        {
            DialogResult resulta = Pasta_Arquivos.ShowDialog();
            if (resulta == DialogResult.OK)
            {
                StatusProgress(Pasta_Arquivos.SelectedPath, progressBar1, true);
                DirectoryInfo dirInfo = new DirectoryInfo(Pasta_Arquivos.SelectedPath);
                nameCBZ = dirInfo.Name;
                SearchFiles(dirInfo, false);
                StatusProgress(Pasta_Arquivos.SelectedPath, progressBar1, false);
                MessageBox.Show("Was done " + nameCBZ + "!");
            }
        }

        private void BtnVolume_Click(object sender, EventArgs e)
        {
            DialogResult result = Pasta_Arquivos.ShowDialog();
            if (result == DialogResult.OK)
            {
                StatusProgress(Pasta_Arquivos.SelectedPath, progressBar1, true);
                DirectoryInfo dirInfo = new DirectoryInfo(Pasta_Arquivos.SelectedPath);
                nameCBZ = dirInfo.Name;
                SearchFiles(dirInfo, true);
                StatusProgress(Pasta_Arquivos.SelectedPath, progressBar1, false);
                MessageBox.Show("Were done " + nVolumes.ToString() + " volumes " + nameCBZ + "!");
                nVolumes = 0;
            }
        }

        private void BtnOrder_Click(object sender, EventArgs e)
        {
            DialogResult result = Pasta_Arquivos.ShowDialog();
            if (result == DialogResult.OK)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(Pasta_Arquivos.SelectedPath);
                StatusProgress(Pasta_Arquivos.SelectedPath, progressBar1, true);
                int c = 0;
                foreach (DirectoryInfo subdirectory in dirInfo.GetDirectories())
                {
                    int Getdir = dirInfo.GetDirectories().Length;
                    c++;
                    string path = Pasta_Arquivos.SelectedPath + @"\" + "Cap_" + c.ToString() + "_";
                    Directory.CreateDirectory(path);
                    string[] files = SearchByExtensions(subdirectory.FullName);
                    foreach (string file in files)
                    {
                        int Getfile = files.Length;
                        string Cam = path + @"\" + Path.GetFileName(file);
                        File.Copy(file, Cam, true);
                    }
                    ClearFolderTemp(subdirectory.FullName);
                    progressBar1.Increment(1);
                }

                foreach (DirectoryInfo subdirectory in dirInfo.GetDirectories())
                {
                    string[] files = SearchByExtensions(subdirectory.FullName);
                    foreach (string file in files)
                    {
                        CopyToFolderTemp(subdirectory.FullName);
                        progressBar1.Increment(1);
                    }
                    ClearFolderTemp(subdirectory.FullName);
                    progressBar1.Increment(1);
                }
                progressBar1.Value = (progressBar1.Maximum);
                StatusProgress(Pasta_Arquivos.SelectedPath, progressBar1, false);
                MessageBox.Show("Complete Order");
            }
        }

        private void BtnOrderFile_Click(object sender, EventArgs e)
        {
            string FolderPath;
            DialogResult resulta = Pasta_Arquivos.ShowDialog();
            if (resulta == DialogResult.OK)
            {
                FolderPath = Pasta_Arquivos.SelectedPath;
                string[] FileNames = OrderInArray(FolderPath);
                RenameInOrder(FileNames, FolderPath);
                MessageBox.Show("Complete Order by file");
            }
            else { return; }
        }

        #endregion

        #region Functions

        /// <summary>
        /// Search files in directory and subdirectory
        /// </summary>
        /// <param name="directory">directory for search</param>
        private void SearchFiles(DirectoryInfo directory)
        {
            foreach (DirectoryInfo subdirectory in directory.GetDirectories())
            { SearchFiles(subdirectory); }
        }
        
        /// <summary>
        /// Search files in directory and subdirectory, checking if it is a volume or chapter
        /// </summary>
        /// <param name="directory">directory for search</param>
        /// <param name="volume">bool for identify if is a volume</param>
        private void SearchFiles(DirectoryInfo directory, bool volume)
        {
            DirectoryInfo[] Directory = directory.GetDirectories();
            if (volume)
            {
                foreach (DirectoryInfo Diretor in Directory)
                {
                    CopyToFolderTemp(Diretor.FullName, true, directory);
                    CreateCBZ(Diretor.FullName, Diretor.Name, volume);
                }
            }
            else
            {
                CopyToFolderTemp(directory.FullName, false, directory);
                CreateCBZ(directory.FullName, directory.Name, volume);
            }
        }

        /// <summary>
        /// Copies files from the indicated path to a temporary folder
        /// </summary>
        /// <param name="pathManga">path directory</param>
        /// <param name="volume">bool for identify if is a volume</param>
        /// <param name="diretorio">directory with name manga</param>
        public void CopyToFolderTemp(string pathManga, bool volume, DirectoryInfo diretorio)
        {
            if (volume)
            {

                if (!Directory.Exists(folder))
                { Directory.CreateDirectory(folder); }
                try
                {
                    string[] files = SearchByExtensions(pathManga);
                    foreach (string file in files)
                    {
                        string nomePasta = file.Substring(pathManga.Length + 1);
                        string Cam = folder + @"\" + nomePasta + Path.GetFileName(file);
                        File.Copy(file, Cam, true);
                        progressBar1.Increment(1);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR COPY");
                    throw;
                }
                Thread.Sleep(1500);
            }
            else
            {
                if (!Directory.Exists(folder))
                { Directory.CreateDirectory(folder); }
                try
                {
                    string[] files = SearchByExtensions(pathManga);
                    foreach (string s in files)
                    {
                        progressBar1.Increment(1);
                        string Cam = folder + @"\" + diretorio.Name + Path.GetFileName(s);
                        File.Copy(s, Cam, true);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR COPY");
                    throw;
                }
                Thread.Sleep(1500);
            }
        }

        /// <summary>
        /// Copies files from the indicated path to a temporary folder
        /// </summary>
        /// <param name="pathIN">path directory</param>
        public void CopyToFolderTemp(string pathIN)
        {
            try
            {
                string[] files = SearchByExtensions(pathIN);
                foreach (string file in files)
                {
                    string nameFile = file.Substring(pathIN.Length + 1);
                    DirectoryInfo dir = new DirectoryInfo(pathIN);
                    string nameFolder = dir.Name;
                    string namePastFolder = dir.FullName.Substring(0, (dir.FullName.Length - nameFolder.Length));
                    string Cam = namePastFolder + nameFolder + nameFile;
                    File.Move(file, Cam);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR COPY");
                throw;
            }
            Thread.Sleep(1500);
        }

        /// <summary>
        /// Creates .cbz file with images saved in temporary folder
        /// </summary>
        /// <param name="nameTitle">string with name title</param>
        /// <param name="cbzName">string cwith name .cbz</param>
        /// <param name="volume">bool for identify if is a volume</param>
        private void CreateCBZ(string nameTitle, string cbzName, bool volume)
        {
            string FolderToZip = folder;
            if (volume)
            {
                string Temp = nameTitle.Substring(0, (nameTitle.Length - cbzName.Length));
                string FileZip = Temp + @"\" + nameCBZ + "_" + cbzName + ".cbz";
                try
                {
                    try
                    {
                        if (!File.Exists(FileZip)) { ZipFile.CreateFromDirectory(FolderToZip, FileZip); }
                    }
                    catch (Exception) { throw; }
                    Thread.Sleep(1000);
                    nVolumes++;
                    ClearFolderTemp(FolderToZip);
                }
                catch
                {
                    MessageBox.Show("ERROR ZIP!");
                    throw;
                }
            }
            else
            {
                string FileZip = nameTitle + @"\" + cbzName + ".cbz";
                try
                {
                    try
                    { if (!File.Exists(FileZip)) { ZipFile.CreateFromDirectory(FolderToZip, FileZip); } }
                    catch (Exception) { throw; }
                    Thread.Sleep(1000);
                    ClearFolderTemp(FolderToZip);
                }
                catch
                {
                    MessageBox.Show("ERROR ZIP!");
                    throw;
                }
            }
        }

        /// <summary>
        /// Clears temporary folder
        /// </summary>
        /// <param name="directory">path with folder for delete</param>
        public void ClearFolderTemp(string directory)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(directory);
            foreach (FileInfo file in di.GetFiles())
            { file.Delete(); }

            foreach (DirectoryInfo dir in di.GetDirectories())
            { dir.Delete(true); }
            di.Delete();
        }

        /// <summary>
        /// Search files only .jpg/.png
        /// </summary>
        /// <param name="startDir">path for search files</param>
        /// <returns>string[] with files found</returns>
        public static string[] SearchByExtensions(string startDir)
        {
            string[] extensions = { "jpg", "png" };

            bool all = extensions == null || extensions.Length == 0;
            Regex regexExtensions = null;
            if (!all)
            {
                StringBuilder regexBuilder = new StringBuilder(@"^.+\.(");
                regexBuilder.Append(string.Join("|", extensions));
                regexBuilder.Append(")$");

                regexExtensions = new Regex(regexBuilder.ToString(), RegexOptions.IgnoreCase | RegexOptions.Compiled);
            }
            return Directory.GetFiles(startDir, "*.*",
               false ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)
               .Where(fi => all || regexExtensions.IsMatch(fi))
               .ToArray();
        }

        /// <summary>
        /// Status progressbar
        /// </summary>
        /// <param name="path">path for verification files numbres</param>
        /// <param name="progressbar">progressbar for set status</param>
        /// <param name="set">bool for identify if in or out status</param>
        public static void StatusProgress(string path, ProgressBar progressbar, bool set)
        {

            if (set)
            {
                int SumFiles = HowmuchFiles(path);
                progressbar.Maximum = SumFiles;
                progressbar.Visible = true;
            }
            else
            {
                Console.Beep(2222, 50);
                progressbar.Visible = false;
                progressbar.Value = 0;
            }

        }

        /// <summary>
        /// Reverse string
        /// </summary>
        /// <param name="text">string for reverse</param>
        /// <returns>string reversed</returns>
        public string Reverse(string text)
        {
            char[] cArray = text.ToCharArray();
            string reverse = String.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            { reverse += cArray[i]; }
            return reverse;
        }

        /// <summary>
        /// Cut string before char "\"
        /// </summary>
        /// <param name="text">string for cut</param>
        /// <returns>substring after cut</returns>
        public string CutString(string text)
        {
            int posicao = text.IndexOf('/');
            return text.Substring(0, posicao);
        }

        /// <summary>
        /// Apply Cut&Reverse string
        /// </summary>
        /// <param name="text">string for format</param>
        /// <returns>string formated</returns>
        public string Format(string text)
        {
            return Reverse(CutString(Reverse(text)));
        }

        /// <summary>
        /// Order files following file .txt
        /// </summary>
        /// <param name="PathFolder">path with folder for order</param>
        /// <returns>string[] filenames in order</returns>
        public string[] OrderInArray(string PathFolder)
        {
            string[] files = Directory.GetFiles(PathFolder, "*.txt*");
            try
            {
                string[] lines = File.ReadAllLines(files[0]);
                string[] Filenames = new string[lines.Length];
                int c = 0;
                foreach (string line in lines)
                {
                    string l = Format(line);
                    Filenames[c] = l;
                    c++;
                }
                c = 0;
                return Filenames;
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR READ .txt");
                throw;
            }
        }

        /// <summary>
        /// Rename files following file .txt
        /// </summary>
        /// <param name="Filenames"></param>
        /// <param name="FolderPath"></param>
        public void RenameInOrder(string[] Filenames, string FolderPath)
        {
            try
            {
                string[] files = SearchByExtensions(FolderPath);
                for (int i = 0; i < Filenames.Length; i++)
                {
                    string source = FolderPath + @"\" + Filenames[i];
                    string destiny = FolderPath + @"\" + (i + 1).ToString() + "_" + Filenames[i];

                    System.IO.File.Copy(source, destiny, true);
                }
                for (int i = 0; i < Filenames.Length; i++)
                {
                    string delete = FolderPath + @"\" + Filenames[i];
                    System.IO.File.Delete(delete);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR RenameOrder");
                throw;
            }
        }

        /// <summary>
        /// Checks the number of files in the path
        /// </summary>
        /// <param name="path">path for how much files</param>
        /// <returns>int with how much files</returns>
        public static int HowmuchFiles(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            int Qtd_directory = dirInfo.GetDirectories().Length;
            int Qtd_files = Directory.GetFiles(path, "*.jpg").Length + Directory.GetFiles(path, "*.png").Length;
            foreach (DirectoryInfo subdirectory in dirInfo.GetDirectories())
            {
                string[] files = SearchByExtensions(subdirectory.FullName);
                Qtd_files += files.Length + 10;
            }
            return Qtd_files + Qtd_directory;
        }

        #endregion

        #region Flat Button

        private void BtnChapter_MouseEnter(object sender, EventArgs e)
        {
            this.BtnChapter.ForeColor = Color.Black;
            this.BtnChapter.BackColor = Color.LightYellow;
            this.BtnChapter.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnChapter.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnChapter_MouseLeave(object sender, EventArgs e)
        {
            this.BtnChapter.ForeColor = Color.LightYellow;
            this.BtnChapter.BackColor = Color.Black;
            this.BtnChapter.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Italic);
            this.BtnChapter.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
        }

        private void BtnVolume_MouseEnter(object sender, EventArgs e)
        {
            this.BtnVolume.ForeColor = Color.Black;
            this.BtnVolume.BackColor = Color.LightYellow;
            this.BtnVolume.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVolume.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnVolume_MouseLeave(object sender, EventArgs e)
        {
            this.BtnVolume.ForeColor = Color.LightYellow;
            this.BtnVolume.BackColor = Color.Black;
            this.BtnVolume.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Italic);
            this.BtnVolume.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
        }

        private void BtnOrderFile_MouseEnter(object sender, EventArgs e)
        {
            this.BtnOrderFile.ForeColor = Color.Black;
            this.BtnOrderFile.BackColor = Color.LightYellow;
            this.BtnOrderFile.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOrderFile.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnOrderFile_MouseLeave(object sender, EventArgs e)
        {
            this.BtnOrderFile.ForeColor = Color.LightYellow;
            this.BtnOrderFile.BackColor = Color.Black;
            this.BtnOrderFile.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Italic);
            this.BtnOrderFile.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
        }

        private void BtnOrder_MouseEnter(object sender, EventArgs e)
        {
            this.BtnOrder.ForeColor = Color.Black;
            this.BtnOrder.BackColor = Color.LightYellow;
            this.BtnOrder.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOrder.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void BtnOrder_MouseLeave(object sender, EventArgs e)
        {
            this.BtnOrder.ForeColor = Color.LightYellow;
            this.BtnOrder.BackColor = Color.Black;
            this.BtnOrder.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Italic);
            this.BtnOrder.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
        }

        private void BtnChapter_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.BtnChapter, "CHAPTER  \r\r Select a folder with files in .jpg/.png formats already ordered to convert to a .cbz format chapter, whose name will consist of the name of the selected folder.");
        }

        private void BtnOrder_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.BtnOrder, "ORDER   \r\r Select the folder with the volume you want to convert, this folder must contain subfolders with the chapters and their files (.jpg / .png) already ordered. \r The files will be renamed, sorted sequentially according to the folder name and moved from the chapters folder to the folder of the selected volume.");
        }

        private void BtnVolume_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.BtnVolume, "VOLUME  \r\r Select the folder of the manga you want to perform the batch conversion, this folder must contain subfolders entitled with their corresponding volume and containing the files already ordered in .jpg/.png format.  \r Each folder will be converted to a volume, whose name will consist of the name of the selected manga folder plus the name of the subfolder volume.");
        }

        private void BtnOrderFile_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.BtnOrderFile, "ORDER BY FILE  \r\r Select the folder with the volume/chapter you want to convert, this folder must contain the files (.jpg/.png) and also a .txt file with the names of the files ordered. The files will be renamed and ordered sequentially according to the sequence of the .txt file.");
        }

        #endregion

    }
}


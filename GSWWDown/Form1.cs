///     GSWWDown - A downloader for gushiwen.cn audio files.
///     Copyright(C) 2025 Luke Zhang

///     This program is free software: you can redistribute it and/or modify
///    it under the terms of the GNU General Public License as published by
///    the Free Software Foundation, either version 3 of the License, or
///    (at your option) any later version.
///
///    This program is distributed in the hope that it will be useful,
///    but WITHOUT ANY WARRANTY; without even the implied warranty of
///    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
///    GNU General Public License for more details.

///    You should have received a copy of the GNU General Public License
///    along with this program.  If not, see <https://www.gnu.org/licenses/>.

using System.Diagnostics;
using System.Text.RegularExpressions;

namespace GSWWDown
{
    public partial class Form1 : Form
    {
        private readonly string developerName = "Luke Zhang";
        private readonly string developerEmail = "lukez@lukezhang.win";        private readonly string developerGitHub = "https://github.com/win-lukezhang";
        private readonly string sourceCode= "https://github.com/win-lukezhang/GSWWDown";
        private readonly string version = "1.0.1";
        private readonly string copyright = "Copyright(C) 2025 Luke Zhang";
        private readonly string license = "GNU v3 License";

        private readonly HttpClient _httpClient = new HttpClient();
        private readonly Dictionary<string, string> _successfulSources = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WriteLog(string.Empty);
            WriteLog("古诗文网音频获取工具 启动成功");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // 清空 _successfulSources 字典
            _successfulSources.Clear();
            comboBox1.Items.Clear();

            string URL = textBox1.Text;
            if (textBox1.Text.Length == 49 && textBox1.Text.EndsWith(".aspx") && textBox1.Text.StartsWith("https://www.gushiwen.cn/shiwenv_"))
            {
                WriteLog("开始获取可用的音频源");
                string ID = GetID(URL);
                WriteLog($"音频 ID: {ID}");
                DebugWrite($"ID: {ID}");
                await TrySource(ID);
            }
            else
            {
                WriteLog("请输入正确的古诗文网音频地址");
                WriteLog($"例如：{textBox1.PlaceholderText}");
            }
        }

        private void WriteLog(string text)
        {
            LogTextBox.Text += Environment.NewLine + text;
        }

        private string GetID(string url)
        {
            try
            {
                var uri = new Uri(url);
                var segments = uri.Segments;
                if (segments.Length > 1)
                {
                    var idSegment = segments[segments.Length - 1];
                    var id = idSegment.Split('_')[1].Split('.')[0];
                    return id;
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                WriteLog($"解析 URL 时出错: {ex.Message}");
                return string.Empty;
            }
        }

        private void DebugWrite(string text)
        {
            Debug.WriteLine(text);
        }

        /// <summary>
        /// 尝试获取可用的音频源
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private async Task TrySource(string ID)
        {
            // 采用 穷举
            // 获取所有可能的音频源的相关 URL
            var sources = new Dictionary<string, string>
                {
                    { "make", "https://ziyuan.guwendao.net/song/make/" },
                    { "songdugongjuren", "https://ziyuan.guwendao.net/song/songdugongjuren/" },
                    { "chenlang", "https://ziyuan.guwendao.net/song/chenlang/" },
                    { "jiangweiwei", "https://ziyuan.guwendao.net/song/jiangweiwei/" },
                    { "qionghua", "https://ziyuan.guwendao.net/song/qionghua/" }
                };

            foreach (var source in sources)
            {
                string sourceURL = await GetSourceURL(ID, source.Value);
                bool success = await GetHTTPSuccess(sourceURL);
                if (success)
                {
                    WriteLog("音频源获取成功：" + source.Key);
                    comboBox1.Items.Add(source.Key);
                    _successfulSources[source.Key] = sourceURL;
                }
                else
                {
                    WriteLog("音频源获取失败：" + source.Key);
                }
            }
        }

        private async Task<string> GetSourceURL(string ID, string URL)
        {
            string NewStr = URL + ID + ".mp3";
            return await Task.FromResult(NewStr);
        }

        private async Task<bool> GetHTTPSuccess(string URL)
        {
            // 尝试：获取 HTTP 状态码
            // 如果状态码为 200，则返回 true
            // 否则返回 false
            try
            {
                var response = await _httpClient.GetAsync(URL);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                WriteLog($"获取 HTTP 状态码时出错: {ex.Message}");
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == -1)
                {
                    WriteLog("请选择一个音频源");
                }
                else
                {
                    string selectedSource = comboBox1.SelectedItem.ToString();
                    if (_successfulSources.TryGetValue(selectedSource, out string sourceURL))
                    {
                        WriteLog($"选中的音频源 URL: {sourceURL}");
                        textBox3.Text = sourceURL;
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog($"获取音频源时出错: \n {ex.Message}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                WriteLog("请先获取音频源");
                return;
            }
            Clipboard.SetText(textBox3.Text);
        }

        private async Task<string> GetTitleFromUrl(string url)
        {
            try
            {
                var response = await _httpClient.GetStringAsync(url);
                var titleMatch = Regex.Match(response, @"<title>\s*(.+?)\s*</title>");
                if (titleMatch.Success)
                {
                    return titleMatch.Groups[1].Value;
                }
                return "未命名";
            }
            catch (Exception ex)
            {
                WriteLog($"获取标题时出错: {ex.Message}");
                return "未命名";
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            string url = textBox3.Text;
            string pageurl = textBox1.Text;
            string title = await GetTitleFromUrl(pageurl);

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "MP3 文件 (*.mp3)|*.mp3|所有文件 (*.*)|*.*";
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.FileName = title + ".mp3";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        // 使用 cURL 下载文件
                        var processStartInfo = new ProcessStartInfo
                        {
                            FileName = "curl",
                            Arguments = $"-o \"{filePath}\" \"{url}\"",
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        };

                        using (var process = new Process { StartInfo = processStartInfo })
                        {
                            process.Start();
                            string output = await process.StandardOutput.ReadToEndAsync();
                            string error = await process.StandardError.ReadToEndAsync();
                            process.WaitForExit();

                            if (process.ExitCode == 0)
                            {
                                WriteLog($"文件已保存到: {filePath}");
                            }
                            else
                            {
                                WriteLog($"使用 cURL 下载文件时出错: {error}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteLog($"保存文件时出错: {ex.Message}");
                    }
                }
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            string url = textBox3.Text;
            string pageurl = textBox1.Text;
            string title = await GetTitleFromUrl(pageurl);

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "MP3 文件 (*.mp3)|*.mp3|所有文件 (*.*)|*.*";
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.FileName = title + ".mp3";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // 询问 IDM 安装位置
                    string idmPath = Microsoft.VisualBasic.Interaction.InputBox("请输入 IDM 安装路径（如果为空，将使用默认路径）:", "IDM 安装路径", "");

                    if (string.IsNullOrWhiteSpace(idmPath))
                    {
                        WriteLog("未输入 IDM 安装路径，将使用默认路径");
                        string programFilesX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
                        idmPath = Path.Combine(programFilesX86, "Internet Download Manager", "IDMan.exe");
                        WriteLog($"默认路径：{idmPath}");
                    }
                    else
                    {
                        WriteLog($"IDM 安装路径: {idmPath}");
                    }

                        try
                    {
                        // 使用 IDM 下载文件
                        var processStartInfo = new ProcessStartInfo
                        {
                            FileName = idmPath,
                            Arguments = $"/d \"{url}\" /p \"{Path.GetDirectoryName(filePath)}\" /f \"{Path.GetFileName(filePath)}\" /n /a",
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        };

                        using (var process = new Process { StartInfo = processStartInfo })
                        {
                            process.Start();
                            string output = process.StandardOutput.ReadToEnd();
                            string error = process.StandardError.ReadToEnd();
                            process.WaitForExit();

                            if (process.ExitCode == 0)
                            {
                                WriteLog($"文件已添加到 IDM 下载队列: {filePath}");
                            }
                            else
                            {
                                WriteLog($"使用 IDM 下载文件时出错: {error}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteLog($"使用 IDM 下载文件时出错: {ex.Message}");
                    }
                }
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            string url = textBox3.Text;
            string pageurl = textBox1.Text;
            string title = await GetTitleFromUrl(pageurl);

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "MP3 文件 (*.mp3)|*.mp3|所有文件 (*.*)|*.*";
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.FileName = title + ".mp3";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        // 使用 BitsAdmin 下载文件
                        var processStartInfo = new ProcessStartInfo
                        {
                            FileName = "bitsadmin",
                            Arguments = $"/transfer myDownloadJob /download /priority normal \"{url}\" \"{filePath}\"",
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        };

                        using (var process = new Process { StartInfo = processStartInfo })
                        {
                            process.Start();
                            string output = process.StandardOutput.ReadToEnd();
                            string error = process.StandardError.ReadToEnd();
                            process.WaitForExit();

                            if (process.ExitCode == 0)
                            {
                                WriteLog($"文件已保存到: {filePath}");
                            }
                            else
                            {
                                WriteLog($"使用 BitsAdmin 下载文件时出错: {error}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteLog($"使用 BitsAdmin 下载文件时出错: {ex.Message}");
                    }
                }
            }
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            string url = textBox3.Text;
            string pageurl = textBox1.Text;
            string title = await GetTitleFromUrl(pageurl);

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "MP3 文件 (*.mp3)|*.mp3|所有文件 (*.*)|*.*";
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.FileName = title + ".mp3";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        // 使用 HttpClient 下载文件
                        var response = await _httpClient.GetAsync(url);
                        response.EnsureSuccessStatusCode();
                        var fileBytes = await response.Content.ReadAsByteArrayAsync();
                        await File.WriteAllBytesAsync(filePath, fileBytes);
                        WriteLog($"文件已保存到: {filePath}");
                    }
                    catch (Exception ex)
                    {
                        WriteLog($"保存文件时出错: {ex.Message}");
                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"古诗文网音频获取工具 {version}\nby {developerName}\n{copyright}\nGitHub: {developerGitHub}\nEmail: {developerEmail}\nGitHub Repo: {sourceCode}\nLicense: {license}","古诗文网音频获取工具",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
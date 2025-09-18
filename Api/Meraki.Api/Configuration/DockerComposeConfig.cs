using System.Diagnostics;

namespace Meraki.Api.Configuration
{
    public class DockerComposeConfig
    {
        public static void RunDockerCompose(string workingDirectory)
        {
            if (AreContainersRunning(workingDirectory))
            {
                Console.WriteLine("Containers já estão rodando. Docker Compose não será executado novamente.");
                return;
            }

            var processInfo = new ProcessStartInfo
            {
                FileName = "docker-compose",
                Arguments = "up -d",
                WorkingDirectory = workingDirectory,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = new Process { StartInfo = processInfo };
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                throw new Exception($"Erro ao executar docker-compose:\n{error}");
            }

            Console.WriteLine("Docker Compose Output:");
            Console.WriteLine(output);
        }

        private static bool AreContainersRunning(string workingDirectory)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = "docker-compose",
                Arguments = "ps",
                WorkingDirectory = workingDirectory,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = new Process { StartInfo = processInfo };
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return output.Contains("Up");
        }

    }
}

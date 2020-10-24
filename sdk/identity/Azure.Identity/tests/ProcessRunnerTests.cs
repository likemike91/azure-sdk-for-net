// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class ProcessRunnerTests
    {
        public ProcessRunnerTests(bool isAsync)
        {
            IsAsync = isAsync;
        }

        public bool IsAsync { get; }

        [Test]
        public async Task ProcessRunnerSucceeded()
        {
            var output = "Test output";
            var process = new TestProcess { Output = output };
            var runner = new ProcessRunner(process, TimeSpan.FromSeconds(30), default);
            var result = await Run(runner);

            Assert.AreEqual(output, result);
        }

        [Test]
        public async Task ProcessRunnerRealProcessSucceeded()
        {
            var output = "Test output";
            var process = CreateRealProcess($"echo {output}", $"echo {output}");
            var runner = new ProcessRunner(process, TimeSpan.FromSeconds(30), default);
            var result = await Run(runner);

            Assert.AreEqual(output, result.TrimEnd());
        }

        [Test]
        public async Task ProcessRunnerRealProcessLargeOutputSucceeded()
        {
            var output = string.Concat(Enumerable.Repeat("ab", 3000));
            //var output = "UzlW1zIV2hGONhIL3ODVjsj4OJ0MsEM0ZU4m5ymD1xZLYbJmIlY1ZjslZWsNJNMkj4YGYWTllLhYIiVIOYXTmt2IzUNMSTUJjBshQkstZSmJOBESw1mMSL4CibOiZUzYYdp4jUizWIxwyLhG06IMDlyj12MNUDT3ELsyP0Yz0zk5hmMMzsiMjyZtIkliR2MLNgIYMCZLNURMtsTeLYzGmNjs1jNlBiDUzIZzUZ5kIF1jMNsTC1WITTtdjZZGYBIIWGTBjLyNMEsxYOENNYNRLwYT5MY2MmzA5tOGVh0biIkOMMINz4ODTVMMjs1OMkj1LWIMEjIhZiTmjLOOYNJQjQYlKuYmzZyMsJlQZGNRsAZVi1WiB2TNmNSLkZIBkkQMMzjzG0NzLLiMsMTTLoIciz4LytO0D4LEZGMMMJhUxMtYczYMhYIt21MmNmkHXE5O1oZjlDQNpTkMxFjYwzL4wMWmTLVLZEWXE0zhIVwH3FDtZNWkyg0ij101ZSZxumNkYIONC2yzZkjiOyYuJiVZNLQZZGNREYROLtNNtihRITTuJs7MmwIUVNjuJNJN1MTI2I51I2lihYyW23TzTMWRQDFhZ2UZ5I2MlDi4cj3WNMTMIyZWDxpLyYGDcLYTmTdA1gmAwMyt4CLOh2xtYsNRWqj4NQTgMMIWWQljT2jQtLIMLIDWiZD3j5Zjji3jTjikjAjEZ4YumYVCmoTWsjwiMiKjZLNDTjZSTCLNGEMUjzSDQTWYRlTZeU5zZbTE5ZQYZwjjWylWNYIiPQINZYtLzTtmjD6hZDINGkmMAuThkyyD4DJlCM1ElUSiNALkmsxWZmI5FYjF450EYkIjWmNEjNzjAjT1WIWdk1kpl2LIjEItTM29NYJ3jjnLYhitDNlMMYwy31zikkVlOMLEXYmjk46zDxF2IjMg2DTIoIsFwzohIJQxZL5z0tN0NOCL2LzNjUzZLsjYTDlZMWjk02YIkxY8DWOORNMQOds4dGmEwMJIwMGzLi3Mk0ziO2GI1FOMmkCQT4LiZIUmTNMYJhNgECsZNtJ5q2VzkmEOCZsY10NTm4iGMEU0D1rZYwS3YLTtjWsIiGLLDhCZQUYjCGcYzOLI2xNNlQmWtDVt2MJNmjZMkwICYgMNhMTZ2SgMTNT4IYUsZzIgMzOZIWjiGilw4MYzTcMZELkjK4ILlTa0tIGMDwyltITX4Mmh0o1hLjIz0AZiy1dO4sNiTgJzMSWj4F4DMkUMINMtLd62GTl1NIxDTHmeNLVdmUNYtMkojrCtZBlTi3NTQUjTzIihZDmdTMsllYWIDEMUmDJtF5ioIlOxAUiOiINOkiBZmginN5jLwLTNyCjy1MwiENWM0WmTNMjlQMIMMGhEYIziZUkjYjmlOIhNTt2gkYL4WN4Dh0dYTIzkuuD0ZYIRkGOWILIZWUw4mZ23yJOIFu2jIWhN3s4ZNjy00NNWdMy5j1YjDIYMwLOR0QCNOijsVLYZNTZmVJ2E2TLGMShVYT3YzESYmTIjv3lW0IyN9MmTyZtw0NMjR3NtksCLNBWi0WzULxOYDiXNViASwV4ZxFEWiQ1jZuHE00IOlGFjWLWWkVskM6OOI3hIkExLR0tkUBITiALZLk1ZWQdscZzMsYiMySAllWkAZNYU2YjFNjmNMjsLPLw2lmZMjcSSZ32N2423ZGYWglzlITjDNYS0WwNwzNOWDj4iwUYNcMiIN4LZGZTNUFNxITmMQMzL0EYgRMGZTmTNpmYRYMNCDGm41mZNjORNYTwiFhsN2x4MI1DMCAxhIGMMMmjQCytWIILN5WcUuYiMDlVIZ4jjRjiNBNNzh1DjjNcmlkUYsmLyYzOMciMjzYONxNyL5VkS0UEZkM4OxgYlzGWMkwNZXl5RYDhyTjDCDmQTN2yYWEMymjYIDVER0U3tRiRPLSHINNEEUNpTI6TRTFDNXiyzMywWW1l2zCQ2UiiYxmBNhLjpTLYIy34sQIMVzFjCj32yk4mIQ5GOdZSRmhXYN2YURIh0WOjN0jTNIsWNThTMMVi2j0DILuDTuBMClwdDiYEMENUtNpqI5kIEMJDzMckZNQNNO1OC3zjAMholdQmNYbHNREm0dS4hTTZSxMzZDJtGELEZiwLjOZYVINI_5zQimWNZhOWmWAtQ2Yi0tSDUHi2NYOOZYjg3YUhKxJLNksdLI4WDziWzLNLZ3QaIYcMMTL1wj55ilhRNzyy00MZIjD3jIhY4MzONRj2qTDILIkLZYDjk3BVhO2HShNsY04IzTUZIzGChkj2IiDtYILkQisOMhOWDbSYWNRNtZysiZDDzTTlslb85ht4kSEUOm1OMNymN5kNsWY0kYlNDcwiztZYhchTLgoZjGWqXN3lfNUYzhBL2QAGYhTzmMIRjzmC5YQ2lNajIjMNVDTUg14MU5dkYJUWMGZlYMdjRTaxlILyAL2DjlYA3IbjTTRYRSjI4Qjdi1IJlwYWDiNQ2CJhzxDy2TYjRQWCZYJRjQExx4L0Nkdzt3RQYjtVYOIQYQIlTiTijghZMDzLhiDYTS0T2IgO2NRiz9LSOlmz5DgBxhMRDMZWIJFVvVDMzXZGmNzINYkGkdGlWNiTOFkKEGLiLTRI9eDN4xEUiD0M0wXkOGsFojkjMZUcR0jdYToNNyykihNZgbDRMO2NIDEDjMsAZI0Dtl0DRMWZCTTUcgtJZwzDEsh1I0-ZtQtFJhNMjRTMMDMRIJow_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.iiiNIONjMuNITEQhTjU3OjmMILSMZjCNLNTyzRxhGZTi1YZQOIIwxwYEjeOc2NZY5IdfWYDMlyDxjN0dNsOmOwBi3LNL1LEDLzFATZ2IIsk6AsnWgmTsaZlY2OCEHy2DNIANMZYql1NjN05GTGtjVZpjwTKmFTMflxsYYUNNNtcjLlawcTzDq1tiTGxjSsNNwN0GmIIckWc11JGYVYLIjUNNsYFNtEZyiaY1NZFzIWI4jITinWTYwGmLNQwjjYe13zWiQMBpGwWQGIdxLT1FLTRWNBhlbV0MyWIOZMjLbbmYIILLYMM0Nwt4ZStjihjMiDWUSW1mNOcGDzBW3YZt0iwNmM2k3tI_MTlljiGMjDRiMDWTMmTNjYiGYMYiBtOYAILjY1wSLNYNYLMzmtm6LTR2zTZjThOhQXCYCIyxzdaxQ45xYGE21YsUBs2jMMjD5YWG3N5OECWkYWZDmldQTUc-IWkzy2II5fsInj4g4sDs1IIIJjYmTRJMDW1YgMyOWzQF3jmMhaYwmIDgWzO1TuZT4iY1yZkTMJTjz2SvW0zSLsDvwmODyTSMh0c5ISzyBTmcUIYRYm21LMW1ddU1sIBIIYMMZYTlkIWIYOlYUODG3jIjRsiS2YlxslIWYgMRJcQND021IGZmzDOgiLZzYOaHkt00DRiNTAyANA4VY3xzj2EDW0qILjT24LM3WiO4LDmUqzNZImNUzMIYWEZYQ5OEtPlII4NNhsnO-TTmjLxNzxjXLwmNzTYWhJsDTNMSzIi0VTO0TYMNTRCsjyiGhIcTWhWOGllkjZT3e.YNc1ZWyNCGWASW_BYzQiYihOcwhaY0cR2GN4SID3U5y2yhi5jjYyjZTQILtY1MZTILwNAjjTxzx5Y1YdNWFWjRwONkMJLiYLNzicSLUmGmMgDAMMDZcmMXIGNTIyYVD0YG1TIs0L3QvOGZT1szkm4WGc10N2MWmeaU4CYjWYz15iCiSOIMN2DHDQ0DYDFCOW1QSmFMEeENYYQmNjlIIZUUmMLswWYFDT3li4EU0Lyic0NDCOSMtYTYZa052YizTTNhNjTMq2NjyJxN0QzXkPNtYgsCD00ITtJF2LRBBwJxhkQWZiCCj2IGZSJt3LKhNMI1M0ai1DZiYTC3I4JNNhYM6FmIdAM1O40wEIGwRFC8N5EGNwwIh5YWiJGIWNLD2jNBYZDlSzYlwOyzdLjBFNTkzZ2i0MEIgC3FD1dhLyT0MLjcgiMY5kL2UIQW0GL5IlCyQI6TTmSYWLTGJbj5EhjzOWik3wYmYGNZGWDu1MNlzNMNiVkZczjiN02YYhTYNiUVLY5MOMTOTIYI4kNPLTLsWIGINYIcUH2eIWGz4KjVZyNDWIhNMS0YY5mjvIT1YNTjIZMm0LTN2YMZkXUmIiCUZcMEWmG3lDNUDszlNDTMlBNwktNlCIhPYgZTQm3aN41NIIIcYzd2Rj0bjEYhhN2ThdjdT5XTz0CNsW3NCjYEZIzlQhtc6iTjxjcMCRdIwMJhm0Etvhl5GrLzi2IQIigiFYTwymzyysLQURmcgohYMNVITFqjLjMiLDhyhM1hMIlMIiGzpLE2klyIMmg55ZQNVtVYGLNIjd4mI0XIIVTWWNLjNhQYgIQZtWV4ID2NNdWBsUT6XkIYYcjmONV5IOWYWGjW3MSwhsjWANFMGE4xlAnsvTcGyYtMTwIZjMYzM3tOCmNYMJTOQIjOzEiG40h4GNwwmtVXSMFlhsiycDYYxMlVyU5WMmjQxzhNNDQx4ZhkW3QQmQMkccdlhRLGNL1ktMjTTdYM2yBm3ZjB3dRI2Y5WcIQTDM4mYmikTuQY1JSVt0BILIiiSTZjJT29yz2LYqtIILDTYzmk0hLLtVMNwkIWmjttNMlDMiMmTTJWG0BM5OM15NT0T5zytONZ3Wt1D45h2S7YZ5lTUEZRMZ0TMTj1i4CNLTcFTYz5UMzdZBE5tzI1U";
            var process = CreateRealProcess($"echo {output}", $"echo {output}");
            var runner = new ProcessRunner(process, TimeSpan.FromSeconds(30), default);
            var result = await Run(runner);

            Assert.AreEqual(output, result.TrimEnd());
        }

        [Test]
        public void ProcessRunnerCanceledByTimeout()
        {
            var cts = new CancellationTokenSource();
            var process = new TestProcess { Output =  "Test output", Timeout = 5000 };
            var runner = new ProcessRunner(process, TimeSpan.FromMilliseconds(100), cts.Token);

            Assert.CatchAsync<OperationCanceledException>(async () => await Run(runner));
        }

        [Test]
        public void ProcessRunnerCanceledByCancellationToken()
        {
            var cts = new CancellationTokenSource();
            var process = new TestProcess { Output =  "Test output", Timeout = 5000 };
            var runner = new ProcessRunner(process, TimeSpan.FromMilliseconds(5000), cts.Token);
            cts.CancelAfter(100);

            Assert.CatchAsync<OperationCanceledException>(async () => await Run(runner));
        }

        [Test]
        public void ProcessRunnerCreatedOnCanceled()
        {
            var process = new TestProcess { Output =  "Test output", Timeout = 5000 };
            var cancellationToken = new CancellationToken(true);
            var runner = new ProcessRunner(process, TimeSpan.FromMilliseconds(5000), cancellationToken);

            Assert.CatchAsync<OperationCanceledException>(async () => await Run(runner));
        }

        [Test]
        public void ProcessRunnerCanceledBeforeRun()
        {
            var cts = new CancellationTokenSource();
            var process = new TestProcess { Output =  "Test output", Timeout = 5000 };
            var runner = new ProcessRunner(process, TimeSpan.FromMilliseconds(5000), cts.Token);

            cts.Cancel();

            Assert.CatchAsync<OperationCanceledException>(async () => await Run(runner));
        }

        [Test]
        public async Task ProcessRunnerCanceledFinished()
        {
            var cts = new CancellationTokenSource();
            var process = new TestProcess { Output =  "Test output" };
            var runner = new ProcessRunner(process, TimeSpan.FromSeconds(5000), cts.Token);
            await Run(runner);
            cts.Cancel();
        }

        [Test]
        public void ProcessRunnerFailedWithErrorMessage()
        {
            var error = "Test error";
            var process = new TestProcess { Error = error };
            var runner = new ProcessRunner(process, TimeSpan.FromSeconds(30), default);

            var exception = Assert.CatchAsync<InvalidOperationException>(async () => await Run(runner));
            Assert.AreEqual(error, exception.Message);
        }

        [Test]
        public void ProcessRunnerRealProcessFailedWithErrorMessage()
        {
            var error = "Test error";
            var process = CreateRealProcess($"echo {error} 1>&2 & exit 1", $">&2 echo {error} & exit 1");
            var runner = new ProcessRunner(process, TimeSpan.FromSeconds(30), default);

            var exception = Assert.CatchAsync<InvalidOperationException>(async () => await Run(runner));
            Assert.AreEqual(error, exception.Message.Trim());
        }

        [Test]
        public void ProcessRunnerFailedOnKillProcess()
        {
            var output = "Test output";
            var process = new TestProcess { Output = output, ExceptionOnProcessKill = new Win32Exception(1), Timeout = 5000 };
            var runner = new ProcessRunner(process, TimeSpan.FromMilliseconds(50), default);

            var exception = Assert.CatchAsync<Win32Exception>(async () => await Run(runner));
            Assert.AreEqual(1, exception.NativeErrorCode);
        }

        private async Task<string> Run(ProcessRunner runner) => IsAsync ? await runner.RunAsync() : runner.Run();

        private static IProcess CreateRealProcess(string windowsCommand, string nonWindowsCommand)
        {
            var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            var fileName = isWindows ? "cmd" : "sh";
            var arguments = isWindows ? $"/C \"{windowsCommand}\"" : $"-c \"{nonWindowsCommand}\"";

            return ProcessService.Default.Create(new ProcessStartInfo {FileName = fileName, Arguments = arguments, ErrorDialog = false, CreateNoWindow = true});
        }
    }
}
